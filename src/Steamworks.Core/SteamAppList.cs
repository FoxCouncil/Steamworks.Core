//   !!  // Steamworks.Core - SteamAppList.cs
// *.-". // Created: 2016-10-22 [2:36 PM]
//  | |  // Copyright 2016 // MIT License // The Fox Council 
// Modified by: Fox Diller on 2016-10-22 @ 3:03 PM

#region Usings

using System;
using System.Runtime.InteropServices;
using System.Text;

#endregion

namespace Steamworks.Core
{
    public class SteamAppList : ISteamAppList
    {
        private readonly IntPtr m_instancePtr;

        public SteamAppList(IntPtr c_instancePtr)
        {
            m_instancePtr = c_instancePtr;
        }

        private void CheckIfUsable()
        {
            if (m_instancePtr == IntPtr.Zero)
            {
                throw new InvalidOperationException("Steam App List Not Initialized!");
            }
        }

        #region Native Method

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamAppList_GetNumInstalledApps")]
        private static extern uint SteamAPI_ISteamAppList_GetNumInstalledApps(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamAppList_GetInstalledApps")]
        private static extern uint SteamAPI_ISteamAppList_GetInstalledApps(IntPtr c_instancePtr, ref uint c_pvecAppId, uint c_unMaxAppIDs);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamAppList_GetAppName")]
        private static extern int SteamAPI_ISteamAppList_GetAppName(IntPtr c_instancePtr, uint c_nAppId, StringBuilder c_pchName, int c_cchNameMax);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamAppList_GetAppInstallDir")]
        private static extern int SteamAPI_ISteamAppList_GetAppInstallDir(IntPtr c_instancePtr, uint c_nAppId, SafeUtf8String c_pchDirectory, int c_cchNameMax);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamAppList_GetAppBuildId")]
        private static extern int SteamAPI_ISteamAppList_GetAppBuildId(IntPtr c_instancePtr, uint c_nAppId);

        #endregion

        #region Overrides of ISteamAppList

        public override IntPtr GetIntPtr()
        {
            return m_instancePtr;
        }

        public override uint GetNumInstalledApps()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamAppList_GetNumInstalledApps(m_instancePtr);

            return a_result;
        }

        public override uint GetInstalledApps(ref uint c_pvecAppId, uint c_unMaxAppIDs)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamAppList_GetInstalledApps(m_instancePtr, ref c_pvecAppId, c_unMaxAppIDs);

            return a_result;
        }

        public override int GetAppName(uint c_nAppId, StringBuilder c_pchName, int c_cchNameMax)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamAppList_GetAppName(m_instancePtr, c_nAppId, c_pchName, c_cchNameMax);

            return a_result;
        }

        public override int GetAppInstallDir(uint c_nAppId, string c_pchDirectory, int c_cchNameMax)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamAppList_GetAppInstallDir(m_instancePtr, c_nAppId, new SafeUtf8String(c_pchDirectory), c_cchNameMax);

            return a_result;
        }

        public override int GetAppBuildId(uint c_nAppId)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamAppList_GetAppBuildId(m_instancePtr, c_nAppId);

            return a_result;
        }

        #endregion
    }

    public abstract class ISteamAppList
    {
        public abstract IntPtr GetIntPtr();
        public abstract uint GetNumInstalledApps();
        public abstract uint GetInstalledApps(ref uint c_pvecAppId, uint c_unMaxAppIDs);
        public abstract int GetAppName(uint c_nAppId, StringBuilder c_pchName, int c_cchNameMax);
        public abstract int GetAppInstallDir(uint c_nAppId, string c_pchDirectory, int c_cchNameMax);
        public abstract int GetAppBuildId(uint c_nAppId);
    }
}