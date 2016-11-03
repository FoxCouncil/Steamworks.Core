//   !!  // Steamworks.Core - SteamMatchmaking.cs
// *.-". // Created: 2016-10-19 [7:51 PM]
//  | |  // Copyright 2016 // MIT License // The Fox Council 
// Modified by: Fox Diller on 2016-10-22 @ 3:03 PM

#region Usings

using System;
using System.Runtime.InteropServices;

#endregion

namespace Steamworks.Core
{
    public class SteamMatchmaking : ISteamMatchmaking
    {
        private readonly IntPtr m_instancePtr;

        public SteamMatchmaking(IntPtr c_instancePtr)
        {
            m_instancePtr = c_instancePtr;
        }

        private void CheckIfUsable()
        {
            if (m_instancePtr == IntPtr.Zero)
            {
                throw new InvalidOperationException("Steam Matchmaking Not Initialized!");
            }
        }

        #region Native Methods

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMatchmaking_GetFavoriteGameCount")]
        private static extern int SteamAPI_ISteamMatchmaking_GetFavoriteGameCount(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMatchmaking_GetFavoriteGame")]
        private static extern bool SteamAPI_ISteamMatchmaking_GetFavoriteGame(IntPtr c_instancePtr, int c_iGame, ref uint c_pnAppId, ref uint c_pnIp, ref char c_pnConnPort, ref char c_pnQueryPort, ref uint c_punFlags, ref uint c_pRTime32LastPlayedOnServer);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMatchmaking_AddFavoriteGame")]
        private static extern int SteamAPI_ISteamMatchmaking_AddFavoriteGame(IntPtr c_instancePtr, uint c_nAppId, uint c_nIp, char c_nConnPort, char c_nQueryPort, uint c_unFlags, uint c_rTime32LastPlayedOnServer);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMatchmaking_RemoveFavoriteGame")]
        private static extern bool SteamAPI_ISteamMatchmaking_RemoveFavoriteGame(IntPtr c_instancePtr, uint c_nAppId, uint c_nIp, char c_nConnPort, char c_nQueryPort, uint c_unFlags);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMatchmaking_RequestLobbyList")]
        private static extern ulong SteamAPI_ISteamMatchmaking_RequestLobbyList(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMatchmaking_AddRequestLobbyListStringFilter")]
        private static extern void SteamAPI_ISteamMatchmaking_AddRequestLobbyListStringFilter(IntPtr c_instancePtr, SafeUtf8String c_pchKeyToMatch, SafeUtf8String c_pchValueToMatch, uint c_eComparisonType);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMatchmaking_AddRequestLobbyListNumericalFilter")]
        private static extern void SteamAPI_ISteamMatchmaking_AddRequestLobbyListNumericalFilter(IntPtr c_instancePtr, SafeUtf8String c_pchKeyToMatch, int c_nValueToMatch, uint c_eComparisonType);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMatchmaking_AddRequestLobbyListNearValueFilter")]
        private static extern void SteamAPI_ISteamMatchmaking_AddRequestLobbyListNearValueFilter(IntPtr c_instancePtr, SafeUtf8String c_pchKeyToMatch, int c_nValueToBeCloseTo);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMatchmaking_AddRequestLobbyListFilterSlotsAvailable")]
        private static extern void SteamAPI_ISteamMatchmaking_AddRequestLobbyListFilterSlotsAvailable(IntPtr c_instancePtr, int c_nSlotsAvailable);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMatchmaking_AddRequestLobbyListDistanceFilter")]
        private static extern void SteamAPI_ISteamMatchmaking_AddRequestLobbyListDistanceFilter(IntPtr c_instancePtr, uint c_eLobbyDistanceFilter);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMatchmaking_AddRequestLobbyListResultCountFilter")]
        private static extern void SteamAPI_ISteamMatchmaking_AddRequestLobbyListResultCountFilter(IntPtr c_instancePtr, int c_cMaxResults);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMatchmaking_AddRequestLobbyListCompatibleMembersFilter")]
        private static extern void SteamAPI_ISteamMatchmaking_AddRequestLobbyListCompatibleMembersFilter(IntPtr c_instancePtr, ulong c_steamIdLobby);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMatchmaking_GetLobbyByIndex")]
        private static extern ulong SteamAPI_ISteamMatchmaking_GetLobbyByIndex(IntPtr c_instancePtr, int c_iLobby);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMatchmaking_CreateLobby")]
        private static extern ulong SteamAPI_ISteamMatchmaking_CreateLobby(IntPtr c_instancePtr, uint c_eLobbyType, int c_cMaxMembers);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMatchmaking_JoinLobby")]
        private static extern ulong SteamAPI_ISteamMatchmaking_JoinLobby(IntPtr c_instancePtr, ulong c_steamIdLobby);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMatchmaking_LeaveLobby")]
        private static extern void SteamAPI_ISteamMatchmaking_LeaveLobby(IntPtr c_instancePtr, ulong c_steamIdLobby);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMatchmaking_InviteUserToLobby")]
        private static extern bool SteamAPI_ISteamMatchmaking_InviteUserToLobby(IntPtr c_instancePtr, ulong c_steamIdLobby, ulong c_steamIdInvitee);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMatchmaking_GetNumLobbyMembers")]
        private static extern int SteamAPI_ISteamMatchmaking_GetNumLobbyMembers(IntPtr c_instancePtr, ulong c_steamIdLobby);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMatchmaking_GetLobbyMemberByIndex")]
        private static extern ulong SteamAPI_ISteamMatchmaking_GetLobbyMemberByIndex(IntPtr c_instancePtr, ulong c_steamIdLobby, int c_iMember);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMatchmaking_GetLobbyData")]
        private static extern IntPtr SteamAPI_ISteamMatchmaking_GetLobbyData(IntPtr c_instancePtr, ulong c_steamIdLobby, SafeUtf8String c_pchKey);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMatchmaking_SetLobbyData")]
        private static extern bool SteamAPI_ISteamMatchmaking_SetLobbyData(IntPtr c_instancePtr, ulong c_steamIdLobby, SafeUtf8String c_pchKey, SafeUtf8String c_pchValue);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMatchmaking_GetLobbyDataCount")]
        private static extern int SteamAPI_ISteamMatchmaking_GetLobbyDataCount(IntPtr c_instancePtr, ulong c_steamIdLobby);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMatchmaking_GetLobbyDataByIndex")]
        private static extern bool SteamAPI_ISteamMatchmaking_GetLobbyDataByIndex(IntPtr c_instancePtr, ulong c_steamIdLobby, int c_iLobbyData, SafeUtf8String c_pchKey, int c_cchKeyBufferSize, SafeUtf8String c_pchValue, int c_cchValueBufferSize);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMatchmaking_DeleteLobbyData")]
        private static extern bool SteamAPI_ISteamMatchmaking_DeleteLobbyData(IntPtr c_instancePtr, ulong c_steamIdLobby, SafeUtf8String c_pchKey);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMatchmaking_GetLobbyMemberData")]
        private static extern IntPtr SteamAPI_ISteamMatchmaking_GetLobbyMemberData(IntPtr c_instancePtr, ulong c_steamIdLobby, ulong c_steamIdUser, SafeUtf8String c_pchKey);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMatchmaking_SetLobbyMemberData")]
        private static extern void SteamAPI_ISteamMatchmaking_SetLobbyMemberData(IntPtr c_instancePtr, ulong c_steamIdLobby, SafeUtf8String c_pchKey, SafeUtf8String c_pchValue);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMatchmaking_SendLobbyChatMsg")]
        private static extern bool SteamAPI_ISteamMatchmaking_SendLobbyChatMsg(IntPtr c_instancePtr, ulong c_steamIdLobby, IntPtr c_pvMsgBody, int c_cubMsgBody);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMatchmaking_GetLobbyChatEntry")]
        private static extern int SteamAPI_ISteamMatchmaking_GetLobbyChatEntry(IntPtr c_instancePtr, ulong c_steamIdLobby, int c_iChatId, ref CSteamId c_pSteamIdUser, IntPtr c_pvData, int c_cubData, ref uint c_peChatEntryType);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMatchmaking_RequestLobbyData")]
        private static extern bool SteamAPI_ISteamMatchmaking_RequestLobbyData(IntPtr c_instancePtr, ulong c_steamIdLobby);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMatchmaking_SetLobbyGameServer")]
        private static extern void SteamAPI_ISteamMatchmaking_SetLobbyGameServer(IntPtr c_instancePtr, ulong c_steamIdLobby, uint c_unGameServerIp, char c_unGameServerPort, ulong c_steamIdGameServer);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMatchmaking_GetLobbyGameServer")]
        private static extern bool SteamAPI_ISteamMatchmaking_GetLobbyGameServer(IntPtr c_instancePtr, ulong c_steamIdLobby, ref uint c_punGameServerIp, ref char c_punGameServerPort, ref CSteamId c_psteamIdGameServer);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMatchmaking_SetLobbyMemberLimit")]
        private static extern bool SteamAPI_ISteamMatchmaking_SetLobbyMemberLimit(IntPtr c_instancePtr, ulong c_steamIdLobby, int c_cMaxMembers);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMatchmaking_GetLobbyMemberLimit")]
        private static extern int SteamAPI_ISteamMatchmaking_GetLobbyMemberLimit(IntPtr c_instancePtr, ulong c_steamIdLobby);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMatchmaking_SetLobbyType")]
        private static extern bool SteamAPI_ISteamMatchmaking_SetLobbyType(IntPtr c_instancePtr, ulong c_steamIdLobby, uint c_eLobbyType);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMatchmaking_SetLobbyJoinable")]
        private static extern bool SteamAPI_ISteamMatchmaking_SetLobbyJoinable(IntPtr c_instancePtr, ulong c_steamIdLobby, bool c_bLobbyJoinable);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMatchmaking_GetLobbyOwner")]
        private static extern ulong SteamAPI_ISteamMatchmaking_GetLobbyOwner(IntPtr c_instancePtr, ulong c_steamIdLobby);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMatchmaking_SetLobbyOwner")]
        private static extern bool SteamAPI_ISteamMatchmaking_SetLobbyOwner(IntPtr c_instancePtr, ulong c_steamIdLobby, ulong c_steamIdNewOwner);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMatchmaking_SetLinkedLobby")]
        private static extern bool SteamAPI_ISteamMatchmaking_SetLinkedLobby(IntPtr c_instancePtr, ulong c_steamIdLobby, ulong c_steamIdLobbyDependent);

        #endregion

        #region Overrides of ISteamMatchmaking

        public override IntPtr GetIntPtr()
        {
            return m_instancePtr;
        }

        public override int GetFavoriteGameCount()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamMatchmaking_GetFavoriteGameCount(m_instancePtr);

            return a_result;
        }

        public override bool GetFavoriteGame(int c_iGame, ref uint c_pnAppId, ref uint c_pnIp, ref char c_pnConnPort, ref char c_pnQueryPort, ref uint c_punFlags, ref uint c_pRTime32LastPlayedOnServer)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamMatchmaking_GetFavoriteGame(m_instancePtr, c_iGame, ref c_pnAppId, ref c_pnIp, ref c_pnConnPort, ref c_pnQueryPort, ref c_punFlags, ref c_pRTime32LastPlayedOnServer);

            return a_result;
        }

