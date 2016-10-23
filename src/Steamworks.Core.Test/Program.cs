using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace Steamworks.Core.Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SteamApi.Init();

            Console.WriteLine(SteamApi.GetHSteamPipe());
            Console.WriteLine(SteamApi.GetHSteamUser());
            Console.WriteLine(SteamApi.Client.GetIpcCallCount());
            Console.WriteLine(SteamApi.Friends.GetPersonaName());

            Console.WriteLine(SteamApi.Controller.Init());

            var a_thing = SteamApi.Controller.GetActionSetHandle("InGameControls");

            var a_fireHandle = SteamApi.Controller.GetDigitalActionHandle("fire");

            SteamApi.Controller.ShowBindingPanel(SteamController.STEAM_CONTROLLER_HANDLE_ALL_CONTROLLERS);

            var a_isRunning = true;

            while (a_isRunning)
            {
                SteamApi.Controller.ActivateActionSet(SteamController.STEAM_CONTROLLER_HANDLE_ALL_CONTROLLERS, a_thing);

                Console.Clear();

                SteamApi.Controller.RunFrame();

                var a_listOfControllerIds = new ulong[SteamController.STEAM_CONTROLLER_MAX_COUNT];

                var a_unmanagedHandle = GCHandle.Alloc(a_listOfControllerIds, GCHandleType.Pinned);

                var a_totalControllers = SteamApi.Controller.GetConnectedControllers(ref a_listOfControllerIds);

                a_unmanagedHandle.Free();

                Console.WriteLine(a_totalControllers);
                Console.WriteLine(string.Join(",", a_listOfControllerIds));

                Console.WriteLine();

                var a_state = SteamApi.Controller.GetDigitalActionData(a_listOfControllerIds[0], a_fireHandle);

                Console.WriteLine(a_state.State);
                Console.WriteLine(a_state.Active);

                Thread.Sleep(100);

                // Console.ReadKey();
            }
            
        }
    }
}
