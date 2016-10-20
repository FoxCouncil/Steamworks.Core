using System;
using System.Runtime.InteropServices;

namespace Steamworks.Core
{
    public class SteamUserStats : ISteamUserStats
    {
        private readonly IntPtr m_instancePtr;

        public SteamUserStats(IntPtr c_instancePtr)
        {
            m_instancePtr = c_instancePtr;
        }

        private void CheckIfUsable()
        {
            if (m_instancePtr == IntPtr.Zero)
            {
                throw new InvalidOperationException("Steam Controller Not Initialized!");
            }
        }

        #region Native Methods

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUserStats_RequestCurrentStats")]
        private static extern bool SteamAPI_ISteamUserStats_RequestCurrentStats(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUserStats_GetStat")]
        private static extern bool SteamAPI_ISteamUserStats_GetStat(IntPtr c_instancePtr, SafeUtf8String c_pchName, ref int c_pData);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUserStats_GetStat0")]
        private static extern bool SteamAPI_ISteamUserStats_GetStat0(IntPtr c_instancePtr, SafeUtf8String c_pchName, ref float c_pData);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUserStats_SetStat")]
        private static extern bool SteamAPI_ISteamUserStats_SetStat(IntPtr c_instancePtr, SafeUtf8String c_pchName, int c_nData);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUserStats_SetStat0")]
        private static extern bool SteamAPI_ISteamUserStats_SetStat0(IntPtr c_instancePtr, SafeUtf8String c_pchName, float c_fData);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUserStats_UpdateAvgRateStat")]
        private static extern bool SteamAPI_ISteamUserStats_UpdateAvgRateStat(IntPtr c_instancePtr, SafeUtf8String c_pchName, float c_flCountThisSession, double c_dSessionLength);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUserStats_GetAchievement")]
        private static extern bool SteamAPI_ISteamUserStats_GetAchievement(IntPtr c_instancePtr, SafeUtf8String c_pchName, ref bool c_pbAchieved);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUserStats_SetAchievement")]
        private static extern bool SteamAPI_ISteamUserStats_SetAchievement(IntPtr c_instancePtr, SafeUtf8String c_pchName);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUserStats_ClearAchievement")]
        private static extern bool SteamAPI_ISteamUserStats_ClearAchievement(IntPtr c_instancePtr, SafeUtf8String c_pchName);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUserStats_GetAchievementAndUnlockTime")]
        private static extern bool SteamAPI_ISteamUserStats_GetAchievementAndUnlockTime(IntPtr c_instancePtr, SafeUtf8String c_pchName, ref bool c_pbAchieved, ref uint c_punUnlockTime);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUserStats_StoreStats")]
        private static extern bool SteamAPI_ISteamUserStats_StoreStats(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUserStats_GetAchievementIcon")]
        private static extern int SteamAPI_ISteamUserStats_GetAchievementIcon(IntPtr c_instancePtr, SafeUtf8String c_pchName);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUserStats_GetAchievementDisplayAttribute")]
        private static extern IntPtr SteamAPI_ISteamUserStats_GetAchievementDisplayAttribute(IntPtr c_instancePtr, SafeUtf8String c_pchName, SafeUtf8String c_pchKey);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUserStats_IndicateAchievementProgress")]
        private static extern bool SteamAPI_ISteamUserStats_IndicateAchievementProgress(IntPtr c_instancePtr, SafeUtf8String c_pchName, uint c_nCurProgress, uint c_nMaxProgress);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUserStats_GetNumAchievements")]
        private static extern uint SteamAPI_ISteamUserStats_GetNumAchievements(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUserStats_GetAchievementName")]
        private static extern IntPtr SteamAPI_ISteamUserStats_GetAchievementName(IntPtr c_instancePtr, uint c_iAchievement);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUserStats_RequestUserStats")]
        private static extern ulong SteamAPI_ISteamUserStats_RequestUserStats(IntPtr c_instancePtr, ulong c_steamIdUser);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUserStats_GetUserStat")]
        private static extern bool SteamAPI_ISteamUserStats_GetUserStat(IntPtr c_instancePtr, ulong c_steamIdUser, SafeUtf8String c_pchName, ref int c_pData);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUserStats_GetUserStat0")]
        private static extern bool SteamAPI_ISteamUserStats_GetUserStat0(IntPtr c_instancePtr, ulong c_steamIdUser, SafeUtf8String c_pchName, ref float c_pData);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUserStats_GetUserAchievement")]
        private static extern bool SteamAPI_ISteamUserStats_GetUserAchievement(IntPtr c_instancePtr, ulong c_steamIdUser, SafeUtf8String c_pchName, ref bool c_pbAchieved);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUserStats_GetUserAchievementAndUnlockTime")]
        private static extern bool SteamAPI_ISteamUserStats_GetUserAchievementAndUnlockTime(IntPtr c_instancePtr, ulong c_steamIdUser, SafeUtf8String c_pchName, ref bool c_pbAchieved, ref uint c_punUnlockTime);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUserStats_ResetAllStats")]
        private static extern bool SteamAPI_ISteamUserStats_ResetAllStats(IntPtr c_instancePtr, bool c_bAchievementsToo);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUserStats_FindOrCreateLeaderboard")]
        private static extern ulong SteamAPI_ISteamUserStats_FindOrCreateLeaderboard(IntPtr c_instancePtr, SafeUtf8String c_pchLeaderboardName, uint c_eLeaderboardSortMethod, uint c_eLeaderboardDisplayType);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUserStats_FindLeaderboard")]
        private static extern ulong SteamAPI_ISteamUserStats_FindLeaderboard(IntPtr c_instancePtr, SafeUtf8String c_pchLeaderboardName);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUserStats_GetLeaderboardName")]
        private static extern IntPtr SteamAPI_ISteamUserStats_GetLeaderboardName(IntPtr c_instancePtr, ulong c_hSteamLeaderboard);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUserStats_GetLeaderboardEntryCount")]
        private static extern int SteamAPI_ISteamUserStats_GetLeaderboardEntryCount(IntPtr c_instancePtr, ulong c_hSteamLeaderboard);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUserStats_GetLeaderboardSortMethod")]
        private static extern uint SteamAPI_ISteamUserStats_GetLeaderboardSortMethod(IntPtr c_instancePtr, ulong c_hSteamLeaderboard);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUserStats_GetLeaderboardDisplayType")]
        private static extern uint SteamAPI_ISteamUserStats_GetLeaderboardDisplayType(IntPtr c_instancePtr, ulong c_hSteamLeaderboard);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUserStats_DownloadLeaderboardEntries")]
        private static extern ulong SteamAPI_ISteamUserStats_DownloadLeaderboardEntries(IntPtr c_instancePtr, ulong c_hSteamLeaderboard, uint c_eLeaderboardDataRequest, int c_nRangeStart, int c_nRangeEnd);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUserStats_DownloadLeaderboardEntriesForUsers")]
        private static extern ulong SteamAPI_ISteamUserStats_DownloadLeaderboardEntriesForUsers(IntPtr c_instancePtr, ulong c_hSteamLeaderboard, [In, Out] CSteamId[] c_prgUsers, int c_cUsers);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUserStats_GetDownloadedLeaderboardEntry")]
        private static extern bool SteamAPI_ISteamUserStats_GetDownloadedLeaderboardEntry(IntPtr c_instancePtr, ulong c_hSteamLeaderboardEntries, int c_index, ref LeaderboardEntry c_pLeaderboardEntry, ref int c_pDetails, int c_cDetailsMax);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUserStats_UploadLeaderboardScore")]
        private static extern ulong SteamAPI_ISteamUserStats_UploadLeaderboardScore(IntPtr c_instancePtr, ulong c_hSteamLeaderboard, uint c_eLeaderboardUploadScoreMethod, int c_nScore, ref int c_pScoreDetails, int c_cScoreDetailsCount);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUserStats_AttachLeaderboardUGC")]
        private static extern ulong SteamAPI_ISteamUserStats_AttachLeaderboardUGC(IntPtr c_instancePtr, ulong c_hSteamLeaderboard, ulong c_hUgc);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUserStats_GetNumberOfCurrentPlayers")]
        private static extern ulong SteamAPI_ISteamUserStats_GetNumberOfCurrentPlayers(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUserStats_RequestGlobalAchievementPercentages")]
        private static extern ulong SteamAPI_ISteamUserStats_RequestGlobalAchievementPercentages(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUserStats_GetMostAchievedAchievementInfo")]
        private static extern int SteamAPI_ISteamUserStats_GetMostAchievedAchievementInfo(IntPtr c_instancePtr, SafeUtf8String c_pchName, uint c_unNameBufLen, ref float c_pflPercent, ref bool c_pbAchieved);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUserStats_GetNextMostAchievedAchievementInfo")]
        private static extern int SteamAPI_ISteamUserStats_GetNextMostAchievedAchievementInfo(IntPtr c_instancePtr, int c_iIteratorPrevious, SafeUtf8String c_pchName, uint c_unNameBufLen, ref float c_pflPercent, ref bool c_pbAchieved);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUserStats_GetAchievementAchievedPercent")]
        private static extern bool SteamAPI_ISteamUserStats_GetAchievementAchievedPercent(IntPtr c_instancePtr, SafeUtf8String c_pchName, ref float c_pflPercent);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUserStats_RequestGlobalStats")]
        private static extern ulong SteamAPI_ISteamUserStats_RequestGlobalStats(IntPtr c_instancePtr, int c_nHistoryDays);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUserStats_GetGlobalStat")]
        private static extern bool SteamAPI_ISteamUserStats_GetGlobalStat(IntPtr c_instancePtr, SafeUtf8String c_pchStatName, ref long c_pData);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUserStats_GetGlobalStat0")]
        private static extern bool SteamAPI_ISteamUserStats_GetGlobalStat0(IntPtr c_instancePtr, SafeUtf8String c_pchStatName, ref double c_pData);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUserStats_GetGlobalStatHistory")]
        private static extern int SteamAPI_ISteamUserStats_GetGlobalStatHistory(IntPtr c_instancePtr, SafeUtf8String c_pchStatName, [In, Out] long[] c_pData, uint c_cubData);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUserStats_GetGlobalStatHistory0")]
        private static extern int SteamAPI_ISteamUserStats_GetGlobalStatHistory0(IntPtr c_instancePtr, SafeUtf8String c_pchStatName, [In, Out] double[] c_pData, uint c_cubData);

        #endregion

        #region Overrides of ISteamUserStats

        public override IntPtr GetIntPtr()
        {
            return m_instancePtr;
        }

        public override bool RequestCurrentStats()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUserStats_RequestCurrentStats(m_instancePtr);

            return a_result;
        }

        public override bool GetStat(string c_pchName, ref int c_pData)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUserStats_GetStat(m_instancePtr, new SafeUtf8String(c_pchName), ref c_pData);

            return a_result;
        }

        public override bool GetStat0(string c_pchName, ref float c_pData)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUserStats_GetStat0(m_instancePtr, new SafeUtf8String(c_pchName), ref c_pData);

            return a_result;
        }

        public override bool SetStat(string c_pchName, int c_nData)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUserStats_SetStat(m_instancePtr, new SafeUtf8String(c_pchName), c_nData);

            return a_result;
        }

        public override bool SetStat0(string c_pchName, float c_fData)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUserStats_SetStat0(m_instancePtr, new SafeUtf8String(c_pchName), c_fData);

            return a_result;
        }