        public override int AddFavoriteGame(uint c_nAppId, uint c_nIp, char c_nConnPort, char c_nQueryPort, uint c_unFlags, uint c_rTime32LastPlayedOnServer)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamMatchmaking_AddFavoriteGame(m_instancePtr, c_nAppId, c_nIp, c_nConnPort, c_nQueryPort, c_unFlags, c_rTime32LastPlayedOnServer);

            return a_result;
        }

        public override bool RemoveFavoriteGame(uint c_nAppId, uint c_nIp, char c_nConnPort, char c_nQueryPort, uint c_unFlags)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamMatchmaking_RemoveFavoriteGame(m_instancePtr, c_nAppId, c_nIp, c_nConnPort, c_nQueryPort, c_unFlags);

            return a_result;
        }

        public override ulong RequestLobbyList()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamMatchmaking_RequestLobbyList(m_instancePtr);

            return a_result;
        }

        public override void AddRequestLobbyListStringFilter(string c_pchKeyToMatch, string c_pchValueToMatch, uint c_eComparisonType)
        {
            CheckIfUsable();

            SteamAPI_ISteamMatchmaking_AddRequestLobbyListStringFilter(m_instancePtr, new SafeUtf8String(c_pchKeyToMatch), new SafeUtf8String(c_pchKeyToMatch), c_eComparisonType);
        }

        public override void AddRequestLobbyListNumericalFilter(string c_pchKeyToMatch, int c_nValueToMatch, uint c_eComparisonType)
        {
            CheckIfUsable();

            SteamAPI_ISteamMatchmaking_AddRequestLobbyListNumericalFilter(m_instancePtr, new SafeUtf8String(c_pchKeyToMatch), c_nValueToMatch, c_eComparisonType);
        }

        public override void AddRequestLobbyListNearValueFilter(string c_pchKeyToMatch, int c_nValueToBeCloseTo)
        {
            CheckIfUsable();

            SteamAPI_ISteamMatchmaking_AddRequestLobbyListNearValueFilter(m_instancePtr, new SafeUtf8String(c_pchKeyToMatch), c_nValueToBeCloseTo);
        }

        public override void AddRequestLobbyListFilterSlotsAvailable(int c_nSlotsAvailable)
        {
            CheckIfUsable();

            SteamAPI_ISteamMatchmaking_AddRequestLobbyListFilterSlotsAvailable(m_instancePtr, c_nSlotsAvailable);
        }

        public override void AddRequestLobbyListDistanceFilter(uint c_eLobbyDistanceFilter)
        {
            CheckIfUsable();

            SteamAPI_ISteamMatchmaking_AddRequestLobbyListDistanceFilter(m_instancePtr, c_eLobbyDistanceFilter);
        }

        public override void AddRequestLobbyListResultCountFilter(int c_cMaxResults)
        {
            CheckIfUsable();

            SteamAPI_ISteamMatchmaking_AddRequestLobbyListResultCountFilter(m_instancePtr, c_cMaxResults);
        }

        public override void AddRequestLobbyListCompatibleMembersFilter(ulong c_steamIdLobby)
        {
            CheckIfUsable();

            SteamAPI_ISteamMatchmaking_AddRequestLobbyListCompatibleMembersFilter(m_instancePtr, c_steamIdLobby);
        }

        public override ulong GetLobbyByIndex(int c_iLobby)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamMatchmaking_GetLobbyByIndex(m_instancePtr, c_iLobby);

            return a_result;
        }

        public override ulong CreateLobby(uint c_eLobbyType, int c_cMaxMembers)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamMatchmaking_CreateLobby(m_instancePtr, c_eLobbyType, c_cMaxMembers);

            return a_result;
        }

        public override ulong JoinLobby(ulong c_steamIdLobby)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamMatchmaking_JoinLobby(m_instancePtr, c_steamIdLobby);

            return a_result;
        }

        public override void LeaveLobby(ulong c_steamIdLobby)
        {
            CheckIfUsable();

            SteamAPI_ISteamMatchmaking_LeaveLobby(m_instancePtr, c_steamIdLobby);
        }

        public override bool InviteUserToLobby(ulong c_steamIdLobby, ulong c_steamIdInvitee)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamMatchmaking_InviteUserToLobby(m_instancePtr, c_steamIdLobby, c_steamIdInvitee);

            return a_result;
        }

        public override int GetNumLobbyMembers(ulong c_steamIdLobby)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamMatchmaking_GetNumLobbyMembers(m_instancePtr, c_steamIdLobby);

            return a_result;
        }

        public override ulong GetLobbyMemberByIndex(ulong c_steamIdLobby, int c_iMember)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamMatchmaking_GetLobbyMemberByIndex(m_instancePtr, c_steamIdLobby, c_iMember);

            return a_result;
        }

        public override string GetLobbyData(ulong c_steamIdLobby, string c_pchKey)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamMatchmaking_GetLobbyData(m_instancePtr, c_steamIdLobby, new SafeUtf8String(c_pchKey));

            return SafeUtf8String.ToString(a_result);
        }

        public override bool SetLobbyData(ulong c_steamIdLobby, string c_pchKey, string c_pchValue)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamMatchmaking_SetLobbyData(m_instancePtr, c_steamIdLobby, new SafeUtf8String(c_pchKey), new SafeUtf8String(c_pchValue));

            return a_result;
        }

        public override int GetLobbyDataCount(ulong c_steamIdLobby)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamMatchmaking_GetLobbyDataCount(m_instancePtr, c_steamIdLobby);

            return a_result;
        }

        public override bool GetLobbyDataByIndex(ulong c_steamIdLobby, int c_iLobbyData, string c_pchKey, int c_cchKeyBufferSize, string c_pchValue, int c_cchValueBufferSize)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamMatchmaking_GetLobbyDataByIndex(m_instancePtr, c_steamIdLobby, c_iLobbyData, new SafeUtf8String(c_pchKey), c_cchKeyBufferSize, new SafeUtf8String(c_pchValue), c_cchValueBufferSize);

            return a_result;
        }

        public override bool DeleteLobbyData(ulong c_steamIdLobby, string c_pchKey)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamMatchmaking_DeleteLobbyData(m_instancePtr, c_steamIdLobby, new SafeUtf8String(c_pchKey));

            return a_result;
        }

        public override string GetLobbyMemberData(ulong c_steamIdLobby, ulong c_steamIdUser, string c_pchKey)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamMatchmaking_GetLobbyMemberData(m_instancePtr, c_steamIdLobby, c_steamIdUser, new SafeUtf8String(c_pchKey));

            return SafeUtf8String.ToString(a_result);
        }

        public override void SetLobbyMemberData(ulong c_steamIdLobby, string c_pchKey, string c_pchValue)
        {
            CheckIfUsable();

            SteamAPI_ISteamMatchmaking_SetLobbyMemberData(m_instancePtr, c_steamIdLobby, new SafeUtf8String(c_pchKey), new SafeUtf8String(c_pchValue));
        }

        public override bool SendLobbyChatMsg(ulong c_steamIdLobby, IntPtr c_pvMsgBody, int c_cubMsgBody)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamMatchmaking_SendLobbyChatMsg(m_instancePtr, c_steamIdLobby, c_pvMsgBody, c_cubMsgBody);

            return a_result;
        }

        public override int GetLobbyChatEntry(ulong c_steamIdLobby, int c_iChatId, out CSteamId c_pSteamIdUser, IntPtr c_pvData, int c_cubData, ref uint c_peChatEntryType)
        {
            CheckIfUsable();

            c_pSteamIdUser = new CSteamId();

            var a_result = SteamAPI_ISteamMatchmaking_GetLobbyChatEntry(m_instancePtr, c_steamIdLobby, c_iChatId, ref c_pSteamIdUser, c_pvData, c_cubData, ref c_peChatEntryType);

            return a_result;
        }

        public override bool RequestLobbyData(ulong c_steamIdLobby)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamMatchmaking_RequestLobbyData(m_instancePtr, c_steamIdLobby);

            return a_result;
        }

        public override void SetLobbyGameServer(ulong c_steamIdLobby, uint c_unGameServerIp, char c_unGameServerPort, ulong c_steamIdGameServer)
        {
            CheckIfUsable();

            SteamAPI_ISteamMatchmaking_SetLobbyGameServer(m_instancePtr, c_steamIdLobby, c_unGameServerIp, c_unGameServerPort, c_steamIdGameServer);
        }

        public override bool GetLobbyGameServer(ulong c_steamIdLobby, ref uint c_punGameServerIp, ref char c_punGameServerPort, out CSteamId c_psteamIdGameServer)
        {
            CheckIfUsable();

            c_psteamIdGameServer = new CSteamId();

            var a_result = SteamAPI_ISteamMatchmaking_GetLobbyGameServer(m_instancePtr, c_steamIdLobby, ref c_punGameServerIp, ref c_punGameServerPort, ref c_psteamIdGameServer);

            return a_result;
        }

        public override bool SetLobbyMemberLimit(ulong c_steamIdLobby, int c_cMaxMembers)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamMatchmaking_SetLobbyMemberLimit(m_instancePtr, c_steamIdLobby, c_cMaxMembers);

            return a_result;
        }

        public override int GetLobbyMemberLimit(ulong c_steamIdLobby)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamMatchmaking_GetLobbyMemberLimit(m_instancePtr, c_steamIdLobby);

            return a_result;
        }

        public override bool SetLobbyType(ulong c_steamIdLobby, uint c_eLobbyType)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamMatchmaking_SetLobbyType(m_instancePtr, c_steamIdLobby, c_eLobbyType);

            return a_result;
        }

        public override bool SetLobbyJoinable(ulong c_steamIdLobby, bool c_bLobbyJoinable)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamMatchmaking_SetLobbyJoinable(m_instancePtr, c_steamIdLobby, c_bLobbyJoinable);

            return a_result;
        }

        public override ulong GetLobbyOwner(ulong c_steamIdLobby)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamMatchmaking_GetLobbyOwner(m_instancePtr, c_steamIdLobby);

            return a_result;
        }

        public override bool SetLobbyOwner(ulong c_steamIdLobby, ulong c_steamIdNewOwner)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamMatchmaking_SetLobbyOwner(m_instancePtr, c_steamIdLobby, c_steamIdNewOwner);

            return a_result;
        }

        public override bool SetLinkedLobby(ulong c_steamIdLobby, ulong c_steamIdLobbyDependent)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamMatchmaking_SetLinkedLobby(m_instancePtr, c_steamIdLobby, c_steamIdLobbyDependent);

            return a_result;
        }

        #endregion
    }

    public abstract class ISteamMatchmaking
    {
        public abstract IntPtr GetIntPtr();
        public abstract int GetFavoriteGameCount();
        public abstract bool GetFavoriteGame(int c_iGame, ref uint c_pnAppId, ref uint c_pnIp, ref char c_pnConnPort, ref char c_pnQueryPort, ref uint c_punFlags, ref uint c_pRTime32LastPlayedOnServer);
        public abstract int AddFavoriteGame(uint c_nAppId, uint c_nIp, char c_nConnPort, char c_nQueryPort, uint c_unFlags, uint c_rTime32LastPlayedOnServer);
        public abstract bool RemoveFavoriteGame(uint c_nAppId, uint c_nIp, char c_nConnPort, char c_nQueryPort, uint c_unFlags);
        public abstract ulong RequestLobbyList();
        public abstract void AddRequestLobbyListStringFilter(string c_pchKeyToMatch, string c_pchValueToMatch, uint c_eComparisonType);
        public abstract void AddRequestLobbyListNumericalFilter(string c_pchKeyToMatch, int c_nValueToMatch, uint c_eComparisonType);
        public abstract void AddRequestLobbyListNearValueFilter(string c_pchKeyToMatch, int c_nValueToBeCloseTo);
        public abstract void AddRequestLobbyListFilterSlotsAvailable(int c_nSlotsAvailable);
        public abstract void AddRequestLobbyListDistanceFilter(uint c_eLobbyDistanceFilter);
        public abstract void AddRequestLobbyListResultCountFilter(int c_cMaxResults);
        public abstract void AddRequestLobbyListCompatibleMembersFilter(ulong c_steamIdLobby);
        public abstract ulong GetLobbyByIndex(int c_iLobby);
        public abstract ulong CreateLobby(uint c_eLobbyType, int c_cMaxMembers);
        public abstract ulong JoinLobby(ulong c_steamIdLobby);
        public abstract void LeaveLobby(ulong c_steamIdLobby);
        public abstract bool InviteUserToLobby(ulong c_steamIdLobby, ulong c_steamIdInvitee);
        public abstract int GetNumLobbyMembers(ulong c_steamIdLobby);
        public abstract ulong GetLobbyMemberByIndex(ulong c_steamIdLobby, int c_iMember);
        public abstract string GetLobbyData(ulong c_steamIdLobby, string c_pchKey);
        public abstract bool SetLobbyData(ulong c_steamIdLobby, string c_pchKey, string c_pchValue);
        public abstract int GetLobbyDataCount(ulong c_steamIdLobby);
        public abstract bool GetLobbyDataByIndex(ulong c_steamIdLobby, int c_iLobbyData, string c_pchKey, int c_cchKeyBufferSize, string c_pchValue, int c_cchValueBufferSize);
        public abstract bool DeleteLobbyData(ulong c_steamIdLobby, string c_pchKey);
        public abstract string GetLobbyMemberData(ulong c_steamIdLobby, ulong c_steamIdUser, string c_pchKey);
        public abstract void SetLobbyMemberData(ulong c_steamIdLobby, string c_pchKey, string c_pchValue);
        public abstract bool SendLobbyChatMsg(ulong c_steamIdLobby, IntPtr c_pvMsgBody, int c_cubMsgBody);
        public abstract int GetLobbyChatEntry(ulong c_steamIdLobby, int c_iChatId, out CSteamId c_pSteamIdUser, IntPtr c_pvData, int c_cubData, ref uint c_peChatEntryType);
        public abstract bool RequestLobbyData(ulong c_steamIdLobby);
        public abstract void SetLobbyGameServer(ulong c_steamIdLobby, uint c_unGameServerIp, char c_unGameServerPort, ulong c_steamIdGameServer);
        public abstract bool GetLobbyGameServer(ulong c_steamIdLobby, ref uint c_punGameServerIp, ref char c_punGameServerPort, out CSteamId c_psteamIdGameServer);
        public abstract bool SetLobbyMemberLimit(ulong c_steamIdLobby, int c_cMaxMembers);
        public abstract int GetLobbyMemberLimit(ulong c_steamIdLobby);
        public abstract bool SetLobbyType(ulong c_steamIdLobby, uint c_eLobbyType);
        public abstract bool SetLobbyJoinable(ulong c_steamIdLobby, bool c_bLobbyJoinable);
        public abstract ulong GetLobbyOwner(ulong c_steamIdLobby);
        public abstract bool SetLobbyOwner(ulong c_steamIdLobby, ulong c_steamIdNewOwner);
        public abstract bool SetLinkedLobby(ulong c_steamIdLobby, ulong c_steamIdLobbyDependent);
    }
}