//   !!  // Steamworks.Core - SteamInventory.cs
// *.-". // Created: 2016-10-22 [9:23 PM]
//  | |  // Copyright 2016 // MIT License // The Fox Council 
// Modified by: Fox Diller on 2016-10-22 @ 10:02 PM

#region Usings

using System;
using System.Runtime.InteropServices;
using System.Text;

#endregion

namespace Steamworks.Core
{
    public class SteamInventory : ISteamInventory
    {
        private readonly IntPtr m_instancePtr;

        public SteamInventory(IntPtr c_instancePtr)
        {
            m_instancePtr = c_instancePtr;
        }

        private void CheckIfUsable()
        {
            if (m_instancePtr == IntPtr.Zero)
            {
                throw new InvalidOperationException("Steam Inventory Not Initialized!");
            }
        }

        #region Native Methods

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamInventory_GetResultStatus")]
        private static extern uint SteamAPI_ISteamInventory_GetResultStatus(IntPtr c_instancePtr, int c_resultHandle);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamInventory_GetResultItems")]
        private static extern bool SteamAPI_ISteamInventory_GetResultItems(IntPtr c_instancePtr, int c_resultHandle, [In, Out] SteamItemDetails[] c_pOutItemsArray, ref uint c_punOutItemsArraySize);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamInventory_GetResultTimestamp")]
        private static extern uint SteamAPI_ISteamInventory_GetResultTimestamp(IntPtr c_instancePtr, int c_resultHandle);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamInventory_CheckResultSteamID")]
        private static extern bool SteamAPI_ISteamInventory_CheckResultSteamID(IntPtr c_instancePtr, int c_resultHandle, ulong c_steamIdExpected);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamInventory_DestroyResult")]
        private static extern void SteamAPI_ISteamInventory_DestroyResult(IntPtr c_instancePtr, int c_resultHandle);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamInventory_GetAllItems")]
        private static extern bool SteamAPI_ISteamInventory_GetAllItems(IntPtr c_instancePtr, ref int c_pResultHandle);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamInventory_GetItemsByID")]
        private static extern bool SteamAPI_ISteamInventory_GetItemsByID(IntPtr c_instancePtr, ref int c_pResultHandle, [In, Out] ulong[] c_pInstanceIDs, uint c_unCountInstanceIDs);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamInventory_SerializeResult")]
        private static extern bool SteamAPI_ISteamInventory_SerializeResult(IntPtr c_instancePtr, int c_resultHandle, IntPtr c_pOutBuffer, ref uint c_punOutBufferSize);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamInventory_DeserializeResult")]
        private static extern bool SteamAPI_ISteamInventory_DeserializeResult(IntPtr c_instancePtr, ref int c_pOutResultHandle, IntPtr c_pBuffer, uint c_unBufferSize, bool c_bReservedMustBeFalse);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamInventory_GenerateItems")]
        private static extern bool SteamAPI_ISteamInventory_GenerateItems(IntPtr c_instancePtr, ref int c_pResultHandle, [In, Out] int[] c_pArrayItemDefs, [In, Out] uint[] c_punArrayQuantity, uint c_unArrayLength);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamInventory_GrantPromoItems")]
        private static extern bool SteamAPI_ISteamInventory_GrantPromoItems(IntPtr c_instancePtr, ref int c_pResultHandle);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamInventory_AddPromoItem")]
        private static extern bool SteamAPI_ISteamInventory_AddPromoItem(IntPtr c_instancePtr, ref int c_pResultHandle, int c_itemDef);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamInventory_AddPromoItems")]
        private static extern bool SteamAPI_ISteamInventory_AddPromoItems(IntPtr c_instancePtr, ref int c_pResultHandle, [In, Out] int[] c_pArrayItemDefs, uint c_unArrayLength);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamInventory_ConsumeItem")]
        private static extern bool SteamAPI_ISteamInventory_ConsumeItem(IntPtr c_instancePtr, ref int c_pResultHandle, ulong c_itemConsume, uint c_unQuantity);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamInventory_ExchangeItems")]
        private static extern bool SteamAPI_ISteamInventory_ExchangeItems(IntPtr c_instancePtr, ref int c_pResultHandle, [In, Out] int[] c_pArrayGenerate, [In, Out] uint[] c_punArrayGenerateQuantity, uint c_unArrayGenerateLength, [In, Out] ulong[] c_pArrayDestroy, [In, Out] uint[] c_punArrayDestroyQuantity, uint c_unArrayDestroyLength);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamInventory_TransferItemQuantity")]
        private static extern bool SteamAPI_ISteamInventory_TransferItemQuantity(IntPtr c_instancePtr, ref int c_pResultHandle, ulong c_itemIdSource, uint c_unQuantity, ulong c_itemIdDest);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamInventory_SendItemDropHeartbeat")]
        private static extern void SteamAPI_ISteamInventory_SendItemDropHeartbeat(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamInventory_TriggerItemDrop")]
        private static extern bool SteamAPI_ISteamInventory_TriggerItemDrop(IntPtr c_instancePtr, ref int c_pResultHandle, int c_dropListDefinition);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamInventory_TradeItems")]
        private static extern bool SteamAPI_ISteamInventory_TradeItems(IntPtr c_instancePtr, ref int c_pResultHandle, ulong c_steamIdTradePartner, [In, Out] ulong[] c_pArrayGive, [In, Out] uint[] c_pArrayGiveQuantity, uint c_nArrayGiveLength, [In, Out] ulong[] c_pArrayGet, [In, Out] uint[] c_pArrayGetQuantity, uint c_nArrayGetLength);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamInventory_LoadItemDefinitions")]
        private static extern bool SteamAPI_ISteamInventory_LoadItemDefinitions(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamInventory_GetItemDefinitionIDs")]
        private static extern bool SteamAPI_ISteamInventory_GetItemDefinitionIDs(IntPtr c_instancePtr, [In, Out] int[] c_pItemDefIDs, ref uint c_punItemDefIDsArraySize);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamInventory_GetItemDefinitionProperty")]
        private static extern bool SteamAPI_ISteamInventory_GetItemDefinitionProperty(IntPtr c_instancePtr, int c_iDefinition, SafeUtf8String c_pchPropertyName, StringBuilder c_pchValueBuffer, ref uint c_punValueBufferSizeOut);

        #endregion

        #region Overrides of ISteamInventory

        public override IntPtr GetIntPtr()
        {
            return m_instancePtr;
        }

        public override uint GetResultStatus(int c_resultHandle)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamInventory_GetResultStatus(m_instancePtr, c_resultHandle);

            return a_result;
        }

        public override bool GetResultItems(int c_resultHandle, out SteamItemDetails[] c_pOutItemsArray)
        {
            CheckIfUsable();

            var a_outItemsArraySize = 0u;

            SteamAPI_ISteamInventory_GetResultItems(m_instancePtr, c_resultHandle, null, ref a_outItemsArraySize);

            c_pOutItemsArray = new SteamItemDetails[a_outItemsArraySize];

            var a_result = SteamAPI_ISteamInventory_GetResultItems(m_instancePtr, c_resultHandle, c_pOutItemsArray, ref a_outItemsArraySize);

            return a_result;
        }

        public override uint GetResultTimestamp(int c_resultHandle)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamInventory_GetResultTimestamp(m_instancePtr, c_resultHandle);

            return a_result;
        }

