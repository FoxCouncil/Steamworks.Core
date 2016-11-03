//   !!  // Steamworks.Core - SteamClient.cs
// *.-". // Created: 2016-10-16 [6:24 PM]
//  | |  // Copyright 2016 // MIT License // The Fox Council 
// Modified by: Fox Diller on 2016-10-22 @ 3:03 PM

#region Usings

using System;
using System.Runtime.InteropServices;

#endregion

namespace Steamworks.Core
{
    public class SteamClient : ISteamClient
    {
        private readonly IntPtr m_instancePtr;

        public SteamClient(IntPtr c_instancePtr)
        {
            m_instancePtr = c_instancePtr;
        }

        private void CheckIfUsable()
        {
            if (m_instancePtr == IntPtr.Zero)
            {
                throw new InvalidOperationException("Steam Client Not Initialized!");
            }
        }

        #region Native Methods

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamClient_CreateSteamPipe")]
        private static extern uint SteamAPI_ISteamClient_CreateSteamPipe(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamClient_BReleaseSteamPipe")]
        private static extern bool SteamAPI_ISteamClient_BReleaseSteamPipe(IntPtr c_instancePtr, uint c_hSteamPipe);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamClient_ConnectToGlobalUser")]
        private static extern uint SteamAPI_ISteamClient_ConnectToGlobalUser(IntPtr c_instancePtr, uint c_hSteamPipe);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamClient_CreateLocalUser")]
        private static extern uint SteamAPI_ISteamClient_CreateLocalUser(IntPtr c_instancePtr, ref uint c_phSteamPipe, uint c_eAccountType);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamClient_ReleaseUser")]
        private static extern void SteamAPI_ISteamClient_ReleaseUser(IntPtr c_instancePtr, uint c_hSteamPipe, uint c_hUser);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamClient_GetISteamUser")]
        private static extern IntPtr SteamAPI_ISteamClient_GetISteamUser(IntPtr c_instancePtr, uint c_hSteamUser, uint c_hSteamPipe, SafeUtf8String c_pchVersion);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamClient_GetISteamGameServer")]
        private static extern IntPtr SteamAPI_ISteamClient_GetISteamGameServer(IntPtr c_instancePtr, uint c_hSteamUser, uint c_hSteamPipe, SafeUtf8String c_pchVersion);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamClient_SetLocalIPBinding")]
        private static extern void SteamAPI_ISteamClient_SetLocalIPBinding(IntPtr c_instancePtr, uint c_unIp, char c_usPort);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamClient_GetISteamFriends")]
        private static extern IntPtr SteamAPI_ISteamClient_GetISteamFriends(IntPtr c_instancePtr, uint c_hSteamUser, uint c_hSteamPipe, SafeUtf8String c_pchVersion);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamClient_GetISteamUtils")]
        private static extern IntPtr SteamAPI_ISteamClient_GetISteamUtils(IntPtr c_instancePtr, uint c_hSteamPipe, SafeUtf8String c_pchVersion);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamClient_GetISteamMatchmaking")]
        private static extern IntPtr SteamAPI_ISteamClient_GetISteamMatchmaking(IntPtr c_instancePtr, uint c_hSteamUser, uint c_hSteamPipe, SafeUtf8String c_pchVersion);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamClient_GetISteamMatchmakingServers")]
        private static extern IntPtr SteamAPI_ISteamClient_GetISteamMatchmakingServers(IntPtr c_instancePtr, uint c_hSteamUser, uint c_hSteamPipe, SafeUtf8String c_pchVersion);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamClient_GetISteamGenericInterface")]
        private static extern IntPtr SteamAPI_ISteamClient_GetISteamGenericInterface(IntPtr c_instancePtr, uint c_hSteamUser, uint c_hSteamPipe, SafeUtf8String c_pchVersion);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamClient_GetISteamUserStats")]
        private static extern IntPtr SteamAPI_ISteamClient_GetISteamUserStats(IntPtr c_instancePtr, uint c_hSteamUser, uint c_hSteamPipe, SafeUtf8String c_pchVersion);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamClient_GetISteamGameServerStats")]
        private static extern IntPtr SteamAPI_ISteamClient_GetISteamGameServerStats(IntPtr c_instancePtr, uint c_hSteamuser, uint c_hSteamPipe, SafeUtf8String c_pchVersion);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamClient_GetISteamApps")]
        private static extern IntPtr SteamAPI_ISteamClient_GetISteamApps(IntPtr c_instancePtr, uint c_hSteamUser, uint c_hSteamPipe, SafeUtf8String c_pchVersion);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamClient_GetISteamNetworking")]
        private static extern IntPtr SteamAPI_ISteamClient_GetISteamNetworking(IntPtr c_instancePtr, uint c_hSteamUser, uint c_hSteamPipe, SafeUtf8String c_pchVersion);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamClient_GetISteamRemoteStorage")]
        private static extern IntPtr SteamAPI_ISteamClient_GetISteamRemoteStorage(IntPtr c_instancePtr, uint c_hSteamuser, uint c_hSteamPipe, SafeUtf8String c_pchVersion);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamClient_GetISteamScreenshots")]
        private static extern IntPtr SteamAPI_ISteamClient_GetISteamScreenshots(IntPtr c_instancePtr, uint c_hSteamuser, uint c_hSteamPipe, SafeUtf8String c_pchVersion);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamClient_GetIPCCallCount")]
        private static extern uint SteamAPI_ISteamClient_GetIPCCallCount(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamClient_SetWarningMessageHook")]
        private static extern void SteamAPI_ISteamClient_SetWarningMessageHook(IntPtr c_instancePtr, IntPtr c_pFunction);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamClient_BShutdownIfAllPipesClosed")]
        private static extern bool SteamAPI_ISteamClient_BShutdownIfAllPipesClosed(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamClient_GetISteamHTTP")]
        private static extern IntPtr SteamAPI_ISteamClient_GetISteamHTTP(IntPtr c_instancePtr, uint c_hSteamuser, uint c_hSteamPipe, SafeUtf8String c_pchVersion);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamClient_GetISteamUnifiedMessages")]
        private static extern IntPtr SteamAPI_ISteamClient_GetISteamUnifiedMessages(IntPtr c_instancePtr, uint c_hSteamuser, uint c_hSteamPipe, SafeUtf8String c_pchVersion);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamClient_GetISteamController")]
        private static extern IntPtr SteamAPI_ISteamClient_GetISteamController(IntPtr c_instancePtr, uint c_hSteamUser, uint c_hSteamPipe, SafeUtf8String c_pchVersion);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamClient_GetISteamUGC")]
        private static extern IntPtr SteamAPI_ISteamClient_GetISteamUGC(IntPtr c_instancePtr, uint c_hSteamUser, uint c_hSteamPipe, SafeUtf8String c_pchVersion);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamClient_GetISteamAppList")]
        private static extern IntPtr SteamAPI_ISteamClient_GetISteamAppList(IntPtr c_instancePtr, uint c_hSteamUser, uint c_hSteamPipe, SafeUtf8String c_pchVersion);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamClient_GetISteamMusic")]
        private static extern IntPtr SteamAPI_ISteamClient_GetISteamMusic(IntPtr c_instancePtr, uint c_hSteamuser, uint c_hSteamPipe, SafeUtf8String c_pchVersion);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamClient_GetISteamMusicRemote")]
        private static extern IntPtr SteamAPI_ISteamClient_GetISteamMusicRemote(IntPtr c_instancePtr, uint c_hSteamuser, uint c_hSteamPipe, SafeUtf8String c_pchVersion);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamClient_GetISteamHTMLSurface")]
        private static extern IntPtr SteamAPI_ISteamClient_GetISteamHTMLSurface(IntPtr c_instancePtr, uint c_hSteamuser, uint c_hSteamPipe, SafeUtf8String c_pchVersion);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamClient_GetISteamInventory")]
        private static extern IntPtr SteamAPI_ISteamClient_GetISteamInventory(IntPtr c_instancePtr, uint c_hSteamuser, uint c_hSteamPipe, SafeUtf8String c_pchVersion);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamClient_GetISteamVideo")]
        private static extern IntPtr SteamAPI_ISteamClient_GetISteamVideo(IntPtr c_instancePtr, uint c_hSteamuser, uint c_hSteamPipe, SafeUtf8String c_pchVersion);

        #endregion

        #region Overrides of ISteamClient

        public override IntPtr GetIntPtr()
        {
            return m_instancePtr;
        }

        public override uint CreateSteamPipe()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamClient_CreateSteamPipe(m_instancePtr);

            return a_result;
        }

        public override bool BReleaseSteamPipe(uint c_hSteamPipe)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamClient_BReleaseSteamPipe(m_instancePtr, c_hSteamPipe);

            return a_result;
        }

        public override uint ConnectToGlobalUser(uint c_hSteamPipe)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamClient_ConnectToGlobalUser(m_instancePtr, c_hSteamPipe);

            return a_result;
        }

