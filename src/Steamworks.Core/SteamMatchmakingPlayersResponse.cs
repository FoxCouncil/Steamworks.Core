//   !!  // Steamworks.Core - SteamMatchmakingPlayersResponse.cs
// *.-". // Created: 2016-10-20 [7:07 PM]
//  | |  // Copyright 2016 // MIT License // The Fox Council 
// Modified by: Fox Diller on 2016-10-22 @ 3:03 PM

#region Usings

using System;
using System.Runtime.InteropServices;

#endregion

namespace Steamworks.Core
{
    public class SteamMatchmakingPlayersResponse : ISteamMatchmakingPlayersResponse
    {
        private readonly IntPtr m_instancePtr;

        public SteamMatchmakingPlayersResponse(IntPtr c_instancePtr)
        {
            m_instancePtr = c_instancePtr;
        }

        private void CheckIfUsable()
        {
            if (m_instancePtr == IntPtr.Zero)
            {
                throw new InvalidOperationException("Steam MatchmakingPlayersResponse Not Initialized!");
            }
        }

        #region Native Methods

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMatchmakingPlayersResponse_AddPlayerToList")]
        private static extern void SteamAPI_ISteamMatchmakingPlayersResponse_AddPlayerToList(IntPtr c_instancePtr, SafeUtf8String c_pchName, int c_nScore, float c_flTimePlayed);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMatchmakingPlayersResponse_PlayersFailedToRespond")]
        private static extern void SteamAPI_ISteamMatchmakingPlayersResponse_PlayersFailedToRespond(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMatchmakingPlayersResponse_PlayersRefreshComplete")]
        private static extern void SteamAPI_ISteamMatchmakingPlayersResponse_PlayersRefreshComplete(IntPtr c_instancePtr);

        #endregion

        #region Overrides of ISteamMatchmakingPlayersResponse

        public override IntPtr GetIntPtr()
        {
            return m_instancePtr;
        }

        public override void AddPlayerToList(string c_pchName, int c_nScore, float c_flTimePlayed)
        {
            CheckIfUsable();

            SteamAPI_ISteamMatchmakingPlayersResponse_AddPlayerToList(m_instancePtr, new SafeUtf8String(c_pchName), c_nScore, c_flTimePlayed);
        }

        public override void PlayersFailedToRespond()
        {
            CheckIfUsable();

            SteamAPI_ISteamMatchmakingPlayersResponse_PlayersFailedToRespond(m_instancePtr);
        }

        public override void PlayersRefreshComplete()
        {
            CheckIfUsable();

            SteamAPI_ISteamMatchmakingPlayersResponse_PlayersRefreshComplete(m_instancePtr);
        }

        #endregion
    }

    public abstract class ISteamMatchmakingPlayersResponse
    {
        public abstract IntPtr GetIntPtr();
        public abstract void AddPlayerToList(string c_pchName, int c_nScore, float c_flTimePlayed);
        public abstract void PlayersFailedToRespond();
        public abstract void PlayersRefreshComplete();
    }
}