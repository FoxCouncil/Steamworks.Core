using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

            SteamApi.Controller.RunFrame();

            var a_listOfControllerIds = new ulong[SteamController.STEAM_CONTROLLER_MAX_COUNT];

            var a_unmanagedHandle = GCHandle.Alloc(a_listOfControllerIds, GCHandleType.Pinned);

            var a_totalControllers = SteamApi.Controller.GetConnectedControllers(ref a_listOfControllerIds);

            a_unmanagedHandle.Free();

            Console.WriteLine(a_totalControllers);
            Console.WriteLine(string.Join(",", a_listOfControllerIds));
        }
    }
}
