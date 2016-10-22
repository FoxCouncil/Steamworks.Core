//   !!  // Steamworks.Core - SteamMusicRemote.cs
// *.-". // Created: 2016-10-22 [2:49 PM]
//  | |  // Copyright 2016 // MIT License // The Fox Council 
// Modified by: Fox Diller on 2016-10-22 @ 3:03 PM

#region Usings

using System;
using System.Runtime.InteropServices;

#endregion

namespace Steamworks.Core
{
    public class SteamMusicRemote : ISteamMusicRemote
    {
        private readonly IntPtr m_instancePtr;

        public SteamMusicRemote(IntPtr c_instancePtr)
        {
            m_instancePtr = c_instancePtr;
        }

        private void CheckIfUsable()
        {
            if (m_instancePtr == IntPtr.Zero)
            {
                throw new InvalidOperationException("Steam Music Remote Not Initialized!");
            }
        }

        #region Native Methods

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMusicRemote_RegisterSteamMusicRemote")]
        private static extern bool SteamAPI_ISteamMusicRemote_RegisterSteamMusicRemote(IntPtr c_instancePtr, SafeUtf8String c_pchName);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMusicRemote_DeregisterSteamMusicRemote")]
        private static extern bool SteamAPI_ISteamMusicRemote_DeregisterSteamMusicRemote(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMusicRemote_BIsCurrentMusicRemote")]
        private static extern bool SteamAPI_ISteamMusicRemote_BIsCurrentMusicRemote(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMusicRemote_BActivationSuccess")]
        private static extern bool SteamAPI_ISteamMusicRemote_BActivationSuccess(IntPtr c_instancePtr, bool c_bValue);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMusicRemote_SetDisplayName")]
        private static extern bool SteamAPI_ISteamMusicRemote_SetDisplayName(IntPtr c_instancePtr, SafeUtf8String c_pchDisplayName);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMusicRemote_SetPNGIcon_64x64")]
        private static extern bool SteamAPI_ISteamMusicRemote_SetPNGIcon_64x64(IntPtr c_instancePtr, IntPtr c_pvBuffer, uint c_cbBufferLength);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMusicRemote_EnablePlayPrevious")]
        private static extern bool SteamAPI_ISteamMusicRemote_EnablePlayPrevious(IntPtr c_instancePtr, bool c_bValue);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMusicRemote_EnablePlayNext")]
        private static extern bool SteamAPI_ISteamMusicRemote_EnablePlayNext(IntPtr c_instancePtr, bool c_bValue);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMusicRemote_EnableShuffled")]
        private static extern bool SteamAPI_ISteamMusicRemote_EnableShuffled(IntPtr c_instancePtr, bool c_bValue);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMusicRemote_EnableLooped")]
        private static extern bool SteamAPI_ISteamMusicRemote_EnableLooped(IntPtr c_instancePtr, bool c_bValue);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMusicRemote_EnableQueue")]
        private static extern bool SteamAPI_ISteamMusicRemote_EnableQueue(IntPtr c_instancePtr, bool c_bValue);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMusicRemote_EnablePlaylists")]
        private static extern bool SteamAPI_ISteamMusicRemote_EnablePlaylists(IntPtr c_instancePtr, bool c_bValue);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMusicRemote_UpdatePlaybackStatus")]
        private static extern bool SteamAPI_ISteamMusicRemote_UpdatePlaybackStatus(IntPtr c_instancePtr, int c_nStatus);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMusicRemote_UpdateShuffled")]
        private static extern bool SteamAPI_ISteamMusicRemote_UpdateShuffled(IntPtr c_instancePtr, bool c_bValue);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMusicRemote_UpdateLooped")]
        private static extern bool SteamAPI_ISteamMusicRemote_UpdateLooped(IntPtr c_instancePtr, bool c_bValue);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMusicRemote_UpdateVolume")]
        private static extern bool SteamAPI_ISteamMusicRemote_UpdateVolume(IntPtr c_instancePtr, float c_flValue);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMusicRemote_CurrentEntryWillChange")]
        private static extern bool SteamAPI_ISteamMusicRemote_CurrentEntryWillChange(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMusicRemote_CurrentEntryIsAvailable")]
        private static extern bool SteamAPI_ISteamMusicRemote_CurrentEntryIsAvailable(IntPtr c_instancePtr, bool c_bAvailable);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMusicRemote_UpdateCurrentEntryText")]
        private static extern bool SteamAPI_ISteamMusicRemote_UpdateCurrentEntryText(IntPtr c_instancePtr, SafeUtf8String c_pchText);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMusicRemote_UpdateCurrentEntryElapsedSeconds")]
        private static extern bool SteamAPI_ISteamMusicRemote_UpdateCurrentEntryElapsedSeconds(IntPtr c_instancePtr, int c_nValue);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMusicRemote_UpdateCurrentEntryCoverArt")]
        private static extern bool SteamAPI_ISteamMusicRemote_UpdateCurrentEntryCoverArt(IntPtr c_instancePtr, IntPtr c_pvBuffer, uint c_cbBufferLength);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMusicRemote_CurrentEntryDidChange")]
        private static extern bool SteamAPI_ISteamMusicRemote_CurrentEntryDidChange(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMusicRemote_QueueWillChange")]
        private static extern bool SteamAPI_ISteamMusicRemote_QueueWillChange(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMusicRemote_ResetQueueEntries")]
        private static extern bool SteamAPI_ISteamMusicRemote_ResetQueueEntries(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMusicRemote_SetQueueEntry")]
        private static extern bool SteamAPI_ISteamMusicRemote_SetQueueEntry(IntPtr c_instancePtr, int c_nId, int c_nPosition, SafeUtf8String c_pchEntryText);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMusicRemote_SetCurrentQueueEntry")]
        private static extern bool SteamAPI_ISteamMusicRemote_SetCurrentQueueEntry(IntPtr c_instancePtr, int c_nId);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMusicRemote_QueueDidChange")]
        private static extern bool SteamAPI_ISteamMusicRemote_QueueDidChange(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMusicRemote_PlaylistWillChange")]
        private static extern bool SteamAPI_ISteamMusicRemote_PlaylistWillChange(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMusicRemote_ResetPlaylistEntries")]
        private static extern bool SteamAPI_ISteamMusicRemote_ResetPlaylistEntries(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMusicRemote_SetPlaylistEntry")]
        private static extern bool SteamAPI_ISteamMusicRemote_SetPlaylistEntry(IntPtr c_instancePtr, int c_nId, int c_nPosition, SafeUtf8String c_pchEntryText);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMusicRemote_SetCurrentPlaylistEntry")]
        private static extern bool SteamAPI_ISteamMusicRemote_SetCurrentPlaylistEntry(IntPtr c_instancePtr, int c_nId);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMusicRemote_PlaylistDidChange")]
        private static extern bool SteamAPI_ISteamMusicRemote_PlaylistDidChange(IntPtr c_instancePtr);

        #endregion

        #region Overrides of ISteamMusicRemote

        public override IntPtr GetIntPtr()
        {
            return m_instancePtr;
        }

        public override bool RegisterSteamMusicRemote(string c_pchName)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamMusicRemote_RegisterSteamMusicRemote(m_instancePtr, new SafeUtf8String(c_pchName));

            return a_result;
        }

        public override bool DeregisterSteamMusicRemote()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamMusicRemote_DeregisterSteamMusicRemote(m_instancePtr);

            return a_result;
        }

        public override bool BIsCurrentMusicRemote()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamMusicRemote_BIsCurrentMusicRemote(m_instancePtr);

            return a_result;
        }

        public override bool BActivationSuccess(bool c_bValue)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamMusicRemote_BActivationSuccess(m_instancePtr, c_bValue);

            return a_result;
        }

        public override bool SetDisplayName(string c_pchDisplayName)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamMusicRemote_SetDisplayName(m_instancePtr, new SafeUtf8String(c_pchDisplayName));

            return a_result;
        }

        public override bool SetPNGIcon_64x64(IntPtr c_pvBuffer, uint c_cbBufferLength)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamMusicRemote_SetPNGIcon_64x64(m_instancePtr, c_pvBuffer, c_cbBufferLength);

            return a_result;
        }

        public override bool EnablePlayPrevious(bool c_bValue)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamMusicRemote_EnablePlayPrevious(m_instancePtr, c_bValue);

            return a_result;
        }

        public override bool EnablePlayNext(bool c_bValue)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamMusicRemote_EnablePlayNext(m_instancePtr, c_bValue);

            return a_result;
        }

        public override bool EnableShuffled(bool c_bValue)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamMusicRemote_EnableShuffled(m_instancePtr, c_bValue);

            return a_result;
        }

