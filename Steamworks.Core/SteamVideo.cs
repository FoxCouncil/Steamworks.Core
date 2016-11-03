//   !!  // Steamworks.Core - SteamVideo.cs
// *.-". // Created: 2016-10-22 [10:02 PM]
//  | |  // Copyright 2016 // MIT License // The Fox Council 
// Modified by: Fox Diller on 2016-10-22 @ 10:12 PM

#region Usings

using System;
using System.Runtime.InteropServices;

#endregion

namespace Steamworks.Core
{
    public class SteamVideo : ISteamVideo
    {
        private readonly IntPtr m_instancePtr;

        public SteamVideo(IntPtr c_instancePtr)
        {
            m_instancePtr = c_instancePtr;
        }

        private void CheckIfUsable()
        {
            if (m_instancePtr == IntPtr.Zero)
            {
                throw new InvalidOperationException("Steam Video Not Initialized!");
            }
        }

        #region Native Methods

        [DllImport("Steam_api", EntryPoint = "SteamAPI_ISteamVideo_GetVideoURL")]
        private static extern void SteamAPI_ISteamVideo_GetVideoURL(IntPtr c_instancePtr, uint c_unVideoAppId);

        [DllImport("Steam_api", EntryPoint = "SteamAPI_ISteamVideo_IsBroadcasting")]
        private static extern bool SteamAPI_ISteamVideo_IsBroadcasting(IntPtr c_instancePtr, ref int c_pnNumViewers);

        #endregion

        #region Overrides of ISteamVideo

        public override IntPtr GetIntPtr()
        {
            return m_instancePtr;
        }

        public override void GetVideoUrl(uint c_unVideoAppId)
        {
            CheckIfUsable();

            SteamAPI_ISteamVideo_GetVideoURL(m_instancePtr, c_unVideoAppId);
        }

        public override bool IsBroadcasting(ref int c_pnNumViewers)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamVideo_IsBroadcasting(m_instancePtr, ref c_pnNumViewers);

            return a_result;
        }

        #endregion
    }

    public abstract class ISteamVideo
    {
        public abstract IntPtr GetIntPtr();
        public abstract void GetVideoUrl(uint c_unVideoAppId);
        public abstract bool IsBroadcasting(ref int c_pnNumViewers);
    }
}