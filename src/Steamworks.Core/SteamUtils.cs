//   !!  // Steamworks.Core - SteamUtils.cs
// *.-". // Created: 2016-10-18 [11:00 PM]
//  | |  // Copyright 2016 // MIT License // The Fox Council 
// Modified by: Fox Diller on 2016-10-22 @ 3:03 PM

#region Usings

using System;
using System.Runtime.InteropServices;

#endregion

namespace Steamworks.Core
{
    public class SteamUtils : ISteamUtils
    {
        private readonly IntPtr m_instancePtr;

        public SteamUtils(IntPtr c_instancePtr)
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

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUtils_GetSecondsSinceAppActive")]
        private static extern uint SteamAPI_ISteamUtils_GetSecondsSinceAppActive(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUtils_GetSecondsSinceComputerActive")]
        private static extern uint SteamAPI_ISteamUtils_GetSecondsSinceComputerActive(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUtils_GetConnectedUniverse")]
        private static extern int SteamAPI_ISteamUtils_GetConnectedUniverse(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUtils_GetServerRealTime")]
        private static extern uint SteamAPI_ISteamUtils_GetServerRealTime(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUtils_GetIPCountry")]
        private static extern IntPtr SteamAPI_ISteamUtils_GetIPCountry(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUtils_GetImageSize")]
        private static extern bool SteamAPI_ISteamUtils_GetImageSize(IntPtr c_instancePtr, int c_iImage, ref uint c_pnWidth, ref uint c_pnHeight);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUtils_GetImageRGBA")]
        private static extern bool SteamAPI_ISteamUtils_GetImageRGBA(IntPtr c_instancePtr, int c_iImage, IntPtr c_pubDest, int c_nDestBufferSize);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUtils_GetCSERIPPort")]
        private static extern bool SteamAPI_ISteamUtils_GetCSERIPPort(IntPtr c_instancePtr, ref uint c_unIp, ref char c_usPort);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUtils_GetCurrentBatteryPower")]
        private static extern byte SteamAPI_ISteamUtils_GetCurrentBatteryPower(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUtils_GetAppID")]
        private static extern uint SteamAPI_ISteamUtils_GetAppID(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUtils_SetOverlayNotificationPosition")]
        private static extern void SteamAPI_ISteamUtils_SetOverlayNotificationPosition(IntPtr c_instancePtr, uint c_eNotificationPosition);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUtils_IsAPICallCompleted")]
        private static extern bool SteamAPI_ISteamUtils_IsAPICallCompleted(IntPtr c_instancePtr, ulong c_hSteamApiCall, ref bool c_pbFailed);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUtils_GetAPICallFailureReason")]
        private static extern int SteamAPI_ISteamUtils_GetAPICallFailureReason(IntPtr c_instancePtr, ulong c_hSteamApiCall);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUtils_GetAPICallResult")]
        private static extern bool SteamAPI_ISteamUtils_GetAPICallResult(IntPtr c_instancePtr, ulong c_hSteamApiCall, IntPtr c_pCallback, int c_cubCallback, int c_iCallbackExpected, ref bool c_pbFailed);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUtils_GetIPCCallCount")]
        private static extern uint SteamAPI_ISteamUtils_GetIPCCallCount(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUtils_SetWarningMessageHook")]
        private static extern void SteamAPI_ISteamUtils_SetWarningMessageHook(IntPtr c_instancePtr, IntPtr c_pFunction);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUtils_IsOverlayEnabled")]
        private static extern bool SteamAPI_ISteamUtils_IsOverlayEnabled(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUtils_BOverlayNeedsPresent")]
        private static extern bool SteamAPI_ISteamUtils_BOverlayNeedsPresent(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUtils_CheckFileSignature")]
        private static extern ulong SteamAPI_ISteamUtils_CheckFileSignature(IntPtr c_instancePtr, SafeUtf8String c_szFileName);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUtils_ShowGamepadTextInput")]
        private static extern bool SteamAPI_ISteamUtils_ShowGamepadTextInput(IntPtr c_instancePtr, int c_eInputMode, int c_eLineInputMode, SafeUtf8String c_pchDescription, uint c_unCharMax, SafeUtf8String c_pchExistingText);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUtils_GetEnteredGamepadTextLength")]
        private static extern uint SteamAPI_ISteamUtils_GetEnteredGamepadTextLength(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUtils_GetEnteredGamepadTextInput")]
        private static extern bool SteamAPI_ISteamUtils_GetEnteredGamepadTextInput(IntPtr c_instancePtr, SafeUtf8String c_pchText, uint c_cchText);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUtils_GetSteamUILanguage")]
        private static extern IntPtr SteamAPI_ISteamUtils_GetSteamUILanguage(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUtils_IsSteamRunningInVR")]
        private static extern bool SteamAPI_ISteamUtils_IsSteamRunningInVR(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUtils_SetOverlayNotificationInset")]
        private static extern void SteamAPI_ISteamUtils_SetOverlayNotificationInset(IntPtr c_instancePtr, int c_nHorizontalInset, int c_nVerticalInset);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUtils_IsSteamInBigPictureMode")]
        private static extern bool SteamAPI_ISteamUtils_IsSteamInBigPictureMode(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUtils_StartVRDashboard")]
        private static extern void SteamAPI_ISteamUtils_StartVRDashboard(IntPtr c_instancePtr);

        #endregion

        #region Overrides of ISteamUtils

        public override IntPtr GetIntPtr()
        {
            return m_instancePtr;
        }

        public override uint GetSecondsSinceAppActive()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUtils_GetSecondsSinceAppActive(m_instancePtr);

            return a_result;
        }

        public override uint GetSecondsSinceComputerActive()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUtils_GetSecondsSinceComputerActive(m_instancePtr);

            return a_result;
        }

        public override int GetConnectedUniverse()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUtils_GetConnectedUniverse(m_instancePtr);

            return a_result;
        }

        public override uint GetServerRealTime()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUtils_GetServerRealTime(m_instancePtr);

            return a_result;
        }

        public override string GetIpCountry()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUtils_GetIPCountry(m_instancePtr);

            return SafeUtf8String.ToString(a_result);
        }

        public override bool GetImageSize(int c_iImage, ref uint c_pnWidth, ref uint c_pnHeight)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUtils_GetImageSize(m_instancePtr, c_iImage, ref c_pnWidth, ref c_pnHeight);

            return a_result;
        }

        public override bool GetImageRgba(int c_iImage, IntPtr c_pubDest, int c_nDestBufferSize)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUtils_GetImageRGBA(m_instancePtr, c_iImage, c_pubDest, c_nDestBufferSize);

            return a_result;
        }

        public override bool GetCseripPort(ref uint c_unIp, ref char c_usPort)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUtils_GetCSERIPPort(m_instancePtr, ref c_unIp, ref c_usPort);

            return a_result;
        }

        public override byte GetCurrentBatteryPower()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUtils_GetCurrentBatteryPower(m_instancePtr);

            return a_result;
        }

        public override uint GetAppId()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUtils_GetAppID(m_instancePtr);

            return a_result;
        }

        public override void SetOverlayNotificationPosition(uint c_eNotificationPosition)
        {
            CheckIfUsable();

            SteamAPI_ISteamUtils_SetOverlayNotificationPosition(m_instancePtr, c_eNotificationPosition);
        }

        public override bool IsApiCallCompleted(ulong c_hSteamApiCall, ref bool c_pbFailed)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUtils_IsAPICallCompleted(m_instancePtr, c_hSteamApiCall, ref c_pbFailed);

            return a_result;
        }

        public override int GetApiCallFailureReason(ulong c_hSteamApiCall)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUtils_GetAPICallFailureReason(m_instancePtr, c_hSteamApiCall);

            return a_result;
        }

        public override bool GetApiCallResult(ulong c_hSteamApiCall, IntPtr c_pCallback, int c_cubCallback, int c_iCallbackExpected, ref bool c_pbFailed)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUtils_GetAPICallResult(m_instancePtr, c_hSteamApiCall, c_pCallback, c_cubCallback, c_iCallbackExpected, ref c_pbFailed);

            return a_result;
        }

        public override uint GetIpcCallCount()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUtils_GetIPCCallCount(m_instancePtr);

            return a_result;
        }

