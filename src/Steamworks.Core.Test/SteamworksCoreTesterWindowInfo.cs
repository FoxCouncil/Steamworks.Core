//   !!  // Steamworks.Core.Test - SteamworksCoreTesterWindowInfo.cs
// *.-". // Created: 2016-10-27 [9:37 PM]
//  | |  // Copyright 2016 // MIT License // The Fox Council 
// Modified by: Fox Diller on 2016-10-27 @ 9:38 PM

#region Usings

using System;
using WolfCurses.Window;

#endregion

namespace Steamworks.Core.Test.Menus.MainMenu
{
    public class SteamworksCoreTesterWindowInfo : WindowData
    {
        public ulong FriendSteamId;

        public string GetMyPersonaState()
        {
            return GetPersonaState((PersonaState)SteamApi.Friends.GetPersonaState());
        }

        public string GetPersonaState(PersonaState c_personaState)
        {
            switch (c_personaState)
            {
                case PersonaState.Offline:
                {
                    return "OFFLINE";
                }

                case PersonaState.Online:
                {
                    return "ONLINE";
                }

                case PersonaState.Busy:
                {
                    return "BUSY";
                }
                case PersonaState.Away:
                {
                    return "AWAY";
                }

                case PersonaState.Snooze:
                {
                    return "SNOOZE";
                }

                case PersonaState.LookingToTrade:
                {
                    return "LOOKING2TRADE";
                }

                case PersonaState.LookingToPlay:
                {
                    return "LOOKING2PLAY";
                }

                case PersonaState.Max:
                {
                    return "WTF";
                }

                default:
                {
                    throw new ArgumentOutOfRangeException($"Unknown PersonaState enum...");
                }
            }
        }
    }
}