        public override bool CheckResultSteamId(int c_resultHandle, ulong c_steamIdExpected)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamInventory_CheckResultSteamID(m_instancePtr, c_resultHandle, c_steamIdExpected);

            return a_result;
        }

        public override void DestroyResult(int c_resultHandle)
        {
            CheckIfUsable();

            SteamAPI_ISteamInventory_DestroyResult(m_instancePtr, c_resultHandle);
        }

        public override bool GetAllItems(ref int c_pResultHandle)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamInventory_GetAllItems(m_instancePtr, ref c_pResultHandle);

            return a_result;
        }

        public override bool GetItemsById(ref int c_pResultHandle, ulong[] c_pInstanceIDs)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamInventory_GetItemsByID(m_instancePtr, ref c_pResultHandle, c_pInstanceIDs, (uint)c_pInstanceIDs.Length);

            return a_result;
        }

        public override bool SerializeResult(int c_resultHandle, IntPtr c_pOutBuffer, ref uint c_punOutBufferSize)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamInventory_SerializeResult(m_instancePtr, c_resultHandle, c_pOutBuffer, ref c_punOutBufferSize);

            return a_result;
        }

        public override bool DeserializeResult(ref int c_pOutResultHandle, IntPtr c_pBuffer, uint c_unBufferSize, bool c_bReservedMustBeFalse)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamInventory_DeserializeResult(m_instancePtr, ref c_pOutResultHandle, c_pBuffer, c_unBufferSize, c_bReservedMustBeFalse);

            return a_result;
        }

        public override bool GenerateItems(ref int c_pResultHandle, int[] c_pArrayItemDefs, uint[] c_punArrayQuantity)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamInventory_GenerateItems(m_instancePtr, ref c_pResultHandle, c_pArrayItemDefs, c_punArrayQuantity, (uint)c_punArrayQuantity.Length);

            return a_result;
        }

        public override bool GrantPromoItems(ref int c_pResultHandle)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamInventory_GrantPromoItems(m_instancePtr, ref c_pResultHandle);

            return a_result;
        }

        public override bool AddPromoItem(ref int c_pResultHandle, int c_itemDef)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamInventory_AddPromoItem(m_instancePtr, ref c_pResultHandle, c_itemDef);

            return a_result;
        }

        public override bool AddPromoItems(ref int c_pResultHandle, int[] c_pArrayItemDefs)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamInventory_AddPromoItems(m_instancePtr, ref c_pResultHandle, c_pArrayItemDefs, (uint)c_pArrayItemDefs.Length);

            return a_result;
        }

        public override bool ConsumeItem(ref int c_pResultHandle, ulong c_itemConsume, uint c_unQuantity)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamInventory_ConsumeItem(m_instancePtr, ref c_pResultHandle, c_itemConsume, c_unQuantity);

            return a_result;
        }

        public override bool ExchangeItems(ref int c_pResultHandle, int[] c_pArrayGenerate, uint[] c_punArrayGenerateQuantity, ulong[] c_pArrayDestroy, uint[] c_punArrayDestroyQuantity)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamInventory_ExchangeItems(m_instancePtr, ref c_pResultHandle, c_pArrayGenerate, c_punArrayGenerateQuantity, (uint)c_punArrayGenerateQuantity.Length, c_pArrayDestroy, c_punArrayDestroyQuantity, (uint)c_punArrayDestroyQuantity.Length);

            return a_result;
        }

        public override bool TransferItemQuantity(ref int c_pResultHandle, ulong c_itemIdSource, uint c_unQuantity, ulong c_itemIdDest)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamInventory_TransferItemQuantity(m_instancePtr, ref c_pResultHandle, c_itemIdSource, c_unQuantity, c_itemIdDest);

            return a_result;
        }

        public override void SendItemDropHeartbeat()
        {
            CheckIfUsable();

            SteamAPI_ISteamInventory_SendItemDropHeartbeat(m_instancePtr);
        }

        public override bool TriggerItemDrop(ref int c_pResultHandle, int c_dropListDefinition)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamInventory_TriggerItemDrop(m_instancePtr, ref c_pResultHandle, c_dropListDefinition);

            return a_result;
        }

        public override bool TradeItems(ref int c_pResultHandle, ulong c_steamIdTradePartner, ulong[] c_pArrayGive, uint[] c_pArrayGiveQuantity, ulong[] c_pArrayGet, uint[] c_pArrayGetQuantity)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamInventory_TradeItems(m_instancePtr, ref c_pResultHandle, c_steamIdTradePartner, c_pArrayGive, c_pArrayGiveQuantity, (uint)c_pArrayGiveQuantity.Length, c_pArrayGet, c_pArrayGetQuantity, (uint)c_pArrayGetQuantity.Length);

            return a_result;
        }

        public override bool LoadItemDefinitions()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamInventory_LoadItemDefinitions(m_instancePtr);

            return a_result;
        }

        public override bool GetItemDefinitionIDs(out int[] c_pItemDefIDs)
        {
            CheckIfUsable();

            var a_itemDefIDsArraySize = 0u;

            SteamAPI_ISteamInventory_GetItemDefinitionIDs(m_instancePtr, null, ref a_itemDefIDsArraySize);

            c_pItemDefIDs = new int[a_itemDefIDsArraySize];

            var a_result = SteamAPI_ISteamInventory_GetItemDefinitionIDs(m_instancePtr, c_pItemDefIDs, ref a_itemDefIDsArraySize);

            return a_result;
        }

        public override bool GetItemDefinitionProperty(int c_iDefinition, string c_pchPropertyName, out string c_pchValueBuffer)
        {
            CheckIfUsable();

            var a_valueBufferSizeOut = 0u;

            var a_safeUtf8String = new SafeUtf8String(c_pchPropertyName);

            SteamAPI_ISteamInventory_GetItemDefinitionProperty(m_instancePtr, c_iDefinition, a_safeUtf8String, null, ref a_valueBufferSizeOut);

            var a_stringBuffer = new StringBuilder((int)a_valueBufferSizeOut);

            var a_result = SteamAPI_ISteamInventory_GetItemDefinitionProperty(m_instancePtr, c_iDefinition, a_safeUtf8String, a_stringBuffer, ref a_valueBufferSizeOut);

            c_pchValueBuffer = a_stringBuffer.ToString();

            return a_result;
        }

        #endregion
    }

    public abstract class ISteamInventory
    {
        public abstract IntPtr GetIntPtr();
        public abstract uint GetResultStatus(int c_resultHandle);
        public abstract bool GetResultItems(int c_resultHandle, out SteamItemDetails[] c_pOutItemsArray);
        public abstract uint GetResultTimestamp(int c_resultHandle);
        public abstract bool CheckResultSteamId(int c_resultHandle, ulong c_steamIdExpected);
        public abstract void DestroyResult(int c_resultHandle);
        public abstract bool GetAllItems(ref int c_pResultHandle);
        public abstract bool GetItemsById(ref int c_pResultHandle, ulong[] c_pInstanceIDs);
        public abstract bool SerializeResult(int c_resultHandle, IntPtr c_pOutBuffer, ref uint c_punOutBufferSize);
        public abstract bool DeserializeResult(ref int c_pOutResultHandle, IntPtr c_pBuffer, uint c_unBufferSize, bool c_bReservedMustBeFalse);
        public abstract bool GenerateItems(ref int c_pResultHandle, int[] c_pArrayItemDefs, uint[] c_punArrayQuantity);
        public abstract bool GrantPromoItems(ref int c_pResultHandle);
        public abstract bool AddPromoItem(ref int c_pResultHandle, int c_itemDef);
        public abstract bool AddPromoItems(ref int c_pResultHandle, int[] c_pArrayItemDefs);
        public abstract bool ConsumeItem(ref int c_pResultHandle, ulong c_itemConsume, uint c_unQuantity);
        public abstract bool ExchangeItems(ref int c_pResultHandle, int[] c_pArrayGenerate, uint[] c_punArrayGenerateQuantity, ulong[] c_pArrayDestroy, uint[] c_punArrayDestroyQuantity);
        public abstract bool TransferItemQuantity(ref int c_pResultHandle, ulong c_itemIdSource, uint c_unQuantity, ulong c_itemIdDest);
        public abstract void SendItemDropHeartbeat();
        public abstract bool TriggerItemDrop(ref int c_pResultHandle, int c_dropListDefinition);
        public abstract bool TradeItems(ref int c_pResultHandle, ulong c_steamIdTradePartner, ulong[] c_pArrayGive, uint[] c_pArrayGiveQuantity, ulong[] c_pArrayGet, uint[] c_pArrayGetQuantity);
        public abstract bool LoadItemDefinitions();
        public abstract bool GetItemDefinitionIDs(out int[] c_pItemDefIDs);
        public abstract bool GetItemDefinitionProperty(int c_iDefinition, string c_pchPropertyName, out string c_pchValueBuffer);
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SteamItemDetails
    {
        public ulong ItemId;
        public int Definition;
        public char Quantity;
        public char Flags;
    }
}