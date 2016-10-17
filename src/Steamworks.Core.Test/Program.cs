using System;
using System.Collections.Generic;
using System.Linq;
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
            Console.WriteLine(SteamApi.Client.GetIPCCallCount());
            
        }
    }
}
