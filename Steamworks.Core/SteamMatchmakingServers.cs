//   !!  // Steamworks.Core - SteamMatchmakingServers.cs
// *.-". // Created: 2016-10-20 [6:41 PM]
//  | |  // Copyright 2016 // MIT License // The Fox Council 
// Modified by: Fox Diller on 2016-10-22 @ 3:03 PM

#region Usings

using System;
using System.Runtime.InteropServices;

#endregion

namespace Steamworks.Core
{
    public class SteamMatchmakingServers : ISteamMatchmakingServers
    {
        private readonly IntPtr m_instancePtr;

        public SteamMatchmakingServers(IntPtr c_instancePtr)
        {
            m_instancePtr = c_instancePtr;
        }

        private void CheckIfUsable()
        {
            if (m_instancePtr == IntPtr.Zero)
            {
                throw new InvalidOperationException("Steam MatchmakingServers Not Initialized!");
            }
        }

        #region Native Methods

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMatchmakingServers_RequestInternetServerList")]
        private static extern uint SteamAPI_ISteamMatchmakingServers_RequestInternetServerList(IntPtr c_instancePtr, uint c_iApp, [In, Out] IntPtr[] c_ppchFilters, uint c_nFilters, IntPtr c_pRequestServersResponse);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMatchmakingServers_RequestLANServerList")]
        private static extern uint SteamAPI_ISteamMatchmakingServers_RequestLANServerList(IntPtr c_instancePtr, uint c_iApp, IntPtr c_pRequestServersResponse);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMatchmakingServers_RequestFriendsServerList")]
        private static extern uint SteamAPI_ISteamMatchmakingServers_RequestFriendsServerList(IntPtr c_instancePtr, uint c_iApp, [In, Out] IntPtr[] c_ppchFilters, uint c_nFilters, IntPtr c_pRequestServersResponse);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMatchmakingServers_RequestFavoritesServerList")]
        private static extern uint SteamAPI_ISteamMatchmakingServers_RequestFavoritesServerList(IntPtr c_instancePtr, uint c_iApp, [In, Out] IntPtr[] c_ppchFilters, uint c_nFilters, IntPtr c_pRequestServersResponse);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMatchmakingServers_RequestHistoryServerList")]
        private static extern uint SteamAPI_ISteamMatchmakingServers_RequestHistoryServerList(IntPtr c_instancePtr, uint c_iApp, [In, Out] IntPtr[] c_ppchFilters, uint c_nFilters, IntPtr c_pRequestServersResponse);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMatchmakingServers_RequestSpectatorServerList")]
        private static extern uint SteamAPI_ISteamMatchmakingServers_RequestSpectatorServerList(IntPtr c_instancePtr, uint c_iApp, [In, Out] IntPtr[] c_ppchFilters, uint c_nFilters, IntPtr c_pRequestServersResponse);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMatchmakingServers_ReleaseRequest")]
        private static extern void SteamAPI_ISteamMatchmakingServers_ReleaseRequest(IntPtr c_instancePtr, uint c_hServerListRequest);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMatchmakingServers_GetServerDetails")]
        private static extern IntPtr SteamAPI_ISteamMatchmakingServers_GetServerDetails(IntPtr c_instancePtr, uint c_hRequest, int c_iServer);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMatchmakingServers_CancelQuery")]
        private static extern void SteamAPI_ISteamMatchmakingServers_CancelQuery(IntPtr c_instancePtr, uint c_hRequest);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMatchmakingServers_RefreshQuery")]
        private static extern void SteamAPI_ISteamMatchmakingServers_RefreshQuery(IntPtr c_instancePtr, uint c_hRequest);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMatchmakingServers_IsRefreshing")]
        private static extern bool SteamAPI_ISteamMatchmakingServers_IsRefreshing(IntPtr c_instancePtr, uint c_hRequest);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMatchmakingServers_GetServerCount")]
        private static extern int SteamAPI_ISteamMatchmakingServers_GetServerCount(IntPtr c_instancePtr, uint c_hRequest);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMatchmakingServers_RefreshServer")]
        private static extern void SteamAPI_ISteamMatchmakingServers_RefreshServer(IntPtr c_instancePtr, uint c_hRequest, int c_iServer);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMatchmakingServers_PingServer")]
        private static extern uint SteamAPI_ISteamMatchmakingServers_PingServer(IntPtr c_instancePtr, uint c_unIp, char c_usPort, IntPtr c_pRequestServersResponse);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMatchmakingServers_PlayerDetails")]
        private static extern uint SteamAPI_ISteamMatchmakingServers_PlayerDetails(IntPtr c_instancePtr, uint c_unIp, char c_usPort, IntPtr c_pRequestServersResponse);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMatchmakingServers_ServerRules")]
        private static extern uint SteamAPI_ISteamMatchmakingServers_ServerRules(IntPtr c_instancePtr, uint c_unIp, char c_usPort, IntPtr c_pRequestServersResponse);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMatchmakingServers_CancelServerQuery")]
        private static extern void SteamAPI_ISteamMatchmakingServers_CancelServerQuery(IntPtr c_instancePtr, uint c_hServerQuery);

