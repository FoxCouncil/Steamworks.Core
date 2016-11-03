//   !!  // Steamworks.Core - SteamUnifiedMessages.cs
// *.-". // Created: 2016-10-22 [1:08 AM]
//  | |  // Copyright 2016 // MIT License // The Fox Council 
// Modified by: Fox Diller on 2016-10-22 @ 3:03 PM

#region Usings

using System;
using System.Runtime.InteropServices;

#endregion

namespace Steamworks.Core
{
    public class SteamUnifiedMessages : ISteamUnifiedMessages
    {
        private readonly IntPtr m_instancePtr;

        public SteamUnifiedMessages(IntPtr c_instancePtr)
        {
            m_instancePtr = c_instancePtr;
        }

        private void CheckIfUsable()
        {
            if (m_instancePtr == IntPtr.Zero)
            {
                throw new InvalidOperationException("Steam Unified Messages Not Initialized!");
            }
        }

        #region Native Methods

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUnifiedMessages_SendMethod")]
        private static extern ulong SteamAPI_ISteamUnifiedMessages_SendMethod(IntPtr c_instancePtr, SafeUtf8String c_pchServiceMethod, IntPtr c_pRequestBuffer, uint c_unRequestBufferSize, ulong c_unContext);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUnifiedMessages_GetMethodResponseInfo")]
        private static extern bool SteamAPI_ISteamUnifiedMessages_GetMethodResponseInfo(IntPtr c_instancePtr, ulong c_hHandle, ref uint c_punResponseSize, ref uint c_peResult);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUnifiedMessages_GetMethodResponseData")]
        private static extern bool SteamAPI_ISteamUnifiedMessages_GetMethodResponseData(IntPtr c_instancePtr, ulong c_hHandle, IntPtr c_pResponseBuffer, uint c_unResponseBufferSize, bool c_bAutoRelease);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUnifiedMessages_ReleaseMethod")]
        private static extern bool SteamAPI_ISteamUnifiedMessages_ReleaseMethod(IntPtr c_instancePtr, ulong c_hHandle);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUnifiedMessages_SendNotification")]
        private static extern bool SteamAPI_ISteamUnifiedMessages_SendNotification(IntPtr c_instancePtr, SafeUtf8String c_pchServiceNotification, IntPtr c_pNotificationBuffer, uint c_unNotificationBufferSize);

        #endregion

        #region Overrides of ISteamUnifiedMessages

        public override IntPtr GetIntPtr()
        {
            return m_instancePtr;
        }

        public override ulong SendMethod(string c_pchServiceMethod, IntPtr c_pRequestBuffer, uint c_unRequestBufferSize, ulong c_unContext)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUnifiedMessages_SendMethod(m_instancePtr, new SafeUtf8String(c_pchServiceMethod), c_pRequestBuffer, c_unRequestBufferSize, c_unContext);

            return a_result;
        }

        public override bool GetMethodResponseInfo(ulong c_hHandle, ref uint c_punResponseSize, ref uint c_peResult)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUnifiedMessages_GetMethodResponseInfo(m_instancePtr, c_hHandle, ref c_punResponseSize, ref c_peResult);

            return a_result;
        }

        public override bool GetMethodResponseData(ulong c_hHandle, IntPtr c_pResponseBuffer, uint c_unResponseBufferSize, bool c_bAutoRelease)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUnifiedMessages_GetMethodResponseData(m_instancePtr, c_hHandle, c_pResponseBuffer, c_unResponseBufferSize, c_bAutoRelease);

            return a_result;
        }

        public override bool ReleaseMethod(ulong c_hHandle)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUnifiedMessages_ReleaseMethod(m_instancePtr, c_hHandle);

            return a_result;
        }

        public override bool SendNotification(string c_pchServiceNotification, IntPtr c_pNotificationBuffer, uint c_unNotificationBufferSize)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUnifiedMessages_SendNotification(m_instancePtr, new SafeUtf8String(c_pchServiceNotification), c_pNotificationBuffer, c_unNotificationBufferSize);

            return a_result;
        }

        #endregion
    }

    public abstract class ISteamUnifiedMessages
    {
        public abstract IntPtr GetIntPtr();
        public abstract ulong SendMethod(string c_pchServiceMethod, IntPtr c_pRequestBuffer, uint c_unRequestBufferSize, ulong c_unContext);
        public abstract bool GetMethodResponseInfo(ulong c_hHandle, ref uint c_punResponseSize, ref uint c_peResult);
        public abstract bool GetMethodResponseData(ulong c_hHandle, IntPtr c_pResponseBuffer, uint c_unResponseBufferSize, bool c_bAutoRelease);
        public abstract bool ReleaseMethod(ulong c_hHandle);
        public abstract bool SendNotification(string c_pchServiceNotification, IntPtr c_pNotificationBuffer, uint c_unNotificationBufferSize);
    }
}