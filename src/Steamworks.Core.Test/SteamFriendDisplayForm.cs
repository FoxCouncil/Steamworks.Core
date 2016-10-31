//   !!  // Steamworks.Core.Test - SteamFriendDisplayForm.cs
// *.-". // Created: 2016-10-30 [7:10 PM]
//  | |  // Copyright 2016 // MIT License // The Fox Council 
// Modified by: Fox Diller on 2016-10-30 @ 7:10 PM

#region Usings

using System;
using System.Text;
using Steamworks.Core.Test.Menus.MainMenu;
using WolfCurses.Window;
using WolfCurses.Window.Form;

#endregion

namespace Steamworks.Core.Test
{
    [ParentWindow(typeof(SteamworksCoreTesterWindow))]
    public class SteamFriendDisplayForm : Form<SteamworksCoreTesterWindowInfo>
    {
        public SteamFriendDisplayForm(IWindow window) : base(window)
        {
        }

        #region Overrides of Form<SteamworksCoreTesterWindowInfo>

        public override string OnRenderForm()
        {
            var a_screen = new StringBuilder();

            var a_columnWidth = 20;

            a_screen.AppendLine();
            a_screen.Append($"{SteamApi.Friends.GetPersonaName()} ({UserData.GetMyPersonaState()})");
            a_screen.Append(" - ");

            var a_friendPersonaName = SteamApi.Friends.GetFriendPersonaName(UserData.FriendSteamId);
            var a_personaState = UserData.GetPersonaState((PersonaState)SteamApi.Friends.GetFriendPersonaState(UserData.FriendSteamId));

            a_screen.Append($"{a_friendPersonaName} ({a_personaState})");

            a_screen.AppendLine();
            a_screen.AppendLine();

            a_screen.AppendLine($"{"Name".PadLeft(a_columnWidth)}: {a_friendPersonaName}");
            a_screen.AppendLine($"{"Status".PadLeft(a_columnWidth)}: {a_personaState}");

            var a_pFriendGameInfo = default(FriendGameInfo);

            var a_isPlaying = SteamApi.Friends.GetFriendGamePlayed(UserData.FriendSteamId, out a_pFriendGameInfo);

            a_screen.AppendLine(a_isPlaying ? 
                $"{"Game State".PadLeft(a_columnWidth)}: IN GAME ({a_pFriendGameInfo.m_gameID})" : 
                $"{"Game State".PadLeft(a_columnWidth)}: NOT IN GAME"
            );

            a_screen.AppendLine($"{"Relationship".PadLeft(a_columnWidth)}: {Enum.GetName(typeof(FriendRelationship), SteamApi.Friends.GetFriendRelationship(UserData.FriendSteamId))}");
            a_screen.AppendLine($"{"Steam Level".PadLeft(a_columnWidth)}: {SteamApi.Friends.GetFriendSteamLevel(UserData.FriendSteamId)}");

            var a_totalKeys = SteamApi.Friends.GetFriendRichPresenceKeyCount(UserData.FriendSteamId);
            for (int a_keyIdx = 0; a_keyIdx < a_totalKeys; a_keyIdx++)
            {
                var a_keyString = SteamApi.Friends.GetFriendRichPresenceKeyByIndex(UserData.FriendSteamId, a_keyIdx);

                a_screen.AppendLine($"{a_keyString.PadLeft(a_columnWidth)}: {SteamApi.Friends.GetFriendRichPresence(UserData.FriendSteamId, a_keyString)}");
            }

            a_screen.AppendLine();
            a_screen.AppendLine();

            a_screen.AppendLine("PRESS [ENTER] TO GO BACK");

            return a_screen.ToString();
        }

        public override void OnInputBufferReturned(string input)
        {
            SetForm(typeof(SteamFriendsForm));
        }

        #endregion

    }
}