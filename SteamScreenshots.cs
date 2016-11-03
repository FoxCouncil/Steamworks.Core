//   !!  // Steamworks.Core - SteamScreenshots.cs
// *.-". // Created: 2016-10-20 [8:44 PM]
//  | |  // Copyright 2016 // MIT License // The Fox Council 
// Modified by: Fox Diller on 2016-10-22 @ 3:03 PM

#region Usings

using System;
using System.Runtime.InteropServices;

#endregion

namespace Steamworks.Core
{
    public class SteamScreenshots : ISteamScreenshots
    {
        private readonly IntPtr m_instancePtr;

        public SteamScreenshots(IntPtr c_instancePtr)
        {
            m_instancePtr = c_instancePtr;
        }

        private void CheckIfUsable()
        {
            if (m_instancePtr == IntPtr.Zero)
            {
                throw new InvalidOperationException("Steam Screenshots Not Initialized!");
            }
        }

        #region Native Methods

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamScreenshots_WriteScreenshot")]
        private static extern uint SteamAPI_ISteamScreenshots_WriteScreenshot(IntPtr c_instancePtr, IntPtr c_pubRgb, uint c_cubRgb, int c_nWidth, int c_nHeight);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamScreenshots_AddScreenshotToLibrary")]
        private static extern uint SteamAPI_ISteamScreenshots_AddScreenshotToLibrary(IntPtr c_instancePtr, SafeUtf8String c_pchFilename, SafeUtf8String c_pchThumbnailFilename, int c_nWidth, int c_nHeight);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamScreenshots_TriggerScreenshot")]
        private static extern void SteamAPI_ISteamScreenshots_TriggerScreenshot(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamScreenshots_HookScreenshots")]
        private static extern void SteamAPI_ISteamScreenshots_HookScreenshots(IntPtr c_instancePtr, bool c_bHook);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamScreenshots_SetLocation")]
        private static extern bool SteamAPI_ISteamScreenshots_SetLocation(IntPtr c_instancePtr, uint c_hScreenshot, SafeUtf8String c_pchLocation);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamScreenshots_TagUser")]
        private static extern bool SteamAPI_ISteamScreenshots_TagUser(IntPtr c_instancePtr, uint c_hScreenshot, ulong c_steamId);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamScreenshots_TagPublishedFile")]
        private static extern bool SteamAPI_ISteamScreenshots_TagPublishedFile(IntPtr c_instancePtr, uint c_hScreenshot, ulong c_unPublishedFileId);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamScreenshots_IsScreenshotsHooked")]
        private static extern bool SteamAPI_ISteamScreenshots_IsScreenshotsHooked(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamScreenshots_AddVRScreenshotToLibrary")]
        private static extern uint SteamAPI_ISteamScreenshots_AddVRScreenshotToLibrary(IntPtr c_instancePtr, uint c_eType, SafeUtf8String c_pchFilename, SafeUtf8String c_pchVrFilename);

        #endregion

        #region Overrides of ISteamScreenshots

        public override IntPtr GetIntPtr()
        {
            return m_instancePtr;
        }

        public override uint WriteScreenshot(IntPtr c_pubRgb, uint c_cubRgb, int c_nWidth, int c_nHeight)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamScreenshots_WriteScreenshot(m_instancePtr, c_pubRgb, c_cubRgb, c_nWidth, c_nHeight);

            return a_result;
        }

        public override uint AddScreenshotToLibrary(string c_pchFilename, string c_pchThumbnailFilename, int c_nWidth, int c_nHeight)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamScreenshots_AddScreenshotToLibrary(m_instancePtr, new SafeUtf8String(c_pchFilename), new SafeUtf8String(c_pchThumbnailFilename), c_nWidth, c_nHeight);

            return a_result;
        }

        public override void TriggerScreenshot()
        {
            CheckIfUsable();

            SteamAPI_ISteamScreenshots_TriggerScreenshot(m_instancePtr);
        }

        public override void HookScreenshots(bool c_bHook)
        {
            CheckIfUsable();

            SteamAPI_ISteamScreenshots_HookScreenshots(m_instancePtr, c_bHook);
        }

        public override bool SetLocation(uint c_hScreenshot, string c_pchLocation)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamScreenshots_SetLocation(m_instancePtr, c_hScreenshot, new SafeUtf8String(c_pchLocation));

            return a_result;
        }

        public override bool TagUser(uint c_hScreenshot, ulong c_steamId)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamScreenshots_TagUser(m_instancePtr, c_hScreenshot, c_steamId);

            return a_result;
        }

        public override bool TagPublishedFile(uint c_hScreenshot, ulong c_unPublishedFileId)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamScreenshots_TagPublishedFile(m_instancePtr, c_hScreenshot, c_unPublishedFileId);

            return a_result;
        }

        public override bool IsScreenshotsHooked()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamScreenshots_IsScreenshotsHooked(m_instancePtr);

            return a_result;
        }

        public override uint AddVrScreenshotToLibrary(uint c_eType, string c_pchFilename, string c_pchVrFilename)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamScreenshots_AddVRScreenshotToLibrary(m_instancePtr, c_eType, new SafeUtf8String(c_pchFilename), new SafeUtf8String(c_pchVrFilename));

            return a_result;
        }

        #endregion
    }

    public abstract class ISteamScreenshots
    {
        public abstract IntPtr GetIntPtr();
        public abstract uint WriteScreenshot(IntPtr c_pubRgb, uint c_cubRgb, int c_nWidth, int c_nHeight);
        public abstract uint AddScreenshotToLibrary(string c_pchFilename, string c_pchThumbnailFilename, int c_nWidth, int c_nHeight);
        public abstract void TriggerScreenshot();
        public abstract void HookScreenshots(bool c_bHook);
        public abstract bool SetLocation(uint c_hScreenshot, string c_pchLocation);
        public abstract bool TagUser(uint c_hScreenshot, ulong c_steamId);
        public abstract bool TagPublishedFile(uint c_hScreenshot, ulong c_unPublishedFileId);
        public abstract bool IsScreenshotsHooked();
        public abstract uint AddVrScreenshotToLibrary(uint c_eType, string c_pchFilename, string c_pchVrFilename);
    }
}