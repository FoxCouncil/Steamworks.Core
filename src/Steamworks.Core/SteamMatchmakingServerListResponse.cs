//   !!  // Steamworks.Core - SteamMatchmakingServerListResponse.cs
// *.-". // Created: 2016-10-20 [7:00 PM]
//  | |  // Copyright 2016 // MIT License // The Fox Council 
// Modified by: Fox Diller on 2016-10-22 @ 3:03 PM

#region Usings

using System;
using System.Runtime.InteropServices;

#endregion

namespace Steamworks.Core
{
    public class SteamMatchmakingServerListResponse : ISteamMatchmakingServerListResponse
    {
        private readonly IntPtr m_instancePtr;

        public SteamMatchmakingServerListResponse(IntPtr c_instancePtr)
        {
            m_instancePtr = c_instancePtr;
        }

        private void CheckIfUsable()
        {
            if (m_instancePtr == IntPtr.Zero)
            {
                throw new InvalidOperationException("Steam MatchmakingServerListResponse Not Initialized!");
            }
        }

        #region Native Methods

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMatchmakingServerListResponse_ServerResponded")]
        private static extern void SteamAPI_ISteamMatchmakingServerListResponse_ServerResponded(IntPtr c_instancePtr, uint c_hRequest, int c_iServer);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMatchmakingServerListResponse_ServerFailedToRespond")]
        private static extern void SteamAPI_ISteamMatchmakingServerListResponse_ServerFailedToRespond(IntPtr c_instancePtr, uint c_hRequest, int c_iServer);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMatchmakingServerListResponse_RefreshComplete")]
        private static extern void SteamAPI_ISteamMatchmakingServerListResponse_RefreshComplete(IntPtr c_instancePtr, uint c_hRequest, uint c_response);

        #endregion

        #region Overrides of ISteamMatchmakingServerListResponse

        public override IntPtr GetIntPtr()
        {
            return m_instancePtr;
        }

        public override void ServerResponded(uint c_hRequest, int c_iServer)
        {
            CheckIfUsable();

            SteamAPI_ISteamMatchmakingServerListResponse_ServerResponded(m_instancePtr, c_hRequest, c_iServer);
        }

        public override void ServerFailedToRespond(uint c_hRequest, int c_iServer)
        {
            CheckIfUsable();

            SteamAPI_ISteamMatchmakingServerListResponse_ServerFailedToRespond(m_instancePtr, c_hRequest, c_iServer);
        }

        public override void RefreshComplete(uint c_hRequest, uint c_response)
        {
            CheckIfUsable();

            SteamAPI_ISteamMatchmakingServerListResponse_RefreshComplete(m_instancePtr, c_hRequest, c_response);
        }

        #endregion
    }


    public abstract class ISteamMatchmakingServerListResponse
    {
        public abstract IntPtr GetIntPtr();
        public abstract void ServerResponded(uint c_hRequest, int c_iServer);
        public abstract void ServerFailedToRespond(uint c_hRequest, int c_iServer);
        public abstract void RefreshComplete(uint c_hRequest, uint c_response);
    }
}