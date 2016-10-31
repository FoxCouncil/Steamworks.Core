//   !!  // Steamworks.Core.Test - Program.cs
// *.-". // Created: 2016-10-14 [9:29 PM]
//  | |  // Copyright 2016 // MIT License // The Fox Council 
// Modified by: Fox Diller on 2016-10-28 @ 11:09 PM

#region Usings

using System;
using System.Text;
using System.Threading;

#endregion

namespace Steamworks.Core.Test
{
    public class Program
    {
        private static SteamworksSimulatorApp m_steamworksSimulatorApp;


        public static void Main(string[] c_args)
        {
            Console.CursorVisible = false;
            Console.OutputEncoding = Encoding.UTF8;
            Console.Title = "Steamworks.Core Tester App";

            m_steamworksSimulatorApp = new SteamworksSimulatorApp();

            m_steamworksSimulatorApp.SceneGraph.ScreenBufferDirtyEvent += c_content =>
            {
                var a_contentSplit = c_content.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

                for (var a_index = 0; a_index < Console.WindowHeight - 1; a_index++)
                {
                    Console.CursorLeft = 0;
                    Console.SetCursorPosition(0, a_index);

                    var a_emptyStringData = new string(' ', Console.WindowWidth);

                    if (a_contentSplit.Length > a_index)
                    {
                        a_emptyStringData = a_contentSplit[a_index].PadRight(Console.WindowWidth);
                    }

                    Console.Write(a_emptyStringData);
                }
            };

            while (m_steamworksSimulatorApp != null)
            {
                m_steamworksSimulatorApp.OnTick(true);

                // Check if a key is being pressed, without blocking thread.
                if (Console.KeyAvailable)
                {
                    // GetModule the key that was pressed, without printing it to console.
                    var a_key = Console.ReadKey(true);

                    // If enter is pressed, pass whatever we have to simulation.
                    // ReSharper disable once SwitchStatementMissingSomeCases
                    switch (a_key.Key)
                    {
                        case ConsoleKey.Enter:
                        {
                            m_steamworksSimulatorApp.InputManager.SendInputBufferAsCommand();
                        }
                            break;

                        case ConsoleKey.Backspace:
                        {
                            m_steamworksSimulatorApp.InputManager.RemoveLastCharOfInputBuffer();
                        }
                            break;

                        default:
                        {
                            m_steamworksSimulatorApp.InputManager.AddCharToInputBuffer(a_key.KeyChar);
                        }
                            break;
                    }
                }

                // Do not consume all of the CPU, allow other messages to occur.
                Thread.Sleep(1);
            }

            // Make user press any key to close out the simulation completely, this way they know it closed without error.
            Console.Clear();
            Console.WriteLine("Goodbye!");
            Console.WriteLine("Press ANY KEY to close this window...");
            Console.ReadKey();
        }

        public static void Quit()
        {
            m_steamworksSimulatorApp.Destroy();
            m_steamworksSimulatorApp = null;
        }
    }
}