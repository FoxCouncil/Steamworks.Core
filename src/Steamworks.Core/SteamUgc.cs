//   !!  // Steamworks.Core - SteamUgc.cs
// *.-". // Created: 2016-10-22 [1:52 AM]
//  | |  // Copyright 2016 // MIT License // The Fox Council 
// Modified by: Fox Diller on 2016-10-22 @ 3:03 PM

#region Usings

using System;
using System.Runtime.InteropServices;
using System.Text;

#endregion

namespace Steamworks.Core
{
    public class SteamUgc : ISteamUgc
    {
        private readonly IntPtr m_instancePtr;

        public SteamUgc(IntPtr c_instancePtr)
        {
            m_instancePtr = c_instancePtr;
        }

        private void CheckIfUsable()
        {
            if (m_instancePtr == IntPtr.Zero)
            {
                throw new InvalidOperationException("Steam Ugc Not Initialized!");
            }
        }

        #region Native Methods

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUGC_CreateQueryUserUGCRequest")]
        private static extern ulong SteamAPI_ISteamUGC_CreateQueryUserUGCRequest(IntPtr c_instancePtr, uint c_unAccountId, uint c_eListType, uint c_eMatchingUgcType, uint c_eSortOrder, uint c_nCreatorAppId, uint c_nConsumerAppId, uint c_unPage);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUGC_CreateQueryAllUGCRequest")]
        private static extern ulong SteamAPI_ISteamUGC_CreateQueryAllUGCRequest(IntPtr c_instancePtr, uint c_eQueryType, uint c_eMatchingeMatchingUgcTypeFileType, uint c_nCreatorAppId, uint c_nConsumerAppId, uint c_unPage);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUGC_CreateQueryUGCDetailsRequest")]
        private static extern ulong SteamAPI_ISteamUGC_CreateQueryUGCDetailsRequest(IntPtr c_instancePtr, ref ulong c_pvecPublishedFileId, uint c_unNumPublishedFileIDs);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUGC_SendQueryUGCRequest")]
        private static extern ulong SteamAPI_ISteamUGC_SendQueryUGCRequest(IntPtr c_instancePtr, ulong c_handle);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUGC_GetQueryUGCResult")]
        private static extern bool SteamAPI_ISteamUGC_GetQueryUGCResult(IntPtr c_instancePtr, ulong c_handle, uint c_index, ref SteamUgcDetails c_pDetails);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUGC_GetQueryUGCPreviewURL")]
        private static extern bool SteamAPI_ISteamUGC_GetQueryUGCPreviewURL(IntPtr c_instancePtr, ulong c_handle, uint c_index, StringBuilder c_pchUrl, uint c_cchUrlSize);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUGC_GetQueryUGCMetadata")]
        private static extern bool SteamAPI_ISteamUGC_GetQueryUGCMetadata(IntPtr c_instancePtr, ulong c_handle, uint c_index, StringBuilder c_pchMetadata, uint c_cchMetadatasize);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUGC_GetQueryUGCChildren")]
        private static extern bool SteamAPI_ISteamUGC_GetQueryUGCChildren(IntPtr c_instancePtr, ulong c_handle, uint c_index, ref ulong c_pvecPublishedFileId, uint c_cMaxEntries);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUGC_GetQueryUGCStatistic")]
        private static extern bool SteamAPI_ISteamUGC_GetQueryUGCStatistic(IntPtr c_instancePtr, ulong c_handle, uint c_index, uint c_eStatType, ref ulong c_pStatValue);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUGC_GetQueryUGCNumAdditionalPreviews")]
        private static extern uint SteamAPI_ISteamUGC_GetQueryUGCNumAdditionalPreviews(IntPtr c_instancePtr, ulong c_handle, uint c_index);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUGC_GetQueryUGCAdditionalPreview")]
        private static extern bool SteamAPI_ISteamUGC_GetQueryUGCAdditionalPreview(IntPtr c_instancePtr, ulong c_handle, uint c_index, uint c_previewIndex, StringBuilder c_pchUrlOrVideoId, uint c_cchUrlSize, StringBuilder c_pchOriginalFileName, uint c_cchOriginalFileNameSize, ref uint c_pPreviewType);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUGC_GetQueryUGCNumKeyValueTags")]
        private static extern uint SteamAPI_ISteamUGC_GetQueryUGCNumKeyValueTags(IntPtr c_instancePtr, ulong c_handle, uint c_index);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUGC_GetQueryUGCKeyValueTag")]
        private static extern bool SteamAPI_ISteamUGC_GetQueryUGCKeyValueTag(IntPtr c_instancePtr, ulong c_handle, uint c_index, uint c_keyValueTagIndex, StringBuilder c_pchKey, uint c_cchKeySize, StringBuilder c_pchValue, uint c_cchValueSize);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUGC_ReleaseQueryUGCRequest")]
        private static extern bool SteamAPI_ISteamUGC_ReleaseQueryUGCRequest(IntPtr c_instancePtr, ulong c_handle);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUGC_AddRequiredTag")]
        private static extern bool SteamAPI_ISteamUGC_AddRequiredTag(IntPtr c_instancePtr, ulong c_handle, SafeUtf8String c_pTagName);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUGC_AddExcludedTag")]
        private static extern bool SteamAPI_ISteamUGC_AddExcludedTag(IntPtr c_instancePtr, ulong c_handle, SafeUtf8String c_pTagName);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUGC_SetReturnOnlyIDs")]
        private static extern bool SteamAPI_ISteamUGC_SetReturnOnlyIDs(IntPtr c_instancePtr, ulong c_handle, bool c_bReturnOnlyIDs);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUGC_SetReturnKeyValueTags")]
        private static extern bool SteamAPI_ISteamUGC_SetReturnKeyValueTags(IntPtr c_instancePtr, ulong c_handle, bool c_bReturnKeyValueTags);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUGC_SetReturnLongDescription")]
        private static extern bool SteamAPI_ISteamUGC_SetReturnLongDescription(IntPtr c_instancePtr, ulong c_handle, bool c_bReturnLongDescription);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUGC_SetReturnMetadata")]
        private static extern bool SteamAPI_ISteamUGC_SetReturnMetadata(IntPtr c_instancePtr, ulong c_handle, bool c_bReturnMetadata);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUGC_SetReturnChildren")]
        private static extern bool SteamAPI_ISteamUGC_SetReturnChildren(IntPtr c_instancePtr, ulong c_handle, bool c_bReturnChildren);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUGC_SetReturnAdditionalPreviews")]
        private static extern bool SteamAPI_ISteamUGC_SetReturnAdditionalPreviews(IntPtr c_instancePtr, ulong c_handle, bool c_bReturnAdditionalPreviews);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUGC_SetReturnTotalOnly")]
        private static extern bool SteamAPI_ISteamUGC_SetReturnTotalOnly(IntPtr c_instancePtr, ulong c_handle, bool c_bReturnTotalOnly);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUGC_SetLanguage")]
        private static extern bool SteamAPI_ISteamUGC_SetLanguage(IntPtr c_instancePtr, ulong c_handle, SafeUtf8String c_pchLanguage);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUGC_SetAllowCachedResponse")]
        private static extern bool SteamAPI_ISteamUGC_SetAllowCachedResponse(IntPtr c_instancePtr, ulong c_handle, uint c_unMaxAgeSeconds);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUGC_SetCloudFileNameFilter")]
        private static extern bool SteamAPI_ISteamUGC_SetCloudFileNameFilter(IntPtr c_instancePtr, ulong c_handle, SafeUtf8String c_pMatchCloudFileName);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUGC_SetMatchAnyTag")]
        private static extern bool SteamAPI_ISteamUGC_SetMatchAnyTag(IntPtr c_instancePtr, ulong c_handle, bool c_bMatchAnyTag);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUGC_SetSearchText")]
        private static extern bool SteamAPI_ISteamUGC_SetSearchText(IntPtr c_instancePtr, ulong c_handle, SafeUtf8String c_pSearchText);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUGC_SetRankedByTrendDays")]
        private static extern bool SteamAPI_ISteamUGC_SetRankedByTrendDays(IntPtr c_instancePtr, ulong c_handle, uint c_unDays);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUGC_AddRequiredKeyValueTag")]
        private static extern bool SteamAPI_ISteamUGC_AddRequiredKeyValueTag(IntPtr c_instancePtr, ulong c_handle, SafeUtf8String c_pKey, SafeUtf8String c_pValue);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUGC_RequestUGCDetails")]
        private static extern ulong SteamAPI_ISteamUGC_RequestUGCDetails(IntPtr c_instancePtr, ulong c_nPublishedFileId, uint c_unMaxAgeSeconds);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUGC_CreateItem")]
        private static extern ulong SteamAPI_ISteamUGC_CreateItem(IntPtr c_instancePtr, uint c_nConsumerAppId, uint c_eFileType);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUGC_StartItemUpdate")]
        private static extern ulong SteamAPI_ISteamUGC_StartItemUpdate(IntPtr c_instancePtr, uint c_nConsumerAppId, ulong c_nPublishedFileId);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUGC_SetItemTitle")]
        private static extern bool SteamAPI_ISteamUGC_SetItemTitle(IntPtr c_instancePtr, ulong c_handle, SafeUtf8String c_pchTitle);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUGC_SetItemDescription")]
        private static extern bool SteamAPI_ISteamUGC_SetItemDescription(IntPtr c_instancePtr, ulong c_handle, SafeUtf8String c_pchDescription);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUGC_SetItemUpdateLanguage")]
        private static extern bool SteamAPI_ISteamUGC_SetItemUpdateLanguage(IntPtr c_instancePtr, ulong c_handle, SafeUtf8String c_pchLanguage);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUGC_SetItemMetadata")]
        private static extern bool SteamAPI_ISteamUGC_SetItemMetadata(IntPtr c_instancePtr, ulong c_handle, SafeUtf8String c_pchMetaData);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUGC_SetItemVisibility")]
        private static extern bool SteamAPI_ISteamUGC_SetItemVisibility(IntPtr c_instancePtr, ulong c_handle, uint c_eVisibility);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUGC_SetItemTags")]
        private static extern bool SteamAPI_ISteamUGC_SetItemTags(IntPtr c_instancePtr, ulong c_updateHandle, ref SteamParamStringArray c_pTags);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUGC_SetItemContent")]
        private static extern bool SteamAPI_ISteamUGC_SetItemContent(IntPtr c_instancePtr, ulong c_handle, SafeUtf8String c_pszContentFolder);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUGC_SetItemPreview")]
        private static extern bool SteamAPI_ISteamUGC_SetItemPreview(IntPtr c_instancePtr, ulong c_handle, SafeUtf8String c_pszPreviewFile);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUGC_RemoveItemKeyValueTags")]
        private static extern bool SteamAPI_ISteamUGC_RemoveItemKeyValueTags(IntPtr c_instancePtr, ulong c_handle, SafeUtf8String c_pchKey);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUGC_AddItemKeyValueTag")]
        private static extern bool SteamAPI_ISteamUGC_AddItemKeyValueTag(IntPtr c_instancePtr, ulong c_handle, SafeUtf8String c_pchKey, SafeUtf8String c_pchValue);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUGC_AddItemPreviewFile")]
        private static extern bool SteamAPI_ISteamUGC_AddItemPreviewFile(IntPtr c_instancePtr, ulong c_handle, SafeUtf8String c_pszPreviewFile, uint c_type);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUGC_AddItemPreviewVideo")]
        private static extern bool SteamAPI_ISteamUGC_AddItemPreviewVideo(IntPtr c_instancePtr, ulong c_handle, SafeUtf8String c_pszVideoId);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUGC_UpdateItemPreviewFile")]
        private static extern bool SteamAPI_ISteamUGC_UpdateItemPreviewFile(IntPtr c_instancePtr, ulong c_handle, uint c_index, SafeUtf8String c_pszPreviewFile);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUGC_UpdateItemPreviewVideo")]
        private static extern bool SteamAPI_ISteamUGC_UpdateItemPreviewVideo(IntPtr c_instancePtr, ulong c_handle, uint c_index, SafeUtf8String c_pszVideoId);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUGC_RemoveItemPreview")]
        private static extern bool SteamAPI_ISteamUGC_RemoveItemPreview(IntPtr c_instancePtr, ulong c_handle, uint c_index);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUGC_SubmitItemUpdate")]
        private static extern ulong SteamAPI_ISteamUGC_SubmitItemUpdate(IntPtr c_instancePtr, ulong c_handle, SafeUtf8String c_pchChangeNote);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUGC_GetItemUpdateProgress")]
        private static extern uint SteamAPI_ISteamUGC_GetItemUpdateProgress(IntPtr c_instancePtr, ulong c_handle, ref ulong c_punBytesProcessed, ref ulong c_punBytesTotal);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUGC_SetUserItemVote")]
        private static extern ulong SteamAPI_ISteamUGC_SetUserItemVote(IntPtr c_instancePtr, ulong c_nPublishedFileId, bool c_bVoteUp);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUGC_GetUserItemVote")]
        private static extern ulong SteamAPI_ISteamUGC_GetUserItemVote(IntPtr c_instancePtr, ulong c_nPublishedFileId);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUGC_AddItemToFavorites")]
        private static extern ulong SteamAPI_ISteamUGC_AddItemToFavorites(IntPtr c_instancePtr, uint c_nAppId, ulong c_nPublishedFileId);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUGC_RemoveItemFromFavorites")]
        private static extern ulong SteamAPI_ISteamUGC_RemoveItemFromFavorites(IntPtr c_instancePtr, uint c_nAppId, ulong c_nPublishedFileId);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUGC_SubscribeItem")]
        private static extern ulong SteamAPI_ISteamUGC_SubscribeItem(IntPtr c_instancePtr, ulong c_nPublishedFileId);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUGC_UnsubscribeItem")]
        private static extern ulong SteamAPI_ISteamUGC_UnsubscribeItem(IntPtr c_instancePtr, ulong c_nPublishedFileId);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUGC_GetNumSubscribedItems")]
        private static extern uint SteamAPI_ISteamUGC_GetNumSubscribedItems(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUGC_GetSubscribedItems")]
        private static extern uint SteamAPI_ISteamUGC_GetSubscribedItems(IntPtr c_instancePtr, ref ulong c_pvecPublishedFileId, uint c_cMaxEntries);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUGC_GetItemState")]
        private static extern uint SteamAPI_ISteamUGC_GetItemState(IntPtr c_instancePtr, ulong c_nPublishedFileId);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUGC_GetItemInstallInfo")]
        private static extern bool SteamAPI_ISteamUGC_GetItemInstallInfo(IntPtr c_instancePtr, ulong c_nPublishedFileId, ref ulong c_punSizeOnDisk, StringBuilder c_pchFolder, uint c_cchFolderSize, ref uint c_punTimeStamp);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUGC_GetItemDownloadInfo")]
        private static extern bool SteamAPI_ISteamUGC_GetItemDownloadInfo(IntPtr c_instancePtr, ulong c_nPublishedFileId, ref ulong c_punBytesDownloaded, ref ulong c_punBytesTotal);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUGC_DownloadItem")]
        private static extern bool SteamAPI_ISteamUGC_DownloadItem(IntPtr c_instancePtr, ulong c_nPublishedFileId, bool c_bHighPriority);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUGC_BInitWorkshopForGameServer")]
        private static extern bool SteamAPI_ISteamUGC_BInitWorkshopForGameServer(IntPtr c_instancePtr, uint c_unWorkshopDepotId, SafeUtf8String c_pszFolder);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUGC_SuspendDownloads")]
        private static extern void SteamAPI_ISteamUGC_SuspendDownloads(IntPtr c_instancePtr, bool c_bSuspend);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUGC_StartPlaytimeTracking")]
        private static extern ulong SteamAPI_ISteamUGC_StartPlaytimeTracking(IntPtr c_instancePtr, ref ulong c_pvecPublishedFileId, uint c_unNumPublishedFileIDs);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUGC_StopPlaytimeTracking")]
        private static extern ulong SteamAPI_ISteamUGC_StopPlaytimeTracking(IntPtr c_instancePtr, ref ulong c_pvecPublishedFileId, uint c_unNumPublishedFileIDs);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamUGC_StopPlaytimeTrackingForAllItems")]
        private static extern ulong SteamAPI_ISteamUGC_StopPlaytimeTrackingForAllItems(IntPtr c_instancePtr);

        #endregion

        #region Overrides of ISteamUgc

        public override IntPtr GetIntPtr()
        {
            return m_instancePtr;
        }

        public override ulong CreateQueryUserUgcRequest(uint c_unAccountId, uint c_eListType, uint c_eMatchingUgcType, uint c_eSortOrder, uint c_nCreatorAppId, uint c_nConsumerAppId, uint c_unPage)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUGC_CreateQueryUserUGCRequest(m_instancePtr, c_unAccountId, c_eListType, c_eMatchingUgcType, c_eSortOrder, c_nCreatorAppId, c_nConsumerAppId, c_unPage);

            return a_result;
        }