        public override uint CreateLocalUser(ref uint c_phSteamPipe, uint c_eAccountType)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamClient_CreateLocalUser(m_instancePtr, ref c_phSteamPipe, c_eAccountType);

            return a_result;
        }

        public override void ReleaseUser(uint c_hSteamPipe, uint c_hUser)
        {
            CheckIfUsable();

            SteamAPI_ISteamClient_ReleaseUser(m_instancePtr, c_hSteamPipe, c_hUser);
        }

        public override IntPtr GetISteamUser(uint c_hSteamUser, uint c_hSteamPipe, string c_pchVersion)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamClient_GetISteamUser(m_instancePtr, c_hSteamUser, c_hSteamPipe, new SafeUtf8String(c_pchVersion));

            return a_result;
        }

        public override IntPtr GetISteamGameServer(uint c_hSteamUser, uint c_hSteamPipe, string c_pchVersion)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamClient_GetISteamGameServer(m_instancePtr, c_hSteamUser, c_hSteamPipe, new SafeUtf8String(c_pchVersion));

            return a_result;
        }

        public override void SetLocalIpBinding(uint c_unIp, char c_usPort)
        {
            CheckIfUsable();

            SteamAPI_ISteamClient_SetLocalIPBinding(m_instancePtr, c_unIp, c_usPort);
        }

        public override IntPtr GetISteamFriends(uint c_hSteamUser, uint c_hSteamPipe, string c_pchVersion)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamClient_GetISteamFriends(m_instancePtr, c_hSteamUser, c_hSteamPipe, new SafeUtf8String(c_pchVersion));

            return a_result;
        }

        public override IntPtr GetISteamUtils(uint c_hSteamPipe, string c_pchVersion)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamClient_GetISteamUtils(m_instancePtr, c_hSteamPipe, new SafeUtf8String(c_pchVersion));

            return a_result;
        }

        public override IntPtr GetISteamMatchmaking(uint c_hSteamUser, uint c_hSteamPipe, string c_pchVersion)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamClient_GetISteamMatchmaking(m_instancePtr, c_hSteamUser, c_hSteamPipe, new SafeUtf8String(c_pchVersion));

            return a_result;
        }

        public override IntPtr GetISteamMatchmakingServers(uint c_hSteamUser, uint c_hSteamPipe, string c_pchVersion)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamClient_GetISteamMatchmakingServers(m_instancePtr, c_hSteamUser, c_hSteamPipe, new SafeUtf8String(c_pchVersion));

            return a_result;
        }

        public override IntPtr GetISteamGenericInterface(uint c_hSteamUser, uint c_hSteamPipe, string c_pchVersion)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamClient_GetISteamGenericInterface(m_instancePtr, c_hSteamUser, c_hSteamPipe, new SafeUtf8String(c_pchVersion));

            return a_result;
        }

        public override IntPtr GetISteamUserStats(uint c_hSteamUser, uint c_hSteamPipe, string c_pchVersion)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamClient_GetISteamUserStats(m_instancePtr, c_hSteamUser, c_hSteamPipe, new SafeUtf8String(c_pchVersion));

            return a_result;
        }

        public override IntPtr GetISteamGameServerStats(uint c_hSteamUser, uint c_hSteamPipe, string c_pchVersion)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamClient_GetISteamGameServerStats(m_instancePtr, c_hSteamUser, c_hSteamPipe, new SafeUtf8String(c_pchVersion));

            return a_result;
        }

        public override IntPtr GetISteamApps(uint c_hSteamUser, uint c_hSteamPipe, string c_pchVersion)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamClient_GetISteamApps(m_instancePtr, c_hSteamUser, c_hSteamPipe, new SafeUtf8String(c_pchVersion));

            return a_result;
        }

        public override IntPtr GetISteamNetworking(uint c_hSteamUser, uint c_hSteamPipe, string c_pchVersion)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamClient_GetISteamNetworking(m_instancePtr, c_hSteamUser, c_hSteamPipe, new SafeUtf8String(c_pchVersion));

            return a_result;
        }

        public override IntPtr GetISteamRemoteStorage(uint c_hSteamUser, uint c_hSteamPipe, string c_pchVersion)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamClient_GetISteamRemoteStorage(m_instancePtr, c_hSteamUser, c_hSteamPipe, new SafeUtf8String(c_pchVersion));

            return a_result;
        }

        public override IntPtr GetISteamScreenshots(uint c_hSteamUser, uint c_hSteamPipe, string c_pchVersion)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamClient_GetISteamScreenshots(m_instancePtr, c_hSteamUser, c_hSteamPipe, new SafeUtf8String(c_pchVersion));

            return a_result;
        }

        public override uint GetIpcCallCount()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamClient_GetIPCCallCount(m_instancePtr);

            return a_result;
        }

        public override void SetWarningMessageHook(IntPtr c_pFunction)
        {
            throw new NotImplementedException();
        }

        public override bool BShutdownIfAllPipesClosed()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamClient_BShutdownIfAllPipesClosed(m_instancePtr);

            return a_result;
        }

        public override IntPtr GetISteamHttp(uint c_hSteamUser, uint c_hSteamPipe, string c_pchVersion)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamClient_GetISteamHTTP(m_instancePtr, c_hSteamUser, c_hSteamPipe, new SafeUtf8String(c_pchVersion));

            return a_result;
        }

        public override IntPtr GetISteamUnifiedMessages(uint c_hSteamUser, uint c_hSteamPipe, string c_pchVersion)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamClient_GetISteamUnifiedMessages(m_instancePtr, c_hSteamUser, c_hSteamPipe, new SafeUtf8String(c_pchVersion));

            return a_result;
        }

        public override IntPtr GetISteamController(uint c_hSteamUser, uint c_hSteamPipe, string c_pchVersion)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamClient_GetISteamController(m_instancePtr, c_hSteamUser, c_hSteamPipe, new SafeUtf8String(c_pchVersion));

            return a_result;
        }

        public override IntPtr GetISteamUgc(uint c_hSteamUser, uint c_hSteamPipe, string c_pchVersion)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamClient_GetISteamUGC(m_instancePtr, c_hSteamUser, c_hSteamPipe, new SafeUtf8String(c_pchVersion));

            return a_result;
        }

        public override IntPtr GetISteamAppList(uint c_hSteamUser, uint c_hSteamPipe, string c_pchVersion)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamClient_GetISteamAppList(m_instancePtr, c_hSteamUser, c_hSteamPipe, new SafeUtf8String(c_pchVersion));

            return a_result;
        }

        public override IntPtr GetISteamMusic(uint c_hSteamUser, uint c_hSteamPipe, string c_pchVersion)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamClient_GetISteamMusic(m_instancePtr, c_hSteamUser, c_hSteamPipe, new SafeUtf8String(c_pchVersion));

            return a_result;
        }

        public override IntPtr GetISteamMusicRemote(uint c_hSteamUser, uint c_hSteamPipe, string c_pchVersion)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamClient_GetISteamMusicRemote(m_instancePtr, c_hSteamUser, c_hSteamPipe, new SafeUtf8String(c_pchVersion));

            return a_result;
        }

        public override IntPtr GetISteamHtmlSurface(uint c_hSteamUser, uint c_hSteamPipe, string c_pchVersion)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamClient_GetISteamHTMLSurface(m_instancePtr, c_hSteamUser, c_hSteamPipe, new SafeUtf8String(c_pchVersion));

            return a_result;
        }

        public override IntPtr GetISteamInventory(uint c_hSteamUser, uint c_hSteamPipe, string c_pchVersion)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamClient_GetISteamInventory(m_instancePtr, c_hSteamUser, c_hSteamPipe, new SafeUtf8String(c_pchVersion));

            return a_result;
        }

        public override IntPtr GetISteamVideo(uint c_hSteamUser, uint c_hSteamPipe, string c_pchVersion)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamClient_GetISteamVideo(m_instancePtr, c_hSteamUser, c_hSteamPipe, new SafeUtf8String(c_pchVersion));

            return a_result;
        }

        #endregion
    }

    public abstract class ISteamClient
    {
        public abstract IntPtr GetIntPtr();

        public abstract uint CreateSteamPipe();

        public abstract bool BReleaseSteamPipe(uint c_hSteamPipe);

        public abstract uint ConnectToGlobalUser(uint c_hSteamPipe);

        public abstract uint CreateLocalUser(ref uint c_phSteamPipe, uint c_eAccountType);

        public abstract void ReleaseUser(uint c_hSteamPipe, uint c_hUser);

        public abstract IntPtr GetISteamUser(uint c_hSteamUser, uint c_hSteamPipe, string c_pchVersion);

        public abstract IntPtr GetISteamGameServer(uint c_hSteamUser, uint c_hSteamPipe, string c_pchVersion);

        public abstract void SetLocalIpBinding(uint c_unIp, char c_usPort);

        public abstract IntPtr GetISteamFriends(uint c_hSteamUser, uint c_hSteamPipe, string c_pchVersion);

        public abstract IntPtr GetISteamUtils(uint c_hSteamPipe, string c_pchVersion);

        public abstract IntPtr GetISteamMatchmaking(uint c_hSteamUser, uint c_hSteamPipe, string c_pchVersion);

        public abstract IntPtr GetISteamMatchmakingServers(uint c_hSteamUser, uint c_hSteamPipe, string c_pchVersion);

        public abstract IntPtr GetISteamGenericInterface(uint c_hSteamUser, uint c_hSteamPipe, string c_pchVersion);

        public abstract IntPtr GetISteamUserStats(uint c_hSteamUser, uint c_hSteamPipe, string c_pchVersion);

        public abstract IntPtr GetISteamGameServerStats(uint c_hSteamuser, uint c_hSteamPipe, string c_pchVersion);

        public abstract IntPtr GetISteamApps(uint c_hSteamUser, uint c_hSteamPipe, string c_pchVersion);

        public abstract IntPtr GetISteamNetworking(uint c_hSteamUser, uint c_hSteamPipe, string c_pchVersion);

        public abstract IntPtr GetISteamRemoteStorage(uint c_hSteamuser, uint c_hSteamPipe, string c_pchVersion);

        public abstract IntPtr GetISteamScreenshots(uint c_hSteamuser, uint c_hSteamPipe, string c_pchVersion);

        public abstract uint GetIpcCallCount();

        public abstract void SetWarningMessageHook(IntPtr c_pFunction);

        public abstract bool BShutdownIfAllPipesClosed();

        public abstract IntPtr GetISteamHttp(uint c_hSteamuser, uint c_hSteamPipe, string c_pchVersion);

        public abstract IntPtr GetISteamUnifiedMessages(uint c_hSteamuser, uint c_hSteamPipe, string c_pchVersion);

        public abstract IntPtr GetISteamController(uint c_hSteamUser, uint c_hSteamPipe, string c_pchVersion);

        public abstract IntPtr GetISteamUgc(uint c_hSteamUser, uint c_hSteamPipe, string c_pchVersion);

        public abstract IntPtr GetISteamAppList(uint c_hSteamUser, uint c_hSteamPipe, string c_pchVersion);

        public abstract IntPtr GetISteamMusic(uint c_hSteamuser, uint c_hSteamPipe, string c_pchVersion);

        public abstract IntPtr GetISteamMusicRemote(uint c_hSteamuser, uint c_hSteamPipe, string c_pchVersion);

        public abstract IntPtr GetISteamHtmlSurface(uint c_hSteamuser, uint c_hSteamPipe, string c_pchVersion);

        public abstract IntPtr GetISteamInventory(uint c_hSteamuser, uint c_hSteamPipe, string c_pchVersion);

        public abstract IntPtr GetISteamVideo(uint c_hSteamuser, uint c_hSteamPipe, string c_pchVersion);
    }
}