//   !!  // Steamworks.Core - SteamApi.cs
// *.-". // Created: 2016-10-14 [8:06 PM]
//  | |  // Copyright 2016 // MIT License // The Fox Council 
// Modified by: Fox Diller on 2016-10-22 @ 3:02 PM

#region Usings

using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;
using string8 = Steamworks.Core.SafeUtf8String;

#endregion

namespace Steamworks.Core
{
    public static class SteamApi
    {
        public delegate bool InitFunc();

        public delegate void ReleaseCurrentThreadMemoryFunc();

        public delegate bool RestartAppIfNecessaryFunc(uint c_ownAppId);

        public delegate void RunCallbacksFunc();

        public delegate void ShutdownFunc();

        public delegate uint GetHSteamUserFunc();

        public delegate uint GetHSteamPipeFunc();

        public unsafe delegate CSteamApiContext* ContextInitFunc(IntPtr c_callbackStruc);

        public delegate IntPtr CreateInterfaceFunc(string8 c_versionString);

        public const string STEAM_DEBUG_APP_ID_FILENAME = "./steam_appid.txt";

        #region Versioning

        public static readonly Version SteamworksCoreVersion = new Version(0, 2, 1, 0);

        public static readonly Version SteamApiVersion = new Version(1, 38);
        public static readonly Version SteamApiDllVersion = new Version(3, 62, 82, 82);


        private const string kSteamworksWin32ModuleName = "steam_api.dll";
        private const string kSteamworksWin64ModuleName = "steam_api64.dll";

        private const string kSteamworksLinux32ModuleName = "libsteam_api.so";
        private const string kSteamworksLinux64ModuleName = "libsteam_api.so";

#if WIN32
        public const string STEAMWORKS_MODULE_NAME = kSteamworksWin32ModuleName;
#elif LINUX32
        public const string STEAMWORKS_MODULE_NAME = kSteamworksLinux32ModuleName;
#elif LINUX64
        public const string STEAMWORKS_MODULE_NAME = kSteamworksLinux64ModuleName;
#else
        public const string STEAMWORKS_MODULE_NAME = kSteamworksWin64ModuleName;
#endif

        public const string STEAMCLIENT_INTERFACE_VERSION = "SteamClient017";
        public const string STEAMUSER_INTERFACE_VERSION = "SteamUser019";
        public const string STEAMFRIENDS_INTERFACE_VERSION = "SteamFriends015";
        public const string STEAMUTILS_INTERFACE_VERSION = "SteamUtils008";
        public const string STEAMMATCHMAKING_INTERFACE_VERSION = "SteamMatchMaking009";
        public const string STEAMMATCHMAKINGSERVERS_INTERFACE_VERSION = "SteamMatchMakingServers002";
        public const string STEAMUSERSTATS_INTERFACE_VERSION = "STEAMUSERSTATS_INTERFACE_VERSION011";
        public const string STEAMAPPS_INTERFACE_VERSION = "STEAMAPPS_INTERFACE_VERSION008";
        public const string STEAMNETWORKING_INTERFACE_VERSION = "SteamNetworking005";
        public const string STEAMREMOTESTORAGE_INTERFACE_VERSION = "STEAMREMOTESTORAGE_INTERFACE_VERSION014";
        public const string STEAMSCREENSHOTS_INTERFACE_VERSION = "STEAMSCREENSHOTS_INTERFACE_VERSION003";
        public const string STEAMHTTP_INTERFACE_VERSION = "STEAMHTTP_INTERFACE_VERSION002";
        public const string STEAMUNIFIEDMESSAGES_INTERFACE_VERSION = "STEAMUNIFIEDMESSAGES_INTERFACE_VERSION001";
        public const string STEAMCONTROLLER_INTERFACE_VERSION = "SteamController004";
        public const string STEAMUGC_INTERFACE_VERSION = "STEAMUGC_INTERFACE_VERSION009";
        public const string STEAMAPPLIST_INTERFACE_VERSION = "STEAMAPPLIST_INTERFACE_VERSION001";
        public const string STEAMMUSIC_INTERFACE_VERSION = "STEAMMUSIC_INTERFACE_VERSION001";
        public const string STEAMMUSICREMOTE_INTERFACE_VERSION = "STEAMMUSICREMOTE_INTERFACE_VERSION001";
        public const string STEAMHTMLSURFACE_INTERFACE_VERSION = "STEAMHTMLSURFACE_INTERFACE_VERSION_003";
        public const string STEAMINVENTORY_INTERFACE_VERSION = "STEAMINVENTORY_INTERFACE_V001";
        public const string STEAMVIDEO_INTERFACE_VERSION = "STEAMVIDEO_INTERFACE_V001";

