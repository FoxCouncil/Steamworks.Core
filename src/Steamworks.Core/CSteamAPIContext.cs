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

            m_pSteamClient = SteamApi.CreateInterface(new SafeUtf8String("SteamClient017"));

            if (m_pSteamClient == IntPtr.Zero)
            {
                return false;
            }

            return true;
        }
    }
}