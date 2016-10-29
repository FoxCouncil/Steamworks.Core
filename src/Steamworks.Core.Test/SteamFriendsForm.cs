//   !!  // Steamworks.Core.Test - SteamFriendsForm.cs
// *.-". // Created: 2016-10-28 [10:28 PM]
//  | |  // Copyright 2016 // MIT License // The Fox Council 
// Modified by: Fox Diller on 2016-10-28 @ 10:29 PM

#region Usings

using System;
using System.Collections.Generic;
using System.Text;
using Steamworks.Core.Test.Menus.MainMenu;
using WolfCurses.Window;
using WolfCurses.Window.Form;

#endregion

namespace Steamworks.Core.Test
{
    [ParentWindow(typeof(SteamworksCoreTesterWindow))]
    public class SteamFriendsForm : Form<SteamworksCoreTesterWindowInfo>
    {
        private int m_totalFriends;
        private Dictionary<ulong, string> m_friendNames;

        private int m_friendPadding = 0;


        public SteamFriendsForm(IWindow c_window) : base(c_window)
        {
            LoadFriends();
        }

        private void LoadFriends()
        {
            m_totalFriends = SteamApi.Friends.GetFriendCount((int)EFriendFlags.k_EFriendFlagImmediate);

            m_friendNames = new Dictionary<ulong, string>(m_totalFriends);

            for (var a_idx = 0; a_idx < m_totalFriends; a_idx++)
            {
                var a_friendId = SteamApi.Friends.GetFriendByIndex(a_idx, (int)EFriendFlags.k_EFriendFlagImmediate);
                var a_friendName = SteamApi.Friends.GetFriendPersonaName(a_friendId);
                var a_friendNameLen = a_friendName.Length;

                m_friendNames.Add(a_friendId, a_friendName);

                m_friendPadding = a_friendNameLen > m_friendPadding ? a_friendNameLen : m_friendPadding;
            }

            m_friendPadding += 1;
        }

        #region Overrides of Form<SteamworksCoreTesterWindowInfo>

        public override string OnRenderForm()
        {
            var a_screen = new StringBuilder();

            a_screen.AppendLine();
            a_screen.AppendLine($"Friends - {SteamApi.Friends.GetPersonaName()} ({GetPersonaState()})");

            a_screen.AppendLine();

            var a_widthIdx = 0;
            var a_line = new StringBuilder();

            foreach (var a_friendName in m_friendNames.Values)
            {
                a_line.Append(a_friendName.PadRight(m_friendPadding));

                a_widthIdx += m_friendPadding;

                if (a_widthIdx + m_friendPadding > Console.WindowWidth)
                {
                    a_screen.AppendLine(a_line.ToString());

                    a_line = new StringBuilder();
                    a_widthIdx = 0;
                }
            }

            return a_screen.ToString();
        }

        public override void OnInputBufferReturned(string c_input)
        {
            
        }

        #endregion

        private static string GetPersonaState()
        {
            switch ((EPersonaState)SteamApi.Friends.GetPersonaState())
            {
                case EPersonaState.k_EPersonaStateOffline:
                {
                    return "OFFLINE";
                }

                case EPersonaState.k_EPersonaStateOnline:
                {
                    return "ONLINE";
                }

                case EPersonaState.k_EPersonaStateBusy:
                {
                    return "BUSY";
                }
                case EPersonaState.k_EPersonaStateAway:
                {
                    return "AWAY";
                }

                case EPersonaState.k_EPersonaStateSnooze:
                {
                    return "SNOOZE";
                }

                case EPersonaState.k_EPersonaStateLookingToTrade:
                {
                    return "LOOKING2TRADE";
                }

                case EPersonaState.k_EPersonaStateLookingToPlay:
                {
                    return "LOOKING2PLAY";
                }

                case EPersonaState.k_EPersonaStateMax:
                {
                    return "WTF";
                }

                default:
                {
                    throw new ArgumentOutOfRangeException("Unknown PersonaState enum...");
                }
            }
        }
    }
}