        #endregion

        private static bool m_isInitialized;

        private static IntPtr m_libProcAddress;

        private static IntPtr m_callbackCounterAndContext;

        /// <summary>Your Steam AppID, default(480) - Spacewar!</summary>
        public static uint AppId { get; set; } = 480;

        /// <summary>Steam's actual init, just a little christmas wrapping for managed access.</summary>
        private static InitFunc NativeInit { get; set; }

        /// <summary>Pretending to be steam_api.h file</summary>
        private static ContextInitFunc ContextInit { get; set; }

        /// <summary>Pretending to be steam_api.h file</summary>
        public static CreateInterfaceFunc CreateInterface { get; set; }

        /// <summary>Shutdown should be called during process shutdown if possible.</summary>
        public static ShutdownFunc Shutdown { get; private set; }

        /// <summary>RestartAppIfNecessary ensures that your executable was launched through Steam.</summary>
        /// <returns>
        /// Returns true if the current process should terminate. Steam is now re-launching your application.
        ///
        /// Returns false if no action needs to be taken. This means that your executable was started through
        /// the Steam client, or a steam_appid.txt file is present in your game's directory (for development).
        /// Your current process should continue if false is returned.
        /// </returns>
        /// <remarks>
        /// If you use the Steam DRM wrapper on your primary executable file, this check is unnecessary 
        /// since the DRM wrapper will ensure that your application was launched properly through Steam.
        /// </remarks>
        public static RestartAppIfNecessaryFunc RestartAppIfNecessary { get; private set; }

        /// <summary>
        /// RunCallbacks is safe to call from multiple threads simultaneously,
        /// but if you choose to do this, callback code could be executed on any thread.
        /// One alternative is to call SteamAPI_RunCallbacks from the main thread only,
        /// and call SteamAPI_ReleaseCurrentThreadMemory regularly on other threads.
        /// </summary>
        public static RunCallbacksFunc RunCallbacks { get; private set; }

        /// <summary>
        /// Many Steam API functions allocate a small amount of thread-local memory for parameter storage.
        /// SteamAPI_ReleaseCurrentThreadMemory() will free API memory associated with the calling thread.
        /// This function is also called automatically by SteamAPI_RunCallbacks(), so a single-threaded
        /// program never needs to explicitly call this function.
        /// </summary>
        public static ReleaseCurrentThreadMemoryFunc ReleaseCurrentThreadMemory { get; private set; }

        /// <summary>Returns the pipe we are communicating to Steam with.</summary>
        public static GetHSteamPipeFunc GetHSteamPipe { get; private set; }

        /// <summary>Returns the user Steam is using while we are communicating with it.</summary>
        public static GetHSteamUserFunc GetHSteamUser { get; private set; }


        /// <summary>Init must be called before using any other API functions. If it fails, an error message will be
        ///     output to the debugger (or stderr) with further information.</summary>
        /// <returns>
        /// A return of <code>true</code> indicates all required interfaces have been acquired and are accessible.
        /// A return of <code>false</code> indicates one of three conditions:
        ///  - The Steam client isn't running. A running Steam client is required to provide implementations of the various Steamworks interfaces.
        ///  - The Steam client couldn't determine the AppID of game. Make sure you have Steam_appid.txt in your game directory.
        ///  - Your application is not running under the same user context as the Steam client, including admin privileges.
        /// </returns>
        public static void Init()
        {
            if (m_isInitialized)
            {
                throw new InvalidOperationException("SteamAPI already initialized!");
            }

            var a_moduleFileVersionInfo = FileVersionInfo.GetVersionInfo(STEAMWORKS_MODULE_NAME);
            var a_moduleVersion = new Version(a_moduleFileVersionInfo.FileVersion);

            if (a_moduleVersion != SteamApiDllVersion)
            {
                throw new VerificationException($"{STEAMWORKS_MODULE_NAME} is the wrong version! Expected <{SteamApiDllVersion}>, FileVersion <{a_moduleVersion}>");
            }

            if (File.Exists(STEAM_DEBUG_APP_ID_FILENAME))
            {
                var a_debugAppId = File.ReadAllText(STEAM_DEBUG_APP_ID_FILENAME);

                AppId = Convert.ToUInt32(a_debugAppId);
            }

            LoadMethods();

            m_isInitialized = NativeInit();

            if (!m_isInitialized)
            {
                throw new InvalidOperationException("SteamAPI could not be initialized!");
            }
        }

