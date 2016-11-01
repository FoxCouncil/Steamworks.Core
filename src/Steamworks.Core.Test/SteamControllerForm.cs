using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Steamworks.Core.Test.Menus.MainMenu;
using WolfCurses.Window;
using WolfCurses.Window.Form;

namespace Steamworks.Core.Test
{
    [ParentWindow(typeof(SteamworksCoreTesterWindow))]
    public class SteamControllerForm : Form<SteamworksCoreTesterWindowInfo>
    {
        private int m_controllerTotal;
        private ulong[] m_controllerIds = new ulong[SteamController.STEAM_CONTROLLER_MAX_COUNT];

        private string m_actionSet = "InGameControls";
        private ulong m_actionSetHandle;

        private string m_fireDigital = "fire";
        private ulong m_fireDigitalHandle;

        private string m_jumpDigital = "Jump";
        private ulong m_jumpDigitalHandle;

        private string m_pauseDigital = "pause_menu";
        private ulong m_pauseDigitalHandle;

        private string m_moveAnalog = "Move";
        private ulong m_moveAnalogHandle;

        private string m_cameraAnalog = "Camera";
        private ulong m_cameraAnalogHandle;

        public SteamControllerForm(IWindow c_window) : base(c_window)
        {
        }

        private void RefreshControllerList()
        {
            var a_controllerIdArray = new ulong[SteamController.STEAM_CONTROLLER_MAX_COUNT];

            var a_unmanagedHandle = GCHandle.Alloc(a_controllerIdArray, GCHandleType.Pinned);

            m_controllerTotal = SteamApi.Controller.GetConnectedControllers(ref a_controllerIdArray);

            a_unmanagedHandle.Free();

            a_controllerIdArray.CopyTo(m_controllerIds, 0);
        }

        #region Overrides of Form<SteamworksCoreTesterWindowInfo>

        public override string OnRenderForm()
        {
            GetControllerStates();

            SteamApi.Controller.ActivateActionSet(SteamController.STEAM_CONTROLLER_HANDLE_ALL_CONTROLLERS, m_actionSetHandle);

            var a_screen = new StringBuilder();

            a_screen.AppendLine();
            a_screen.AppendLine();

            a_screen.AppendLine($"=[ {m_controllerTotal} Controller Handles - Action Set: {m_actionSet}({m_actionSetHandle}) ]=");
            a_screen.AppendLine("===========================================================================================================================");

            for (var a_idx = 0; a_idx < SteamController.STEAM_CONTROLLER_MAX_COUNT; a_idx++)
            {
                a_screen.AppendLine($"  {(a_idx+1).ToString().PadLeft(2)}. {m_controllerIds[a_idx].ToString().PadRight(14)} | {m_fireDigital}({m_fireDigitalHandle}): [{GetDigitalState(a_idx, m_fireDigitalHandle)}] | {m_jumpDigital}({m_jumpDigitalHandle}): [{GetDigitalState(a_idx, m_jumpDigitalHandle)}] | {m_pauseDigital}({m_pauseDigitalHandle}): [{GetDigitalState(a_idx, m_pauseDigitalHandle)}] | {GetAnalogState(a_idx, m_cameraAnalogHandle, 3)} | {GetAnalogState(a_idx, m_moveAnalogHandle, 11)}");
            }            

            a_screen.AppendLine("===========================================================================================================================");

            return a_screen.ToString();
        }

        private string GetAnalogState(int c_cIdx, ulong c_analogControlHandle, int c_padding)
        {
            var a_analogTest = SteamApi.Controller.GetAnalogActionData(m_controllerIds[c_cIdx], c_analogControlHandle);

            return $"X: {a_analogTest.X.ToString().PadLeft(c_padding)} - Y: {a_analogTest.Y.ToString().PadLeft(c_padding)}";
        }

        private void GetControllerStates()
        {
           
        }

        private string GetDigitalState(int c_controllerIdx, ulong c_ditigalControlHandle)
        {
            if (c_ditigalControlHandle < 1)
            {
                return "X";
            }

            var a_state = SteamApi.Controller.GetDigitalActionData(m_controllerIds[c_controllerIdx], c_ditigalControlHandle);

            return Convert.ToBoolean(a_state.State) ? "█" : " ";
        }

        public override void OnInputBufferReturned(string c_input)
        {
            ClearForm();
        }

        public override void OnTick(bool c_systemTick, bool c_skipDay)
        {
            RefreshControllerList();
        }

        public override void OnFormPostCreate()
        {
            SteamApi.Controller.Init();

            m_actionSetHandle = SteamApi.Controller.GetActionSetHandle(m_actionSet);

            m_fireDigitalHandle = SteamApi.Controller.GetDigitalActionHandle(m_fireDigital);
            m_jumpDigitalHandle = SteamApi.Controller.GetDigitalActionHandle(m_jumpDigital);
            m_pauseDigitalHandle = SteamApi.Controller.GetDigitalActionHandle(m_pauseDigital);

            m_moveAnalogHandle = SteamApi.Controller.GetAnalogActionHandle(m_moveAnalog);
            m_cameraAnalogHandle = SteamApi.Controller.GetAnalogActionHandle(m_cameraAnalog);
        }

        #endregion
    }
}
