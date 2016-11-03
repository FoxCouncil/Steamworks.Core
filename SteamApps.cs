//   !!  // Steamworks.Core - SteamApps.cs
// *.-". // Created: 2016-10-20 [5:43 PM]
//  | |  // Copyright 2016 // MIT License // The Fox Council 
// Modified by: Fox Diller on 2016-10-22 @ 3:03 PM

#region Usings

using System;
using System.Runtime.InteropServices;

#endregion

namespace Steamworks.Core
{
    public class SteamApps : ISteamApps
    {
        private readonly IntPtr m_instancePtr;

        public SteamApps(IntPtr c_instancePtr)
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

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamApps_BIsSubscribed")]
        private static extern bool SteamAPI_ISteamApps_BIsSubscribed(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamApps_BIsLowViolence")]
        private static extern bool SteamAPI_ISteamApps_BIsLowViolence(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamApps_BIsCybercafe")]
        private static extern bool SteamAPI_ISteamApps_BIsCybercafe(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamApps_BIsVACBanned")]
        private static extern bool SteamAPI_ISteamApps_BIsVACBanned(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamApps_GetCurrentGameLanguage")]
        private static extern IntPtr SteamAPI_ISteamApps_GetCurrentGameLanguage(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamApps_GetAvailableGameLanguages")]
        private static extern IntPtr SteamAPI_ISteamApps_GetAvailableGameLanguages(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamApps_BIsSubscribedApp")]
        private static extern bool SteamAPI_ISteamApps_BIsSubscribedApp(IntPtr c_instancePtr, uint c_appId);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamApps_BIsDlcInstalled")]
        private static extern bool SteamAPI_ISteamApps_BIsDlcInstalled(IntPtr c_instancePtr, uint c_appId);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamApps_GetEarliestPurchaseUnixTime")]
        private static extern uint SteamAPI_ISteamApps_GetEarliestPurchaseUnixTime(IntPtr c_instancePtr, uint c_nAppId);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamApps_BIsSubscribedFromFreeWeekend")]
        private static extern bool SteamAPI_ISteamApps_BIsSubscribedFromFreeWeekend(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamApps_GetDLCCount")]
        private static extern int SteamAPI_ISteamApps_GetDLCCount(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamApps_BGetDLCDataByIndex")]
        private static extern bool SteamAPI_ISteamApps_BGetDLCDataByIndex(IntPtr c_instancePtr, int c_iDlc, ref uint c_pAppId, ref bool c_pbAvailable, SafeUtf8String c_pchName, int c_cchNameBufferSize);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamApps_InstallDLC")]
        private static extern void SteamAPI_ISteamApps_InstallDLC(IntPtr c_instancePtr, uint c_nAppId);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamApps_UninstallDLC")]
        private static extern void SteamAPI_ISteamApps_UninstallDLC(IntPtr c_instancePtr, uint c_nAppId);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamApps_RequestAppProofOfPurchaseKey")]
        private static extern void SteamAPI_ISteamApps_RequestAppProofOfPurchaseKey(IntPtr c_instancePtr, uint c_nAppId);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamApps_GetCurrentBetaName")]
        private static extern bool SteamAPI_ISteamApps_GetCurrentBetaName(IntPtr c_instancePtr, SafeUtf8String c_pchName, int c_cchNameBufferSize);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamApps_MarkContentCorrupt")]
        private static extern bool SteamAPI_ISteamApps_MarkContentCorrupt(IntPtr c_instancePtr, bool c_bMissingFilesOnly);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamApps_GetInstalledDepots")]
        private static extern uint SteamAPI_ISteamApps_GetInstalledDepots(IntPtr c_instancePtr, uint c_appId, ref uint c_pvecDepots, uint c_cMaxDepots);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamApps_GetAppInstallDir")]
        private static extern uint SteamAPI_ISteamApps_GetAppInstallDir(IntPtr c_instancePtr, uint c_appId, SafeUtf8String c_pchFolder, uint c_cchFolderBufferSize);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamApps_BIsAppInstalled")]
        private static extern bool SteamAPI_ISteamApps_BIsAppInstalled(IntPtr c_instancePtr, uint c_appId);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamApps_GetAppOwner")]
        private static extern ulong SteamAPI_ISteamApps_GetAppOwner(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamApps_GetLaunchQueryParam")]
        private static extern IntPtr SteamAPI_ISteamApps_GetLaunchQueryParam(IntPtr c_instancePtr, SafeUtf8String c_pchKey);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamApps_GetDlcDownloadProgress")]
        private static extern bool SteamAPI_ISteamApps_GetDlcDownloadProgress(IntPtr c_instancePtr, uint c_nAppId, ref ulong c_punBytesDownloaded, ref ulong c_punBytesTotal);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamApps_GetAppBuildId")]
        private static extern int SteamAPI_ISteamApps_GetAppBuildId(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamApps_RequestAllProofOfPurchaseKeys")]
        private static extern void SteamAPI_ISteamApps_RequestAllProofOfPurchaseKeys(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamApps_GetFileDetails")]
        private static extern ulong SteamAPI_ISteamApps_GetFileDetails(IntPtr c_instancePtr, SafeUtf8String c_pszFileName);

        #endregion

        #region Overrides of ISteamApps

        public override IntPtr GetIntPtr()
        {
            return m_instancePtr;
        }

        public override bool BIsSubscribed()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamApps_BIsSubscribed(m_instancePtr);

            return a_result;
        }

        public override bool BIsLowViolence()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamApps_BIsLowViolence(m_instancePtr);

            return a_result;
        }

        public override bool BIsCybercafe()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamApps_BIsCybercafe(m_instancePtr);

            return a_result;
        }

        public override bool BisVacBanned()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamApps_BIsVACBanned(m_instancePtr);

            return a_result;
        }

        public override string GetCurrentGameLanguage()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamApps_GetCurrentGameLanguage(m_instancePtr);

            return SafeUtf8String.ToString(a_result);
        }

        public override string GetAvailableGameLanguages()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamApps_GetAvailableGameLanguages(m_instancePtr);

            return SafeUtf8String.ToString(a_result);
        }

        public override bool BIsSubscribedApp(uint c_appId)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamApps_BIsSubscribedApp(m_instancePtr, c_appId);

            return a_result;
        }

        public override bool BIsDlcInstalled(uint c_appId)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamApps_BIsDlcInstalled(m_instancePtr, c_appId);

            return a_result;
        }

        public override uint GetEarliestPurchaseUnixTime(uint c_nAppId)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamApps_GetEarliestPurchaseUnixTime(m_instancePtr, c_nAppId);

            return a_result;
        }

        public override bool BIsSubscribedFromFreeWeekend()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamApps_BIsSubscribedFromFreeWeekend(m_instancePtr);

            return a_result;
        }

        public override int GetDlcCount()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamApps_GetDLCCount(m_instancePtr);

            return a_result;
        }