        public override bool UpdateAvgRateStat(string c_pchName, float c_flCountThisSession, double c_dSessionLength)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUserStats_UpdateAvgRateStat(m_instancePtr, new SafeUtf8String(c_pchName), c_flCountThisSession, c_dSessionLength);

            return a_result;
        }

        public override bool GetAchievement(string c_pchName, ref bool c_pbAchieved)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUserStats_GetAchievement(m_instancePtr, new SafeUtf8String(c_pchName), ref c_pbAchieved);

            return a_result;
        }

        public override bool SetAchievement(string c_pchName)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUserStats_SetAchievement(m_instancePtr, new SafeUtf8String(c_pchName));

            return a_result;
        }

        public override bool ClearAchievement(string c_pchName)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUserStats_ClearAchievement(m_instancePtr, new SafeUtf8String(c_pchName));

            return a_result;
        }

        public override bool GetAchievementAndUnlockTime(string c_pchName, ref bool c_pbAchieved, ref uint c_punUnlockTime)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUserStats_GetAchievementAndUnlockTime(m_instancePtr, new SafeUtf8String(c_pchName), ref c_pbAchieved, ref c_punUnlockTime);

            return a_result;
        }

        public override bool StoreStats()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUserStats_StoreStats(m_instancePtr);

            return a_result;
        }

        public override int GetAchievementIcon(string c_pchName)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUserStats_GetAchievementIcon(m_instancePtr, new SafeUtf8String(c_pchName));

            return a_result;
        }

        public override string GetAchievementDisplayAttribute(string c_pchName, string c_pchKey)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUserStats_GetAchievementDisplayAttribute(m_instancePtr, new SafeUtf8String(c_pchName), new SafeUtf8String(c_pchKey));

            return SafeUtf8String.ToString(a_result);
        }

        public override bool IndicateAchievementProgress(string c_pchName, uint c_nCurProgress, uint c_nMaxProgress)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUserStats_IndicateAchievementProgress(m_instancePtr, new SafeUtf8String(c_pchName), c_nCurProgress, c_nMaxProgress);

            return a_result;
        }

        public override uint GetNumAchievements()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUserStats_GetNumAchievements(m_instancePtr);

            return a_result;
        }

        public override string GetAchievementName(uint c_iAchievement)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUserStats_GetAchievementName(m_instancePtr, c_iAchievement);

            return SafeUtf8String.ToString(a_result);
        }

        public override ulong RequestUserStats(ulong c_steamIdUser)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUserStats_RequestUserStats(m_instancePtr, c_steamIdUser);

            return a_result;
        }

        public override bool GetUserStat(ulong c_steamIdUser, string c_pchName, ref int c_pData)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUserStats_GetUserStat(m_instancePtr, c_steamIdUser, new SafeUtf8String(c_pchName), ref c_pData);

            return a_result;
        }

        public override bool GetUserStat0(ulong c_steamIdUser, string c_pchName, ref float c_pData)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUserStats_GetUserStat0(m_instancePtr, c_steamIdUser, new SafeUtf8String(c_pchName), ref c_pData);

            return a_result;
        }

        public override bool GetUserAchievement(ulong c_steamIdUser, string c_pchName, ref bool c_pbAchieved)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUserStats_GetUserAchievement(m_instancePtr, c_steamIdUser, new SafeUtf8String(c_pchName), ref c_pbAchieved);

            return a_result;
        }

        public override bool GetUserAchievementAndUnlockTime(ulong c_steamIdUser, string c_pchName, ref bool c_pbAchieved, ref uint c_punUnlockTime)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUserStats_GetUserAchievementAndUnlockTime(m_instancePtr, c_steamIdUser, new SafeUtf8String(c_pchName), ref c_pbAchieved, ref c_punUnlockTime);

            return a_result;
        }

        public override bool ResetAllStats(bool c_bAchievementsToo)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUserStats_ResetAllStats(m_instancePtr, c_bAchievementsToo);

            return a_result;
        }

        public override ulong FindOrCreateLeaderboard(string c_pchLeaderboardName, uint c_eLeaderboardSortMethod, uint c_eLeaderboardDisplayType)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUserStats_FindOrCreateLeaderboard(m_instancePtr, new SafeUtf8String(c_pchLeaderboardName), c_eLeaderboardSortMethod, c_eLeaderboardDisplayType);

            return a_result;
        }

        public override ulong FindLeaderboard(string c_pchLeaderboardName)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUserStats_FindLeaderboard(m_instancePtr, new SafeUtf8String(c_pchLeaderboardName));

            return a_result;
        }

        public override string GetLeaderboardName(ulong c_hSteamLeaderboard)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUserStats_GetLeaderboardName(m_instancePtr, c_hSteamLeaderboard);

            return SafeUtf8String.ToString(a_result);
        }

        public override int GetLeaderboardEntryCount(ulong c_hSteamLeaderboard)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUserStats_GetLeaderboardEntryCount(m_instancePtr, c_hSteamLeaderboard);

            return a_result;
        }

        public override uint GetLeaderboardSortMethod(ulong c_hSteamLeaderboard)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUserStats_GetLeaderboardSortMethod(m_instancePtr, c_hSteamLeaderboard);

            return a_result;
        }

        public override uint GetLeaderboardDisplayType(ulong c_hSteamLeaderboard)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUserStats_GetLeaderboardDisplayType(m_instancePtr, c_hSteamLeaderboard);

            return a_result;
        }

        public override ulong DownloadLeaderboardEntries(ulong c_hSteamLeaderboard, uint c_eLeaderboardDataRequest, int c_nRangeStart, int c_nRangeEnd)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUserStats_DownloadLeaderboardEntries(m_instancePtr, c_hSteamLeaderboard, c_eLeaderboardDataRequest, c_nRangeStart, c_nRangeEnd);

            return a_result;
        }

        public override ulong DownloadLeaderboardEntriesForUsers(ulong c_hSteamLeaderboard, CSteamId[] c_prgUsers)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUserStats_DownloadLeaderboardEntriesForUsers(m_instancePtr, c_hSteamLeaderboard, c_prgUsers, 0);

            return a_result;
        }

        public override bool GetDownloadedLeaderboardEntry(ulong c_hSteamLeaderboardEntries, int c_index, ref LeaderboardEntry c_pLeaderboardEntry, ref int c_pDetails, int c_cDetailsMax)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUserStats_GetDownloadedLeaderboardEntry(m_instancePtr, c_hSteamLeaderboardEntries, c_index, ref c_pLeaderboardEntry, ref c_pDetails, c_cDetailsMax);

            return a_result;
        }

        public override ulong UploadLeaderboardScore(ulong c_hSteamLeaderboard, uint c_eLeaderboardUploadScoreMethod, int c_nScore, ref int c_pScoreDetails, int c_cScoreDetailsCount)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUserStats_UploadLeaderboardScore(m_instancePtr, c_hSteamLeaderboard, c_eLeaderboardUploadScoreMethod, c_nScore, ref c_pScoreDetails, c_cScoreDetailsCount);

            return a_result;
        }

        public override ulong AttachLeaderboardUgc(ulong c_hSteamLeaderboard, ulong c_hUgc)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUserStats_AttachLeaderboardUGC(m_instancePtr, c_hSteamLeaderboard, c_hUgc);

            return a_result;
        }

        public override ulong GetNumberOfCurrentPlayers()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUserStats_GetNumberOfCurrentPlayers(m_instancePtr);

            return a_result;
        }

        public override ulong RequestGlobalAchievementPercentages()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUserStats_RequestGlobalAchievementPercentages(m_instancePtr);

            return a_result;
        }

        public override int GetMostAchievedAchievementInfo(string c_pchName, uint c_unNameBufLen, ref float c_pflPercent, ref bool c_pbAchieved)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUserStats_GetMostAchievedAchievementInfo(m_instancePtr, new SafeUtf8String(c_pchName), c_unNameBufLen, ref c_pflPercent, ref c_pbAchieved);

            return a_result;
        }

        public override int GetNextMostAchievedAchievementInfo(int c_iIteratorPrevious, string c_pchName, uint c_unNameBufLen, ref float c_pflPercent, ref bool c_pbAchieved)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUserStats_GetNextMostAchievedAchievementInfo(m_instancePtr, c_iIteratorPrevious, new SafeUtf8String(c_pchName), c_unNameBufLen, ref c_pflPercent, ref c_pbAchieved);

            return a_result;
        }

        public override bool GetAchievementAchievedPercent(string c_pchName, ref float c_pflPercent)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUserStats_GetAchievementAchievedPercent(m_instancePtr, new SafeUtf8String(c_pchName), ref c_pflPercent);

            return a_result;
        }

        public override ulong RequestGlobalStats(int c_nHistoryDays)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUserStats_RequestGlobalStats(m_instancePtr, c_nHistoryDays);

            return a_result;
        }

        public override bool GetGlobalStat(string c_pchStatName, ref long c_pData)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUserStats_GetGlobalStat(m_instancePtr, new SafeUtf8String(c_pchStatName), ref c_pData);

            return a_result;
        }

        public override bool GetGlobalStat0(string c_pchStatName, ref double c_pData)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUserStats_GetGlobalStat0(m_instancePtr, new SafeUtf8String(c_pchStatName), ref c_pData);

            return a_result;
        }

        public override int GetGlobalStatHistory(string c_pchStatName, long[] c_pData)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUserStats_GetGlobalStatHistory(m_instancePtr, new SafeUtf8String(c_pchStatName), c_pData, 0);

            return a_result;
        }

        public override int GetGlobalStatHistory0(string c_pchStatName, double[] c_pData)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUserStats_GetGlobalStatHistory0(m_instancePtr, new SafeUtf8String(c_pchStatName), c_pData, 0);

            return a_result;
        }

        #endregion
    }

    public abstract class ISteamUserStats
    {
        public abstract IntPtr GetIntPtr();
        public abstract bool RequestCurrentStats();
        public abstract bool GetStat(string c_pchName, ref int c_pData);
        public abstract bool GetStat0(string c_pchName, ref float c_pData);
        public abstract bool SetStat(string c_pchName, int c_nData);
        public abstract bool SetStat0(string c_pchName, float c_fData);
        public abstract bool UpdateAvgRateStat(string c_pchName, float c_flCountThisSession, double c_dSessionLength);
        public abstract bool GetAchievement(string c_pchName, ref bool c_pbAchieved);
        public abstract bool SetAchievement(string c_pchName);
        public abstract bool ClearAchievement(string c_pchName);
        public abstract bool GetAchievementAndUnlockTime(string c_pchName, ref bool c_pbAchieved, ref uint c_punUnlockTime);
        public abstract bool StoreStats();
        public abstract int GetAchievementIcon(string c_pchName);
        public abstract string GetAchievementDisplayAttribute(string c_pchName, string c_pchKey);
        public abstract bool IndicateAchievementProgress(string c_pchName, uint c_nCurProgress, uint c_nMaxProgress);
        public abstract uint GetNumAchievements();
        public abstract string GetAchievementName(uint c_iAchievement);
        public abstract ulong RequestUserStats(ulong c_steamIdUser);
        public abstract bool GetUserStat(ulong c_steamIdUser, string c_pchName, ref int c_pData);
        public abstract bool GetUserStat0(ulong c_steamIdUser, string c_pchName, ref float c_pData);
        public abstract bool GetUserAchievement(ulong c_steamIdUser, string c_pchName, ref bool c_pbAchieved);
        public abstract bool GetUserAchievementAndUnlockTime(ulong c_steamIdUser, string c_pchName, ref bool c_pbAchieved, ref uint c_punUnlockTime);
        public abstract bool ResetAllStats(bool c_bAchievementsToo);
        public abstract ulong FindOrCreateLeaderboard(string c_pchLeaderboardName, uint c_eLeaderboardSortMethod, uint c_eLeaderboardDisplayType);
        public abstract ulong FindLeaderboard(string c_pchLeaderboardName);
        public abstract string GetLeaderboardName(ulong c_hSteamLeaderboard);
        public abstract int GetLeaderboardEntryCount(ulong c_hSteamLeaderboard);
        public abstract uint GetLeaderboardSortMethod(ulong c_hSteamLeaderboard);
        public abstract uint GetLeaderboardDisplayType(ulong c_hSteamLeaderboard);
        public abstract ulong DownloadLeaderboardEntries(ulong c_hSteamLeaderboard, uint c_eLeaderboardDataRequest, int c_nRangeStart, int c_nRangeEnd);
        public abstract ulong DownloadLeaderboardEntriesForUsers(ulong c_hSteamLeaderboard, CSteamId[] c_prgUsers);
        public abstract bool GetDownloadedLeaderboardEntry(ulong c_hSteamLeaderboardEntries, int c_index, ref LeaderboardEntry c_pLeaderboardEntry, ref int c_pDetails, int c_cDetailsMax);
        public abstract ulong UploadLeaderboardScore(ulong c_hSteamLeaderboard, uint c_eLeaderboardUploadScoreMethod, int c_nScore, ref int c_pScoreDetails, int c_cScoreDetailsCount);
        public abstract ulong AttachLeaderboardUgc(ulong c_hSteamLeaderboard, ulong c_hUgc);
        public abstract ulong GetNumberOfCurrentPlayers();
        public abstract ulong RequestGlobalAchievementPercentages();
        public abstract int GetMostAchievedAchievementInfo(string c_pchName, uint c_unNameBufLen, ref float c_pflPercent, ref bool c_pbAchieved);
        public abstract int GetNextMostAchievedAchievementInfo(int c_iIteratorPrevious, string c_pchName, uint c_unNameBufLen, ref float c_pflPercent, ref bool c_pbAchieved);
        public abstract bool GetAchievementAchievedPercent(string c_pchName, ref float c_pflPercent);
        public abstract ulong RequestGlobalStats(int c_nHistoryDays);
        public abstract bool GetGlobalStat(string c_pchStatName, ref long c_pData);
        public abstract bool GetGlobalStat0(string c_pchStatName, ref double c_pData);
        public abstract int GetGlobalStatHistory(string c_pchStatName, long[] c_pData);
        public abstract int GetGlobalStatHistory0(string c_pchStatName, double[] c_pData);
    }

    public struct LeaderboardEntry
    {
        public CSteamId SteamIdUser; // user with the entry - use SteamFriends()->GetFriendPersonaName() & SteamFriends()->GetFriendAvatar() to get more info
        public int GlobalRank; // [1..N], where N is the number of users with an entry in the leaderboard
        public int Score; // score as set in the leaderboard
        public int Details; // number of int32 details available for this entry
        public ulong Ugc; // handle for UGC attached to the entry
    }
}