        private static unsafe void LoadMethods()
        {
            NativeInit = LoadSteamworksFunction<InitFunc>("SteamAPI_Init");
            Shutdown = LoadSteamworksFunction<ShutdownFunc>("SteamAPI_Shutdown");

            RestartAppIfNecessary = LoadSteamworksFunction<RestartAppIfNecessaryFunc>("SteamAPI_RestartAppIfNecessary");
            RunCallbacks = LoadSteamworksFunction<RunCallbacksFunc>("SteamAPI_RunCallbacks");
            ReleaseCurrentThreadMemory = LoadSteamworksFunction<ReleaseCurrentThreadMemoryFunc>("SteamAPI_ReleaseCurrentThreadMemory");

            GetHSteamPipe = LoadSteamworksFunction<GetHSteamPipeFunc>("SteamAPI_GetHSteamPipe");
            GetHSteamUser = LoadSteamworksFunction<GetHSteamUserFunc>("SteamAPI_GetHSteamUser");

            // Steam Internals
            ContextInit = LoadSteamworksFunction<ContextInitFunc>("SteamInternal_ContextInit");
            CreateInterface = LoadSteamworksFunction<CreateInterfaceFunc>("SteamInternal_CreateInterface");
        }

        public unsafe delegate void OnContextInitFunc(CSteamApiContext* c_contextPtr);

        public static unsafe OnContextInitFunc OnContextInitPtr = OnContextInit;

        private static unsafe CSteamApiContext* m_steamApiContext;

        private static unsafe CSteamApiContext* GetSteamApiContext()
        {
            if (m_steamApiContext != null)
            {
                return m_steamApiContext;
            }

            var a_callbackCounterAndContext = CallbackCounterAndContext();

            m_steamApiContext = ContextInit(a_callbackCounterAndContext);

            return m_steamApiContext;
        }

        private static unsafe IntPtr CallbackCounterAndContext()
        {
            if (m_callbackCounterAndContext != IntPtr.Zero)
            {
                return m_callbackCounterAndContext;
            }

            var a_size = 2 + Marshal.SizeOf<CSteamApiContext>() / Marshal.SizeOf<IntPtr>();

            var a_callbackCounterAndContext = new IntPtr[a_size];

            a_callbackCounterAndContext[0] = Marshal.GetFunctionPointerForDelegate(OnContextInitPtr);

            m_callbackCounterAndContext = Marshal.UnsafeAddrOfPinnedArrayElement(a_callbackCounterAndContext, 0);

            return m_callbackCounterAndContext;
        }

        private static unsafe void OnContextInit(CSteamApiContext* c_contextPointer)
        {
            c_contextPointer->Clear();

            if (GetHSteamPipe() != 0)
            {
                c_contextPointer->Init();
            }
        }

        private static TDelegate LoadSteamworksFunction<TDelegate>(string c_functionName)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                if (m_libProcAddress == IntPtr.Zero)
                {
                    m_libProcAddress = LoadLibrary(kSteamworksWin64ModuleName);

                    if (m_libProcAddress == IntPtr.Zero)
                    {
                        throw new InvalidOperationException(Marshal.GetLastWin32Error().ToString());
                    }
                }

                var a_procAddress = GetProcAddress(m_libProcAddress, c_functionName);

                if (a_procAddress == IntPtr.Zero)
                {
                    throw new InvalidOperationException($"{c_functionName} failed to load");
                }

                return Marshal.GetDelegateForFunctionPointer<TDelegate>(a_procAddress);
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                if (m_libProcAddress == IntPtr.Zero)
                {
                    m_libProcAddress = dlopen(kSteamworksLinux64ModuleName, DlLoadFlags.RTLD_NOW);

                    if (m_libProcAddress == IntPtr.Zero)
                    {
                        throw new InvalidOperationException(Marshal.GetLastWin32Error().ToString());
                    }
                }

                var a_procAddress = dlsym(m_libProcAddress, c_functionName);

                if (a_procAddress == IntPtr.Zero)
                {
                    throw new InvalidOperationException($"{c_functionName} failed to load");
                }

                return Marshal.GetDelegateForFunctionPointer<TDelegate>(a_procAddress);
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                throw new NotImplementedException();
            }

