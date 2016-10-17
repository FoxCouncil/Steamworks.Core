using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Steamworks.Core
{
    public abstract class ISteamClient
    {
        public abstract IntPtr GetIntPtr();

        public abstract uint CreateSteamPipe();

        public abstract bool BReleaseSteamPipe(uint hSteamPipe);

        public abstract uint ConnectToGlobalUser(uint hSteamPipe);

        public abstract uint CreateLocalUser(ref uint phSteamPipe, uint eAccountType);

        public abstract void ReleaseUser(uint hSteamPipe, uint hUser);

        public abstract IntPtr GetISteamUser(uint hSteamUser, uint hSteamPipe, string pchVersion);

        public abstract IntPtr GetISteamGameServer(uint hSteamUser, uint hSteamPipe, string pchVersion);

        public abstract void SetLocalIPBinding(uint unIP, char usPort);

        public abstract IntPtr GetISteamFriends(uint hSteamUser, uint hSteamPipe, string pchVersion);

        public abstract IntPtr GetISteamUtils(uint hSteamPipe, string pchVersion);

        public abstract IntPtr GetISteamMatchmaking(uint hSteamUser, uint hSteamPipe, string pchVersion);

        public abstract IntPtr GetISteamMatchmakingServers(uint hSteamUser, uint hSteamPipe, string pchVersion);

        public abstract IntPtr GetISteamGenericInterface(uint hSteamUser, uint hSteamPipe, string pchVersion);

        public abstract IntPtr GetISteamUserStats(uint hSteamUser, uint hSteamPipe, string pchVersion);

        public abstract IntPtr GetISteamGameServerStats(uint hSteamuser, uint hSteamPipe, string pchVersion);

        public abstract IntPtr GetISteamApps(uint hSteamUser, uint hSteamPipe, string pchVersion);

        public abstract IntPtr GetISteamNetworking(uint hSteamUser, uint hSteamPipe, string pchVersion);

        public abstract IntPtr GetISteamRemoteStorage(uint hSteamuser, uint hSteamPipe, string pchVersion);

        public abstract IntPtr GetISteamScreenshots(uint hSteamuser, uint hSteamPipe, string pchVersion);

        public abstract uint GetIPCCallCount();

        public abstract void SetWarningMessageHook(IntPtr pFunction);

        public abstract bool BShutdownIfAllPipesClosed();

        public abstract IntPtr GetISteamHTTP(uint hSteamuser, uint hSteamPipe, string pchVersion);

        public abstract IntPtr GetISteamUnifiedMessages(uint hSteamuser, uint hSteamPipe, string pchVersion);

        public abstract IntPtr GetISteamController(uint hSteamUser, uint hSteamPipe, string pchVersion);

        public abstract IntPtr GetISteamUGC(uint hSteamUser, uint hSteamPipe, string pchVersion);

        public abstract IntPtr GetISteamAppList(uint hSteamUser, uint hSteamPipe, string pchVersion);

        public abstract IntPtr GetISteamMusic(uint hSteamuser, uint hSteamPipe, string pchVersion);

        public abstract IntPtr GetISteamMusicRemote(uint hSteamuser, uint hSteamPipe, string pchVersion);

        public abstract IntPtr GetISteamHTMLSurface(uint hSteamuser, uint hSteamPipe, string pchVersion);

        public abstract IntPtr GetISteamInventory(uint hSteamuser, uint hSteamPipe, string pchVersion);

        public abstract IntPtr GetISteamVideo(uint hSteamuser, uint hSteamPipe, string pchVersion);
    }
}
