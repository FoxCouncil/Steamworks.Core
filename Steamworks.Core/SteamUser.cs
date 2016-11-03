//   !!  // Steamworks.Core - SteamUser.cs
// *.-". // Created: 2016-10-17 [9:49 PM]
//  | |  // Copyright 2016 // MIT License // The Fox Council 
// Modified by: Fox Diller on 2016-10-22 @ 3:03 PM

#region Usings

using System;
using System.Runtime.InteropServices;

#endregion

namespace Steamworks.Core
{
    public class SteamUser : ISteamUser
    {
        private readonly IntPtr m_instancePtr;

        public SteamUser(IntPtr c_instancePtr)
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

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUser_GetHSteamUser")]
        internal static extern uint SteamAPI_ISteamUser_GetHSteamUser(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUser_BLoggedOn")]
        internal static extern bool SteamAPI_ISteamUser_BLoggedOn(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUser_GetSteamID")]
        internal static extern ulong SteamAPI_ISteamUser_GetSteamID(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUser_InitiateGameConnection")]
        internal static extern int SteamAPI_ISteamUser_InitiateGameConnection(IntPtr c_instancePtr, IntPtr c_pAuthBlob, int c_cbMaxAuthBlob, ulong c_steamIdGameServer, uint c_unIpServer, char c_usPortServer, bool c_bSecure);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUser_TerminateGameConnection")]
        internal static extern void SteamAPI_ISteamUser_TerminateGameConnection(IntPtr c_instancePtr, uint c_unIpServer, char c_usPortServer);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUser_TrackAppUsageEvent")]
        internal static extern void SteamAPI_ISteamUser_TrackAppUsageEvent(IntPtr c_instancePtr, ulong c_gameId, int c_eAppUsageEvent, SafeUtf8String c_pchExtraInfo);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUser_GetUserDataFolder")]
        internal static extern bool SteamAPI_ISteamUser_GetUserDataFolder(IntPtr c_instancePtr, SafeUtf8String c_pchBuffer, int c_cubBuffer);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUser_StartVoiceRecording")]
        internal static extern void SteamAPI_ISteamUser_StartVoiceRecording(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUser_StopVoiceRecording")]
        internal static extern void SteamAPI_ISteamUser_StopVoiceRecording(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUser_GetAvailableVoice")]
        internal static extern uint SteamAPI_ISteamUser_GetAvailableVoice(IntPtr c_instancePtr, ref uint c_pcbCompressed, ref uint c_pcbUncompressed, uint c_nUncompressedVoiceDesiredSampleRate);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUser_GetVoice")]
        internal static extern uint SteamAPI_ISteamUser_GetVoice(IntPtr c_instancePtr, bool c_bWantCompressed, IntPtr c_pDestBuffer, uint c_cbDestBufferSize, ref uint c_nBytesWritten, bool c_bWantUncompressed, IntPtr c_pUncompressedDestBuffer, uint c_cbUncompressedDestBufferSize, ref uint c_nUncompressBytesWritten, uint c_nUncompressedVoiceDesiredSampleRate);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUser_DecompressVoice")]
        internal static extern uint SteamAPI_ISteamUser_DecompressVoice(IntPtr c_instancePtr, IntPtr c_pCompressed, uint c_cbCompressed, IntPtr c_pDestBuffer, uint c_cbDestBufferSize, ref uint c_nBytesWritten, uint c_nDesiredSampleRate);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUser_GetVoiceOptimalSampleRate")]
        internal static extern uint SteamAPI_ISteamUser_GetVoiceOptimalSampleRate(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUser_GetAuthSessionTicket")]
        internal static extern uint SteamAPI_ISteamUser_GetAuthSessionTicket(IntPtr c_instancePtr, IntPtr c_pTicket, int c_cbMaxTicket, ref uint c_pcbTicket);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUser_BeginAuthSession")]
        internal static extern uint SteamAPI_ISteamUser_BeginAuthSession(IntPtr c_instancePtr, IntPtr c_pAuthTicket, int c_cbAuthTicket, ulong c_steamId);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUser_EndAuthSession")]
        internal static extern void SteamAPI_ISteamUser_EndAuthSession(IntPtr c_instancePtr, ulong c_steamId);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUser_CancelAuthTicket")]
        internal static extern void SteamAPI_ISteamUser_CancelAuthTicket(IntPtr c_instancePtr, uint c_hAuthTicket);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUser_UserHasLicenseForApp")]
        internal static extern uint SteamAPI_ISteamUser_UserHasLicenseForApp(IntPtr c_instancePtr, ulong c_steamId, uint c_appId);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUser_BIsBehindNAT")]
        internal static extern bool SteamAPI_ISteamUser_BIsBehindNAT(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUser_AdvertiseGame")]
        internal static extern void SteamAPI_ISteamUser_AdvertiseGame(IntPtr c_instancePtr, ulong c_steamIdGameServer, uint c_unIpServer, char c_usPortServer);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUser_RequestEncryptedAppTicket")]
        internal static extern ulong SteamAPI_ISteamUser_RequestEncryptedAppTicket(IntPtr c_instancePtr, IntPtr c_pDataToInclude, int c_cbDataToInclude);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUser_GetEncryptedAppTicket")]
        internal static extern bool SteamAPI_ISteamUser_GetEncryptedAppTicket(IntPtr c_instancePtr, IntPtr c_pTicket, int c_cbMaxTicket, ref uint c_pcbTicket);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUser_GetGameBadgeLevel")]
        internal static extern int SteamAPI_ISteamUser_GetGameBadgeLevel(IntPtr c_instancePtr, int c_nSeries, bool c_bFoil);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUser_GetPlayerSteamLevel")]
        internal static extern int SteamAPI_ISteamUser_GetPlayerSteamLevel(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUser_RequestStoreAuthURL")]
        internal static extern ulong SteamAPI_ISteamUser_RequestStoreAuthURL(IntPtr c_instancePtr, SafeUtf8String c_pchRedirectUrl);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUser_BIsPhoneVerified")]
        internal static extern bool SteamAPI_ISteamUser_BIsPhoneVerified(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUser_BIsTwoFactorEnabled")]
        internal static extern bool SteamAPI_ISteamUser_BIsTwoFactorEnabled(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUser_BIsPhoneIdentifying")]
        internal static extern bool SteamAPI_ISteamUser_BIsPhoneIdentifying(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUser_BIsPhoneRequiringVerification")]
        internal static extern bool SteamAPI_ISteamUser_BIsPhoneRequiringVerification(IntPtr c_instancePtr);

        #endregion

        #region Overrides of ISteamUser

        public override IntPtr GetIntPtr()
        {
            return m_instancePtr;
        }

        public override uint GetHSteamUser()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUser_GetHSteamUser(m_instancePtr);

            return a_result;
        }

        public override bool BLoggedOn()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUser_BLoggedOn(m_instancePtr);

            return a_result;
        }

        public override ulong GetSteamId()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUser_GetSteamID(m_instancePtr);

            return a_result;
        }

        public override int InitiateGameConnection(IntPtr c_pAuthBlob, int c_cbMaxAuthBlob, ulong c_steamIdGameServer, uint c_unIpServer, char c_usPortServer, bool c_bSecure)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUser_InitiateGameConnection(m_instancePtr, c_pAuthBlob, c_cbMaxAuthBlob, c_steamIdGameServer, c_unIpServer, c_usPortServer, c_bSecure);

            return a_result;
        }

        public override void TerminateGameConnection(uint c_unIpServer, char c_usPortServer)
        {
            CheckIfUsable();

            SteamAPI_ISteamUser_TerminateGameConnection(m_instancePtr, c_unIpServer, c_usPortServer);
        }

        public override void TrackAppUsageEvent(ulong c_gameId, int c_eAppUsageEvent, string c_pchExtraInfo)
        {
            CheckIfUsable();

            SteamAPI_ISteamUser_TrackAppUsageEvent(m_instancePtr, c_gameId, c_eAppUsageEvent, new SafeUtf8String(c_pchExtraInfo));
        }

        public override bool GetUserDataFolder(string c_pchBuffer, int c_cubBuffer)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUser_GetUserDataFolder(m_instancePtr, new SafeUtf8String(c_pchBuffer), c_cubBuffer);

            return a_result;
        }

        public override void StartVoiceRecording()
        {
            CheckIfUsable();

            SteamAPI_ISteamUser_StartVoiceRecording(m_instancePtr);
        }

        public override void StopVoiceRecording()
        {
            CheckIfUsable();

            SteamAPI_ISteamUser_StopVoiceRecording(m_instancePtr);
        }

        public override uint GetAvailableVoice(ref uint c_pcbCompressed, ref uint c_pcbUncompressed, uint c_nUncompressedVoiceDesiredSampleRate)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUser_GetAvailableVoice(m_instancePtr, ref c_pcbCompressed, ref c_pcbUncompressed, c_nUncompressedVoiceDesiredSampleRate);

            return a_result;
        }

        public override uint GetVoice(bool c_bWantCompressed, IntPtr c_pDestBuffer, uint c_cbDestBufferSize, ref uint c_nBytesWritten, bool c_bWantUncompressed, IntPtr c_pUncompressedDestBuffer, uint c_cbUncompressedDestBufferSize, ref uint c_nUncompressBytesWritten, uint c_nUncompressedVoiceDesiredSampleRate)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUser_GetVoice(m_instancePtr, c_bWantCompressed, c_pDestBuffer, c_cbDestBufferSize, ref c_nBytesWritten, c_bWantUncompressed, c_pUncompressedDestBuffer, c_cbUncompressedDestBufferSize, ref c_nUncompressBytesWritten, c_nUncompressedVoiceDesiredSampleRate);

            return a_result;
        }

        public override uint DecompressVoice(IntPtr c_pCompressed, uint c_cbCompressed, IntPtr c_pDestBuffer, uint c_cbDestBufferSize, ref uint c_nBytesWritten, uint c_nDesiredSampleRate)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUser_DecompressVoice(m_instancePtr, c_pCompressed, c_cbCompressed, c_pDestBuffer, c_cbDestBufferSize, ref c_nBytesWritten, c_nDesiredSampleRate);

            return a_result;
        }

        public override uint GetVoiceOptimalSampleRate()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUser_GetVoiceOptimalSampleRate(m_instancePtr);

            return a_result;
        }

        public override uint GetAuthSessionTicket(IntPtr c_pTicket, int c_cbMaxTicket, ref uint c_pcbTicket)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUser_GetAuthSessionTicket(m_instancePtr, c_pTicket, c_cbMaxTicket, ref c_pcbTicket);

            return a_result;
        }

        public override uint BeginAuthSession(IntPtr c_pAuthTicket, int c_cbAuthTicket, ulong c_steamId)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUser_BeginAuthSession(m_instancePtr, c_pAuthTicket, c_cbAuthTicket, c_steamId);

            return a_result;
        }

