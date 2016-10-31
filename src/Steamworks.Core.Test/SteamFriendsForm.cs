//   !!  // Steamworks.Core.Test - SteamFriendsForm.cs
// *.-". // Created: 2016-10-28 [10:28 PM]
//  | |  // Copyright 2016 // MIT License // The Fox Council 
// Modified by: Fox Diller on 2016-10-28 @ 10:29 PM

#region Usings

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
        private List<string> m_friendNames;
        private List<ulong> m_friendIds;

        private int m_friendPadding;
        private int m_totalFriendsCanDisplay;
        private int m_totalPages;
        private int m_currentPage;

        private int m_currentWindowWidth;
        private int m_currentWindowHeight;

        private EFriendFlags m_friendFlags;

        public SteamFriendsForm(IWindow c_window) : base(c_window)
        {
        }

        private void LoadFriends(EFriendFlags c_friendFlags = EFriendFlags.k_EFriendFlagImmediate, uint c_pageNumber = 0)
        {
            m_friendPadding = 0;
            m_totalFriends = SteamApi.Friends.GetFriendCount((int)c_friendFlags);

            m_friendIds = new List<ulong>(m_totalFriends);
            m_friendNames = new List<string>(m_totalFriends);

            for (var a_idx = 0; a_idx < m_totalFriends; a_idx++)
            {
                var a_friendId = SteamApi.Friends.GetFriendByIndex(a_idx, (int)EFriendFlags.k_EFriendFlagImmediate);
                var a_friendName = SteamApi.Friends.GetFriendPersonaName(a_friendId);
                var a_friendNameLen = a_friendName.Length;

                m_friendIds.Add(a_friendId);
                m_friendNames.Add(a_friendName);

                m_friendPadding = a_friendNameLen > m_friendPadding ? a_friendNameLen : m_friendPadding;
            }

            m_friendPadding += 6;

            var a_widthCalc = Console.WindowWidth / m_friendPadding;
            var a_heightCalc = Console.WindowHeight - 7;
            m_totalFriendsCanDisplay = a_widthCalc * a_heightCalc;

            m_totalPages = (int)Math.Ceiling((double)m_totalFriends / m_totalFriendsCanDisplay);
            m_currentPage = 0;
        }

        #region Overrides of Form<SteamworksCoreTesterWindowInfo>

        public override string OnRenderForm()
        {
            if (m_currentWindowWidth != Console.WindowWidth || m_currentWindowHeight != Console.WindowHeight)
            {
                LoadFriends();

                m_currentWindowWidth = Console.WindowWidth;
                m_currentWindowHeight = Console.WindowHeight;
            }

            var a_screen = new StringBuilder();

            a_screen.AppendLine();
            a_screen.Append($"{SteamApi.Friends.GetPersonaName()} ({UserData.GetMyPersonaState()})");
            a_screen.Append(" - ");
            a_screen.Append("Friends List");
            a_screen.Append(" - ");
            a_screen.Append($"Total: {m_totalFriends}");

            if (m_totalPages > 1)
            {
                a_screen.Append(" - ");
                a_screen.Append($"Page: {m_currentPage + 1} of {m_totalPages}");

                if (m_currentPage != m_totalPages - 1)
                {
                    a_screen.Append(" - ");
                    a_screen.Append("[N]ext Page");
                }

                if (m_currentPage != 0)
                {
                    a_screen.Append(" - ");
                    a_screen.Append("[P]revious Page");
                }
            }

            a_screen.Append(" - ");
            a_screen.Append("[Q]uit");

            a_screen.AppendLine();
            a_screen.AppendLine();

            DrawFriends(a_screen);

            return a_screen.ToString();
        }

        private void DrawFriends(StringBuilder c_screen)
        {
            var a_widthIdx = 0;
            var a_line = new StringBuilder();

            var a_skipAmount = m_currentPage * m_totalFriendsCanDisplay;

            var a_subArray = m_friendNames.Skip(a_skipAmount).Take(m_totalFriendsCanDisplay);

            foreach (var a_friendName in a_subArray)
            {
                var a_newFriendName = $"{m_friendNames.IndexOf(a_friendName).ToString().PadLeft(3)}: {a_friendName}";
                a_line.Append(a_newFriendName.PadRight(m_friendPadding));

                a_widthIdx += m_friendPadding;

                if (a_widthIdx + m_friendPadding <= Console.WindowWidth)
                {
                    continue;
                }

                c_screen.AppendLine(a_line.ToString());

                a_line = new StringBuilder();
                a_widthIdx = 0;
            }

            if (a_line.Length > 0)
            {
                c_screen.AppendLine(a_line.ToString());
            }
        }

        public override void OnInputBufferReturned(string c_input)
        {
            uint a_selection;

            c_input = c_input.ToLower();

            if (c_input.Equals("n") && m_currentPage != m_totalPages - 1)
            {
                m_currentPage++;
            }
            else if (c_input.Equals("p") && m_currentPage != 0)
            {
                m_currentPage--;
            }
            else if (c_input.Equals("q"))
            {
                ClearForm();
            }
            else if (uint.TryParse(c_input, out a_selection))
            {
                if (a_selection > m_friendIds.Count)
                {
                    return;
                }

                UserData.FriendSteamId = m_friendIds[(int)a_selection];
                SetForm(typeof(SteamFriendDisplayForm));
            }
        }

        #endregion
    }
}