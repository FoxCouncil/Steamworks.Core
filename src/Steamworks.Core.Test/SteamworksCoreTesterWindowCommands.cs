//   !!  // Steamworks.Core.Test - SteamworksCoreTesterWindowCommands.cs
// *.-". // Created: 2016-10-27 [9:37 PM]
//  | |  // Copyright 2016 // MIT License // The Fox Council 
// Modified by: Fox Diller on 2016-10-27 @ 9:38 PM

#region Usings

using WolfCurses.Utility;

#endregion

namespace Steamworks.Core.Test
{
    /// <summary>Commands that will be loaded into the example window.</summary>
    public enum SteamworksCoreTesterWindowCommands
    {
        [Description("   SteamFriends() API\n")]
        SteamFriends = 1,

        [Description("SteamController() API\n")]
        SteamController = 2,

        [Description("Quit the tester")]
        Quit = 99
    }
}