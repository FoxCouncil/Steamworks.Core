//   !!  // Steamworks.Core - SteamController.cs
// *.-". // Created: 2016-10-18 [7:51 PM]
//  | |  // Copyright 2016 // MIT License // The Fox Council 
// Modified by: Fox Diller on 2016-10-22 @ 3:03 PM

#region Usings

using System;
using System.Runtime.InteropServices;

#endregion

namespace Steamworks.Core
{
    public class SteamController : ISteamController
    {
        private readonly IntPtr m_instancePtr;

        public SteamController(IntPtr c_instancePtr)
        {
            m_instancePtr = c_instancePtr;
        }

        private void CheckIfUsable()
        {
            if (m_instancePtr == IntPtr.Zero)
            {
                throw new InvalidOperationException("Steam Controller Not Initialized!");
            }
        }

        #region Constants

        public const int STEAM_CONTROLLER_MAX_COUNT = 16;
        public const int STEAM_CONTROLLER_MAX_ANALOG_ACTIONS = 16;
        public const int STEAM_CONTROLLER_MAX_DIGITAL_ACTIONS = 128;
        public const int STEAM_CONTROLLER_MAX_ORIGINS = 8;
        public const ulong STEAM_CONTROLLER_HANDLE_ALL_CONTROLLERS = ulong.MaxValue;
        public const float STEAM_CONTROLLER_MIN_ANALOG_ACTION_DATA = -1.0f;
        public const float STEAM_CONTROLLER_MAX_ANALOG_ACTION_DATA = 1.0f;

        #endregion

        #region Native Methods

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamController_Init")]
        private static extern bool SteamAPI_ISteamController_Init(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamController_Shutdown")]
        private static extern bool SteamAPI_ISteamController_Shutdown(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamController_RunFrame")]
        private static extern void SteamAPI_ISteamController_RunFrame(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamController_GetConnectedControllers")]
        private static extern int SteamAPI_ISteamController_GetConnectedControllers(IntPtr c_instancePtr, ulong[] c_handlesOut);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamController_ShowBindingPanel")]
        private static extern bool SteamAPI_ISteamController_ShowBindingPanel(IntPtr c_instancePtr, ulong c_controllerHandle);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamController_GetActionSetHandle")]
        private static extern ulong SteamAPI_ISteamController_GetActionSetHandle(IntPtr c_instancePtr, SafeUtf8String c_pszActionSetName);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamController_ActivateActionSet")]
        private static extern void SteamAPI_ISteamController_ActivateActionSet(IntPtr c_instancePtr, ulong c_controllerHandle, ulong c_actionSetHandle);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamController_GetCurrentActionSet")]
        private static extern ulong SteamAPI_ISteamController_GetCurrentActionSet(IntPtr c_instancePtr, ulong c_controllerHandle);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamController_GetDigitalActionHandle")]
        private static extern ulong SteamAPI_ISteamController_GetDigitalActionHandle(IntPtr c_instancePtr, SafeUtf8String c_pszActionName);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamController_GetDigitalActionData")]
        private static extern ControllerDigitalActionData SteamAPI_ISteamController_GetDigitalActionData(IntPtr c_instancePtr, ulong c_controllerHandle, ulong c_digitalActionHandle);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamController_GetDigitalActionOrigins")]
        private static extern int SteamAPI_ISteamController_GetDigitalActionOrigins(IntPtr c_instancePtr, ulong c_controllerHandle, ulong c_actionSetHandle, ulong c_digitalActionHandle, ref uint c_originsOut);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamController_GetAnalogActionHandle")]
        private static extern ulong SteamAPI_ISteamController_GetAnalogActionHandle(IntPtr c_instancePtr, SafeUtf8String c_pszActionName);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamController_GetAnalogActionData")]
        private static extern ControllerAnalogActionData SteamAPI_ISteamController_GetAnalogActionData(IntPtr c_instancePtr, ulong c_controllerHandle, ulong c_analogActionHandle);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamController_GetAnalogActionOrigins")]
        private static extern int SteamAPI_ISteamController_GetAnalogActionOrigins(IntPtr c_instancePtr, ulong c_controllerHandle, ulong c_actionSetHandle, ulong c_analogActionHandle, ref uint c_originsOut);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamController_StopAnalogActionMomentum")]
        private static extern void SteamAPI_ISteamController_StopAnalogActionMomentum(IntPtr c_instancePtr, ulong c_controllerHandle, ulong c_eAction);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamController_TriggerHapticPulse")]
        private static extern void SteamAPI_ISteamController_TriggerHapticPulse(IntPtr c_instancePtr, ulong c_controllerHandle, uint c_eTargetPad, char c_usDurationMicroSec);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamController_TriggerRepeatedHapticPulse")]
        private static extern void SteamAPI_ISteamController_TriggerRepeatedHapticPulse(IntPtr c_instancePtr, ulong c_controllerHandle, uint c_eTargetPad, char c_usDurationMicroSec, char c_usOffMicroSec, char c_unRepeat, uint c_nFlags);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamController_GetGamepadIndexForController")]
        private static extern int SteamAPI_ISteamController_GetGamepadIndexForController(IntPtr c_instancePtr, ulong c_ulControllerHandle);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamController_GetControllerForGamepadIndex")]
        private static extern ulong SteamAPI_ISteamController_GetControllerForGamepadIndex(IntPtr c_instancePtr, int c_nIndex);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamController_GetMotionData")]
        private static extern ControllerMotionData SteamAPI_ISteamController_GetMotionData(IntPtr c_instancePtr, ulong c_controllerHandle);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamController_ShowDigitalActionOrigins")]
        private static extern bool SteamAPI_ISteamController_ShowDigitalActionOrigins(IntPtr c_instancePtr, ulong c_controllerHandle, ulong c_digitalActionHandle, float c_flScale, float c_flXPosition, float c_flYPosition);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamController_ShowAnalogActionOrigins")]
        private static extern bool SteamAPI_ISteamController_ShowAnalogActionOrigins(IntPtr c_instancePtr, ulong c_controllerHandle, ulong c_analogActionHandle, float c_flScale, float c_flXPosition, float c_flYPosition);

        #endregion

        #region Overrides of ISteamController

        public override IntPtr GetIntPtr()
        {
            return m_instancePtr;
        }

        public override bool Init()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamController_Init(m_instancePtr);

            return a_result;
        }

        public override bool Shutdown()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamController_Shutdown(m_instancePtr);

            return a_result;
        }

        public override void RunFrame()
        {
            CheckIfUsable();

            SteamAPI_ISteamController_RunFrame(m_instancePtr);
        }

        public override int GetConnectedControllers(ref ulong[] c_handlesOut)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamController_GetConnectedControllers(m_instancePtr, c_handlesOut);

            return a_result;
        }

