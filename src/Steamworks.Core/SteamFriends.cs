using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Steamworks.Core
{
    public class SteamFriends : ISteamFriends
    {
        private readonly IntPtr m_instancePtr;

        public SteamFriends(IntPtr c_instancePtr)
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

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamFriends_GetPersonaName")]
        internal static extern IntPtr SteamAPI_ISteamFriends_GetPersonaName(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamFriends_SetPersonaName")]
        internal static extern ulong SteamAPI_ISteamFriends_SetPersonaName(IntPtr c_instancePtr, SafeUtf8String c_pchPersonaName);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamFriends_GetPersonaState")]
        internal static extern uint SteamAPI_ISteamFriends_GetPersonaState(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamFriends_GetFriendCount")]
        internal static extern int SteamAPI_ISteamFriends_GetFriendCount(IntPtr c_instancePtr, int c_iFriendFlags);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamFriends_GetFriendByIndex")]
        internal static extern ulong SteamAPI_ISteamFriends_GetFriendByIndex(IntPtr c_instancePtr, int c_iFriend, int c_iFriendFlags);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamFriends_GetFriendRelationship")]
        internal static extern uint SteamAPI_ISteamFriends_GetFriendRelationship(IntPtr c_instancePtr, ulong c_steamIdFriend);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamFriends_GetFriendPersonaState")]
        internal static extern uint SteamAPI_ISteamFriends_GetFriendPersonaState(IntPtr c_instancePtr, ulong c_steamIdFriend);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamFriends_GetFriendPersonaName")]
        internal static extern IntPtr SteamAPI_ISteamFriends_GetFriendPersonaName(IntPtr c_instancePtr, ulong c_steamIdFriend);
        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamFriends_GetFriendGamePlayed")]
        internal static extern bool SteamAPI_ISteamFriends_GetFriendGamePlayed(IntPtr c_instancePtr, ulong c_steamIdFriend, ref FriendGameInfo c_pFriendGameInfo);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamFriends_GetFriendPersonaNameHistory")]
        internal static extern IntPtr SteamAPI_ISteamFriends_GetFriendPersonaNameHistory(IntPtr c_instancePtr, ulong c_steamIdFriend, int c_iPersonaName);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamFriends_GetFriendSteamLevel")]
        internal static extern int SteamAPI_ISteamFriends_GetFriendSteamLevel(IntPtr c_instancePtr, ulong c_steamIdFriend);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamFriends_GetPlayerNickname")]
        internal static extern IntPtr SteamAPI_ISteamFriends_GetPlayerNickname(IntPtr c_instancePtr, ulong c_steamIdPlayer);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamFriends_GetFriendsGroupCount")]
        internal static extern int SteamAPI_ISteamFriends_GetFriendsGroupCount(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamFriends_GetFriendsGroupIDByIndex")]
        internal static extern char SteamAPI_ISteamFriends_GetFriendsGroupIDByIndex(IntPtr c_instancePtr, int c_iFg);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamFriends_GetFriendsGroupName")]
        internal static extern IntPtr SteamAPI_ISteamFriends_GetFriendsGroupName(IntPtr c_instancePtr, char c_friendsGroupId);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamFriends_GetFriendsGroupMembersCount")]
        internal static extern int SteamAPI_ISteamFriends_GetFriendsGroupMembersCount(IntPtr c_instancePtr, char c_friendsGroupId);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamFriends_GetFriendsGroupMembersList")]
        internal static extern void SteamAPI_ISteamFriends_GetFriendsGroupMembersList(IntPtr c_instancePtr, char c_friendsGroupId, [In, Out] CSteamId[] c_pOutSteamIdMembers, int c_nMembersCount);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamFriends_HasFriend")]
        internal static extern bool SteamAPI_ISteamFriends_HasFriend(IntPtr c_instancePtr, ulong c_steamIdFriend, int c_iFriendFlags);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamFriends_GetClanCount")]
        internal static extern int SteamAPI_ISteamFriends_GetClanCount(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamFriends_GetClanByIndex")]
        internal static extern ulong SteamAPI_ISteamFriends_GetClanByIndex(IntPtr c_instancePtr, int c_iClan);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamFriends_GetClanName")]
        internal static extern IntPtr SteamAPI_ISteamFriends_GetClanName(IntPtr c_instancePtr, ulong c_steamIdClan);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamFriends_GetClanTag")]
        internal static extern IntPtr SteamAPI_ISteamFriends_GetClanTag(IntPtr c_instancePtr, ulong c_steamIdClan);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamFriends_GetClanActivityCounts")]
        internal static extern bool SteamAPI_ISteamFriends_GetClanActivityCounts(IntPtr c_instancePtr, ulong c_steamIdClan, ref int c_pnOnline, ref int c_pnInGame, ref int c_pnChatting);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamFriends_DownloadClanActivityCounts")]
        internal static extern ulong SteamAPI_ISteamFriends_DownloadClanActivityCounts(IntPtr c_instancePtr, [In, Out] CSteamId[] c_psteamIdClans, int c_cClansToRequest);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamFriends_GetFriendCountFromSource")]
        internal static extern int SteamAPI_ISteamFriends_GetFriendCountFromSource(IntPtr c_instancePtr, ulong c_steamIdSource);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamFriends_GetFriendFromSourceByIndex")]
        internal static extern ulong SteamAPI_ISteamFriends_GetFriendFromSourceByIndex(IntPtr c_instancePtr, ulong c_steamIdSource, int c_iFriend);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamFriends_IsUserInSource")]
        internal static extern bool SteamAPI_ISteamFriends_IsUserInSource(IntPtr c_instancePtr, ulong c_steamIdUser, ulong c_steamIdSource);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamFriends_SetInGameVoiceSpeaking")]
        internal static extern void SteamAPI_ISteamFriends_SetInGameVoiceSpeaking(IntPtr c_instancePtr, ulong c_steamIdUser, bool c_bSpeaking);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamFriends_ActivateGameOverlay")]
        internal static extern void SteamAPI_ISteamFriends_ActivateGameOverlay(IntPtr c_instancePtr, SafeUtf8String c_pchDialog);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamFriends_ActivateGameOverlayToUser")]
        internal static extern void SteamAPI_ISteamFriends_ActivateGameOverlayToUser(IntPtr c_instancePtr, SafeUtf8String c_pchDialog, ulong c_steamId);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamFriends_ActivateGameOverlayToWebPage")]
        internal static extern void SteamAPI_ISteamFriends_ActivateGameOverlayToWebPage(IntPtr c_instancePtr, SafeUtf8String c_pchUrl);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamFriends_ActivateGameOverlayToStore")]
        internal static extern void SteamAPI_ISteamFriends_ActivateGameOverlayToStore(IntPtr c_instancePtr, uint c_nAppId, char c_eFlag);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamFriends_SetPlayedWith")]
        internal static extern void SteamAPI_ISteamFriends_SetPlayedWith(IntPtr c_instancePtr, ulong c_steamIdUserPlayedWith);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamFriends_ActivateGameOverlayInviteDialog")]
        internal static extern void SteamAPI_ISteamFriends_ActivateGameOverlayInviteDialog(IntPtr c_instancePtr, ulong c_steamIdLobby);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamFriends_GetSmallFriendAvatar")]
        internal static extern int SteamAPI_ISteamFriends_GetSmallFriendAvatar(IntPtr c_instancePtr, ulong c_steamIdFriend);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamFriends_GetMediumFriendAvatar")]
        internal static extern int SteamAPI_ISteamFriends_GetMediumFriendAvatar(IntPtr c_instancePtr, ulong c_steamIdFriend);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamFriends_GetLargeFriendAvatar")]
        internal static extern int SteamAPI_ISteamFriends_GetLargeFriendAvatar(IntPtr c_instancePtr, ulong c_steamIdFriend);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamFriends_RequestUserInformation")]
        internal static extern bool SteamAPI_ISteamFriends_RequestUserInformation(IntPtr c_instancePtr, ulong c_steamIdUser, bool c_bRequireNameOnly);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamFriends_RequestClanOfficerList")]
        internal static extern ulong SteamAPI_ISteamFriends_RequestClanOfficerList(IntPtr c_instancePtr, ulong c_steamIdClan);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamFriends_GetClanOwner")]
        internal static extern ulong SteamAPI_ISteamFriends_GetClanOwner(IntPtr c_instancePtr, ulong c_steamIdClan);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamFriends_GetClanOfficerCount")]
        internal static extern int SteamAPI_ISteamFriends_GetClanOfficerCount(IntPtr c_instancePtr, ulong c_steamIdClan);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamFriends_GetClanOfficerByIndex")]
        internal static extern ulong SteamAPI_ISteamFriends_GetClanOfficerByIndex(IntPtr c_instancePtr, ulong c_steamIdClan, int c_iOfficer);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamFriends_GetUserRestrictions")]
        internal static extern uint SteamAPI_ISteamFriends_GetUserRestrictions(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamFriends_SetRichPresence")]
        internal static extern bool SteamAPI_ISteamFriends_SetRichPresence(IntPtr c_instancePtr, SafeUtf8String c_pchKey, SafeUtf8String c_pchValue);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamFriends_ClearRichPresence")]
        internal static extern void SteamAPI_ISteamFriends_ClearRichPresence(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamFriends_GetFriendRichPresence")]
        internal static extern IntPtr SteamAPI_ISteamFriends_GetFriendRichPresence(IntPtr c_instancePtr, ulong c_steamIdFriend, SafeUtf8String c_pchKey);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamFriends_GetFriendRichPresenceKeyCount")]
        internal static extern int SteamAPI_ISteamFriends_GetFriendRichPresenceKeyCount(IntPtr c_instancePtr, ulong c_steamIdFriend);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamFriends_GetFriendRichPresenceKeyByIndex")]
        internal static extern IntPtr SteamAPI_ISteamFriends_GetFriendRichPresenceKeyByIndex(IntPtr c_instancePtr, ulong c_steamIdFriend, int c_iKey);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamFriends_RequestFriendRichPresence")]
        internal static extern void SteamAPI_ISteamFriends_RequestFriendRichPresence(IntPtr c_instancePtr, ulong c_steamIdFriend);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamFriends_InviteUserToGame")]
        internal static extern bool SteamAPI_ISteamFriends_InviteUserToGame(IntPtr c_instancePtr, ulong c_steamIdFriend, SafeUtf8String c_pchConnectSafeUtf8String);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamFriends_GetCoplayFriendCount")]
        internal static extern int SteamAPI_ISteamFriends_GetCoplayFriendCount(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamFriends_GetCoplayFriend")]
        internal static extern ulong SteamAPI_ISteamFriends_GetCoplayFriend(IntPtr c_instancePtr, int c_iCoplayFriend);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamFriends_GetFriendCoplayTime")]
        internal static extern int SteamAPI_ISteamFriends_GetFriendCoplayTime(IntPtr c_instancePtr, ulong c_steamIdFriend);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamFriends_GetFriendCoplayGame")]
        internal static extern uint SteamAPI_ISteamFriends_GetFriendCoplayGame(IntPtr c_instancePtr, ulong c_steamIdFriend);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamFriends_JoinClanChatRoom")]
        internal static extern ulong SteamAPI_ISteamFriends_JoinClanChatRoom(IntPtr c_instancePtr, ulong c_steamIdClan);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamFriends_LeaveClanChatRoom")]
        internal static extern bool SteamAPI_ISteamFriends_LeaveClanChatRoom(IntPtr c_instancePtr, ulong c_steamIdClan);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamFriends_GetClanChatMemberCount")]
        internal static extern int SteamAPI_ISteamFriends_GetClanChatMemberCount(IntPtr c_instancePtr, ulong c_steamIdClan);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamFriends_GetChatMemberByIndex")]
        internal static extern ulong SteamAPI_ISteamFriends_GetChatMemberByIndex(IntPtr c_instancePtr, ulong c_steamIdClan, int c_iUser);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamFriends_SendClanChatMessage")]
        internal static extern bool SteamAPI_ISteamFriends_SendClanChatMessage(IntPtr c_instancePtr, ulong c_steamIdClanChat, SafeUtf8String c_pchText);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamFriends_GetClanChatMessage")]
        internal static extern int SteamAPI_ISteamFriends_GetClanChatMessage(IntPtr c_instancePtr, ulong c_steamIdClanChat, int c_iMessage, IntPtr c_prgchText, int c_cchTextMax, ref uint c_peChatEntryType, ref CSteamId c_psteamidChatter);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamFriends_IsClanChatAdmin")]
        internal static extern bool SteamAPI_ISteamFriends_IsClanChatAdmin(IntPtr c_instancePtr, ulong c_steamIdClanChat, ulong c_steamIdUser);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamFriends_IsClanChatWindowOpenInSteam")]
        internal static extern bool SteamAPI_ISteamFriends_IsClanChatWindowOpenInSteam(IntPtr c_instancePtr, ulong c_steamIdClanChat);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamFriends_OpenClanChatWindowInSteam")]
        internal static extern bool SteamAPI_ISteamFriends_OpenClanChatWindowInSteam(IntPtr c_instancePtr, ulong c_steamIdClanChat);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamFriends_CloseClanChatWindowInSteam")]
        internal static extern bool SteamAPI_ISteamFriends_CloseClanChatWindowInSteam(IntPtr c_instancePtr, ulong c_steamIdClanChat);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamFriends_SetListenForFriendsMessages")]
        internal static extern bool SteamAPI_ISteamFriends_SetListenForFriendsMessages(IntPtr c_instancePtr, bool c_bInterceptEnabled);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamFriends_ReplyToFriendMessage")]
        internal static extern bool SteamAPI_ISteamFriends_ReplyToFriendMessage(IntPtr c_instancePtr, ulong c_steamIdFriend, SafeUtf8String c_pchMsgToSend);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamFriends_GetFriendMessage")]
        internal static extern int SteamAPI_ISteamFriends_GetFriendMessage(IntPtr c_instancePtr, ulong c_steamIdFriend, int c_iMessageId, IntPtr c_pvData, int c_cubData, ref uint c_peChatEntryType);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamFriends_GetFollowerCount")]
        internal static extern ulong SteamAPI_ISteamFriends_GetFollowerCount(IntPtr c_instancePtr, ulong c_steamId);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamFriends_IsFollowing")]
        internal static extern ulong SteamAPI_ISteamFriends_IsFollowing(IntPtr c_instancePtr, ulong c_steamId);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamFriends_EnumerateFollowingList")]
        internal static extern ulong SteamAPI_ISteamFriends_EnumerateFollowingList(IntPtr c_instancePtr, uint c_unStartIndex);

        #endregion

        #region Overrides of ISteamFriends

        public override IntPtr GetIntPtr()
        {
            return m_instancePtr;
        }

        public override string GetPersonaName()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamFriends_GetPersonaName(m_instancePtr);

            return SafeUtf8String.ToString(a_result);
        }

        public override ulong SetPersonaName(string c_pchPersonaName)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamFriends_SetPersonaName(m_instancePtr, new SafeUtf8String(c_pchPersonaName));

            return a_result;
        }

        public override uint GetPersonaState()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamFriends_GetPersonaState(m_instancePtr);

            return a_result;
        }

        public override int GetFriendCount(int c_iFriendFlags)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamFriends_GetFriendCount(m_instancePtr, c_iFriendFlags);

            return a_result;
        }

        public override ulong GetFriendByIndex(int c_iFriend, int c_iFriendFlags)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamFriends_GetFriendByIndex(m_instancePtr, c_iFriend, c_iFriendFlags);

            return a_result;
        }

        public override uint GetFriendRelationship(ulong c_steamIdFriend)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamFriends_GetFriendRelationship(m_instancePtr, c_steamIdFriend);

            return a_result;
        }

        public override uint GetFriendPersonaState(ulong c_steamIdFriend)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamFriends_GetFriendPersonaState(m_instancePtr, c_steamIdFriend);

            return a_result;
        }

        public override string GetFriendPersonaName(ulong c_steamIdFriend)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamFriends_GetFriendPersonaName(m_instancePtr, c_steamIdFriend);

            return SafeUtf8String.ToString(a_result);
        }

        public override bool GetFriendGamePlayed(ulong c_steamIdFriend, out FriendGameInfo c_pFriendGameInfo)
        {
            CheckIfUsable();

            c_pFriendGameInfo = default(FriendGameInfo);

            var a_result = SteamAPI_ISteamFriends_GetFriendGamePlayed(m_instancePtr, c_steamIdFriend, ref c_pFriendGameInfo);

            return a_result;
        }

        public override string GetFriendPersonaNameHistory(ulong c_steamIdFriend, int c_iPersonaName)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamFriends_GetFriendPersonaNameHistory(m_instancePtr, c_steamIdFriend, c_iPersonaName);

            return SafeUtf8String.ToString(a_result);
        }

        public override int GetFriendSteamLevel(ulong c_steamIdFriend)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamFriends_GetFriendSteamLevel(m_instancePtr, c_steamIdFriend);

            return a_result;
        }

        public override string GetPlayerNickname(ulong c_steamIdPlayer)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamFriends_GetPlayerNickname(m_instancePtr, c_steamIdPlayer);

            return SafeUtf8String.ToString(a_result);
        }

        public override int GetFriendsGroupCount()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamFriends_GetFriendsGroupCount(m_instancePtr);

            return a_result;
        }

        public override char GetFriendsGroupIdByIndex(int c_iFg)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamFriends_GetFriendsGroupIDByIndex(m_instancePtr, c_iFg);

            return a_result;
        }

        public override string GetFriendsGroupName(char c_friendsGroupId)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamFriends_GetFriendsGroupName(m_instancePtr, c_friendsGroupId);

            return SafeUtf8String.ToString(a_result);
        }

        public override int GetFriendsGroupMembersCount(char c_friendsGroupId)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamFriends_GetFriendsGroupMembersCount(m_instancePtr, c_friendsGroupId);

            return a_result;
        }

        public override void GetFriendsGroupMembersList(char c_friendsGroupId, out CSteamId[] c_cSteamIds, int c_nMembersCount)
        {
            CheckIfUsable();

            c_cSteamIds = new CSteamId[c_nMembersCount];

            SteamAPI_ISteamFriends_GetFriendsGroupMembersList(m_instancePtr, c_friendsGroupId, c_cSteamIds, c_nMembersCount);
        }

        public override bool HasFriend(ulong c_steamIdFriend, int c_iFriendFlags)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamFriends_HasFriend(m_instancePtr, c_steamIdFriend, c_iFriendFlags);

            return a_result;
        }

        public override int GetClanCount()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamFriends_GetClanCount(m_instancePtr);

            return a_result;
        }

        public override ulong GetClanByIndex(int c_iClan)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamFriends_GetClanByIndex(m_instancePtr, c_iClan);

            return a_result;
        }

        public override string GetClanName(ulong c_steamIdClan)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamFriends_GetClanName(m_instancePtr, c_steamIdClan);

            return SafeUtf8String.ToString(a_result);
        }

        public override string GetClanTag(ulong c_steamIdClan)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamFriends_GetClanTag(m_instancePtr, c_steamIdClan);

            return SafeUtf8String.ToString(a_result);
        }

        public override bool GetClanActivityCounts(ulong c_steamIdClan, ref int c_pnOnline, ref int c_pnInGame, ref int c_pnChatting)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamFriends_GetClanActivityCounts(m_instancePtr, c_steamIdClan, ref c_pnOnline, ref c_pnInGame, ref c_pnChatting);

            return a_result;
        }

        public override ulong DownloadClanActivityCounts(CSteamId[] c_psteamIdClans)
        {
            throw new NotImplementedException("TODO FIXME");
            //CheckIfUsable();

            //var a_result = SteamAPI_ISteamFriends_DownloadClanActivityCounts(m_instancePtr, c_psteamIdClans);

            //return a_result;
        }

        public override int GetFriendCountFromSource(ulong c_steamIdSource)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamFriends_GetFriendCountFromSource(m_instancePtr, c_steamIdSource);

            return a_result;
        }

        public override ulong GetFriendFromSourceByIndex(ulong c_steamIdSource, int c_iFriend)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamFriends_GetFriendFromSourceByIndex(m_instancePtr, c_steamIdSource, c_iFriend);

            return a_result;
        }

        public override bool IsUserInSource(ulong c_steamIdUser, ulong c_steamIdSource)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamFriends_IsUserInSource(m_instancePtr, c_steamIdUser, c_steamIdSource);

            return a_result;
        }

        public override void SetInGameVoiceSpeaking(ulong c_steamIdUser, bool c_bSpeaking)
        {
            CheckIfUsable();

            SteamAPI_ISteamFriends_SetInGameVoiceSpeaking(m_instancePtr, c_steamIdUser, c_bSpeaking);
        }

        public override void ActivateGameOverlay(string c_pchDialog)
        {
            CheckIfUsable();

            SteamAPI_ISteamFriends_ActivateGameOverlay(m_instancePtr, new SafeUtf8String(c_pchDialog));
        }

        public override void ActivateGameOverlayToUser(string c_pchDialog, ulong c_steamId)
        {
            CheckIfUsable();

            SteamAPI_ISteamFriends_ActivateGameOverlayToUser(m_instancePtr, new SafeUtf8String(c_pchDialog), c_steamId);
        }

        public override void ActivateGameOverlayToWebPage(string c_pchUrl)
        {
            CheckIfUsable();

            SteamAPI_ISteamFriends_ActivateGameOverlayToWebPage(m_instancePtr, new SafeUtf8String(c_pchUrl));
        }

        public override void ActivateGameOverlayToStore(uint c_nAppId, char c_eFlag)
        {
            CheckIfUsable();

            SteamAPI_ISteamFriends_ActivateGameOverlayToStore(m_instancePtr, c_nAppId, c_eFlag);
        }

        public override void SetPlayedWith(ulong c_steamIdUserPlayedWith)
        {
            CheckIfUsable();

            SteamAPI_ISteamFriends_SetPlayedWith(m_instancePtr, c_steamIdUserPlayedWith);
        }

        public override void ActivateGameOverlayInviteDialog(ulong c_steamIdLobby)
        {
            CheckIfUsable();

            SteamAPI_ISteamFriends_ActivateGameOverlayInviteDialog(m_instancePtr, c_steamIdLobby);
        }

        public override int GetSmallFriendAvatar(ulong c_steamIdFriend)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamFriends_GetSmallFriendAvatar(m_instancePtr, c_steamIdFriend);

            return a_result;
        }

        public override int GetMediumFriendAvatar(ulong c_steamIdFriend)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamFriends_GetMediumFriendAvatar(m_instancePtr, c_steamIdFriend);

            return a_result;
        }

        public override int GetLargeFriendAvatar(ulong c_steamIdFriend)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamFriends_GetLargeFriendAvatar(m_instancePtr, c_steamIdFriend);

            return a_result;
        }

        public override bool RequestUserInformation(ulong c_steamIdUser, bool c_bRequireNameOnly)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamFriends_RequestUserInformation(m_instancePtr, c_steamIdUser, c_bRequireNameOnly);

            return a_result;
        }

        public override ulong RequestClanOfficerList(ulong c_steamIdClan)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamFriends_RequestClanOfficerList(m_instancePtr, c_steamIdClan);

            return a_result;
        }

        public override ulong GetClanOwner(ulong c_steamIdClan)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamFriends_GetClanOwner(m_instancePtr, c_steamIdClan);

            return a_result;
        }

        public override int GetClanOfficerCount(ulong c_steamIdClan)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamFriends_GetClanOfficerCount(m_instancePtr, c_steamIdClan);

            return a_result;
        }

        public override ulong GetClanOfficerByIndex(ulong c_steamIdClan, int c_iOfficer)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamFriends_GetClanOfficerByIndex(m_instancePtr, c_steamIdClan, c_iOfficer);

            return a_result;
        }

        public override uint GetUserRestrictions()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamFriends_GetUserRestrictions(m_instancePtr);

            return a_result;
        }

        public override bool SetRichPresence(string c_pchKey, string c_pchValue)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamFriends_SetRichPresence(m_instancePtr, new SafeUtf8String(c_pchKey), new SafeUtf8String(c_pchValue));

            return a_result;
        }

        public override void ClearRichPresence()
        {
            CheckIfUsable();

            SteamAPI_ISteamFriends_ClearRichPresence(m_instancePtr);
        }

        public override string GetFriendRichPresence(ulong c_steamIdFriend, string c_pchKey)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamFriends_GetFriendRichPresence(m_instancePtr, c_steamIdFriend, new SafeUtf8String(c_pchKey));

            return SafeUtf8String.ToString(a_result);
        }

        public override int GetFriendRichPresenceKeyCount(ulong c_steamIdFriend)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamFriends_GetFriendRichPresenceKeyCount(m_instancePtr, c_steamIdFriend);

            return a_result;
        }

        public override string GetFriendRichPresenceKeyByIndex(ulong c_steamIdFriend, int c_iKey)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamFriends_GetFriendRichPresenceKeyByIndex(m_instancePtr, c_steamIdFriend, c_iKey);

            return SafeUtf8String.ToString(a_result);
        }

        public override void RequestFriendRichPresence(ulong c_steamIdFriend)
        {
            CheckIfUsable();

            SteamAPI_ISteamFriends_RequestFriendRichPresence(m_instancePtr, c_steamIdFriend);
        }

        public override bool InviteUserToGame(ulong c_steamIdFriend, string c_pchConnectString)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamFriends_InviteUserToGame(m_instancePtr, c_steamIdFriend, new SafeUtf8String(c_pchConnectString));

            return a_result;
        }

        public override int GetCoplayFriendCount()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamFriends_GetCoplayFriendCount(m_instancePtr);

            return a_result;
        }

        public override ulong GetCoplayFriend(int c_iCoplayFriend)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamFriends_GetCoplayFriend(m_instancePtr, c_iCoplayFriend);

            return a_result;
        }

        public override int GetFriendCoplayTime(ulong c_steamIdFriend)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamFriends_GetFriendCoplayTime(m_instancePtr, c_steamIdFriend);

            return a_result;
        }

        public override uint GetFriendCoplayGame(ulong c_steamIdFriend)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamFriends_GetFriendCoplayGame(m_instancePtr, c_steamIdFriend);

            return a_result;
        }

        public override ulong JoinClanChatRoom(ulong c_steamIdClan)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamFriends_JoinClanChatRoom(m_instancePtr, c_steamIdClan);

            return a_result;
        }

        public override bool LeaveClanChatRoom(ulong c_steamIdClan)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamFriends_LeaveClanChatRoom(m_instancePtr, c_steamIdClan);

            return a_result;
        }

        public override int GetClanChatMemberCount(ulong c_steamIdClan)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamFriends_GetClanChatMemberCount(m_instancePtr, c_steamIdClan);

            return a_result;
        }

        public override ulong GetChatMemberByIndex(ulong c_steamIdClan, int c_iUser)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamFriends_GetChatMemberByIndex(m_instancePtr, c_steamIdClan, c_iUser);

            return a_result;
        }

        public override bool SendClanChatMessage(ulong c_steamIdClanChat, string c_pchText)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamFriends_SendClanChatMessage(m_instancePtr, c_steamIdClanChat, new SafeUtf8String(c_pchText));

            return a_result;
        }

        public override int GetClanChatMessage(ulong c_steamIdClanChat, int c_iMessage, IntPtr c_prgchText, int c_cchTextMax, ref uint c_peChatEntryType, out CSteamId c_psteamidChatter)
        {
            CheckIfUsable();

            c_psteamidChatter = default(CSteamId);

            var a_result = SteamAPI_ISteamFriends_GetClanChatMessage(m_instancePtr, c_steamIdClanChat, c_iMessage, c_prgchText, c_cchTextMax, ref c_peChatEntryType, ref c_psteamidChatter);

            return a_result;
        }

        public override bool IsClanChatAdmin(ulong c_steamIdClanChat, ulong c_steamIdUser)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamFriends_IsClanChatAdmin(m_instancePtr, c_steamIdClanChat, c_steamIdUser);

            return a_result;
        }

        public override bool IsClanChatWindowOpenInSteam(ulong c_steamIdClanChat)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamFriends_IsClanChatWindowOpenInSteam(m_instancePtr, c_steamIdClanChat);

            return a_result;
        }

        public override bool OpenClanChatWindowInSteam(ulong c_steamIdClanChat)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamFriends_OpenClanChatWindowInSteam(m_instancePtr, c_steamIdClanChat);

            return a_result;
        }

        public override bool CloseClanChatWindowInSteam(ulong c_steamIdClanChat)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamFriends_CloseClanChatWindowInSteam(m_instancePtr, c_steamIdClanChat);

            return a_result;
        }

        public override bool SetListenForFriendsMessages(bool c_bInterceptEnabled)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamFriends_SetListenForFriendsMessages(m_instancePtr, c_bInterceptEnabled);

            return a_result;
        }

        public override bool ReplyToFriendMessage(ulong c_steamIdFriend, string c_pchMsgToSend)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamFriends_ReplyToFriendMessage(m_instancePtr, c_steamIdFriend, new SafeUtf8String(c_pchMsgToSend));

            return a_result;
        }

        public override int GetFriendMessage(ulong c_steamIdFriend, int c_iMessageId, IntPtr c_pvData, int c_cubData, ref uint c_peChatEntryType)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamFriends_GetFriendMessage(m_instancePtr, c_steamIdFriend, c_iMessageId, c_pvData, c_cubData, ref c_peChatEntryType);

            return a_result;
        }

        public override ulong GetFollowerCount(ulong c_steamId)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamFriends_GetFollowerCount(m_instancePtr, c_steamId);

            return a_result;
        }

        public override ulong IsFollowing(ulong c_steamId)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamFriends_IsFollowing(m_instancePtr, c_steamId);

            return a_result;
        }

        public override ulong EnumerateFollowingList(uint c_unStartIndex)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamFriends_EnumerateFollowingList(m_instancePtr, c_unStartIndex);

            return a_result;
        }

        #endregion
    }

    public abstract class ISteamFriends
    {
        public abstract IntPtr GetIntPtr();

        public abstract string GetPersonaName();

        public abstract ulong SetPersonaName(string c_pchPersonaName);

        public abstract uint GetPersonaState();

        public abstract int GetFriendCount(int c_iFriendFlags);

        public abstract ulong GetFriendByIndex(int c_iFriend, int c_iFriendFlags);

        public abstract uint GetFriendRelationship(ulong c_steamIdFriend);

        public abstract uint GetFriendPersonaState(ulong c_steamIdFriend);

        public abstract string GetFriendPersonaName(ulong c_steamIdFriend);

        public abstract bool GetFriendGamePlayed(ulong c_steamIdFriend, out FriendGameInfo c_pFriendGameInfo);

        public abstract string GetFriendPersonaNameHistory(ulong c_steamIdFriend, int c_iPersonaName);

        public abstract int GetFriendSteamLevel(ulong c_steamIdFriend);

        public abstract string GetPlayerNickname(ulong c_steamIdPlayer);

        public abstract int GetFriendsGroupCount();

        public abstract char GetFriendsGroupIdByIndex(int c_iFg);

        public abstract string GetFriendsGroupName(char c_friendsGroupId);

        public abstract int GetFriendsGroupMembersCount(char c_friendsGroupId);

        public abstract void GetFriendsGroupMembersList(char c_friendsGroupId, out CSteamId[] c_pOutSteamIdMembers, int c_nMembersCount);

        public abstract bool HasFriend(ulong c_steamIdFriend, int c_iFriendFlags);

        public abstract int GetClanCount();

        public abstract ulong GetClanByIndex(int c_iClan);

        public abstract string GetClanName(ulong c_steamIdClan);

        public abstract string GetClanTag(ulong c_steamIdClan);

        public abstract bool GetClanActivityCounts(ulong c_steamIdClan, ref int c_pnOnline, ref int c_pnInGame, ref int c_pnChatting);

        public abstract ulong DownloadClanActivityCounts(CSteamId[] c_psteamIdClans);

        public abstract int GetFriendCountFromSource(ulong c_steamIdSource);

        public abstract ulong GetFriendFromSourceByIndex(ulong c_steamIdSource, int c_iFriend);

        public abstract bool IsUserInSource(ulong c_steamIdUser, ulong c_steamIdSource);

        public abstract void SetInGameVoiceSpeaking(ulong c_steamIdUser, bool c_bSpeaking);

        public abstract void ActivateGameOverlay(string c_pchDialog);

        public abstract void ActivateGameOverlayToUser(string c_pchDialog, ulong c_steamId);

        public abstract void ActivateGameOverlayToWebPage(string c_pchUrl);

        public abstract void ActivateGameOverlayToStore(uint c_nAppId, char c_eFlag);

        public abstract void SetPlayedWith(ulong c_steamIdUserPlayedWith);

        public abstract void ActivateGameOverlayInviteDialog(ulong c_steamIdLobby);

        public abstract int GetSmallFriendAvatar(ulong c_steamIdFriend);

        public abstract int GetMediumFriendAvatar(ulong c_steamIdFriend);

        public abstract int GetLargeFriendAvatar(ulong c_steamIdFriend);

        public abstract bool RequestUserInformation(ulong c_steamIdUser, bool c_bRequireNameOnly);

        public abstract ulong RequestClanOfficerList(ulong c_steamIdClan);

        public abstract ulong GetClanOwner(ulong c_steamIdClan);

        public abstract int GetClanOfficerCount(ulong c_steamIdClan);

        public abstract ulong GetClanOfficerByIndex(ulong c_steamIdClan, int c_iOfficer);

        public abstract uint GetUserRestrictions();

        public abstract bool SetRichPresence(string c_pchKey, string c_pchValue);

        public abstract void ClearRichPresence();

        public abstract string GetFriendRichPresence(ulong c_steamIdFriend, string c_pchKey);

        public abstract int GetFriendRichPresenceKeyCount(ulong c_steamIdFriend);

        public abstract string GetFriendRichPresenceKeyByIndex(ulong c_steamIdFriend, int c_iKey);

        public abstract void RequestFriendRichPresence(ulong c_steamIdFriend);

        public abstract bool InviteUserToGame(ulong c_steamIdFriend, string c_pchConnectString);

        public abstract int GetCoplayFriendCount();

        public abstract ulong GetCoplayFriend(int c_iCoplayFriend);

        public abstract int GetFriendCoplayTime(ulong c_steamIdFriend);

        public abstract uint GetFriendCoplayGame(ulong c_steamIdFriend);

        public abstract ulong JoinClanChatRoom(ulong c_steamIdClan);

        public abstract bool LeaveClanChatRoom(ulong c_steamIdClan);

        public abstract int GetClanChatMemberCount(ulong c_steamIdClan);

        public abstract ulong GetChatMemberByIndex(ulong c_steamIdClan, int c_iUser);

        public abstract bool SendClanChatMessage(ulong c_steamIdClanChat, string c_pchText);

        public abstract int GetClanChatMessage(ulong c_steamIdClanChat, int c_iMessage, IntPtr c_prgchText, int c_cchTextMax, ref uint c_peChatEntryType, out CSteamId c_psteamidChatter);

        public abstract bool IsClanChatAdmin(ulong c_steamIdClanChat, ulong c_steamIdUser);

        public abstract bool IsClanChatWindowOpenInSteam(ulong c_steamIdClanChat);

        public abstract bool OpenClanChatWindowInSteam(ulong c_steamIdClanChat);

        public abstract bool CloseClanChatWindowInSteam(ulong c_steamIdClanChat);

        public abstract bool SetListenForFriendsMessages(bool c_bInterceptEnabled);

        public abstract bool ReplyToFriendMessage(ulong c_steamIdFriend, string c_pchMsgToSend);

        public abstract int GetFriendMessage(ulong c_steamIdFriend, int c_iMessageId, IntPtr c_pvData, int c_cubData, ref uint c_peChatEntryType);

        public abstract ulong GetFollowerCount(ulong c_steamId);

        public abstract ulong IsFollowing(ulong c_steamId);

        public abstract ulong EnumerateFollowingList(uint c_unStartIndex);
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FriendGameInfo
    {
        public ulong m_gameID;
        public uint m_unGameIP;
        public char m_usGamePort;
        public char m_usQueryPort;
        public ulong m_steamIDLobby;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CSteamId
    {
        public SteamId SteamID;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SteamId
    {
        public SteamIdComponent Component;
        public ulong All64Bits;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SteamIdComponent
    {
        public uint AccountID;
        public uint AccountInstance;
        public uint AccountType;
        public EUniverse Universe;
    }
}
