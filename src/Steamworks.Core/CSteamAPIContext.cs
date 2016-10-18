//   !!  // Steamworks.Core - CSteamAPIContext.cs
// *.-". // Created: 2016-10-16 [6:21 PM]
//  | |  // Copyright 2016 // MIT License // The Fox Council 
// Modified by: Fox Diller on 2016-10-16 @ 6:21 PM

#region Usings

using System;
using System.Runtime.InteropServices;

#endregion

namespace Steamworks.Core
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct CSteamApiContext
    {
        public IntPtr m_pSteamClient; // class ISteamClient *
        public IntPtr m_pSteamUser; // class ISteamUser *
        public IntPtr m_pSteamFriends; // class ISteamFriends *
        public IntPtr m_pSteamUtils; // class ISteamUtils *
        public IntPtr m_pSteamMatchmaking; // class ISteamMatchmaking *
        public IntPtr m_pSteamUserStats; // class ISteamUserStats *
        public IntPtr m_pSteamApps; // class ISteamApps *
        public IntPtr m_pSteamMatchmakingServers; // class ISteamMatchmakingServers *
        public IntPtr m_pSteamNetworking; // class ISteamNetworking *
        public IntPtr m_pSteamRemoteStorage; // class ISteamRemoteStorage *
        public IntPtr m_pSteamScreenshots; // class ISteamScreenshots *
        public IntPtr m_pSteamHTTP; // class ISteamHTTP *
        public IntPtr m_pSteamUnifiedMessages; // class ISteamUnifiedMessages *
        public IntPtr m_pController; // class ISteamController *
        public IntPtr m_pSteamUGC; // class ISteamUGC *
        public IntPtr m_pSteamAppList; // class ISteamAppList *
        public IntPtr m_pSteamMusic; // class ISteamMusic *
        public IntPtr m_pSteamMusicRemote; // class ISteamMusicRemote *
        public IntPtr m_pSteamHTMLSurface; // class ISteamHTMLSurface *
        public IntPtr m_pSteamInventory; // class ISteamInventory *
        public IntPtr m_pSteamVideo; // class ISteamVideo *

        public void Clear()
        {
            m_pSteamClient = IntPtr.Zero;
            m_pSteamUser = IntPtr.Zero;
            m_pSteamFriends = IntPtr.Zero;
            m_pSteamUtils = IntPtr.Zero;
            m_pSteamMatchmaking = IntPtr.Zero;
            m_pSteamUserStats = IntPtr.Zero;
            m_pSteamApps = IntPtr.Zero;
            m_pSteamMatchmakingServers = IntPtr.Zero;
            m_pSteamNetworking = IntPtr.Zero;
            m_pSteamRemoteStorage = IntPtr.Zero;
            m_pSteamScreenshots = IntPtr.Zero;
            m_pSteamHTTP = IntPtr.Zero;
            m_pSteamUnifiedMessages = IntPtr.Zero;
            m_pController = IntPtr.Zero;
            m_pSteamUGC = IntPtr.Zero;
            m_pSteamAppList = IntPtr.Zero;
            m_pSteamMusic = IntPtr.Zero;
            m_pSteamMusicRemote = IntPtr.Zero;
            m_pSteamHTMLSurface = IntPtr.Zero;
            m_pSteamInventory = IntPtr.Zero;
            m_pSteamVideo = IntPtr.Zero;
        }

        public bool Init()
        {
            var a_steamUser = SteamApi.GetHSteamUser();
            var a_steamPipe = SteamApi.GetHSteamPipe();

            if (a_steamPipe == 0)
            {
                return false;
            }

            m_pSteamClient = SteamApi.CreateInterface(new SafeUtf8String(SteamApi.STEAMCLIENT_INTERFACE_VERSION));

            if (m_pSteamClient == IntPtr.Zero)
            {
                return false;
            }

            var a_tempSteamClient = new SteamClient(m_pSteamClient);

            m_pSteamUser = a_tempSteamClient.GetISteamUser(a_steamUser, a_steamPipe, SteamApi.STEAMUSER_INTERFACE_VERSION);

            if (m_pSteamUser == IntPtr.Zero)
            {
                return false;
            }

            m_pSteamFriends = a_tempSteamClient.GetISteamFriends(a_steamUser, a_steamPipe, SteamApi.STEAMFRIENDS_INTERFACE_VERSION);

            if (m_pSteamFriends == IntPtr.Zero)
            {
                return false;
            }

            m_pSteamUtils = a_tempSteamClient.GetISteamUtils(a_steamPipe, SteamApi.STEAMUTILS_INTERFACE_VERSION);

            if (m_pSteamFriends == IntPtr.Zero)
            {
                return false;
            }

            m_pSteamMatchmaking = a_tempSteamClient.GetISteamMatchmaking(a_steamUser, a_steamPipe, SteamApi.STEAMMATCHMAKING_INTERFACE_VERSION);

            if (m_pSteamMatchmaking == IntPtr.Zero)
            {
                return false; 
            }

            m_pSteamMatchmakingServers = a_tempSteamClient.GetISteamMatchmakingServers(a_steamUser, a_steamPipe, SteamApi.STEAMMATCHMAKINGSERVERS_INTERFACE_VERSION);

            if (m_pSteamMatchmakingServers == IntPtr.Zero)
            {
                return false; 
            }

            m_pSteamUserStats = a_tempSteamClient.GetISteamUserStats(a_steamUser, a_steamPipe, SteamApi.STEAMUSERSTATS_INTERFACE_VERSION);

            if (m_pSteamUserStats == IntPtr.Zero)
            {
                return false;
            }

            m_pSteamApps = a_tempSteamClient.GetISteamApps(a_steamUser, a_steamPipe, SteamApi.STEAMAPPS_INTERFACE_VERSION);

            if (m_pSteamApps == IntPtr.Zero)
            {
                return false;
            }

            m_pSteamNetworking = a_tempSteamClient.GetISteamNetworking(a_steamUser, a_steamPipe, SteamApi.STEAMNETWORKING_INTERFACE_VERSION);

            if (m_pSteamNetworking == IntPtr.Zero)
            {
                return false;
            }

            m_pSteamRemoteStorage = a_tempSteamClient.GetISteamRemoteStorage(a_steamUser, a_steamPipe, SteamApi.STEAMREMOTESTORAGE_INTERFACE_VERSION);

            if (m_pSteamRemoteStorage == IntPtr.Zero)
            {
                return false;
            }

            m_pSteamScreenshots = a_tempSteamClient.GetISteamScreenshots(a_steamUser, a_steamPipe, SteamApi.STEAMSCREENSHOTS_INTERFACE_VERSION);

            if (m_pSteamScreenshots == IntPtr.Zero)
            {
                return false;
            }

            m_pSteamHTTP = a_tempSteamClient.GetISteamHttp(a_steamUser, a_steamPipe, SteamApi.STEAMHTTP_INTERFACE_VERSION);

            if (m_pSteamHTTP == IntPtr.Zero)
            {
                return false;
            }

            m_pSteamUnifiedMessages = a_tempSteamClient.GetISteamUnifiedMessages(a_steamUser, a_steamPipe, SteamApi.STEAMUNIFIEDMESSAGES_INTERFACE_VERSION);

            if (m_pSteamUnifiedMessages == IntPtr.Zero)
            {
                return false;
            }

            m_pController = a_tempSteamClient.GetISteamController(a_steamUser, a_steamPipe, SteamApi.STEAMCONTROLLER_INTERFACE_VERSION);

            if (m_pController == IntPtr.Zero)
            {
                return false;
            }

            m_pSteamUGC = a_tempSteamClient.GetISteamUgc(a_steamUser, a_steamPipe, SteamApi.STEAMUGC_INTERFACE_VERSION);

            if (m_pSteamUGC == IntPtr.Zero)
            {
                return false;
            }

            m_pSteamAppList = a_tempSteamClient.GetISteamAppList(a_steamUser, a_steamPipe, SteamApi.STEAMAPPLIST_INTERFACE_VERSION);

            if (m_pSteamAppList == IntPtr.Zero)
            {
                return false;
            }

            m_pSteamMusic = a_tempSteamClient.GetISteamMusic(a_steamUser, a_steamPipe, SteamApi.STEAMMUSIC_INTERFACE_VERSION);

            if (m_pSteamMusic == IntPtr.Zero)
            {
                return false;
            }

            m_pSteamMusicRemote = a_tempSteamClient.GetISteamMusicRemote(a_steamUser, a_steamPipe, SteamApi.STEAMMUSICREMOTE_INTERFACE_VERSION);

            if (m_pSteamMusicRemote == IntPtr.Zero)
            {
                return false;
            }

            m_pSteamHTMLSurface = a_tempSteamClient.GetISteamHtmlSurface(a_steamUser, a_steamPipe, SteamApi.STEAMHTMLSURFACE_INTERFACE_VERSION);

            if (m_pSteamHTMLSurface == IntPtr.Zero)
            {
                return false;
            }

            m_pSteamInventory = a_tempSteamClient.GetISteamInventory(a_steamUser, a_steamPipe, SteamApi.STEAMINVENTORY_INTERFACE_VERSION);

            if (m_pSteamInventory == IntPtr.Zero)
            {
                return false;
            }

            m_pSteamVideo = a_tempSteamClient.GetISteamVideo(a_steamUser, a_steamPipe, SteamApi.STEAMVIDEO_INTERFACE_VERSION);

            if (m_pSteamVideo == IntPtr.Zero)
            {
                return false;
            }

            return true;
        }
    }
}