        public override void SetWarningMessageHook(IntPtr c_pFunction)
        {
            CheckIfUsable();

            SteamAPI_ISteamUtils_SetWarningMessageHook(m_instancePtr, c_pFunction);
        }

        public override bool IsOverlayEnabled()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUtils_IsOverlayEnabled(m_instancePtr);

            return a_result;
        }

        public override bool BOverlayNeedsPresent()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUtils_BOverlayNeedsPresent(m_instancePtr);

            return a_result;
        }

        public override ulong CheckFileSignature(string c_szFileName)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUtils_CheckFileSignature(m_instancePtr, new SafeUtf8String(c_szFileName));

            return a_result;
        }

        public override bool ShowGamepadTextInput(int c_eInputMode, int c_eLineInputMode, string c_pchDescription, uint c_unCharMax, string c_pchExistingText)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUtils_ShowGamepadTextInput(m_instancePtr, c_eInputMode, c_eLineInputMode, new SafeUtf8String(c_pchDescription), c_unCharMax, new SafeUtf8String(c_pchExistingText));

            return a_result;
        }

        public override uint GetEnteredGamepadTextLength()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUtils_GetEnteredGamepadTextLength(m_instancePtr);

            return a_result;
        }

        public override bool GetEnteredGamepadTextInput(string c_pchText, uint c_cchText)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUtils_GetEnteredGamepadTextInput(m_instancePtr, new SafeUtf8String(c_pchText), c_cchText);

            return a_result;
        }

        public override string GetSteamUiLanguage()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUtils_GetSteamUILanguage(m_instancePtr);

            return SafeUtf8String.ToString(a_result);
        }

        public override bool IsSteamRunningInVr()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUtils_IsSteamRunningInVR(m_instancePtr);

            return a_result;
        }

        public override void SetOverlayNotificationInset(int c_nHorizontalInset, int c_nVerticalInset)
        {
            CheckIfUsable();

            SteamAPI_ISteamUtils_SetOverlayNotificationInset(m_instancePtr, c_nHorizontalInset, c_nVerticalInset);
        }

        public override bool IsSteamInBigPictureMode()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUtils_IsSteamInBigPictureMode(m_instancePtr);

            return a_result;
        }

        public override void StartVrDashboard()
        {
            CheckIfUsable();

            SteamAPI_ISteamUtils_StartVRDashboard(m_instancePtr);
        }

        #endregion
    }

    public abstract class ISteamUtils
    {
        public abstract IntPtr GetIntPtr();
        public abstract uint GetSecondsSinceAppActive();
        public abstract uint GetSecondsSinceComputerActive();
        public abstract int GetConnectedUniverse();
        public abstract uint GetServerRealTime();
        public abstract string GetIpCountry();
        public abstract bool GetImageSize(int c_iImage, ref uint c_pnWidth, ref uint c_pnHeight);
        public abstract bool GetImageRgba(int c_iImage, IntPtr c_pubDest, int c_nDestBufferSize);
        public abstract bool GetCseripPort(ref uint c_unIp, ref char c_usPort);
        public abstract byte GetCurrentBatteryPower();
        public abstract uint GetAppId();
        public abstract void SetOverlayNotificationPosition(uint c_eNotificationPosition);
        public abstract bool IsApiCallCompleted(ulong c_hSteamApiCall, ref bool c_pbFailed);
        public abstract int GetApiCallFailureReason(ulong c_hSteamApiCall);
        public abstract bool GetApiCallResult(ulong c_hSteamApiCall, IntPtr c_pCallback, int c_cubCallback, int c_iCallbackExpected, ref bool c_pbFailed);
        public abstract uint GetIpcCallCount();
        public abstract void SetWarningMessageHook(IntPtr c_pFunction);
        public abstract bool IsOverlayEnabled();
        public abstract bool BOverlayNeedsPresent();
        public abstract ulong CheckFileSignature(string c_szFileName);
        public abstract bool ShowGamepadTextInput(int c_eInputMode, int c_eLineInputMode, string c_pchDescription, uint c_unCharMax, string c_pchExistingText);
        public abstract uint GetEnteredGamepadTextLength();
        public abstract bool GetEnteredGamepadTextInput(string c_pchText, uint c_cchText);
        public abstract string GetSteamUiLanguage();
        public abstract bool IsSteamRunningInVr();
        public abstract void SetOverlayNotificationInset(int c_nHorizontalInset, int c_nVerticalInset);
        public abstract bool IsSteamInBigPictureMode();
        public abstract void StartVrDashboard();
    }
}