        public override bool BGetDlcDataByIndex(int c_iDlc, ref uint c_pAppId, ref bool c_pbAvailable, string c_pchName, int c_cchNameBufferSize)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamApps_BGetDLCDataByIndex(m_instancePtr, c_iDlc, ref c_pAppId, ref c_pbAvailable, new SafeUtf8String(c_pchName), c_cchNameBufferSize);

            return a_result;
        }

        public override void InstallDlc(uint c_nAppId)
        {
            CheckIfUsable();

            SteamAPI_ISteamApps_InstallDLC(m_instancePtr, c_nAppId);
        }

        public override void UninstallDlc(uint c_nAppId)
        {
            CheckIfUsable();

            SteamAPI_ISteamApps_UninstallDLC(m_instancePtr, c_nAppId);
        }

        public override void RequestAppProofOfPurchaseKey(uint c_nAppId)
        {
            CheckIfUsable();

            SteamAPI_ISteamApps_RequestAppProofOfPurchaseKey(m_instancePtr, c_nAppId);
        }

        public override bool GetCurrentBetaName(string c_pchName, int c_cchNameBufferSize)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamApps_GetCurrentBetaName(m_instancePtr, new SafeUtf8String(c_pchName), c_cchNameBufferSize);

            return a_result;
        }

        public override bool MarkContentCorrupt(bool c_bMissingFilesOnly)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamApps_MarkContentCorrupt(m_instancePtr, c_bMissingFilesOnly);

            return a_result;
        }

        public override uint GetInstalledDepots(uint c_appId, ref uint c_pvecDepots, uint c_cMaxDepots)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamApps_GetInstalledDepots(m_instancePtr, c_appId, ref c_pvecDepots, c_cMaxDepots);

            return a_result;
        }

        public override uint GetAppInstallDir(uint c_appId, string c_pchFolder, uint c_cchFolderBufferSize)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamApps_GetAppInstallDir(m_instancePtr, c_appId, new SafeUtf8String(c_pchFolder), c_cchFolderBufferSize);

            return a_result;
        }

        public override bool BIsAppInstalled(uint c_appId)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamApps_BIsAppInstalled(m_instancePtr, c_appId);

            return a_result;
        }

        public override ulong GetAppOwner()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamApps_GetAppOwner(m_instancePtr);

            return a_result;
        }

        public override string GetLaunchQueryParam(string c_pchKey)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamApps_GetLaunchQueryParam(m_instancePtr, new SafeUtf8String(c_pchKey));

            return SafeUtf8String.ToString(a_result);
        }

        public override bool GetDlcDownloadProgress(uint c_nAppId, ref ulong c_punBytesDownloaded, ref ulong c_punBytesTotal)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamApps_GetDlcDownloadProgress(m_instancePtr, c_nAppId, ref c_punBytesDownloaded, ref c_punBytesTotal);

            return a_result;
        }

        public override int GetAppBuildId()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamApps_GetAppBuildId(m_instancePtr);

            return a_result;
        }

        public override void RequestAllProofOfPurchaseKeys()
        {
            CheckIfUsable();

            SteamAPI_ISteamApps_RequestAllProofOfPurchaseKeys(m_instancePtr);
        }

        public override ulong GetFileDetails(string c_pszFileName)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamApps_GetFileDetails(m_instancePtr, new SafeUtf8String(c_pszFileName));

            return a_result;
        }

        #endregion
    }

    public abstract class ISteamApps
    {
        public abstract IntPtr GetIntPtr();
        public abstract bool BIsSubscribed();
        public abstract bool BIsLowViolence();
        public abstract bool BIsCybercafe();
        public abstract bool BisVacBanned();
        public abstract string GetCurrentGameLanguage();
        public abstract string GetAvailableGameLanguages();
        public abstract bool BIsSubscribedApp(uint c_appId);
        public abstract bool BIsDlcInstalled(uint c_appId);
        public abstract uint GetEarliestPurchaseUnixTime(uint c_nAppId);
        public abstract bool BIsSubscribedFromFreeWeekend();
        public abstract int GetDlcCount();
        public abstract bool BGetDlcDataByIndex(int c_iDlc, ref uint c_pAppId, ref bool c_pbAvailable, string c_pchName, int c_cchNameBufferSize);
        public abstract void InstallDlc(uint c_nAppId);
        public abstract void UninstallDlc(uint c_nAppId);
        public abstract void RequestAppProofOfPurchaseKey(uint c_nAppId);
        public abstract bool GetCurrentBetaName(string c_pchName, int c_cchNameBufferSize);
        public abstract bool MarkContentCorrupt(bool c_bMissingFilesOnly);
        public abstract uint GetInstalledDepots(uint c_appId, ref uint c_pvecDepots, uint c_cMaxDepots);
        public abstract uint GetAppInstallDir(uint c_appId, string c_pchFolder, uint c_cchFolderBufferSize);
        public abstract bool BIsAppInstalled(uint c_appId);
        public abstract ulong GetAppOwner();
        public abstract string GetLaunchQueryParam(string c_pchKey);
        public abstract bool GetDlcDownloadProgress(uint c_nAppId, ref ulong c_punBytesDownloaded, ref ulong c_punBytesTotal);
        public abstract int GetAppBuildId();
        public abstract void RequestAllProofOfPurchaseKeys();
        public abstract ulong GetFileDetails(string c_pszFileName);
    }
}