        public override bool ShowBindingPanel(ulong c_controllerHandle)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamController_ShowBindingPanel(m_instancePtr, c_controllerHandle);

            return a_result;
        }

        public override ulong GetActionSetHandle(string c_pszActionSetName)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamController_GetActionSetHandle(m_instancePtr, new SafeUtf8String(c_pszActionSetName));

            return a_result;
        }

        public override void ActivateActionSet(ulong c_controllerHandle, ulong c_actionSetHandle)
        {
            CheckIfUsable();

            SteamAPI_ISteamController_ActivateActionSet(m_instancePtr, c_controllerHandle, c_actionSetHandle);
        }

        public override ulong GetCurrentActionSet(ulong c_controllerHandle)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamController_GetCurrentActionSet(m_instancePtr, c_controllerHandle);

            return a_result;
        }

        public override ulong GetDigitalActionHandle(string c_pszActionName)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamController_GetDigitalActionHandle(m_instancePtr, new SafeUtf8String(c_pszActionName));

            return a_result;
        }

        public override ControllerDigitalActionData GetDigitalActionData(ulong c_controllerHandle, ulong c_digitalActionHandle)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamController_GetDigitalActionData(m_instancePtr, c_controllerHandle, c_digitalActionHandle);

            return a_result;
        }

        public override int GetDigitalActionOrigins(ulong c_controllerHandle, ulong c_actionSetHandle, ulong c_digitalActionHandle, ref uint c_originsOut)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamController_GetDigitalActionOrigins(m_instancePtr, c_controllerHandle, c_actionSetHandle, c_digitalActionHandle, ref c_originsOut);

            return a_result;
        }

        public override ulong GetAnalogActionHandle(string c_pszActionName)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamController_GetAnalogActionHandle(m_instancePtr, new SafeUtf8String(c_pszActionName));

            return a_result;
        }

        public override ControllerAnalogActionData GetAnalogActionData(ulong c_controllerHandle, ulong c_analogActionHandle)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamController_GetAnalogActionData(m_instancePtr, c_controllerHandle, c_analogActionHandle);

            return a_result;
        }

        public override int GetAnalogActionOrigins(ulong c_controllerHandle, ulong c_actionSetHandle, ulong c_analogActionHandle, ref uint c_originsOut)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamController_GetAnalogActionOrigins(m_instancePtr, c_controllerHandle, c_actionSetHandle, c_analogActionHandle, ref c_originsOut);

            return a_result;
        }

        public override void StopAnalogActionMomentum(ulong c_controllerHandle, ulong c_eAction)
        {
            CheckIfUsable();

            SteamAPI_ISteamController_StopAnalogActionMomentum(m_instancePtr, c_controllerHandle, c_eAction);
        }

        public override void TriggerHapticPulse(ulong c_controllerHandle, uint c_eTargetPad, char c_usDurationMicroSec)
        {
            CheckIfUsable();

            SteamAPI_ISteamController_TriggerHapticPulse(m_instancePtr, c_controllerHandle, c_eTargetPad, c_usDurationMicroSec);
        }

        public override void TriggerRepeatedHapticPulse(ulong c_controllerHandle, uint c_eTargetPad, char c_usDurationMicroSec, char c_usOffMicroSec, char c_unRepeat, uint c_nFlags)
        {
            CheckIfUsable();

            SteamAPI_ISteamController_TriggerRepeatedHapticPulse(m_instancePtr, c_controllerHandle, c_eTargetPad, c_usDurationMicroSec, c_usOffMicroSec, c_unRepeat, c_nFlags);
        }

        public override int GetGamepadIndexForController(ulong c_ulControllerHandle)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamController_GetGamepadIndexForController(m_instancePtr, c_ulControllerHandle);

            return a_result;
        }

        public override ulong GetControllerForGamepadIndex(int c_nIndex)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamController_GetControllerForGamepadIndex(m_instancePtr, c_nIndex);

            return a_result;
        }

        public override ControllerMotionData GetMotionData(ulong c_controllerHandle)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamController_GetMotionData(m_instancePtr, c_controllerHandle);

            return a_result;
        }

        public override bool ShowDigitalActionOrigins(ulong c_controllerHandle, ulong c_digitalActionHandle, float c_flScale, float c_flXPosition, float c_flYPosition)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamController_ShowDigitalActionOrigins(m_instancePtr, c_controllerHandle, c_digitalActionHandle, c_flScale, c_flXPosition, c_flYPosition);

            return a_result;
        }

        public override bool ShowAnalogActionOrigins(ulong c_controllerHandle, ulong c_analogActionHandle, float c_flScale, float c_flXPosition, float c_flYPosition)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamController_ShowAnalogActionOrigins(m_instancePtr, c_controllerHandle, c_analogActionHandle, c_flScale, c_flXPosition, c_flYPosition);

            return a_result;
        }

        #endregion
    }

    public abstract class ISteamController
    {
        public abstract IntPtr GetIntPtr();
        public abstract bool Init();
        public abstract bool Shutdown();
        public abstract void RunFrame();
        public abstract int GetConnectedControllers(ref ulong[] c_handlesOut);
        public abstract bool ShowBindingPanel(ulong c_controllerHandle);
        public abstract ulong GetActionSetHandle(string c_pszActionSetName);
        public abstract void ActivateActionSet(ulong c_controllerHandle, ulong c_actionSetHandle);
        public abstract ulong GetCurrentActionSet(ulong c_controllerHandle);
        public abstract ulong GetDigitalActionHandle(string c_pszActionName);
        public abstract ControllerDigitalActionData GetDigitalActionData(ulong c_controllerHandle, ulong c_digitalActionHandle);
        public abstract int GetDigitalActionOrigins(ulong c_controllerHandle, ulong c_actionSetHandle, ulong c_digitalActionHandle, ref uint c_originsOut);
        public abstract ulong GetAnalogActionHandle(string c_pszActionName);
        public abstract ControllerAnalogActionData GetAnalogActionData(ulong c_controllerHandle, ulong c_analogActionHandle);
        public abstract int GetAnalogActionOrigins(ulong c_controllerHandle, ulong c_actionSetHandle, ulong c_analogActionHandle, ref uint c_originsOut);
        public abstract void StopAnalogActionMomentum(ulong c_controllerHandle, ulong c_eAction);
        public abstract void TriggerHapticPulse(ulong c_controllerHandle, uint c_eTargetPad, char c_usDurationMicroSec);
        public abstract void TriggerRepeatedHapticPulse(ulong c_controllerHandle, uint c_eTargetPad, char c_usDurationMicroSec, char c_usOffMicroSec, char c_unRepeat, uint c_nFlags);
        public abstract int GetGamepadIndexForController(ulong c_ulControllerHandle);
        public abstract ulong GetControllerForGamepadIndex(int c_nIndex);
        public abstract ControllerMotionData GetMotionData(ulong c_controllerHandle);
        public abstract bool ShowDigitalActionOrigins(ulong c_controllerHandle, ulong c_digitalActionHandle, float c_flScale, float c_flXPosition, float c_flYPosition);
        public abstract bool ShowAnalogActionOrigins(ulong c_controllerHandle, ulong c_analogActionHandle, float c_flScale, float c_flXPosition, float c_flYPosition);
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ControllerDigitalActionData
    {
        public byte State;
        public byte Active;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ControllerAnalogActionData
    {
        public EControllerSourceMode Mode;
        public float X;
        public float Y;

        [MarshalAs(UnmanagedType.I1)] public bool Active;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ControllerMotionData
    {
        public float RotQuatX;
        public float RotQuatY;
        public float RotQuatZ;
        public float RotQuatW;
        public float PosAccelX;
        public float PosAccelY;
        public float PosAccelZ;
        public float RotVelX;
        public float RotVelY;
        public float RotVelZ;
    }
}