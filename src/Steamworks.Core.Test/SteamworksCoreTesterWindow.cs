//   !!  // Steamworks.Core.Test - SteamworksCoreTesterWindow.cs
// *.-". // Created: 2016-10-27 [9:37 PM]
//  | |  // Copyright 2016 // MIT License // The Fox Council 
// Modified by: Fox Diller on 2016-10-27 @ 9:39 PM

#region Usings

using System;
using System.Text;
using Microsoft.DotNet.InternalAbstractions;
using WolfCurses;
using WolfCurses.Window;

#endregion

namespace Steamworks.Core.Test.Menus.MainMenu
{
    public class SteamworksCoreTesterWindow : Window<SteamworksCoreTesterWindowCommands, SteamworksCoreTesterWindowInfo>
    {
        public SteamworksCoreTesterWindow(SimulationApp c_simUnit) : base(c_simUnit)
        {
        }

        /// <summary>
        ///     Called after the Windows has been added to list of modes and made active.
        /// </summary>
        public override void OnWindowPostCreate()
        {
            base.OnWindowPostCreate();

            MenuHeader = $"-==[ Welcome, {SteamApi.Friends.GetPersonaName()} ]==-";

            AddCommand(SteamFriends, SteamworksCoreTesterWindowCommands.SteamFriends);
            AddCommand(SteamController, SteamworksCoreTesterWindowCommands.SteamController);

            AddCommand(Quit, SteamworksCoreTesterWindowCommands.Quit);
        }

        private void Quit()
        {
            Program.Quit();
        }

        private void SteamFriends()
        {
            SetForm(typeof(SteamFriendsForm));
        }

        private void SteamController()
        {
            SetForm(typeof(SteamControllerForm));
        }
    }
}