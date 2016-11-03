//   !!  // Steamworks.Core - SteamMatchmakingPingResponse.cs
// *.-". // Created: 2016-10-20 [7:05 PM]
//  | |  // Copyright 2016 // MIT License // The Fox Council 
// Modified by: Fox Diller on 2016-10-22 @ 3:03 PM

#region Usings

using System;
using System.Runtime.InteropServices;

#endregion

namespace Steamworks.Core
{
    public class SteamMatchmakingPingResponse : ISteamMatchmakingPingResponse
    {
        private readonly IntPtr m_instancePtr;

        public SteamMatchmakingPingResponse(IntPtr c_instancePtr)
        {
            m_instancePtr = c_instancePtr;
        }

        private void CheckIfUsable()
        {
            if (m_instancePtr == IntPtr.Zero)
            {
                throw new InvalidOperationException("Steam MatchmakingPingResponse Not Initialized!");
            }
        }

        #region Native Methods

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMatchmakingPingResponse_ServerResponded")]
        private static extern void SteamAPI_ISteamMatchmakingPingResponse_ServerResponded(IntPtr c_instancePtr, IntPtr c_server);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMatchmakingPingResponse_ServerFailedToRespond")]
        private static extern void SteamAPI_ISteamMatchmakingPingResponse_ServerFailedToRespond(IntPtr c_instancePtr);

        #endregion

        #region Overrides of ISteamMatchmakingPingResponse

        public override IntPtr GetIntPtr()
        {
            return m_instancePtr;
        }

        public override void ServerResponded(IntPtr c_server)
        {
            CheckIfUsable();

            SteamAPI_ISteamMatchmakingPingResponse_ServerResponded(m_instancePtr, c_server);
        }

        public override void ServerFailedToRespond()
        {
            CheckIfUsable();

            SteamAPI_ISteamMatchmakingPingResponse_ServerFailedToRespond(m_instancePtr);
        }

        #endregion
    }

    public abstract class ISteamMatchmakingPingResponse
    {
        public abstract IntPtr GetIntPtr();
        public abstract void ServerResponded(IntPtr c_server);
        public abstract void ServerFailedToRespond();
    }
}