        public override bool EnableLooped(bool c_bValue)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamMusicRemote_EnableLooped(m_instancePtr, c_bValue);

            return a_result;
        }

        public override bool EnableQueue(bool c_bValue)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamMusicRemote_EnableQueue(m_instancePtr, c_bValue);

            return a_result;
        }

        public override bool EnablePlaylists(bool c_bValue)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamMusicRemote_EnablePlaylists(m_instancePtr, c_bValue);

            return a_result;
        }

        public override bool UpdatePlaybackStatus(int c_nStatus)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamMusicRemote_UpdatePlaybackStatus(m_instancePtr, c_nStatus);

            return a_result;
        }

        public override bool UpdateShuffled(bool c_bValue)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamMusicRemote_UpdateShuffled(m_instancePtr, c_bValue);

            return a_result;
        }

        public override bool UpdateLooped(bool c_bValue)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamMusicRemote_UpdateLooped(m_instancePtr, c_bValue);

            return a_result;
        }

        public override bool UpdateVolume(float c_flValue)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamMusicRemote_UpdateVolume(m_instancePtr, c_flValue);

            return a_result;
        }

        public override bool CurrentEntryWillChange()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamMusicRemote_CurrentEntryWillChange(m_instancePtr);

            return a_result;
        }

        public override bool CurrentEntryIsAvailable(bool c_bAvailable)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamMusicRemote_CurrentEntryIsAvailable(m_instancePtr, c_bAvailable);

            return a_result;
        }

        public override bool UpdateCurrentEntryText(string c_pchText)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamMusicRemote_UpdateCurrentEntryText(m_instancePtr, new SafeUtf8String(c_pchText));

            return a_result;
        }

        public override bool UpdateCurrentEntryElapsedSeconds(int c_nValue)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamMusicRemote_UpdateCurrentEntryElapsedSeconds(m_instancePtr, c_nValue);

            return a_result;
        }

        public override bool UpdateCurrentEntryCoverArt(IntPtr c_pvBuffer, uint c_cbBufferLength)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamMusicRemote_UpdateCurrentEntryCoverArt(m_instancePtr, c_pvBuffer, c_cbBufferLength);

            return a_result;
        }

        public override bool CurrentEntryDidChange()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamMusicRemote_CurrentEntryDidChange(m_instancePtr);

            return a_result;
        }

        public override bool QueueWillChange()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamMusicRemote_QueueWillChange(m_instancePtr);

            return a_result;
        }

        public override bool ResetQueueEntries()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamMusicRemote_ResetQueueEntries(m_instancePtr);

            return a_result;
        }

        public override bool SetQueueEntry(int c_nId, int c_nPosition, string c_pchEntryText)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamMusicRemote_SetQueueEntry(m_instancePtr, c_nId, c_nPosition, new SafeUtf8String(c_pchEntryText));

            return a_result;
        }

        public override bool SetCurrentQueueEntry(int c_nId)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamMusicRemote_SetCurrentQueueEntry(m_instancePtr, c_nId);

            return a_result;
        }

        public override bool QueueDidChange()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamMusicRemote_QueueDidChange(m_instancePtr);

            return a_result;
        }

        public override bool PlaylistWillChange()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamMusicRemote_PlaylistWillChange(m_instancePtr);

            return a_result;
        }

        public override bool ResetPlaylistEntries()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamMusicRemote_ResetPlaylistEntries(m_instancePtr);

            return a_result;
        }

        public override bool SetPlaylistEntry(int c_nId, int c_nPosition, string c_pchEntryText)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamMusicRemote_SetPlaylistEntry(m_instancePtr, c_nId, c_nPosition, new SafeUtf8String(c_pchEntryText));

            return a_result;
        }

        public override bool SetCurrentPlaylistEntry(int c_nId)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamMusicRemote_SetCurrentPlaylistEntry(m_instancePtr, c_nId);

            return a_result;
        }

        public override bool PlaylistDidChange()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamMusicRemote_PlaylistDidChange(m_instancePtr);

            return a_result;
        }

        #endregion
    }

    public abstract class ISteamMusicRemote
    {
        public abstract IntPtr GetIntPtr();
        public abstract bool RegisterSteamMusicRemote(string c_pchName);
        public abstract bool DeregisterSteamMusicRemote();
        public abstract bool BIsCurrentMusicRemote();
        public abstract bool BActivationSuccess(bool c_bValue);
        public abstract bool SetDisplayName(string c_pchDisplayName);
        public abstract bool SetPNGIcon_64x64(IntPtr c_pvBuffer, uint c_cbBufferLength);
        public abstract bool EnablePlayPrevious(bool c_bValue);
        public abstract bool EnablePlayNext(bool c_bValue);
        public abstract bool EnableShuffled(bool c_bValue);
        public abstract bool EnableLooped(bool c_bValue);
        public abstract bool EnableQueue(bool c_bValue);
        public abstract bool EnablePlaylists(bool c_bValue);
        public abstract bool UpdatePlaybackStatus(int c_nStatus);
        public abstract bool UpdateShuffled(bool c_bValue);
        public abstract bool UpdateLooped(bool c_bValue);
        public abstract bool UpdateVolume(float c_flValue);
        public abstract bool CurrentEntryWillChange();
        public abstract bool CurrentEntryIsAvailable(bool c_bAvailable);
        public abstract bool UpdateCurrentEntryText(string c_pchText);
        public abstract bool UpdateCurrentEntryElapsedSeconds(int c_nValue);
        public abstract bool UpdateCurrentEntryCoverArt(IntPtr c_pvBuffer, uint c_cbBufferLength);
        public abstract bool CurrentEntryDidChange();
        public abstract bool QueueWillChange();
        public abstract bool ResetQueueEntries();
        public abstract bool SetQueueEntry(int c_nId, int c_nPosition, string c_pchEntryText);
        public abstract bool SetCurrentQueueEntry(int c_nId);
        public abstract bool QueueDidChange();
        public abstract bool PlaylistWillChange();
        public abstract bool ResetPlaylistEntries();
        public abstract bool SetPlaylistEntry(int c_nId, int c_nPosition, string c_pchEntryText);
        public abstract bool SetCurrentPlaylistEntry(int c_nId);
        public abstract bool PlaylistDidChange();
    }
}