        #endregion

        #region Overrides of ISteamMatchmakingServers

        public override IntPtr GetIntPtr()
        {
            return m_instancePtr;
        }

        public override uint RequestInternetServerList(uint c_iApp, IntPtr[] c_ppchFilters, ISteamMatchmakingServerListResponse c_pRequestServersResponse)
        {
            CheckIfUsable();

            var a_objPtr = IntPtr.Zero;

            var a_result = SteamAPI_ISteamMatchmakingServers_RequestInternetServerList(m_instancePtr, c_iApp, c_ppchFilters, 0, a_objPtr);

            c_pRequestServersResponse = new SteamMatchmakingServerListResponse(a_objPtr);

            return a_result;
        }

        public override uint RequestLanServerList(uint c_iApp, ISteamMatchmakingServerListResponse c_pRequestServersResponse)
        {
            CheckIfUsable();

            var a_objPtr = IntPtr.Zero;

            var a_result = SteamAPI_ISteamMatchmakingServers_RequestLANServerList(m_instancePtr, c_iApp, a_objPtr);

            c_pRequestServersResponse = new SteamMatchmakingServerListResponse(a_objPtr);

            return a_result;
        }

        public override uint RequestFriendsServerList(uint c_iApp, IntPtr[] c_ppchFilters, ISteamMatchmakingServerListResponse c_pRequestServersResponse)
        {
            CheckIfUsable();

            var a_objPtr = IntPtr.Zero;

            var a_result = SteamAPI_ISteamMatchmakingServers_RequestFriendsServerList(m_instancePtr, c_iApp, c_ppchFilters, 0, a_objPtr);

            c_pRequestServersResponse = new SteamMatchmakingServerListResponse(a_objPtr);

            return a_result;
        }

        public override uint RequestFavoritesServerList(uint c_iApp, IntPtr[] c_ppchFilters, ISteamMatchmakingServerListResponse c_pRequestServersResponse)
        {
            CheckIfUsable();

            var a_objPtr = IntPtr.Zero;

            var a_result = SteamAPI_ISteamMatchmakingServers_RequestFavoritesServerList(m_instancePtr, c_iApp, c_ppchFilters, 0, a_objPtr);

            c_pRequestServersResponse = new SteamMatchmakingServerListResponse(a_objPtr);

            return a_result;
        }

        public override uint RequestHistoryServerList(uint c_iApp, IntPtr[] c_ppchFilters, ISteamMatchmakingServerListResponse c_pRequestServersResponse)
        {
            CheckIfUsable();

            var a_objPtr = IntPtr.Zero;

            var a_result = SteamAPI_ISteamMatchmakingServers_RequestHistoryServerList(m_instancePtr, c_iApp, c_ppchFilters, 0, a_objPtr);

            c_pRequestServersResponse = new SteamMatchmakingServerListResponse(a_objPtr);

            return a_result;
        }

        public override uint RequestSpectatorServerList(uint c_iApp, IntPtr[] c_ppchFilters, ISteamMatchmakingServerListResponse c_pRequestServersResponse)
        {
            CheckIfUsable();

            var a_objPtr = IntPtr.Zero;

            var a_result = SteamAPI_ISteamMatchmakingServers_RequestSpectatorServerList(m_instancePtr, c_iApp, c_ppchFilters, 0, a_objPtr);

            c_pRequestServersResponse = new SteamMatchmakingServerListResponse(a_objPtr);

            return a_result;
        }

        public override void ReleaseRequest(uint c_hServerListRequest)
        {
            CheckIfUsable();

            SteamAPI_ISteamMatchmakingServers_ReleaseRequest(m_instancePtr, c_hServerListRequest);
        }

        public override GameServerItem GetServerDetails(uint c_hRequest, int c_iServer)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamMatchmakingServers_GetServerDetails(m_instancePtr, c_hRequest, c_iServer);

            return Marshal.PtrToStructure<GameServerItem>(a_result);
        }

        public override void CancelQuery(uint c_hRequest)
        {
            CheckIfUsable();

            SteamAPI_ISteamMatchmakingServers_CancelQuery(m_instancePtr, c_hRequest);
        }

        public override void RefreshQuery(uint c_hRequest)
        {
            CheckIfUsable();

            SteamAPI_ISteamMatchmakingServers_RefreshQuery(m_instancePtr, c_hRequest);
        }

        public override bool IsRefreshing(uint c_hRequest)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamMatchmakingServers_IsRefreshing(m_instancePtr, c_hRequest);

