//   !!  // Steamworks.Core - SteamRemoteStorage.cs
// *.-". // Created: 2016-10-20 [8:02 PM]
//  | |  // Copyright 2016 // MIT License // The Fox Council 
// Modified by: Fox Diller on 2016-10-22 @ 3:03 PM

#region Usings

using System;
using System.Runtime.InteropServices;
using System.Text;

#endregion

namespace Steamworks.Core
{
    public class SteamRemoteStorage : ISteamRemoteStorage
    {
        private readonly IntPtr m_instancePtr;

        public SteamRemoteStorage(IntPtr c_instancePtr)
        {
            m_instancePtr = c_instancePtr;
        }

        private void CheckIfUsable()
        {
            if (m_instancePtr == IntPtr.Zero)
            {
                throw new InvalidOperationException("Steam Remote Storage Not Initialized!");
            }
        }

        #region Callbacks

        public delegate void RemoteStorageFileReadAsyncCompleteCallResult(RemoteStorageFileReadAsyncComplete c_pRemoteStorageFileReadAsyncComplete, bool c_bIoFailure);

        #endregion

        #region Native Methods

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "CRemoteStorageFileReadAsyncComplete_t_SetCallResult")]
        private static extern ulong CRemoteStorageFileReadAsyncComplete_t_SetCallResult(ulong c_hAPICall, RemoteStorageFileReadAsyncCompleteCallResult c_func);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "CRemoteStorageFileReadAsyncComplete_t_RemoveCallResult")]
        private static extern ulong CRemoteStorageFileReadAsyncComplete_t_RemoveCallResult(ulong c_handle);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamRemoteStorage_FileWrite")]
        private static extern bool SteamAPI_ISteamRemoteStorage_FileWrite(IntPtr c_instancePtr, SafeUtf8String c_pchFile, IntPtr c_pvData, int c_cubData);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamRemoteStorage_FileRead")]
        private static extern int SteamAPI_ISteamRemoteStorage_FileRead(IntPtr c_instancePtr, SafeUtf8String c_pchFile, IntPtr c_pvData, int c_cubDataToRead);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamRemoteStorage_FileWriteAsync")]
        private static extern ulong SteamAPI_ISteamRemoteStorage_FileWriteAsync(IntPtr c_instancePtr, SafeUtf8String c_pchFile, IntPtr c_pvData, uint c_cubData);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamRemoteStorage_FileReadAsync")]
        private static extern ulong SteamAPI_ISteamRemoteStorage_FileReadAsync(IntPtr c_instancePtr, SafeUtf8String c_pchFile, uint c_nOffset, uint c_cubToRead);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamRemoteStorage_FileReadAsyncComplete")]
        private static extern bool SteamAPI_ISteamRemoteStorage_FileReadAsyncComplete(IntPtr c_instancePtr, ulong c_hReadCall, IntPtr c_pvBuffer, uint c_cubToRead);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamRemoteStorage_FileForget")]
        private static extern bool SteamAPI_ISteamRemoteStorage_FileForget(IntPtr c_instancePtr, SafeUtf8String c_pchFile);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamRemoteStorage_FileDelete")]
        private static extern bool SteamAPI_ISteamRemoteStorage_FileDelete(IntPtr c_instancePtr, SafeUtf8String c_pchFile);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamRemoteStorage_FileShare")]
        private static extern ulong SteamAPI_ISteamRemoteStorage_FileShare(IntPtr c_instancePtr, SafeUtf8String c_pchFile);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamRemoteStorage_SetSyncPlatforms")]
        private static extern bool SteamAPI_ISteamRemoteStorage_SetSyncPlatforms(IntPtr c_instancePtr, SafeUtf8String c_pchFile, uint c_eRemoteStoragePlatform);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamRemoteStorage_FileWriteStreamOpen")]
        private static extern ulong SteamAPI_ISteamRemoteStorage_FileWriteStreamOpen(IntPtr c_instancePtr, SafeUtf8String c_pchFile);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamRemoteStorage_FileWriteStreamWriteChunk")]
        private static extern bool SteamAPI_ISteamRemoteStorage_FileWriteStreamWriteChunk(IntPtr c_instancePtr, ulong c_writeHandle, IntPtr c_pvData, int c_cubData);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamRemoteStorage_FileWriteStreamClose")]
        private static extern bool SteamAPI_ISteamRemoteStorage_FileWriteStreamClose(IntPtr c_instancePtr, ulong c_writeHandle);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamRemoteStorage_FileWriteStreamCancel")]
        private static extern bool SteamAPI_ISteamRemoteStorage_FileWriteStreamCancel(IntPtr c_instancePtr, ulong c_writeHandle);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamRemoteStorage_FileExists")]
        private static extern bool SteamAPI_ISteamRemoteStorage_FileExists(IntPtr c_instancePtr, SafeUtf8String c_pchFile);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamRemoteStorage_FilePersisted")]
        private static extern bool SteamAPI_ISteamRemoteStorage_FilePersisted(IntPtr c_instancePtr, SafeUtf8String c_pchFile);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamRemoteStorage_GetFileSize")]
        private static extern int SteamAPI_ISteamRemoteStorage_GetFileSize(IntPtr c_instancePtr, SafeUtf8String c_pchFile);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamRemoteStorage_GetFileTimestamp")]
        private static extern long SteamAPI_ISteamRemoteStorage_GetFileTimestamp(IntPtr c_instancePtr, SafeUtf8String c_pchFile);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamRemoteStorage_GetSyncPlatforms")]
        private static extern uint SteamAPI_ISteamRemoteStorage_GetSyncPlatforms(IntPtr c_instancePtr, SafeUtf8String c_pchFile);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamRemoteStorage_GetFileCount")]
        private static extern int SteamAPI_ISteamRemoteStorage_GetFileCount(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamRemoteStorage_GetFileNameAndSize")]
        private static extern IntPtr SteamAPI_ISteamRemoteStorage_GetFileNameAndSize(IntPtr c_instancePtr, int c_iFile, ref int c_pnFileSizeInBytes);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamRemoteStorage_GetQuota")]
        private static extern bool SteamAPI_ISteamRemoteStorage_GetQuota(IntPtr c_instancePtr, ref ulong c_pnTotalBytes, ref ulong c_puAvailableBytes);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamRemoteStorage_IsCloudEnabledForAccount")]
        private static extern bool SteamAPI_ISteamRemoteStorage_IsCloudEnabledForAccount(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamRemoteStorage_IsCloudEnabledForApp")]
        private static extern bool SteamAPI_ISteamRemoteStorage_IsCloudEnabledForApp(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamRemoteStorage_SetCloudEnabledForApp")]
        private static extern void SteamAPI_ISteamRemoteStorage_SetCloudEnabledForApp(IntPtr c_instancePtr, bool c_bEnabled);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamRemoteStorage_UGCDownload")]
        private static extern ulong SteamAPI_ISteamRemoteStorage_UGCDownload(IntPtr c_instancePtr, ulong c_hContent, uint c_unPriority);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamRemoteStorage_GetUGCDownloadProgress")]
        private static extern bool SteamAPI_ISteamRemoteStorage_GetUGCDownloadProgress(IntPtr c_instancePtr, ulong c_hContent, ref int c_pnBytesDownloaded, ref int c_pnBytesExpected);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamRemoteStorage_GetUGCDetails")]
        private static extern bool SteamAPI_ISteamRemoteStorage_GetUGCDetails(IntPtr c_instancePtr, ulong c_hContent, ref uint c_pnAppId, StringBuilder c_ppchName, ref int c_pnFileSizeInBytes, ref CSteamId c_pSteamIdOwner);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamRemoteStorage_UGCRead")]
        private static extern int SteamAPI_ISteamRemoteStorage_UGCRead(IntPtr c_instancePtr, ulong c_hContent, IntPtr c_pvData, int c_cubDataToRead, uint c_cOffset, uint c_eAction);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamRemoteStorage_GetCachedUGCCount")]
        private static extern int SteamAPI_ISteamRemoteStorage_GetCachedUGCCount(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamRemoteStorage_GetCachedUGCHandle")]
        private static extern ulong SteamAPI_ISteamRemoteStorage_GetCachedUGCHandle(IntPtr c_instancePtr, int c_iCachedContent);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamRemoteStorage_PublishWorkshopFile")]
        private static extern ulong SteamAPI_ISteamRemoteStorage_PublishWorkshopFile(IntPtr c_instancePtr, SafeUtf8String c_pchFile, SafeUtf8String c_pchPreviewFile, uint c_nConsumerAppId, SafeUtf8String c_pchTitle, SafeUtf8String c_pchDescription, uint c_eVisibility, ref SteamParamStringArray c_pTags, uint c_eWorkshopFileType);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamRemoteStorage_CreatePublishedFileUpdateRequest")]
        private static extern ulong SteamAPI_ISteamRemoteStorage_CreatePublishedFileUpdateRequest(IntPtr c_instancePtr, ulong c_unPublishedFileId);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamRemoteStorage_UpdatePublishedFileFile")]
        private static extern bool SteamAPI_ISteamRemoteStorage_UpdatePublishedFileFile(IntPtr c_instancePtr, ulong c_updateHandle, SafeUtf8String c_pchFile);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamRemoteStorage_UpdatePublishedFilePreviewFile")]
        private static extern bool SteamAPI_ISteamRemoteStorage_UpdatePublishedFilePreviewFile(IntPtr c_instancePtr, ulong c_updateHandle, SafeUtf8String c_pchPreviewFile);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamRemoteStorage_UpdatePublishedFileTitle")]
        private static extern bool SteamAPI_ISteamRemoteStorage_UpdatePublishedFileTitle(IntPtr c_instancePtr, ulong c_updateHandle, SafeUtf8String c_pchTitle);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamRemoteStorage_UpdatePublishedFileDescription")]
        private static extern bool SteamAPI_ISteamRemoteStorage_UpdatePublishedFileDescription(IntPtr c_instancePtr, ulong c_updateHandle, SafeUtf8String c_pchDescription);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamRemoteStorage_UpdatePublishedFileVisibility")]
        private static extern bool SteamAPI_ISteamRemoteStorage_UpdatePublishedFileVisibility(IntPtr c_instancePtr, ulong c_updateHandle, uint c_eVisibility);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamRemoteStorage_UpdatePublishedFileTags")]
        private static extern bool SteamAPI_ISteamRemoteStorage_UpdatePublishedFileTags(IntPtr c_instancePtr, ulong c_updateHandle, ref SteamParamStringArray c_pTags);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamRemoteStorage_CommitPublishedFileUpdate")]
        private static extern ulong SteamAPI_ISteamRemoteStorage_CommitPublishedFileUpdate(IntPtr c_instancePtr, ulong c_updateHandle);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamRemoteStorage_GetPublishedFileDetails")]
        private static extern ulong SteamAPI_ISteamRemoteStorage_GetPublishedFileDetails(IntPtr c_instancePtr, ulong c_unPublishedFileId, uint c_unMaxSecondsOld);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamRemoteStorage_DeletePublishedFile")]
        private static extern ulong SteamAPI_ISteamRemoteStorage_DeletePublishedFile(IntPtr c_instancePtr, ulong c_unPublishedFileId);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamRemoteStorage_EnumerateUserPublishedFiles")]
        private static extern ulong SteamAPI_ISteamRemoteStorage_EnumerateUserPublishedFiles(IntPtr c_instancePtr, uint c_unStartIndex);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamRemoteStorage_SubscribePublishedFile")]
        private static extern ulong SteamAPI_ISteamRemoteStorage_SubscribePublishedFile(IntPtr c_instancePtr, ulong c_unPublishedFileId);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamRemoteStorage_EnumerateUserSubscribedFiles")]
        private static extern ulong SteamAPI_ISteamRemoteStorage_EnumerateUserSubscribedFiles(IntPtr c_instancePtr, uint c_unStartIndex);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamRemoteStorage_UnsubscribePublishedFile")]
        private static extern ulong SteamAPI_ISteamRemoteStorage_UnsubscribePublishedFile(IntPtr c_instancePtr, ulong c_unPublishedFileId);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamRemoteStorage_UpdatePublishedFileSetChangeDescription")]
        private static extern bool SteamAPI_ISteamRemoteStorage_UpdatePublishedFileSetChangeDescription(IntPtr c_instancePtr, ulong c_updateHandle, SafeUtf8String c_pchChangeDescription);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamRemoteStorage_GetPublishedItemVoteDetails")]
        private static extern ulong SteamAPI_ISteamRemoteStorage_GetPublishedItemVoteDetails(IntPtr c_instancePtr, ulong c_unPublishedFileId);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamRemoteStorage_UpdateUserPublishedItemVote")]
        private static extern ulong SteamAPI_ISteamRemoteStorage_UpdateUserPublishedItemVote(IntPtr c_instancePtr, ulong c_unPublishedFileId, bool c_bVoteUp);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamRemoteStorage_GetUserPublishedItemVoteDetails")]
        private static extern ulong SteamAPI_ISteamRemoteStorage_GetUserPublishedItemVoteDetails(IntPtr c_instancePtr, ulong c_unPublishedFileId);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamRemoteStorage_EnumerateUserSharedWorkshopFiles")]
        private static extern ulong SteamAPI_ISteamRemoteStorage_EnumerateUserSharedWorkshopFiles(IntPtr c_instancePtr, ulong c_steamId, uint c_unStartIndex, ref SteamParamStringArray c_pRequiredTags, ref SteamParamStringArray c_pExcludedTags);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamRemoteStorage_PublishVideo")]
        private static extern ulong SteamAPI_ISteamRemoteStorage_PublishVideo(IntPtr c_instancePtr, uint c_eVideoProvider, SafeUtf8String c_pchVideoAccount, SafeUtf8String c_pchVideoIdentifier, SafeUtf8String c_pchPreviewFile, uint c_nConsumerAppId, SafeUtf8String c_pchTitle, SafeUtf8String c_pchDescription, uint c_eVisibility, ref SteamParamStringArray c_pTags);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamRemoteStorage_SetUserPublishedFileAction")]
        private static extern ulong SteamAPI_ISteamRemoteStorage_SetUserPublishedFileAction(IntPtr c_instancePtr, ulong c_unPublishedFileId, uint c_eAction);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamRemoteStorage_EnumeratePublishedFilesByUserAction")]
        private static extern ulong SteamAPI_ISteamRemoteStorage_EnumeratePublishedFilesByUserAction(IntPtr c_instancePtr, uint c_eAction, uint c_unStartIndex);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamRemoteStorage_EnumeratePublishedWorkshopFiles")]
        private static extern ulong SteamAPI_ISteamRemoteStorage_EnumeratePublishedWorkshopFiles(IntPtr c_instancePtr, uint c_eEnumerationType, uint c_unStartIndex, uint c_unCount, uint c_unDays, ref SteamParamStringArray c_pTags, ref SteamParamStringArray c_pUserTags);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamRemoteStorage_UGCDownloadToLocation")]
        private static extern ulong SteamAPI_ISteamRemoteStorage_UGCDownloadToLocation(IntPtr c_instancePtr, ulong c_hContent, SafeUtf8String c_pchLocation, uint c_unPriority);

        #endregion

        #region Overrides of ISteamRemoteStorage

        public override IntPtr GetIntPtr()
        {
            return m_instancePtr;
        }

        public override bool FileWrite(string c_pchFile, IntPtr c_pvData, int c_cubData)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamRemoteStorage_FileWrite(m_instancePtr, new SafeUtf8String(c_pchFile), c_pvData, c_cubData);

            return a_result;
        }

        public override int FileRead(string c_pchFile, IntPtr c_pvData, int c_cubDataToRead)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamRemoteStorage_FileRead(m_instancePtr, new SafeUtf8String(c_pchFile), c_pvData, c_cubDataToRead);

            return a_result;
        }

        public override ulong FileWriteAsync(string c_pchFile, IntPtr c_pvData, uint c_cubData)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamRemoteStorage_FileWriteAsync(m_instancePtr, new SafeUtf8String(c_pchFile), c_pvData, c_cubData);

            return a_result;
        }

        public override ulong FileReadAsync(string c_pchFile, uint c_nOffset, uint c_cubToRead)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamRemoteStorage_FileReadAsync(m_instancePtr, new SafeUtf8String(c_pchFile), c_nOffset, c_cubToRead);

            return a_result;
        }

        public override bool FileReadAsyncComplete(ulong c_hReadCall, IntPtr c_pvBuffer, uint c_cubToRead)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamRemoteStorage_FileReadAsyncComplete(m_instancePtr, c_hReadCall, c_pvBuffer, c_cubToRead);

            return a_result;
        }

        public override bool FileForget(string c_pchFile)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamRemoteStorage_FileForget(m_instancePtr, new SafeUtf8String(c_pchFile));

            return a_result;
        }

        public override bool FileDelete(string c_pchFile)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamRemoteStorage_FileDelete(m_instancePtr, new SafeUtf8String(c_pchFile));

            return a_result;
        }

        public override ulong FileShare(string c_pchFile)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamRemoteStorage_FileShare(m_instancePtr, new SafeUtf8String(c_pchFile));

            return a_result;
        }

        public override bool SetSyncPlatforms(string c_pchFile, uint c_eRemoteStoragePlatform)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamRemoteStorage_SetSyncPlatforms(m_instancePtr, new SafeUtf8String(c_pchFile), c_eRemoteStoragePlatform);

            return a_result;
        }

        public override ulong FileWriteStreamOpen(string c_pchFile)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamRemoteStorage_FileWriteStreamOpen(m_instancePtr, new SafeUtf8String(c_pchFile));

            return a_result;
        }

        public override bool FileWriteStreamWriteChunk(ulong c_writeHandle, IntPtr c_pvData, int c_cubData)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamRemoteStorage_FileWriteStreamWriteChunk(m_instancePtr, c_writeHandle, c_pvData, c_cubData);

            return a_result;
        }

        public override bool FileWriteStreamClose(ulong c_writeHandle)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamRemoteStorage_FileWriteStreamClose(m_instancePtr, c_writeHandle);

            return a_result;
        }

        public override bool FileWriteStreamCancel(ulong c_writeHandle)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamRemoteStorage_FileWriteStreamCancel(m_instancePtr, c_writeHandle);

            return a_result;
        }

        public override bool FileExists(string c_pchFile)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamRemoteStorage_FileExists(m_instancePtr, new SafeUtf8String(c_pchFile));

            return a_result;
        }

        public override bool FilePersisted(string c_pchFile)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamRemoteStorage_FilePersisted(m_instancePtr, new SafeUtf8String(c_pchFile));

            return a_result;
        }

        public override int GetFileSize(string c_pchFile)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamRemoteStorage_GetFileSize(m_instancePtr, new SafeUtf8String(c_pchFile));

            return a_result;
        }

        public override long GetFileTimestamp(string c_pchFile)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamRemoteStorage_GetFileTimestamp(m_instancePtr, new SafeUtf8String(c_pchFile));

            return a_result;
        }

        public override uint GetSyncPlatforms(string c_pchFile)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamRemoteStorage_GetSyncPlatforms(m_instancePtr, new SafeUtf8String(c_pchFile));

            return a_result;
        }

        public override int GetFileCount()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamRemoteStorage_GetFileCount(m_instancePtr);

            return a_result;
        }

        public override string GetFileNameAndSize(int c_iFile, ref int c_pnFileSizeInBytes)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamRemoteStorage_GetFileNameAndSize(m_instancePtr, c_iFile, ref c_pnFileSizeInBytes);

            return SafeUtf8String.ToString(a_result);
        }

        public override bool GetQuota(ref ulong c_pnTotalBytes, ref ulong c_puAvailableBytes)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamRemoteStorage_GetQuota(m_instancePtr, ref c_pnTotalBytes, ref c_puAvailableBytes);

            return a_result;
        }

        public override bool IsCloudEnabledForAccount()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamRemoteStorage_IsCloudEnabledForAccount(m_instancePtr);

            return a_result;
        }

        public override bool IsCloudEnabledForApp()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamRemoteStorage_IsCloudEnabledForApp(m_instancePtr);

            return a_result;
        }

        public override void SetCloudEnabledForApp(bool c_bEnabled)
        {
            CheckIfUsable();

            SteamAPI_ISteamRemoteStorage_SetCloudEnabledForApp(m_instancePtr, c_bEnabled);
        }

        public override ulong UgcDownload(ulong c_hContent, uint c_unPriority)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamRemoteStorage_UGCDownload(m_instancePtr, c_hContent, c_unPriority);

            return a_result;
        }

        public override bool GetUgcDownloadProgress(ulong c_hContent, ref int c_pnBytesDownloaded, ref int c_pnBytesExpected)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamRemoteStorage_GetUGCDownloadProgress(m_instancePtr, c_hContent, ref c_pnBytesDownloaded, ref c_pnBytesExpected);

            return a_result;
        }

        public override bool GetUgcDetails(ulong c_hContent, ref uint c_pnAppId, string c_ppchName, ref int c_pnFileSizeInBytes, out CSteamId c_pSteamIdOwner)
        {
            CheckIfUsable();

            c_pSteamIdOwner = new CSteamId();

            var a_result = SteamAPI_ISteamRemoteStorage_GetUGCDetails(m_instancePtr, c_hContent, ref c_pnAppId, new StringBuilder(c_ppchName), ref c_pnFileSizeInBytes, ref c_pSteamIdOwner);

            return a_result;
        }

        public override int UgcRead(ulong c_hContent, IntPtr c_pvData, int c_cubDataToRead, uint c_cOffset, uint c_eAction)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamRemoteStorage_UGCRead(m_instancePtr, c_hContent, c_pvData, c_cubDataToRead, c_cOffset, c_eAction);

            return a_result;
        }

        public override int GetCachedUgcCount()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamRemoteStorage_GetCachedUGCCount(m_instancePtr);

            return a_result;
        }

        public override ulong GetCachedUgcHandle(int c_iCachedContent)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamRemoteStorage_GetCachedUGCHandle(m_instancePtr, c_iCachedContent);

            return a_result;
        }

        public override ulong PublishWorkshopFile(string c_pchFile, string c_pchPreviewFile, uint c_nConsumerAppId, string c_pchTitle, string c_pchDescription, uint c_eVisibility, ref SteamParamStringArray c_pTags, uint c_eWorkshopFileType)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamRemoteStorage_PublishWorkshopFile(m_instancePtr, new SafeUtf8String(c_pchFile), new SafeUtf8String(c_pchPreviewFile), c_nConsumerAppId, new SafeUtf8String(c_pchTitle), new SafeUtf8String(c_pchDescription), c_eVisibility, ref c_pTags, c_eWorkshopFileType);

            return a_result;
        }

        public override ulong CreatePublishedFileUpdateRequest(ulong c_unPublishedFileId)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamRemoteStorage_CreatePublishedFileUpdateRequest(m_instancePtr, c_unPublishedFileId);

            return a_result;
        }

        public override bool UpdatePublishedFileFile(ulong c_updateHandle, string c_pchFile)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamRemoteStorage_UpdatePublishedFileFile(m_instancePtr, c_updateHandle, new SafeUtf8String(c_pchFile));

            return a_result;
        }

        public override bool UpdatePublishedFilePreviewFile(ulong c_updateHandle, string c_pchPreviewFile)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamRemoteStorage_UpdatePublishedFilePreviewFile(m_instancePtr, c_updateHandle, new SafeUtf8String(c_pchPreviewFile));

            return a_result;
        }

        public override bool UpdatePublishedFileTitle(ulong c_updateHandle, string c_pchTitle)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamRemoteStorage_UpdatePublishedFileTitle(m_instancePtr, c_updateHandle, new SafeUtf8String(c_pchTitle));

            return a_result;
        }

        public override bool UpdatePublishedFileDescription(ulong c_updateHandle, string c_pchDescription)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamRemoteStorage_UpdatePublishedFileDescription(m_instancePtr, c_updateHandle, new SafeUtf8String(c_pchDescription));

            return a_result;
        }

        public override bool UpdatePublishedFileVisibility(ulong c_updateHandle, uint c_eVisibility)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamRemoteStorage_UpdatePublishedFileVisibility(m_instancePtr, c_updateHandle, c_eVisibility);

            return a_result;
        }

        public override bool UpdatePublishedFileTags(ulong c_updateHandle, ref SteamParamStringArray c_pTags)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamRemoteStorage_UpdatePublishedFileTags(m_instancePtr, c_updateHandle, ref c_pTags);

            return a_result;
        }

        public override ulong CommitPublishedFileUpdate(ulong c_updateHandle)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamRemoteStorage_CommitPublishedFileUpdate(m_instancePtr, c_updateHandle);

            return a_result;
        }

        public override ulong GetPublishedFileDetails(ulong c_unPublishedFileId, uint c_unMaxSecondsOld)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamRemoteStorage_GetPublishedFileDetails(m_instancePtr, c_unPublishedFileId, c_unMaxSecondsOld);

            return a_result;
        }

        public override ulong DeletePublishedFile(ulong c_unPublishedFileId)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamRemoteStorage_DeletePublishedFile(m_instancePtr, c_unPublishedFileId);

            return a_result;
        }

        public override ulong EnumerateUserPublishedFiles(uint c_unStartIndex)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamRemoteStorage_EnumerateUserPublishedFiles(m_instancePtr, c_unStartIndex);

            return a_result;
        }

        public override ulong SubscribePublishedFile(ulong c_unPublishedFileId)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamRemoteStorage_SubscribePublishedFile(m_instancePtr, c_unPublishedFileId);

            return a_result;
        }

        public override ulong EnumerateUserSubscribedFiles(uint c_unStartIndex)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamRemoteStorage_EnumerateUserSubscribedFiles(m_instancePtr, c_unStartIndex);

            return a_result;
        }

        public override ulong UnsubscribePublishedFile(ulong c_unPublishedFileId)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamRemoteStorage_UnsubscribePublishedFile(m_instancePtr, c_unPublishedFileId);

            return a_result;
        }

        public override bool UpdatePublishedFileSetChangeDescription(ulong c_updateHandle, string c_pchChangeDescription)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamRemoteStorage_UpdatePublishedFileSetChangeDescription(m_instancePtr, c_updateHandle, new SafeUtf8String(c_pchChangeDescription));

            return a_result;
        }

        public override ulong GetPublishedItemVoteDetails(ulong c_unPublishedFileId)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamRemoteStorage_GetPublishedItemVoteDetails(m_instancePtr, c_unPublishedFileId);

            return a_result;
        }

        public override ulong UpdateUserPublishedItemVote(ulong c_unPublishedFileId, bool c_bVoteUp)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamRemoteStorage_UpdateUserPublishedItemVote(m_instancePtr, c_unPublishedFileId, c_bVoteUp);

            return a_result;
        }

        public override ulong GetUserPublishedItemVoteDetails(ulong c_unPublishedFileId)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamRemoteStorage_GetUserPublishedItemVoteDetails(m_instancePtr, c_unPublishedFileId);

            return a_result;
        }

        public override ulong EnumerateUserSharedWorkshopFiles(ulong c_steamId, uint c_unStartIndex, ref SteamParamStringArray c_pRequiredTags, ref SteamParamStringArray c_pExcludedTags)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamRemoteStorage_EnumerateUserSharedWorkshopFiles(m_instancePtr, c_steamId, c_unStartIndex, ref c_pRequiredTags, ref c_pExcludedTags);

            return a_result;
        }

        public override ulong PublishVideo(uint c_eVideoProvider, string c_pchVideoAccount, string c_pchVideoIdentifier, string c_pchPreviewFile, uint c_nConsumerAppId, string c_pchTitle, string c_pchDescription, uint c_eVisibility, ref SteamParamStringArray c_pTags)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamRemoteStorage_PublishVideo(m_instancePtr, c_eVideoProvider, new SafeUtf8String(c_pchVideoAccount), new SafeUtf8String(c_pchVideoIdentifier), new SafeUtf8String(c_pchPreviewFile), c_nConsumerAppId, new SafeUtf8String(c_pchTitle), new SafeUtf8String(c_pchDescription), c_eVisibility, ref c_pTags);

            return a_result;
        }

        public override ulong SetUserPublishedFileAction(ulong c_unPublishedFileId, uint c_eAction)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamRemoteStorage_SetUserPublishedFileAction(m_instancePtr, c_unPublishedFileId, c_eAction);

            return a_result;
        }

        public override ulong EnumeratePublishedFilesByUserAction(uint c_eAction, uint c_unStartIndex)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamRemoteStorage_EnumeratePublishedFilesByUserAction(m_instancePtr, c_eAction, c_unStartIndex);

            return a_result;
        }

        public override ulong EnumeratePublishedWorkshopFiles(uint c_eEnumerationType, uint c_unStartIndex, uint c_unCount, uint c_unDays, ref SteamParamStringArray c_pTags, ref SteamParamStringArray c_pUserTags)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamRemoteStorage_EnumeratePublishedWorkshopFiles(m_instancePtr, c_eEnumerationType, c_unStartIndex, c_unCount, c_unDays, ref c_pTags, ref c_pUserTags);

            return a_result;
        }

        public override ulong UgcDownloadToLocation(ulong c_hContent, string c_pchLocation, uint c_unPriority)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamRemoteStorage_UGCDownloadToLocation(m_instancePtr, c_hContent, new SafeUtf8String(c_pchLocation), c_unPriority);

            return a_result;
        }

        #endregion
    }

    public abstract class ISteamRemoteStorage
    {
        public abstract IntPtr GetIntPtr();
        public abstract bool FileWrite(string c_pchFile, IntPtr c_pvData, int c_cubData);
        public abstract int FileRead(string c_pchFile, IntPtr c_pvData, int c_cubDataToRead);
        public abstract ulong FileWriteAsync(string c_pchFile, IntPtr c_pvData, uint c_cubData);
        public abstract ulong FileReadAsync(string c_pchFile, uint c_nOffset, uint c_cubToRead);
        public abstract bool FileReadAsyncComplete(ulong c_hReadCall, IntPtr c_pvBuffer, uint c_cubToRead);
        public abstract bool FileForget(string c_pchFile);
        public abstract bool FileDelete(string c_pchFile);
        public abstract ulong FileShare(string c_pchFile);
        public abstract bool SetSyncPlatforms(string c_pchFile, uint c_eRemoteStoragePlatform);
        public abstract ulong FileWriteStreamOpen(string c_pchFile);
        public abstract bool FileWriteStreamWriteChunk(ulong c_writeHandle, IntPtr c_pvData, int c_cubData);
        public abstract bool FileWriteStreamClose(ulong c_writeHandle);
        public abstract bool FileWriteStreamCancel(ulong c_writeHandle);
        public abstract bool FileExists(string c_pchFile);
        public abstract bool FilePersisted(string c_pchFile);
        public abstract int GetFileSize(string c_pchFile);
        public abstract long GetFileTimestamp(string c_pchFile);
        public abstract uint GetSyncPlatforms(string c_pchFile);
        public abstract int GetFileCount();
        public abstract string GetFileNameAndSize(int c_iFile, ref int c_pnFileSizeInBytes);
        public abstract bool GetQuota(ref ulong c_pnTotalBytes, ref ulong c_puAvailableBytes);
        public abstract bool IsCloudEnabledForAccount();
        public abstract bool IsCloudEnabledForApp();
        public abstract void SetCloudEnabledForApp(bool c_bEnabled);
        public abstract ulong UgcDownload(ulong c_hContent, uint c_unPriority);
        public abstract bool GetUgcDownloadProgress(ulong c_hContent, ref int c_pnBytesDownloaded, ref int c_pnBytesExpected);
        public abstract bool GetUgcDetails(ulong c_hContent, ref uint c_pnAppId, string c_ppchName, ref int c_pnFileSizeInBytes, out CSteamId c_pSteamIdOwner);
        public abstract int UgcRead(ulong c_hContent, IntPtr c_pvData, int c_cubDataToRead, uint c_cOffset, uint c_eAction);
        public abstract int GetCachedUgcCount();
        public abstract ulong GetCachedUgcHandle(int c_iCachedContent);
        public abstract ulong PublishWorkshopFile(string c_pchFile, string c_pchPreviewFile, uint c_nConsumerAppId, string c_pchTitle, string c_pchDescription, uint c_eVisibility, ref SteamParamStringArray c_pTags, uint c_eWorkshopFileType);
        public abstract ulong CreatePublishedFileUpdateRequest(ulong c_unPublishedFileId);
        public abstract bool UpdatePublishedFileFile(ulong c_updateHandle, string c_pchFile);
        public abstract bool UpdatePublishedFilePreviewFile(ulong c_updateHandle, string c_pchPreviewFile);
        public abstract bool UpdatePublishedFileTitle(ulong c_updateHandle, string c_pchTitle);
        public abstract bool UpdatePublishedFileDescription(ulong c_updateHandle, string c_pchDescription);
        public abstract bool UpdatePublishedFileVisibility(ulong c_updateHandle, uint c_eVisibility);
        public abstract bool UpdatePublishedFileTags(ulong c_updateHandle, ref SteamParamStringArray c_pTags);
        public abstract ulong CommitPublishedFileUpdate(ulong c_updateHandle);
        public abstract ulong GetPublishedFileDetails(ulong c_unPublishedFileId, uint c_unMaxSecondsOld);
        public abstract ulong DeletePublishedFile(ulong c_unPublishedFileId);
        public abstract ulong EnumerateUserPublishedFiles(uint c_unStartIndex);
        public abstract ulong SubscribePublishedFile(ulong c_unPublishedFileId);
        public abstract ulong EnumerateUserSubscribedFiles(uint c_unStartIndex);
        public abstract ulong UnsubscribePublishedFile(ulong c_unPublishedFileId);
        public abstract bool UpdatePublishedFileSetChangeDescription(ulong c_updateHandle, string c_pchChangeDescription);
        public abstract ulong GetPublishedItemVoteDetails(ulong c_unPublishedFileId);
        public abstract ulong UpdateUserPublishedItemVote(ulong c_unPublishedFileId, bool c_bVoteUp);
        public abstract ulong GetUserPublishedItemVoteDetails(ulong c_unPublishedFileId);
        public abstract ulong EnumerateUserSharedWorkshopFiles(ulong c_steamId, uint c_unStartIndex, ref SteamParamStringArray c_pRequiredTags, ref SteamParamStringArray c_pExcludedTags);
        public abstract ulong PublishVideo(uint c_eVideoProvider, string c_pchVideoAccount, string c_pchVideoIdentifier, string c_pchPreviewFile, uint c_nConsumerAppId, string c_pchTitle, string c_pchDescription, uint c_eVisibility, ref SteamParamStringArray c_pTags);
        public abstract ulong SetUserPublishedFileAction(ulong c_unPublishedFileId, uint c_eAction);
        public abstract ulong EnumeratePublishedFilesByUserAction(uint c_eAction, uint c_unStartIndex);
        public abstract ulong EnumeratePublishedWorkshopFiles(uint c_eEnumerationType, uint c_unStartIndex, uint c_unCount, uint c_unDays, ref SteamParamStringArray c_pTags, ref SteamParamStringArray c_pUserTags);
        public abstract ulong UgcDownloadToLocation(ulong c_hContent, string c_pchLocation, uint c_unPriority);
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SteamParamStringArray
    {
        public SafeUtf8String m_ppStrings; // const char **
        public int m_nNumStrings;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RemoteStorageFileReadAsyncComplete
    {
        public ulong FileReadAsync;
        public EResult Result;
        public uint Offset;
        public uint Read;
    }
}