//   !!  // Steamworks.Core - SteamNetworking.cs
// *.-". // Created: 2016-10-20 [7:42 PM]
//  | |  // Copyright 2016 // MIT License // The Fox Council 
// Modified by: Fox Diller on 2016-10-22 @ 3:03 PM

#region Usings

using System;
using System.Runtime.InteropServices;

#endregion

namespace Steamworks.Core
{
    public class SteamNetworking : ISteamNetworking
    {
        private readonly IntPtr m_instancePtr;

        public SteamNetworking(IntPtr c_instancePtr)
        {
            m_instancePtr = c_instancePtr;
        }

        private void CheckIfUsable()
        {
            if (m_instancePtr == IntPtr.Zero)
            {
                throw new InvalidOperationException("Steam Networking Not Initialized!");
            }
        }

        #region Native Methods

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamNetworking_SendP2PPacket")]
        private static extern bool SteamAPI_ISteamNetworking_SendP2PPacket(IntPtr c_instancePtr, ulong c_steamIdRemote, IntPtr c_pubData, uint c_cubData, uint c_eP2PSendType, int c_nChannel);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamNetworking_IsP2PPacketAvailable")]
        private static extern bool SteamAPI_ISteamNetworking_IsP2PPacketAvailable(IntPtr c_instancePtr, ref uint c_pcubMsgSize, int c_nChannel);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamNetworking_ReadP2PPacket")]
        private static extern bool SteamAPI_ISteamNetworking_ReadP2PPacket(IntPtr c_instancePtr, IntPtr c_pubDest, uint c_cubDest, ref uint c_pcubMsgSize, ref CSteamId c_psteamIdRemote, int c_nChannel);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamNetworking_AcceptP2PSessionWithUser")]
        private static extern bool SteamAPI_ISteamNetworking_AcceptP2PSessionWithUser(IntPtr c_instancePtr, ulong c_steamIdRemote);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamNetworking_CloseP2PSessionWithUser")]
        private static extern bool SteamAPI_ISteamNetworking_CloseP2PSessionWithUser(IntPtr c_instancePtr, ulong c_steamIdRemote);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamNetworking_CloseP2PChannelWithUser")]
        private static extern bool SteamAPI_ISteamNetworking_CloseP2PChannelWithUser(IntPtr c_instancePtr, ulong c_steamIdRemote, int c_nChannel);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamNetworking_GetP2PSessionState")]
        private static extern bool SteamAPI_ISteamNetworking_GetP2PSessionState(IntPtr c_instancePtr, ulong c_steamIdRemote, ref P2PSessionState c_pConnectionState);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamNetworking_AllowP2PPacketRelay")]
        private static extern bool SteamAPI_ISteamNetworking_AllowP2PPacketRelay(IntPtr c_instancePtr, bool c_bAllow);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamNetworking_CreateListenSocket")]
        private static extern uint SteamAPI_ISteamNetworking_CreateListenSocket(IntPtr c_instancePtr, int c_nVirtualP2PPort, uint c_nIp, char c_nPort, bool c_bAllowUseOfPacketRelay);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamNetworking_CreateP2PConnectionSocket")]
        private static extern uint SteamAPI_ISteamNetworking_CreateP2PConnectionSocket(IntPtr c_instancePtr, ulong c_steamIdTarget, int c_nVirtualPort, int c_nTimeoutSec, bool c_bAllowUseOfPacketRelay);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamNetworking_CreateConnectionSocket")]
        private static extern uint SteamAPI_ISteamNetworking_CreateConnectionSocket(IntPtr c_instancePtr, uint c_nIp, char c_nPort, int c_nTimeoutSec);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamNetworking_DestroySocket")]
        private static extern bool SteamAPI_ISteamNetworking_DestroySocket(IntPtr c_instancePtr, uint c_hSocket, bool c_bNotifyRemoteEnd);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamNetworking_DestroyListenSocket")]
        private static extern bool SteamAPI_ISteamNetworking_DestroyListenSocket(IntPtr c_instancePtr, uint c_hSocket, bool c_bNotifyRemoteEnd);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamNetworking_SendDataOnSocket")]
        private static extern bool SteamAPI_ISteamNetworking_SendDataOnSocket(IntPtr c_instancePtr, uint c_hSocket, IntPtr c_pubData, uint c_cubData, bool c_bReliable);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamNetworking_IsDataAvailableOnSocket")]
        private static extern bool SteamAPI_ISteamNetworking_IsDataAvailableOnSocket(IntPtr c_instancePtr, uint c_hSocket, ref uint c_pcubMsgSize);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamNetworking_RetrieveDataFromSocket")]
        private static extern bool SteamAPI_ISteamNetworking_RetrieveDataFromSocket(IntPtr c_instancePtr, uint c_hSocket, IntPtr c_pubDest, uint c_cubDest, ref uint c_pcubMsgSize);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamNetworking_IsDataAvailable")]
        private static extern bool SteamAPI_ISteamNetworking_IsDataAvailable(IntPtr c_instancePtr, uint c_hListenSocket, ref uint c_pcubMsgSize, ref uint c_phSocket);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamNetworking_RetrieveData")]
        private static extern bool SteamAPI_ISteamNetworking_RetrieveData(IntPtr c_instancePtr, uint c_hListenSocket, IntPtr c_pubDest, uint c_cubDest, ref uint c_pcubMsgSize, ref uint c_phSocket);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamNetworking_GetSocketInfo")]
        private static extern bool SteamAPI_ISteamNetworking_GetSocketInfo(IntPtr c_instancePtr, uint c_hSocket, ref CSteamId c_pSteamIdRemote, ref int c_peSocketStatus, ref uint c_punIpRemote, ref char c_punPortRemote);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamNetworking_GetListenSocketInfo")]
        private static extern bool SteamAPI_ISteamNetworking_GetListenSocketInfo(IntPtr c_instancePtr, uint c_hListenSocket, ref uint c_pnIp, ref char c_pnPort);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamNetworking_GetSocketConnectionType")]
        private static extern uint SteamAPI_ISteamNetworking_GetSocketConnectionType(IntPtr c_instancePtr, uint c_hSocket);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamNetworking_GetMaxPacketSize")]
        private static extern int SteamAPI_ISteamNetworking_GetMaxPacketSize(IntPtr c_instancePtr, uint c_hSocket);

