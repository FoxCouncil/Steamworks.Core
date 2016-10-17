//   !!  // Steamworks.Core - SteamApi.cs
// *.-". // Created: 2016-10-14 [8:06 PM]
//  | |  // Copyright 2016 // MIT License // The Fox Council 
// Modified by: Fox Diller on 2016-10-15 @ 10:25 PM

#region Usings

using System;
using System.IO;
using System.Runtime.InteropServices;
using string8 = Steamworks.Core.SafeUtf8String;

#endregion

namespace Steamworks.Core
{
    public static class SteamApi
    {
        public delegate bool InitFunc();

        public delegate void ReleaseCurrentThreadMemoryFunc();

        public delegate bool RestartAppIfNecessaryFunc(uint c_ownAppId);

        public delegate void ShutdownFunc();

        public delegate int GetHSteamUserFunc();

        public delegate int GetHSteamPipeFunc();

        public unsafe delegate CSteamApiContext* ContextInitFunc(IntPtr c_callbackStruc);

        public delegate IntPtr CreateInterfaceFunc(string8 c_versionString);

        public const string STEAM_DEBUG_APP_ID_FILENAME = "./steam_appid.txt";

        public static readonly Version SteamworksCoreVersion = new Version(1, 0, 0, 0);

        public static readonly Version SteamApiVersion = new Version(1, 38);
        public static readonly Version SteamApiDllVersion = new Version(3, 64, 82, 82);

        private static bool m_isInitialized;

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

        private static void LoadMethods()
        {
            NativeInit = LoadSteamworksFunction<InitFunc>("SteamAPI_Init");
            Shutdown = LoadSteamworksFunction<ShutdownFunc>("SteamAPI_Shutdown");

            RestartAppIfNecessary = LoadSteamworksFunction<RestartAppIfNecessaryFunc>("SteamAPI_RestartAppIfNecessary");
            ReleaseCurrentThreadMemory = LoadSteamworksFunction<ReleaseCurrentThreadMemoryFunc>("SteamAPI_ReleaseCurrentThreadMemory");

            GetHSteamPipe = LoadSteamworksFunction<GetHSteamPipeFunc>("SteamAPI_GetHSteamPipe");
            GetHSteamUser = LoadSteamworksFunction<GetHSteamUserFunc>("SteamAPI_GetHSteamUser");

            // Steam Internals
            ContextInit = LoadSteamworksFunction<ContextInitFunc>("SteamInternal_ContextInit");
            CreateInterface = LoadSteamworksFunction<CreateInterfaceFunc>("SteamInternal_CreateInterface");
        }

        public unsafe delegate void OnContextInitFunc(CSteamApiContext* c_contextPtr);

        public static unsafe OnContextInitFunc OnContextInitPtr = OnContextInit;

        private static unsafe CSteamApiContext* GetSteamApiContext()
        {
            var a_callbackCounterAndContext = CallbackCounterAndContext();

            return ContextInit(Marshal.UnsafeAddrOfPinnedArrayElement(a_callbackCounterAndContext, 0));
        }

        private static unsafe IntPtr[] CallbackCounterAndContext()
        {
            if (m_callbackCounterAndContext != null)
            {
                return m_callbackCounterAndContext;
            }

            var a_size = 2 + Marshal.SizeOf<CSteamApiContext>() / Marshal.SizeOf<IntPtr>();

            m_callbackCounterAndContext = new IntPtr[a_size];

            m_callbackCounterAndContext[0] = Marshal.GetFunctionPointerForDelegate(OnContextInitPtr);

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

        public static TDelegate LoadSteamworksFunction<TDelegate>(string c_functionName)
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
            else if(RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                throw new NotImplementedException();
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                throw new NotImplementedException();
            }

            return default(TDelegate);
        }

        #region Accessors

        public static unsafe ISteamClient Client
        {
            get
            {
                var a_pContext = GetSteamApiContext()->m_pSteamClient;

                var a_ptrHandle = (GCHandle)a_pContext;

                return a_ptrHandle.Target as ISteamClient;
            }
        }

        #endregion

        #region Windows Interop

        private const string kSteamworksWin32ModuleName = "steam_api.dll";
        private const string kSteamworksWin64ModuleName = "steam_api64.dll";

        private const string kKernel32ModuleName = "kernel32.dll";

        private static IntPtr m_libProcAddress;
        private static IntPtr[] m_callbackCounterAndContext;

        [DllImport(kKernel32ModuleName, CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        private static extern IntPtr GetProcAddress(IntPtr c_hModule, string c_procName);

        [DllImport(kKernel32ModuleName, SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern IntPtr LoadLibrary(string c_lpFileName);

        #endregion
    }
}