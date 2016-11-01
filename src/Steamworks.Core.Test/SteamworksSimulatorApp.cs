//   !!  // Steamworks.Core.Test - SteamworksSimulatorApp.cs
// *.-". // Created: 2016-10-27 [9:25 PM]
//  | |  // Copyright 2016 // MIT License // The Fox Council 
// Modified by: Fox Diller on 2016-10-27 @ 9:25 PM

#region Usings

using System;
using System.Collections.Generic;
using Steamworks.Core.Test.Menus.MainMenu;
using WolfCurses;

#endregion

namespace Steamworks.Core.Test
{
    public class SteamworksSimulatorApp : SimulationApp
    {
        public SteamworksSimulatorApp()
        {
            SteamApi.Init();
        }

        #region Overrides of SimulationApp

        protected override void OnFirstTick()
        {
            WindowManager.Add(typeof(SteamworksCoreTesterWindow));
        }

        protected override void OnPreDestroy()
        {
            SteamApi.Shutdown();
        }

        public override string OnPreRender()
        {
            return string.Empty;
        }

        public override void OnTick(bool c_systemTick, bool c_skipTick = false)
        {
            base.OnTick(c_systemTick, c_skipTick);

            SteamApi.RunCallbacks();
        }

        public override IEnumerable<Type> AllowedWindows
        {
            get
            {
                var a_windowList = new List<Type>
                {
                    typeof (SteamworksCoreTesterWindow)
                };

                return a_windowList;
            }
        }

        #endregion
    }
}