        #endregion

        #region Overrides of ISteamNetworking

        public override IntPtr GetIntPtr()
        {
            return m_instancePtr;
        }

        public override bool SendP2PPacket(ulong c_steamIdRemote, IntPtr c_pubData, uint c_cubData, uint c_eP2PSendType, int c_nChannel)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamNetworking_SendP2PPacket(m_instancePtr, c_steamIdRemote, c_pubData, c_cubData, c_eP2PSendType, c_nChannel);

            return a_result;
        }

        public override bool IsP2PPacketAvailable(ref uint c_pcubMsgSize, int c_nChannel)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamNetworking_IsP2PPacketAvailable(m_instancePtr, ref c_pcubMsgSize, c_nChannel);

            return a_result;
        }

        public override bool ReadP2PPacket(IntPtr c_pubDest, uint c_cubDest, ref uint c_pcubMsgSize, ref CSteamId c_psteamIdRemote, int c_nChannel)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamNetworking_ReadP2PPacket(m_instancePtr, c_pubDest, c_cubDest, ref c_pcubMsgSize, ref c_psteamIdRemote, c_nChannel);

            return a_result;
        }

        public override bool AcceptP2PSessionWithUser(ulong c_steamIdRemote)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamNetworking_AcceptP2PSessionWithUser(m_instancePtr, c_steamIdRemote);

            return a_result;
        }

        public override bool CloseP2PSessionWithUser(ulong c_steamIdRemote)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamNetworking_CloseP2PSessionWithUser(m_instancePtr, c_steamIdRemote);

            return a_result;
        }

        public override bool CloseP2PChannelWithUser(ulong c_steamIdRemote, int c_nChannel)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamNetworking_CloseP2PChannelWithUser(m_instancePtr, c_steamIdRemote, c_nChannel);

            return a_result;
        }

        public override bool GetP2PSessionState(ulong c_steamIdRemote, ref P2PSessionState c_pConnectionState)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamNetworking_GetP2PSessionState(m_instancePtr, c_steamIdRemote, ref c_pConnectionState);

            return a_result;
        }

        public override bool AllowP2PPacketRelay(bool c_bAllow)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamNetworking_AllowP2PPacketRelay(m_instancePtr, c_bAllow);

            return a_result;
        }

        public override uint CreateListenSocket(int c_nVirtualP2PPort, uint c_nIp, char c_nPort, bool c_bAllowUseOfPacketRelay)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamNetworking_CreateListenSocket(m_instancePtr, c_nVirtualP2PPort, c_nIp, c_nPort, c_bAllowUseOfPacketRelay);

            return a_result;
        }

        public override uint CreateP2PConnectionSocket(ulong c_steamIdTarget, int c_nVirtualPort, int c_nTimeoutSec, bool c_bAllowUseOfPacketRelay)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamNetworking_CreateP2PConnectionSocket(m_instancePtr, c_steamIdTarget, c_nVirtualPort, c_nTimeoutSec, c_bAllowUseOfPacketRelay);

            return a_result;
        }

        public override uint CreateConnectionSocket(uint c_nIp, char c_nPort, int c_nTimeoutSec)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamNetworking_CreateConnectionSocket(m_instancePtr, c_nIp, c_nPort, c_nTimeoutSec);

            return a_result;
        }

        public override bool DestroySocket(uint c_hSocket, bool c_bNotifyRemoteEnd)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamNetworking_DestroySocket(m_instancePtr, c_hSocket, c_bNotifyRemoteEnd);

            return a_result;
        }

        public override bool DestroyListenSocket(uint c_hSocket, bool c_bNotifyRemoteEnd)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamNetworking_DestroyListenSocket(m_instancePtr, c_hSocket, c_bNotifyRemoteEnd);

            return a_result;
        }

        public override bool SendDataOnSocket(uint c_hSocket, IntPtr c_pubData, uint c_cubData, bool c_bReliable)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamNetworking_SendDataOnSocket(m_instancePtr, c_hSocket, c_pubData, c_cubData, c_bReliable);

            return a_result;
        }

        public override bool IsDataAvailableOnSocket(uint c_hSocket, ref uint c_pcubMsgSize)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamNetworking_IsDataAvailableOnSocket(m_instancePtr, c_hSocket, ref c_pcubMsgSize);

            return a_result;
        }

        public override bool RetrieveDataFromSocket(uint c_hSocket, IntPtr c_pubDest, uint c_cubDest, ref uint c_pcubMsgSize)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamNetworking_RetrieveDataFromSocket(m_instancePtr, c_hSocket, c_pubDest, c_cubDest, ref c_pcubMsgSize);

            return a_result;
        }

        public override bool IsDataAvailable(uint c_hListenSocket, ref uint c_pcubMsgSize, ref uint c_phSocket)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamNetworking_IsDataAvailable(m_instancePtr, c_hListenSocket, ref c_pcubMsgSize, ref c_phSocket);

            return a_result;
        }

        public override bool RetrieveData(uint c_hListenSocket, IntPtr c_pubDest, uint c_cubDest, ref uint c_pcubMsgSize, ref uint c_phSocket)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamNetworking_RetrieveData(m_instancePtr, c_hListenSocket, c_pubDest, c_cubDest, ref c_pcubMsgSize, ref c_phSocket);

            return a_result;
        }

        public override bool GetSocketInfo(uint c_hSocket, ref CSteamId c_pSteamIdRemote, ref int c_peSocketStatus, ref uint c_punIpRemote, ref char c_punPortRemote)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamNetworking_GetSocketInfo(m_instancePtr, c_hSocket, ref c_pSteamIdRemote, ref c_peSocketStatus, ref c_punIpRemote, ref c_punPortRemote);

            return a_result;
        }

        public override bool GetListenSocketInfo(uint c_hListenSocket, ref uint c_pnIp, ref char c_pnPort)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamNetworking_GetListenSocketInfo(m_instancePtr, c_hListenSocket, ref c_pnIp, ref c_pnPort);

            return a_result;
        }

        public override uint GetSocketConnectionType(uint c_hSocket)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamNetworking_GetSocketConnectionType(m_instancePtr, c_hSocket);

            return a_result;
        }

        public override int GetMaxPacketSize(uint c_hSocket)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamNetworking_GetMaxPacketSize(m_instancePtr, c_hSocket);

            return a_result;
        }

        #endregion
    }

    public abstract class ISteamNetworking
    {
        public abstract IntPtr GetIntPtr();
        public abstract bool SendP2PPacket(ulong c_steamIdRemote, IntPtr c_pubData, uint c_cubData, uint c_eP2PSendType, int c_nChannel);
        public abstract bool IsP2PPacketAvailable(ref uint c_pcubMsgSize, int c_nChannel);
        public abstract bool ReadP2PPacket(IntPtr c_pubDest, uint c_cubDest, ref uint c_pcubMsgSize, ref CSteamId c_psteamIdRemote, int c_nChannel);
        public abstract bool AcceptP2PSessionWithUser(ulong c_steamIdRemote);
        public abstract bool CloseP2PSessionWithUser(ulong c_steamIdRemote);
        public abstract bool CloseP2PChannelWithUser(ulong c_steamIdRemote, int c_nChannel);
        public abstract bool GetP2PSessionState(ulong c_steamIdRemote, ref P2PSessionState c_pConnectionState);
        public abstract bool AllowP2PPacketRelay(bool c_bAllow);
        public abstract uint CreateListenSocket(int c_nVirtualP2PPort, uint c_nIp, char c_nPort, bool c_bAllowUseOfPacketRelay);
        public abstract uint CreateP2PConnectionSocket(ulong c_steamIdTarget, int c_nVirtualPort, int c_nTimeoutSec, bool c_bAllowUseOfPacketRelay);
        public abstract uint CreateConnectionSocket(uint c_nIp, char c_nPort, int c_nTimeoutSec);
        public abstract bool DestroySocket(uint c_hSocket, bool c_bNotifyRemoteEnd);
        public abstract bool DestroyListenSocket(uint c_hSocket, bool c_bNotifyRemoteEnd);
        public abstract bool SendDataOnSocket(uint c_hSocket, IntPtr c_pubData, uint c_cubData, bool c_bReliable);
        public abstract bool IsDataAvailableOnSocket(uint c_hSocket, ref uint c_pcubMsgSize);
        public abstract bool RetrieveDataFromSocket(uint c_hSocket, IntPtr c_pubDest, uint c_cubDest, ref uint c_pcubMsgSize);
        public abstract bool IsDataAvailable(uint c_hListenSocket, ref uint c_pcubMsgSize, ref uint c_phSocket);
        public abstract bool RetrieveData(uint c_hListenSocket, IntPtr c_pubDest, uint c_cubDest, ref uint c_pcubMsgSize, ref uint c_phSocket);
        public abstract bool GetSocketInfo(uint c_hSocket, ref CSteamId c_pSteamIdRemote, ref int c_peSocketStatus, ref uint c_punIpRemote, ref char c_punPortRemote);
        public abstract bool GetListenSocketInfo(uint c_hListenSocket, ref uint c_pnIp, ref char c_pnPort);
        public abstract uint GetSocketConnectionType(uint c_hSocket);
        public abstract int GetMaxPacketSize(uint c_hSocket);
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct P2PSessionState
    {
        public byte ConnectionActive;
        public byte Connecting;
        public byte P2PSessionError;
        public byte UsingRelay;
        public int BytesQueuedForSend;
        public int PacketsQueuedForSend;
        public uint RemoteIP;
        public char RemotePort;
    }
}