        public override void EndAuthSession(ulong c_steamId)
        {
            CheckIfUsable();

            SteamAPI_ISteamUser_EndAuthSession(m_instancePtr, c_steamId);
        }

        public override void CancelAuthTicket(uint c_hAuthTicket)
        {
            CheckIfUsable();

            SteamAPI_ISteamUser_CancelAuthTicket(m_instancePtr, c_hAuthTicket);
        }

        public override uint UserHasLicenseForApp(ulong c_steamId, uint c_appId)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUser_UserHasLicenseForApp(m_instancePtr, c_steamId, c_appId);

            return a_result;
        }

        public override bool BIsBehindNat()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUser_BIsBehindNAT(m_instancePtr);

            return a_result;
        }

        public override void AdvertiseGame(ulong c_steamIdGameServer, uint c_unIpServer, char c_usPortServer)
        {
            CheckIfUsable();

            SteamAPI_ISteamUser_AdvertiseGame(m_instancePtr, c_steamIdGameServer, c_unIpServer, c_usPortServer);
        }

        public override ulong RequestEncryptedAppTicket(IntPtr c_pDataToInclude, int c_cbDataToInclude)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUser_RequestEncryptedAppTicket(m_instancePtr, c_pDataToInclude, c_cbDataToInclude);

            return a_result;
        }

        public override bool GetEncryptedAppTicket(IntPtr c_pTicket, int c_cbMaxTicket, ref uint c_pcbTicket)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUser_GetEncryptedAppTicket(m_instancePtr, c_pTicket, c_cbMaxTicket, ref c_pcbTicket);

            return a_result;
        }

        public override int GetGameBadgeLevel(int c_nSeries, bool c_bFoil)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUser_GetGameBadgeLevel(m_instancePtr, c_nSeries, c_bFoil);

            return a_result;
        }

        public override int GetPlayerSteamLevel()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUser_GetPlayerSteamLevel(m_instancePtr);

            return a_result;
        }

        public override ulong RequestStoreAuthUrl(string c_pchRedirectUrl)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUser_RequestStoreAuthURL(m_instancePtr, new SafeUtf8String(c_pchRedirectUrl));

            return a_result;
        }

        public override bool BIsPhoneVerified()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUser_BIsPhoneVerified(m_instancePtr);

            return a_result;
        }

        public override bool BIsTwoFactorEnabled()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUser_BIsTwoFactorEnabled(m_instancePtr);

            return a_result;
        }

        public override bool BIsPhoneIdentifying()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUser_BIsPhoneIdentifying(m_instancePtr);

            return a_result;
        }

        public override bool BIsPhoneRequiringVerification()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUser_BIsPhoneRequiringVerification(m_instancePtr);

            return a_result;
        }

        #endregion
    }

    public abstract class ISteamUser
    {
        public abstract IntPtr GetIntPtr();
        public abstract uint GetHSteamUser();
        public abstract bool BLoggedOn();
        public abstract ulong GetSteamId();
        public abstract int InitiateGameConnection(IntPtr c_pAuthBlob, int c_cbMaxAuthBlob, ulong c_steamIdGameServer, uint c_unIpServer, char c_usPortServer, bool c_bSecure);
        public abstract void TerminateGameConnection(uint c_unIpServer, char c_usPortServer);
        public abstract void TrackAppUsageEvent(ulong c_gameId, int c_eAppUsageEvent, string c_pchExtraInfo);
        public abstract bool GetUserDataFolder(string c_pchBuffer, int c_cubBuffer);
        public abstract void StartVoiceRecording();
        public abstract void StopVoiceRecording();
        public abstract uint GetAvailableVoice(ref uint c_pcbCompressed, ref uint c_pcbUncompressed, uint c_nUncompressedVoiceDesiredSampleRate);
        public abstract uint GetVoice(bool c_bWantCompressed, IntPtr c_pDestBuffer, uint c_cbDestBufferSize, ref uint c_nBytesWritten, bool c_bWantUncompressed, IntPtr c_pUncompressedDestBuffer, uint c_cbUncompressedDestBufferSize, ref uint c_nUncompressBytesWritten, uint c_nUncompressedVoiceDesiredSampleRate);
        public abstract uint DecompressVoice(IntPtr c_pCompressed, uint c_cbCompressed, IntPtr c_pDestBuffer, uint c_cbDestBufferSize, ref uint c_nBytesWritten, uint c_nDesiredSampleRate);
        public abstract uint GetVoiceOptimalSampleRate();
        public abstract uint GetAuthSessionTicket(IntPtr c_pTicket, int c_cbMaxTicket, ref uint c_pcbTicket);
        public abstract uint BeginAuthSession(IntPtr c_pAuthTicket, int c_cbAuthTicket, ulong c_steamId);
        public abstract void EndAuthSession(ulong c_steamId);
        public abstract void CancelAuthTicket(uint c_hAuthTicket);
        public abstract uint UserHasLicenseForApp(ulong c_steamId, uint c_appId);
        public abstract bool BIsBehindNat();
        public abstract void AdvertiseGame(ulong c_steamIdGameServer, uint c_unIpServer, char c_usPortServer);
        public abstract ulong RequestEncryptedAppTicket(IntPtr c_pDataToInclude, int c_cbDataToInclude);
        public abstract bool GetEncryptedAppTicket(IntPtr c_pTicket, int c_cbMaxTicket, ref uint c_pcbTicket);
        public abstract int GetGameBadgeLevel(int c_nSeries, bool c_bFoil);
        public abstract int GetPlayerSteamLevel();
        public abstract ulong RequestStoreAuthUrl(string c_pchRedirectUrl);
        public abstract bool BIsPhoneVerified();
        public abstract bool BIsTwoFactorEnabled();
        public abstract bool BIsPhoneIdentifying();
        public abstract bool BIsPhoneRequiringVerification();
    }
}