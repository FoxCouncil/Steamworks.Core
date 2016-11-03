//   !!  // Steamworks.Core - SteamMusic.cs
// *.-". // Created: 2016-10-22 [2:42 PM]
//  | |  // Copyright 2016 // MIT License // The Fox Council 
// Modified by: Fox Diller on 2016-10-22 @ 3:03 PM

#region Usings

using System;
using System.Runtime.InteropServices;

#endregion

namespace Steamworks.Core
{
    public class SteamMusic : ISteamMusic
    {
        private readonly IntPtr m_instancePtr;

        public SteamMusic(IntPtr c_instancePtr)
        {
            m_instancePtr = c_instancePtr;
        }

        private void CheckIfUsable()
        {
            if (m_instancePtr == IntPtr.Zero)
            {
                throw new InvalidOperationException("Steam Music Not Initialized!");
            }
        }

        #region Native Methods

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMusic_BIsEnabled")]
        internal static extern bool SteamAPI_ISteamMusic_BIsEnabled(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMusic_BIsPlaying")]
        internal static extern bool SteamAPI_ISteamMusic_BIsPlaying(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMusic_GetPlaybackStatus")]
        internal static extern int SteamAPI_ISteamMusic_GetPlaybackStatus(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMusic_Play")]
        internal static extern void SteamAPI_ISteamMusic_Play(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMusic_Pause")]
        internal static extern void SteamAPI_ISteamMusic_Pause(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMusic_PlayPrevious")]
        internal static extern void SteamAPI_ISteamMusic_PlayPrevious(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMusic_PlayNext")]
        internal static extern void SteamAPI_ISteamMusic_PlayNext(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMusic_SetVolume")]
        internal static extern void SteamAPI_ISteamMusic_SetVolume(IntPtr c_instancePtr, float c_flVolume);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamMusic_GetVolume")]
        internal static extern float SteamAPI_ISteamMusic_GetVolume(IntPtr c_instancePtr);

        #endregion

        #region Overrides of ISteamMusic

        public override IntPtr GetIntPtr()
        {
            return m_instancePtr;
        }

        public override bool BIsEnabled()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamMusic_BIsEnabled(m_instancePtr);

            return a_result;
        }

        public override bool BIsPlaying()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamMusic_BIsPlaying(m_instancePtr);

            return a_result;
        }

        public override int GetPlaybackStatus()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamMusic_GetPlaybackStatus(m_instancePtr);

            return a_result;
        }

        public override void Play()
        {
            CheckIfUsable();

            SteamAPI_ISteamMusic_Play(m_instancePtr);
        }

        public override void Pause()
        {
            CheckIfUsable();

            SteamAPI_ISteamMusic_Pause(m_instancePtr);
        }

        public override void PlayPrevious()
        {
            CheckIfUsable();

            SteamAPI_ISteamMusic_PlayPrevious(m_instancePtr);
        }

        public override void PlayNext()
        {
            CheckIfUsable();

            SteamAPI_ISteamMusic_PlayNext(m_instancePtr);
        }

        public override void SetVolume(float c_flVolume)
        {
            CheckIfUsable();

            SteamAPI_ISteamMusic_SetVolume(m_instancePtr, c_flVolume);
        }

        public override float GetVolume()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamMusic_GetVolume(m_instancePtr);

            return a_result;
        }

        #endregion
    }

    public abstract class ISteamMusic
    {
        public abstract IntPtr GetIntPtr();
        public abstract bool BIsEnabled();
        public abstract bool BIsPlaying();
        public abstract int GetPlaybackStatus();
        public abstract void Play();
        public abstract void Pause();
        public abstract void PlayPrevious();
        public abstract void PlayNext();
        public abstract void SetVolume(float c_flVolume);
        public abstract float GetVolume();
    }
}