            return default(TDelegate);
        }

        #region Accessors

        private static SteamClient m_steamClient;

        public static unsafe SteamClient Client
        {
            get
            {
                if (m_steamClient != null)
                {
                    return m_steamClient;
                }

                m_steamClient = new SteamClient(GetSteamApiContext()->m_pSteamClient);

                return m_steamClient;
            }
        }

        private static SteamUser m_steamUser;

        public static unsafe SteamUser User
        {
            get
            {
                if (m_steamUser != null)
                {
                    return m_steamUser;
                }

                m_steamUser = new SteamUser(GetSteamApiContext()->m_pSteamUser);

                return m_steamUser;
            }
        }

        private static SteamFriends m_steamFriends;

        public static unsafe SteamFriends Friends
        {
            get
            {
                if (m_steamFriends != null)
                {
                    return m_steamFriends;
                }

                m_steamFriends = new SteamFriends(GetSteamApiContext()->m_pSteamFriends);

                return m_steamFriends;
            }
        }

        private static SteamUtils m_steamUtils;

        public static unsafe SteamUtils Utils
        {
            get
            {
                if (m_steamUtils != null)
                {
                    return m_steamUtils;
                }

                m_steamUtils = new SteamUtils(GetSteamApiContext()->m_pSteamUtils);

                return m_steamUtils;
            }
        }

        private static SteamMatchmaking m_steamMatchmaking;

        public static unsafe SteamMatchmaking Matchmaking
        {
            get
            {
                if (m_steamMatchmaking != null)
                {
                    return m_steamMatchmaking;
                }

                m_steamMatchmaking = new SteamMatchmaking(GetSteamApiContext()->m_pSteamMatchmaking);

                return m_steamMatchmaking;
            }
        }

        private static SteamUserStats m_steamUserStats;

        public static unsafe SteamUserStats UserStats
        {
            get
            {
                if (m_steamUserStats != null)
                {
                    return m_steamUserStats;
                }

                m_steamUserStats = new SteamUserStats(GetSteamApiContext()->m_pSteamUserStats);

                return m_steamUserStats;
            }
        }

        private static SteamApps m_steamApps;

        public static unsafe SteamApps Apps
        {
            get
            {
                if (m_steamApps != null)
                {
                    return m_steamApps;
                }

                m_steamApps = new SteamApps(GetSteamApiContext()->m_pSteamApps);

                return m_steamApps;
            }
        }

        private static SteamMatchmakingServers m_steamMatchmakingServers;

        public static unsafe SteamMatchmakingServers MatchmakingServers
        {
            get
            {
                if (m_steamMatchmakingServers != null)
                {
                    return m_steamMatchmakingServers;
                }

                m_steamMatchmakingServers = new SteamMatchmakingServers(GetSteamApiContext()->m_pSteamMatchmakingServers);

                return m_steamMatchmakingServers;
            }
        }

        private static SteamNetworking m_steamNetworking;

        public static unsafe SteamNetworking Networking
        {
            get
            {
                if (m_steamNetworking != null)
                {
                    return m_steamNetworking;
                }

                m_steamNetworking = new SteamNetworking(GetSteamApiContext()->m_pSteamNetworking);

                return m_steamNetworking;
            }
        }

        private static SteamRemoteStorage m_steamRemoteStorage;

        public static unsafe SteamRemoteStorage RemoteStorage
        {
            get
            {
                if (m_steamRemoteStorage != null)
                {
                    return m_steamRemoteStorage;
                }

                m_steamRemoteStorage = new SteamRemoteStorage(GetSteamApiContext()->m_pSteamRemoteStorage);

                return m_steamRemoteStorage;
            }
        }

        private static SteamScreenshots m_steamScreenshots;

        public static unsafe SteamScreenshots Screenshots
        {
            get
            {
                if (m_steamScreenshots != null)
                {
                    return m_steamScreenshots;
                }

                m_steamScreenshots = new SteamScreenshots(GetSteamApiContext()->m_pSteamScreenshots);

                return m_steamScreenshots;
            }
        }

        private static SteamHttp m_steamHttp;

        public static unsafe SteamHttp Http
        {
            get
            {
                if (m_steamHttp != null)
                {
                    return m_steamHttp;
                }

                m_steamHttp = new SteamHttp(GetSteamApiContext()->m_pSteamHTTP);

                return m_steamHttp;
            }
        }

        private static SteamUnifiedMessages m_steamUnifiedMessages;

        public static unsafe SteamUnifiedMessages UnifiedMessages
        {
            get
            {
                if (m_steamUnifiedMessages != null)
                {
                    return m_steamUnifiedMessages;
                }

                m_steamUnifiedMessages = new SteamUnifiedMessages(GetSteamApiContext()->m_pSteamUnifiedMessages);

                return m_steamUnifiedMessages;
            }
        }

        private static SteamController m_steamController;

        public static unsafe SteamController Controller
        {
            get
            {
                if (m_steamController != null)
                {
                    return m_steamController;
                }

                m_steamController = new SteamController(GetSteamApiContext()->m_pController);

                return m_steamController;
            }
        }

        private static SteamUgc m_steamUgc;

        public static unsafe SteamUgc Ugc
        {
            get
            {
                if (m_steamUgc != null)
                {
                    return m_steamUgc;
                }

                m_steamUgc = new SteamUgc(GetSteamApiContext()->m_pSteamUGC);

                return m_steamUgc;
            }
        }

        private static SteamAppList m_steamAppList;

        public static unsafe SteamAppList AppList
        {
            get
            {
                if (m_steamAppList != null)
                {
                    return m_steamAppList;
                }

                m_steamAppList = new SteamAppList(GetSteamApiContext()->m_pSteamAppList);

                return m_steamAppList;
            }
        }

        private static SteamMusic m_steamMusic;

        public static unsafe SteamMusic Music
        {
            get
            {
                if (m_steamMusic != null)
                {
                    return m_steamMusic;
                }

                m_steamMusic = new SteamMusic(GetSteamApiContext()->m_pSteamMusic);

                return m_steamMusic;
            }
        }

        private static SteamMusicRemote m_steamMusicRemote;

        public static unsafe SteamMusicRemote MusicRemote
        {
            get
            {
                if (m_steamMusicRemote != null)
                {
                    return m_steamMusicRemote;
                }

                m_steamMusicRemote = new SteamMusicRemote(GetSteamApiContext()->m_pSteamMusicRemote);

                return m_steamMusicRemote;
            }
        }

        private static SteamHtmlSurface m_steamHtmlSurface;

        public static unsafe SteamHtmlSurface HtmlSurface
        {
            get
            {
                if (m_steamHtmlSurface != null)
                {
                    return m_steamHtmlSurface;
                }

                m_steamHtmlSurface = new SteamHtmlSurface(GetSteamApiContext()->m_pSteamHTMLSurface);

                return m_steamHtmlSurface;
            }
        }

        private static SteamInventory m_steamInventory;

        public static unsafe SteamInventory Inventory
        {
            get
            {
                if (m_steamInventory != null)
                {
                    return m_steamInventory;
                }

                m_steamInventory = new SteamInventory(GetSteamApiContext()->m_pSteamInventory);

                return m_steamInventory;
            }
        }

        private static SteamVideo m_steamVideo;

        public static unsafe SteamVideo Video
        {
            get
            {
                if (m_steamVideo != null)
                {
                    return m_steamVideo;
                }

                m_steamVideo = new SteamVideo(GetSteamApiContext()->m_pSteamVideo);

                return m_steamVideo;
            }
        }

        #endregion

        #region Windows Interop

        private const string kKernel32ModuleName = "kernel32.dll";

        [DllImport(kKernel32ModuleName, SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern IntPtr LoadLibrary(string c_lpFileName);

        [DllImport(kKernel32ModuleName, CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        private static extern IntPtr GetProcAddress(IntPtr c_hModule, string c_procName);

        #endregion

        #region Linux Interop

        private const string kDlModuleName = "dl";

        [DllImport(kDlModuleName)]
        private static extern IntPtr dlopen([MarshalAs(UnmanagedType.LPTStr)] string c_filename, DlLoadFlags c_flags);

        [DllImport(kDlModuleName)]
        private static extern IntPtr dlsym(IntPtr c_handle, [MarshalAs(UnmanagedType.LPTStr)] string c_symbol);

        // ReSharper disable InconsistentNaming
        private enum DlLoadFlags : int
        {
            RTLD_LAZY = 0x0001,
            RTLD_NOW = 0x0002,
            RTLD_GLOBAL = 0x0100,
            RTLD_LOCAL = 0x0000,
            RTLD_NOSHARE = 0x1000,
            RTLD_EXE = 0x2000,
            RTLD_SCRIPT = 0x4000
        }
        // ReSharper enable InconsistentNaming

        #endregion
    }
}