        public override ulong CreateQueryAllUgcRequest(uint c_eQueryType, uint c_eMatchingeMatchingUgcTypeFileType, uint c_nCreatorAppId, uint c_nConsumerAppId, uint c_unPage)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUGC_CreateQueryAllUGCRequest(m_instancePtr, c_eQueryType, c_eMatchingeMatchingUgcTypeFileType, c_nCreatorAppId, c_nConsumerAppId, c_unPage);

            return a_result;
        }

        public override ulong CreateQueryUgcDetailsRequest(ref ulong c_pvecPublishedFileId, uint c_unNumPublishedFileIDs)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUGC_CreateQueryUGCDetailsRequest(m_instancePtr, ref c_pvecPublishedFileId, c_unNumPublishedFileIDs);

            return a_result;
        }

        public override ulong SendQueryUgcRequest(ulong c_handle)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUGC_SendQueryUGCRequest(m_instancePtr, c_handle);

            return a_result;
        }

        public override bool GetQueryUgcResult(ulong c_handle, uint c_index, ref SteamUgcDetails c_pDetails)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUGC_GetQueryUGCResult(m_instancePtr, c_handle, c_index, ref c_pDetails);

            return a_result;
        }

        public override bool GetQueryUgcPreviewUrl(ulong c_handle, uint c_index, out string c_pchUrl)
        {
            CheckIfUsable();

            var a_stringBuilder = new StringBuilder(2048);

            var a_result = SteamAPI_ISteamUGC_GetQueryUGCPreviewURL(m_instancePtr, c_handle, c_index, a_stringBuilder, 2048);

            c_pchUrl = a_stringBuilder.ToString();

            return a_result;
        }

        public override bool GetQueryUgcMetadata(ulong c_handle, uint c_index, out string c_pchMetadata)
        {
            CheckIfUsable();

            var a_stringBuilder = new StringBuilder(2048);

            var a_result = SteamAPI_ISteamUGC_GetQueryUGCMetadata(m_instancePtr, c_handle, c_index, a_stringBuilder, 2048);

            c_pchMetadata = a_stringBuilder.ToString();

            return a_result;
        }

        public override bool GetQueryUgcChildren(ulong c_handle, uint c_index, ref ulong c_pvecPublishedFileId, uint c_cMaxEntries)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUGC_GetQueryUGCChildren(m_instancePtr, c_handle, c_index, ref c_pvecPublishedFileId, c_cMaxEntries);

            return a_result;
        }

        public override bool GetQueryUgcStatistic(ulong c_handle, uint c_index, uint c_eStatType, ref ulong c_pStatValue)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUGC_GetQueryUGCStatistic(m_instancePtr, c_handle, c_index, c_eStatType, ref c_pStatValue);

            return a_result;
        }

        public override uint GetQueryUgcNumAdditionalPreviews(ulong c_handle, uint c_index)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUGC_GetQueryUGCNumAdditionalPreviews(m_instancePtr, c_handle, c_index);

            return a_result;
        }

        public override bool GetQueryUgcAdditionalPreview(ulong c_handle, uint c_index, uint c_previewIndex, out string c_pchUrlOrVideoId, out string c_pchOriginalFileName, uint c_cchOriginalFileNameSize, ref uint c_pPreviewType)
        {
            CheckIfUsable();

            var a_stringBuilder1 = new StringBuilder(2048);
            var a_stringBuilder2 = new StringBuilder(2048);

            var a_result = SteamAPI_ISteamUGC_GetQueryUGCAdditionalPreview(m_instancePtr, c_handle, c_index, c_previewIndex, a_stringBuilder1, 2048, a_stringBuilder2, 2048, ref c_pPreviewType);

            c_pchUrlOrVideoId = a_stringBuilder1.ToString();
            c_pchOriginalFileName = a_stringBuilder2.ToString();

            return a_result;
        }

        public override uint GetQueryUgcNumKeyValueTags(ulong c_handle, uint c_index)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUGC_GetQueryUGCNumKeyValueTags(m_instancePtr, c_handle, c_index);

            return a_result;
        }

        public override bool GetQueryUgcKeyValueTag(ulong c_handle, uint c_index, uint c_keyValueTagIndex, out string c_pchKey, out string c_pchValue)
        {
            CheckIfUsable();

            var a_stringBuilder1 = new StringBuilder(2048);
            var a_stringBuilder2 = new StringBuilder(2048);

            var a_result = SteamAPI_ISteamUGC_GetQueryUGCKeyValueTag(m_instancePtr, c_handle, c_index, c_keyValueTagIndex, a_stringBuilder1, 2048, a_stringBuilder2, 2048);

            c_pchKey = a_stringBuilder1.ToString();
            c_pchValue = a_stringBuilder2.ToString();

            return a_result;
        }

        public override bool ReleaseQueryUgcRequest(ulong c_handle)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUGC_ReleaseQueryUGCRequest(m_instancePtr, c_handle);

            return a_result;
        }

        public override bool AddRequiredTag(ulong c_handle, string c_pTagName)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUGC_AddRequiredTag(m_instancePtr, c_handle, new SafeUtf8String(c_pTagName));

            return a_result;
        }

        public override bool AddExcludedTag(ulong c_handle, string c_pTagName)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUGC_AddExcludedTag(m_instancePtr, c_handle, new SafeUtf8String(c_pTagName));

            return a_result;
        }

        public override bool SetReturnOnlyIDs(ulong c_handle, bool c_bReturnOnlyIDs)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUGC_SetReturnOnlyIDs(m_instancePtr, c_handle, c_bReturnOnlyIDs);

            return a_result;
        }

        public override bool SetReturnKeyValueTags(ulong c_handle, bool c_bReturnKeyValueTags)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUGC_SetReturnKeyValueTags(m_instancePtr, c_handle, c_bReturnKeyValueTags);

            return a_result;
        }

        public override bool SetReturnLongDescription(ulong c_handle, bool c_bReturnLongDescription)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUGC_SetReturnLongDescription(m_instancePtr, c_handle, c_bReturnLongDescription);

            return a_result;
        }

        public override bool SetReturnMetadata(ulong c_handle, bool c_bReturnMetadata)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUGC_SetReturnMetadata(m_instancePtr, c_handle, c_bReturnMetadata);

            return a_result;
        }

        public override bool SetReturnChildren(ulong c_handle, bool c_bReturnChildren)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUGC_SetReturnChildren(m_instancePtr, c_handle, c_bReturnChildren);

            return a_result;
        }

        public override bool SetReturnAdditionalPreviews(ulong c_handle, bool c_bReturnAdditionalPreviews)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUGC_SetReturnAdditionalPreviews(m_instancePtr, c_handle, c_bReturnAdditionalPreviews);

            return a_result;
        }

        public override bool SetReturnTotalOnly(ulong c_handle, bool c_bReturnTotalOnly)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUGC_SetReturnTotalOnly(m_instancePtr, c_handle, c_bReturnTotalOnly);

            return a_result;
        }

        public override bool SetLanguage(ulong c_handle, string c_pchLanguage)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUGC_SetLanguage(m_instancePtr, c_handle, new SafeUtf8String(c_pchLanguage));

            return a_result;
        }

        public override bool SetAllowCachedResponse(ulong c_handle, uint c_unMaxAgeSeconds)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUGC_SetAllowCachedResponse(m_instancePtr, c_handle, c_unMaxAgeSeconds);

            return a_result;
        }

        public override bool SetCloudFileNameFilter(ulong c_handle, string c_pMatchCloudFileName)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUGC_SetCloudFileNameFilter(m_instancePtr, c_handle, new SafeUtf8String(c_pMatchCloudFileName));

            return a_result;
        }

        public override bool SetMatchAnyTag(ulong c_handle, bool c_bMatchAnyTag)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUGC_SetMatchAnyTag(m_instancePtr, c_handle, c_bMatchAnyTag);

            return a_result;
        }

        public override bool SetSearchText(ulong c_handle, string c_pSearchText)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUGC_SetSearchText(m_instancePtr, c_handle, new SafeUtf8String(c_pSearchText));

            return a_result;
        }

        public override bool SetRankedByTrendDays(ulong c_handle, uint c_unDays)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUGC_SetRankedByTrendDays(m_instancePtr, c_handle, c_unDays);

            return a_result;
        }

        public override bool AddRequiredKeyValueTag(ulong c_handle, string c_pKey, string c_pValue)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUGC_AddRequiredKeyValueTag(m_instancePtr, c_handle, new SafeUtf8String(c_pKey), new SafeUtf8String(c_pValue));

            return a_result;
        }

        public override ulong RequestUgcDetails(ulong c_nPublishedFileId, uint c_unMaxAgeSeconds)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUGC_RequestUGCDetails(m_instancePtr, c_nPublishedFileId, c_unMaxAgeSeconds);

            return a_result;
        }

        public override ulong CreateItem(uint c_nConsumerAppId, uint c_eFileType)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUGC_CreateItem(m_instancePtr, c_nConsumerAppId, c_eFileType);

            return a_result;
        }

        public override ulong StartItemUpdate(uint c_nConsumerAppId, ulong c_nPublishedFileId)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUGC_StartItemUpdate(m_instancePtr, c_nConsumerAppId, c_nPublishedFileId);

            return a_result;
        }

        public override bool SetItemTitle(ulong c_handle, string c_pchTitle)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUGC_SetItemTitle(m_instancePtr, c_handle, new SafeUtf8String(c_pchTitle));

            return a_result;
        }

        public override bool SetItemDescription(ulong c_handle, string c_pchDescription)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUGC_SetItemDescription(m_instancePtr, c_handle, new SafeUtf8String(c_pchDescription));

            return a_result;
        }

        public override bool SetItemUpdateLanguage(ulong c_handle, string c_pchLanguage)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUGC_SetItemUpdateLanguage(m_instancePtr, c_handle, new SafeUtf8String(c_pchLanguage));

            return a_result;
        }

        public override bool SetItemMetadata(ulong c_handle, string c_pchMetaData)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUGC_SetItemMetadata(m_instancePtr, c_handle, new SafeUtf8String(c_pchMetaData));

            return a_result;
        }

        public override bool SetItemVisibility(ulong c_handle, uint c_eVisibility)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUGC_SetItemVisibility(m_instancePtr, c_handle, c_eVisibility);

            return a_result;
        }

        public override bool SetItemTags(ulong c_updateHandle, ref SteamParamStringArray c_pTags)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUGC_SetItemTags(m_instancePtr, c_updateHandle, ref c_pTags);

            return a_result;
        }

        public override bool SetItemContent(ulong c_handle, string c_pszContentFolder)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUGC_SetItemContent(m_instancePtr, c_handle, new SafeUtf8String(c_pszContentFolder));

            return a_result;
        }

        public override bool SetItemPreview(ulong c_handle, string c_pszPreviewFile)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUGC_SetItemPreview(m_instancePtr, c_handle, new SafeUtf8String(c_pszPreviewFile));

            return a_result;
        }

        public override bool RemoveItemKeyValueTags(ulong c_handle, string c_pchKey)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUGC_RemoveItemKeyValueTags(m_instancePtr, c_handle, new SafeUtf8String(c_pchKey));

            return a_result;
        }

        public override bool AddItemKeyValueTag(ulong c_handle, string c_pchKey, string c_pchValue)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUGC_AddItemKeyValueTag(m_instancePtr, c_handle, new SafeUtf8String(c_pchKey), new SafeUtf8String(c_pchValue));

            return a_result;
        }

        public override bool AddItemPreviewFile(ulong c_handle, string c_pszPreviewFile, uint c_type)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUGC_AddItemPreviewFile(m_instancePtr, c_handle, new SafeUtf8String(c_pszPreviewFile), c_type);

            return a_result;
        }

        public override bool AddItemPreviewVideo(ulong c_handle, string c_pszVideoId)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUGC_AddItemPreviewVideo(m_instancePtr, c_handle, new SafeUtf8String(c_pszVideoId));

            return a_result;
        }

        public override bool UpdateItemPreviewFile(ulong c_handle, uint c_index, string c_pszPreviewFile)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUGC_UpdateItemPreviewFile(m_instancePtr, c_handle, c_index, new SafeUtf8String(c_pszPreviewFile));

            return a_result;
        }

        public override bool UpdateItemPreviewVideo(ulong c_handle, uint c_index, string c_pszVideoId)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUGC_UpdateItemPreviewVideo(m_instancePtr, c_handle, c_index, new SafeUtf8String(c_pszVideoId));

            return a_result;
        }

        public override bool RemoveItemPreview(ulong c_handle, uint c_index)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUGC_RemoveItemPreview(m_instancePtr, c_handle, c_index);

            return a_result;
        }

        public override ulong SubmitItemUpdate(ulong c_handle, string c_pchChangeNote)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUGC_SubmitItemUpdate(m_instancePtr, c_handle, new SafeUtf8String(c_pchChangeNote));

            return a_result;
        }

        public override uint GetItemUpdateProgress(ulong c_handle, ref ulong c_punBytesProcessed, ref ulong c_punBytesTotal)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUGC_GetItemUpdateProgress(m_instancePtr, c_handle, ref c_punBytesProcessed, ref c_punBytesTotal);

            return a_result;
        }

        public override ulong SetUserItemVote(ulong c_nPublishedFileId, bool c_bVoteUp)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUGC_SetUserItemVote(m_instancePtr, c_nPublishedFileId, c_bVoteUp);

            return a_result;
        }

        public override ulong GetUserItemVote(ulong c_nPublishedFileId)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUGC_GetUserItemVote(m_instancePtr, c_nPublishedFileId);

            return a_result;
        }

        public override ulong AddItemToFavorites(uint c_nAppId, ulong c_nPublishedFileId)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUGC_AddItemToFavorites(m_instancePtr, c_nAppId, c_nPublishedFileId);

            return a_result;
        }

        public override ulong RemoveItemFromFavorites(uint c_nAppId, ulong c_nPublishedFileId)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUGC_RemoveItemFromFavorites(m_instancePtr, c_nAppId, c_nPublishedFileId);

            return a_result;
        }

        public override ulong SubscribeItem(ulong c_nPublishedFileId)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUGC_SubscribeItem(m_instancePtr, c_nPublishedFileId);

            return a_result;
        }

        public override ulong UnsubscribeItem(ulong c_nPublishedFileId)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUGC_UnsubscribeItem(m_instancePtr, c_nPublishedFileId);

            return a_result;
        }

        public override uint GetNumSubscribedItems()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUGC_GetNumSubscribedItems(m_instancePtr);

            return a_result;
        }

        public override uint GetSubscribedItems(ref ulong c_pvecPublishedFileId, uint c_cMaxEntries)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUGC_GetSubscribedItems(m_instancePtr, ref c_pvecPublishedFileId, c_cMaxEntries);

            return a_result;
        }

        public override uint GetItemState(ulong c_nPublishedFileId)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUGC_GetItemState(m_instancePtr, c_nPublishedFileId);

            return a_result;
        }

        public override bool GetItemInstallInfo(ulong c_nPublishedFileId, ref ulong c_punSizeOnDisk, out string c_pchFolder, ref uint c_punTimeStamp)
        {
            CheckIfUsable();

            var a_stringBuilder = new StringBuilder(2048);

            var a_result = SteamAPI_ISteamUGC_GetItemInstallInfo(m_instancePtr, c_nPublishedFileId, ref c_punSizeOnDisk, a_stringBuilder, 2048, ref c_punTimeStamp);

            c_pchFolder = a_stringBuilder.ToString();

            return a_result;
        }

        public override bool GetItemDownloadInfo(ulong c_nPublishedFileId, ref ulong c_punBytesDownloaded, ref ulong c_punBytesTotal)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUGC_GetItemDownloadInfo(m_instancePtr, c_nPublishedFileId, ref c_punBytesDownloaded, ref c_punBytesTotal);

            return a_result;
        }

        public override bool DownloadItem(ulong c_nPublishedFileId, bool c_bHighPriority)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUGC_DownloadItem(m_instancePtr, c_nPublishedFileId, c_bHighPriority);

            return a_result;
        }

        public override bool BInitWorkshopForGameServer(uint c_unWorkshopDepotId, string c_pszFolder)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUGC_BInitWorkshopForGameServer(m_instancePtr, c_unWorkshopDepotId, new SafeUtf8String(c_pszFolder));

            return a_result;
        }

        public override void SuspendDownloads(bool c_bSuspend)
        {
            CheckIfUsable();

            SteamAPI_ISteamUGC_SuspendDownloads(m_instancePtr, c_bSuspend);
        }

        public override ulong StartPlaytimeTracking(ref ulong c_pvecPublishedFileId, uint c_unNumPublishedFileIDs)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUGC_StartPlaytimeTracking(m_instancePtr, ref c_pvecPublishedFileId, c_unNumPublishedFileIDs);

            return a_result;
        }

        public override ulong StopPlaytimeTracking(ref ulong c_pvecPublishedFileId, uint c_unNumPublishedFileIDs)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUGC_StopPlaytimeTracking(m_instancePtr, ref c_pvecPublishedFileId, c_unNumPublishedFileIDs);

            return a_result;
        }

        public override ulong StopPlaytimeTrackingForAllItems()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamUGC_StopPlaytimeTrackingForAllItems(m_instancePtr);

            return a_result;
        }

        #endregion
    }

    public abstract class ISteamUgc
    {
        public abstract IntPtr GetIntPtr();
        public abstract ulong CreateQueryUserUgcRequest(uint c_unAccountId, uint c_eListType, uint c_eMatchingUgcType, uint c_eSortOrder, uint c_nCreatorAppId, uint c_nConsumerAppId, uint c_unPage);
        public abstract ulong CreateQueryAllUgcRequest(uint c_eQueryType, uint c_eMatchingeMatchingUgcTypeFileType, uint c_nCreatorAppId, uint c_nConsumerAppId, uint c_unPage);
        public abstract ulong CreateQueryUgcDetailsRequest(ref ulong c_pvecPublishedFileId, uint c_unNumPublishedFileIDs);
        public abstract ulong SendQueryUgcRequest(ulong c_handle);
        public abstract bool GetQueryUgcResult(ulong c_handle, uint c_index, ref SteamUgcDetails c_pDetails);
        public abstract bool GetQueryUgcPreviewUrl(ulong c_handle, uint c_index, out string c_pchUrl);
        public abstract bool GetQueryUgcMetadata(ulong c_handle, uint c_index, out string c_pchMetadata);
        public abstract bool GetQueryUgcChildren(ulong c_handle, uint c_index, ref ulong c_pvecPublishedFileId, uint c_cMaxEntries);
        public abstract bool GetQueryUgcStatistic(ulong c_handle, uint c_index, uint c_eStatType, ref ulong c_pStatValue);
        public abstract uint GetQueryUgcNumAdditionalPreviews(ulong c_handle, uint c_index);
        public abstract bool GetQueryUgcAdditionalPreview(ulong c_handle, uint c_index, uint c_previewIndex, out string c_pchUrlOrVideoId, out string c_pchOriginalFileName, uint c_cchOriginalFileNameSize, ref uint c_pPreviewType);
        public abstract uint GetQueryUgcNumKeyValueTags(ulong c_handle, uint c_index);
        public abstract bool GetQueryUgcKeyValueTag(ulong c_handle, uint c_index, uint c_keyValueTagIndex, out string c_pchKey, out string c_pchValue);
        public abstract bool ReleaseQueryUgcRequest(ulong c_handle);
        public abstract bool AddRequiredTag(ulong c_handle, string c_pTagName);
        public abstract bool AddExcludedTag(ulong c_handle, string c_pTagName);
        public abstract bool SetReturnOnlyIDs(ulong c_handle, bool c_bReturnOnlyIDs);
        public abstract bool SetReturnKeyValueTags(ulong c_handle, bool c_bReturnKeyValueTags);
        public abstract bool SetReturnLongDescription(ulong c_handle, bool c_bReturnLongDescription);
        public abstract bool SetReturnMetadata(ulong c_handle, bool c_bReturnMetadata);
        public abstract bool SetReturnChildren(ulong c_handle, bool c_bReturnChildren);
        public abstract bool SetReturnAdditionalPreviews(ulong c_handle, bool c_bReturnAdditionalPreviews);
        public abstract bool SetReturnTotalOnly(ulong c_handle, bool c_bReturnTotalOnly);
        public abstract bool SetLanguage(ulong c_handle, string c_pchLanguage);
        public abstract bool SetAllowCachedResponse(ulong c_handle, uint c_unMaxAgeSeconds);
        public abstract bool SetCloudFileNameFilter(ulong c_handle, string c_pMatchCloudFileName);
        public abstract bool SetMatchAnyTag(ulong c_handle, bool c_bMatchAnyTag);
        public abstract bool SetSearchText(ulong c_handle, string c_pSearchText);
        public abstract bool SetRankedByTrendDays(ulong c_handle, uint c_unDays);
        public abstract bool AddRequiredKeyValueTag(ulong c_handle, string c_pKey, string c_pValue);
        public abstract ulong RequestUgcDetails(ulong c_nPublishedFileId, uint c_unMaxAgeSeconds);
        public abstract ulong CreateItem(uint c_nConsumerAppId, uint c_eFileType);
        public abstract ulong StartItemUpdate(uint c_nConsumerAppId, ulong c_nPublishedFileId);
        public abstract bool SetItemTitle(ulong c_handle, string c_pchTitle);
        public abstract bool SetItemDescription(ulong c_handle, string c_pchDescription);
        public abstract bool SetItemUpdateLanguage(ulong c_handle, string c_pchLanguage);
        public abstract bool SetItemMetadata(ulong c_handle, string c_pchMetaData);
        public abstract bool SetItemVisibility(ulong c_handle, uint c_eVisibility);
        public abstract bool SetItemTags(ulong c_updateHandle, ref SteamParamStringArray c_pTags);
        public abstract bool SetItemContent(ulong c_handle, string c_pszContentFolder);
        public abstract bool SetItemPreview(ulong c_handle, string c_pszPreviewFile);
        public abstract bool RemoveItemKeyValueTags(ulong c_handle, string c_pchKey);
        public abstract bool AddItemKeyValueTag(ulong c_handle, string c_pchKey, string c_pchValue);
        public abstract bool AddItemPreviewFile(ulong c_handle, string c_pszPreviewFile, uint c_type);
        public abstract bool AddItemPreviewVideo(ulong c_handle, string c_pszVideoId);
        public abstract bool UpdateItemPreviewFile(ulong c_handle, uint c_index, string c_pszPreviewFile);
        public abstract bool UpdateItemPreviewVideo(ulong c_handle, uint c_index, string c_pszVideoId);
        public abstract bool RemoveItemPreview(ulong c_handle, uint c_index);
        public abstract ulong SubmitItemUpdate(ulong c_handle, string c_pchChangeNote);
        public abstract uint GetItemUpdateProgress(ulong c_handle, ref ulong c_punBytesProcessed, ref ulong c_punBytesTotal);
        public abstract ulong SetUserItemVote(ulong c_nPublishedFileId, bool c_bVoteUp);
        public abstract ulong GetUserItemVote(ulong c_nPublishedFileId);
        public abstract ulong AddItemToFavorites(uint c_nAppId, ulong c_nPublishedFileId);
        public abstract ulong RemoveItemFromFavorites(uint c_nAppId, ulong c_nPublishedFileId);
        public abstract ulong SubscribeItem(ulong c_nPublishedFileId);
        public abstract ulong UnsubscribeItem(ulong c_nPublishedFileId);
        public abstract uint GetNumSubscribedItems();
        public abstract uint GetSubscribedItems(ref ulong c_pvecPublishedFileId, uint c_cMaxEntries);
        public abstract uint GetItemState(ulong c_nPublishedFileId);
        public abstract bool GetItemInstallInfo(ulong c_nPublishedFileId, ref ulong c_punSizeOnDisk, out string c_pchFolder, ref uint c_punTimeStamp);
        public abstract bool GetItemDownloadInfo(ulong c_nPublishedFileId, ref ulong c_punBytesDownloaded, ref ulong c_punBytesTotal);
        public abstract bool DownloadItem(ulong c_nPublishedFileId, bool c_bHighPriority);
        public abstract bool BInitWorkshopForGameServer(uint c_unWorkshopDepotId, string c_pszFolder);
        public abstract void SuspendDownloads(bool c_bSuspend);
        public abstract ulong StartPlaytimeTracking(ref ulong c_pvecPublishedFileId, uint c_unNumPublishedFileIDs);
        public abstract ulong StopPlaytimeTracking(ref ulong c_pvecPublishedFileId, uint c_unNumPublishedFileIDs);
        public abstract ulong StopPlaytimeTrackingForAllItems();
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SteamUgcDetails
    {
        public ulong PublishedFileId;

        public EResult Result;

        public EWorkshopFileType FileType;

        public uint CreatorAppID;

        public uint ConsumerAppID;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 129)] public string Title; //char[129]

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8000)] public string Description; //char[8000]

        public ulong SteamIDOwner;

        public uint Created;

        public uint Updated;

        public uint AddedToUserList;

        public ERemoteStoragePublishedFileVisibility Visibility;

        [MarshalAs(UnmanagedType.I1)] public bool Banned;

        [MarshalAs(UnmanagedType.I1)] public bool AcceptedForUse;

        [MarshalAs(UnmanagedType.I1)] public bool TagsTruncated;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1025)] public string Tags; //char[1025]

        public ulong File;

        public ulong PreviewFile;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)] public string FileName; //char[260]

        public int FileSize;

        public int PreviewFileSize;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)] public string URL; //char[256]

        public uint VotesUp;

        public uint VotesDown;

        public float Score;

        public uint NumChildren;
    }
}