            return a_result;
        }

        public override int GetServerCount(uint c_hRequest)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamMatchmakingServers_GetServerCount(m_instancePtr, c_hRequest);

            return a_result;
        }

        public override void RefreshServer(uint c_hRequest, int c_iServer)
        {
            CheckIfUsable();

            SteamAPI_ISteamMatchmakingServers_RefreshServer(m_instancePtr, c_hRequest, c_iServer);
        }

        public override uint PingServer(uint c_unIp, char c_usPort, ISteamMatchmakingPingResponse c_pRequestServersResponse)
        {
            CheckIfUsable();

            var a_objPtr = IntPtr.Zero;

            var a_result = SteamAPI_ISteamMatchmakingServers_PingServer(m_instancePtr, c_unIp, c_usPort, a_objPtr);

            c_pRequestServersResponse = new SteamMatchmakingPingResponse(a_objPtr);

            return a_result;
        }

        public override uint PlayerDetails(uint c_unIp, char c_usPort, ISteamMatchmakingPlayersResponse c_pRequestServersResponse)
        {
            CheckIfUsable();

            var a_objPtr = IntPtr.Zero;

            var a_result = SteamAPI_ISteamMatchmakingServers_PlayerDetails(m_instancePtr, c_unIp, c_usPort, a_objPtr);

            c_pRequestServersResponse = new SteamMatchmakingPlayersResponse(a_objPtr);

            return a_result;
        }

        public override uint ServerRules(uint c_unIp, char c_usPort, ISteamMatchmakingRulesResponse c_pRequestServersResponse)
        {
            CheckIfUsable();

            var a_objPtr = IntPtr.Zero;

            var a_result = SteamAPI_ISteamMatchmakingServers_ServerRules(m_instancePtr, c_unIp, c_usPort, a_objPtr);

            c_pRequestServersResponse = new SteamMatchmakingRulesResponse(a_objPtr);

            return a_result;
        }

        public override void CancelServerQuery(uint c_hServerQuery)
        {
            CheckIfUsable();

            SteamAPI_ISteamMatchmakingServers_CancelServerQuery(m_instancePtr, c_hServerQuery);
        }

        #endregion
    }

    public abstract class ISteamMatchmakingServers
    {
        public abstract IntPtr GetIntPtr();
        public abstract uint RequestInternetServerList(uint c_iApp, IntPtr[] c_ppchFilters, ISteamMatchmakingServerListResponse c_pRequestServersResponse);
        public abstract uint RequestLanServerList(uint c_iApp, ISteamMatchmakingServerListResponse c_pRequestServersResponse);
        public abstract uint RequestFriendsServerList(uint c_iApp, IntPtr[] c_ppchFilters, ISteamMatchmakingServerListResponse c_pRequestServersResponse);
        public abstract uint RequestFavoritesServerList(uint c_iApp, IntPtr[] c_ppchFilters, ISteamMatchmakingServerListResponse c_pRequestServersResponse);
        public abstract uint RequestHistoryServerList(uint c_iApp, IntPtr[] c_ppchFilters, ISteamMatchmakingServerListResponse c_pRequestServersResponse);
        public abstract uint RequestSpectatorServerList(uint c_iApp, IntPtr[] c_ppchFilters, ISteamMatchmakingServerListResponse c_pRequestServersResponse);
        public abstract void ReleaseRequest(uint c_hServerListRequest);
        public abstract GameServerItem GetServerDetails(uint c_hRequest, int c_iServer);
        public abstract void CancelQuery(uint c_hRequest);
        public abstract void RefreshQuery(uint c_hRequest);
        public abstract bool IsRefreshing(uint c_hRequest);
        public abstract int GetServerCount(uint c_hRequest);
        public abstract void RefreshServer(uint c_hRequest, int c_iServer);
        public abstract uint PingServer(uint c_unIp, char c_usPort, ISteamMatchmakingPingResponse c_pRequestServersResponse);
        public abstract uint PlayerDetails(uint c_unIp, char c_usPort, ISteamMatchmakingPlayersResponse c_pRequestServersResponse);
        public abstract uint ServerRules(uint c_unIp, char c_usPort, ISteamMatchmakingRulesResponse c_pRequestServersResponse);
        public abstract void CancelServerQuery(uint c_hServerQuery);
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct GameServerItem
    {
        public ServerNetAdr NetAdr;

        public int Ping;

        [MarshalAs(UnmanagedType.I1)] public bool HadSuccessfulResponse;

        [MarshalAs(UnmanagedType.I1)] public bool DoNotRefresh;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)] public string GameDir; //char[32]

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)] public string Map; //char[32]

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)] public string GameDescription; //char[64]

        public uint AppId;

        public int Players;

        public int MaxPlayers;

        public int BotPlayers;

        [MarshalAs(UnmanagedType.I1)] public bool Password;

        [MarshalAs(UnmanagedType.I1)] public bool Secure;

        public uint TimeLastPlayed;

        public int ServerVersion;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)] public string ServerName; //char[64]

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)] public string GameTags; //char[128]

        public ulong SteamId;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ServerNetAdr
    {
        public char ConnectionPort;
        public char QueryPort;
        public uint Ip;
    }
}