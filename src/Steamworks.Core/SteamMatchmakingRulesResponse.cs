//   !!  // Steamworks.Core - SteamMatchmakingRulesResponse.cs
// *.-". // Created: 2016-10-20 [7:11 PM]
//  | |  // Copyright 2016 // MIT License // The Fox Council 
// Modified by: Fox Diller on 2016-10-22 @ 3:03 PM

#region Usings

using System;
using System.Runtime.InteropServices;

#endregion

namespace Steamworks.Core
{
    public class SteamMatchmakingRulesResponse : ISteamMatchmakingRulesResponse
    {
        private readonly IntPtr m_instancePtr;

        public SteamMatchmakingRulesResponse(IntPtr c_instancePtr)
        {
            m_instancePtr = c_instancePtr;
        }

        private void CheckIfUsable()
        {
            if (m_instancePtr == IntPtr.Zero)
            {
                throw new InvalidOperationException("Steam MatchmakingRulesResponse Not Initialized!");
            }
        }

        #region Native Methods

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMatchmakingRulesResponse_RulesResponded")]
        private static extern void SteamAPI_ISteamMatchmakingRulesResponse_RulesResponded(IntPtr c_instancePtr, SafeUtf8String c_pchRule, SafeUtf8String c_pchValue);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMatchmakingRulesResponse_RulesFailedToRespond")]
        private static extern void SteamAPI_ISteamMatchmakingRulesResponse_RulesFailedToRespond(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMatchmakingRulesResponse_RulesRefreshComplete")]
        private static extern void SteamAPI_ISteamMatchmakingRulesResponse_RulesRefreshComplete(IntPtr c_instancePtr);

        #endregion

        #region Overrides of ISteamMatchmakingRulesResponse

        public override IntPtr GetIntPtr()
        {
            return m_instancePtr;
            ;
        }

        public override void RulesResponded(string c_pchRule, string c_pchValue)
        {
            CheckIfUsable();

            SteamAPI_ISteamMatchmakingRulesResponse_RulesResponded(m_instancePtr, new SafeUtf8String(c_pchRule), new SafeUtf8String(c_pchValue));
        }

        public override void RulesFailedToRespond()
        {
            CheckIfUsable();

            SteamAPI_ISteamMatchmakingRulesResponse_RulesFailedToRespond(m_instancePtr);
        }

        public override void RulesRefreshComplete()
        {
            CheckIfUsable();

            SteamAPI_ISteamMatchmakingRulesResponse_RulesRefreshComplete(m_instancePtr);
        }

        #endregion
    }

    public abstract class ISteamMatchmakingRulesResponse
    {
        public abstract IntPtr GetIntPtr();
        public abstract void RulesResponded(string c_pchRule, string c_pchValue);
        public abstract void RulesFailedToRespond();
        public abstract void RulesRefreshComplete();
    }
}