//   !!  // Steamworks.Core - SteamHttp.cs
// *.-". // Created: 2016-10-21 [11:34 PM]
//  | |  // Copyright 2016 // MIT License // The Fox Council 
// Modified by: Fox Diller on 2016-10-22 @ 3:03 PM

#region Usings

using System;
using System.Runtime.InteropServices;

#endregion

namespace Steamworks.Core
{
    public class SteamHttp : ISteamHTTP
    {
        private readonly IntPtr m_instancePtr;

        public SteamHttp(IntPtr c_instancePtr)
        {
            m_instancePtr = c_instancePtr;
        }

        private void CheckIfUsable()
        {
            if (m_instancePtr == IntPtr.Zero)
            {
                throw new InvalidOperationException("Steam Http Not Initialized!");
            }
        }

        #region Native Methods

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamHTTP_CreateHTTPRequest")]
        private static extern uint SteamAPI_ISteamHTTP_CreateHTTPRequest(IntPtr c_instancePtr, uint c_eHttpRequestMethod, SafeUtf8String c_pchAbsoluteUrl);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamHTTP_SetHTTPRequestContextValue")]
        private static extern bool SteamAPI_ISteamHTTP_SetHTTPRequestContextValue(IntPtr c_instancePtr, uint c_hRequest, ulong c_ulContextValue);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamHTTP_SetHTTPRequestNetworkActivityTimeout")]
        private static extern bool SteamAPI_ISteamHTTP_SetHTTPRequestNetworkActivityTimeout(IntPtr c_instancePtr, uint c_hRequest, uint c_unTimeoutSeconds);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamHTTP_SetHTTPRequestHeaderValue")]
        private static extern bool SteamAPI_ISteamHTTP_SetHTTPRequestHeaderValue(IntPtr c_instancePtr, uint c_hRequest, SafeUtf8String c_pchHeaderName, SafeUtf8String c_pchHeaderValue);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamHTTP_SetHTTPRequestGetOrPostParameter")]
        private static extern bool SteamAPI_ISteamHTTP_SetHTTPRequestGetOrPostParameter(IntPtr c_instancePtr, uint c_hRequest, SafeUtf8String c_pchParamName, SafeUtf8String c_pchParamValue);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamHTTP_SendHTTPRequest")]
        private static extern bool SteamAPI_ISteamHTTP_SendHTTPRequest(IntPtr c_instancePtr, uint c_hRequest, ref ulong c_pCallHandle);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamHTTP_SendHTTPRequestAndStreamResponse")]
        private static extern bool SteamAPI_ISteamHTTP_SendHTTPRequestAndStreamResponse(IntPtr c_instancePtr, uint c_hRequest, ref ulong c_pCallHandle);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamHTTP_DeferHTTPRequest")]
        private static extern bool SteamAPI_ISteamHTTP_DeferHTTPRequest(IntPtr c_instancePtr, uint c_hRequest);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamHTTP_PrioritizeHTTPRequest")]
        private static extern bool SteamAPI_ISteamHTTP_PrioritizeHTTPRequest(IntPtr c_instancePtr, uint c_hRequest);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamHTTP_GetHTTPResponseHeaderSize")]
        private static extern bool SteamAPI_ISteamHTTP_GetHTTPResponseHeaderSize(IntPtr c_instancePtr, uint c_hRequest, SafeUtf8String c_pchHeaderName, ref uint c_unResponseHeaderSize);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamHTTP_GetHTTPResponseHeaderValue")]
        private static extern bool SteamAPI_ISteamHTTP_GetHTTPResponseHeaderValue(IntPtr c_instancePtr, uint c_hRequest, SafeUtf8String c_pchHeaderName, IntPtr c_pHeaderValueBuffer, uint c_unBufferSize);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamHTTP_GetHTTPResponseBodySize")]
        private static extern bool SteamAPI_ISteamHTTP_GetHTTPResponseBodySize(IntPtr c_instancePtr, uint c_hRequest, ref uint c_unBodySize);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamHTTP_GetHTTPResponseBodyData")]
        private static extern bool SteamAPI_ISteamHTTP_GetHTTPResponseBodyData(IntPtr c_instancePtr, uint c_hRequest, IntPtr c_pBodyDataBuffer, uint c_unBufferSize);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamHTTP_GetHTTPStreamingResponseBodyData")]
        private static extern bool SteamAPI_ISteamHTTP_GetHTTPStreamingResponseBodyData(IntPtr c_instancePtr, uint c_hRequest, uint c_cOffset, IntPtr c_pBodyDataBuffer, uint c_unBufferSize);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamHTTP_ReleaseHTTPRequest")]
        private static extern bool SteamAPI_ISteamHTTP_ReleaseHTTPRequest(IntPtr c_instancePtr, uint c_hRequest);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamHTTP_GetHTTPDownloadProgressPct")]
        private static extern bool SteamAPI_ISteamHTTP_GetHTTPDownloadProgressPct(IntPtr c_instancePtr, uint c_hRequest, ref float c_pflPercentOut);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamHTTP_SetHTTPRequestRawPostBody")]
        private static extern bool SteamAPI_ISteamHTTP_SetHTTPRequestRawPostBody(IntPtr c_instancePtr, uint c_hRequest, SafeUtf8String c_pchContentType, IntPtr c_pubBody, uint c_unBodyLen);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamHTTP_CreateCookieContainer")]
        private static extern uint SteamAPI_ISteamHTTP_CreateCookieContainer(IntPtr c_instancePtr, bool c_bAllowResponsesToModify);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamHTTP_ReleaseCookieContainer")]
        private static extern bool SteamAPI_ISteamHTTP_ReleaseCookieContainer(IntPtr c_instancePtr, uint c_hCookieContainer);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamHTTP_SetCookie")]
        private static extern bool SteamAPI_ISteamHTTP_SetCookie(IntPtr c_instancePtr, uint c_hCookieContainer, SafeUtf8String c_pchHost, SafeUtf8String c_pchUrl, SafeUtf8String c_pchCookie);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamHTTP_SetHTTPRequestCookieContainer")]
        private static extern bool SteamAPI_ISteamHTTP_SetHTTPRequestCookieContainer(IntPtr c_instancePtr, uint c_hRequest, uint c_hCookieContainer);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamHTTP_SetHTTPRequestUserAgentInfo")]
        private static extern bool SteamAPI_ISteamHTTP_SetHTTPRequestUserAgentInfo(IntPtr c_instancePtr, uint c_hRequest, SafeUtf8String c_pchUserAgentInfo);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamHTTP_SetHTTPRequestRequiresVerifiedCertificate")]
        private static extern bool SteamAPI_ISteamHTTP_SetHTTPRequestRequiresVerifiedCertificate(IntPtr c_instancePtr, uint c_hRequest, bool c_bRequireVerifiedCertificate);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamHTTP_SetHTTPRequestAbsoluteTimeoutMS")]
        private static extern bool SteamAPI_ISteamHTTP_SetHTTPRequestAbsoluteTimeoutMS(IntPtr c_instancePtr, uint c_hRequest, uint c_unMilliseconds);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamHTTP_GetHTTPRequestWasTimedOut")]
        private static extern bool SteamAPI_ISteamHTTP_GetHTTPRequestWasTimedOut(IntPtr c_instancePtr, uint c_hRequest, ref bool c_pbWasTimedOut);

        #endregion

        #region Overrides of ISteamHTTP

        public override IntPtr GetIntPtr()
        {
            return m_instancePtr;
        }

        public override uint CreateHttpRequest(uint c_eHttpRequestMethod, string c_pchAbsoluteUrl)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamHTTP_CreateHTTPRequest(m_instancePtr, c_eHttpRequestMethod, new SafeUtf8String(c_pchAbsoluteUrl));

            return a_result;
        }

        public override bool SetHttpRequestContextValue(uint c_hRequest, ulong c_ulContextValue)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamHTTP_SetHTTPRequestContextValue(m_instancePtr, c_hRequest, c_ulContextValue);

            return a_result;
        }

        public override bool SetHttpRequestNetworkActivityTimeout(uint c_hRequest, uint c_unTimeoutSeconds)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamHTTP_SetHTTPRequestNetworkActivityTimeout(m_instancePtr, c_hRequest, c_unTimeoutSeconds);

            return a_result;
        }

        public override bool SetHttpRequestHeaderValue(uint c_hRequest, string c_pchHeaderName, string c_pchHeaderValue)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamHTTP_SetHTTPRequestHeaderValue(m_instancePtr, c_hRequest, new SafeUtf8String(c_pchHeaderName), new SafeUtf8String(c_pchHeaderValue));

            return a_result;
        }

        public override bool SetHttpRequestGetOrPostParameter(uint c_hRequest, string c_pchParamName, string c_pchParamValue)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamHTTP_SetHTTPRequestGetOrPostParameter(m_instancePtr, c_hRequest, new SafeUtf8String(c_pchParamName), new SafeUtf8String(c_pchParamValue));

            return a_result;
        }

        public override bool SendHttpRequest(uint c_hRequest, ref ulong c_pCallHandle)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamHTTP_SendHTTPRequest(m_instancePtr, c_hRequest, ref c_pCallHandle);

            return a_result;
        }

        public override bool SendHttpRequestAndStreamResponse(uint c_hRequest, ref ulong c_pCallHandle)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamHTTP_SendHTTPRequestAndStreamResponse(m_instancePtr, c_hRequest, ref c_pCallHandle);

            return a_result;
        }

        public override bool DeferHttpRequest(uint c_hRequest)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamHTTP_DeferHTTPRequest(m_instancePtr, c_hRequest);

            return a_result;
        }

        public override bool PrioritizeHttpRequest(uint c_hRequest)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamHTTP_PrioritizeHTTPRequest(m_instancePtr, c_hRequest);

            return a_result;
        }

        public override bool GetHttpResponseHeaderSize(uint c_hRequest, string c_pchHeaderName, ref uint c_unResponseHeaderSize)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamHTTP_GetHTTPResponseHeaderSize(m_instancePtr, c_hRequest, new SafeUtf8String(c_pchHeaderName), ref c_unResponseHeaderSize);

            return a_result;
        }

        public override bool GetHttpResponseHeaderValue(uint c_hRequest, string c_pchHeaderName, IntPtr c_pHeaderValueBuffer, uint c_unBufferSize)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamHTTP_GetHTTPResponseHeaderValue(m_instancePtr, c_hRequest, new SafeUtf8String(c_pchHeaderName), c_pHeaderValueBuffer, c_unBufferSize);

            return a_result;
        }

        public override bool GetHttpResponseBodySize(uint c_hRequest, ref uint c_unBodySize)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamHTTP_GetHTTPResponseBodySize(m_instancePtr, c_hRequest, ref c_unBodySize);

            return a_result;
        }

        public override bool GetHttpResponseBodyData(uint c_hRequest, IntPtr c_pBodyDataBuffer, uint c_unBufferSize)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamHTTP_GetHTTPResponseBodyData(m_instancePtr, c_hRequest, c_pBodyDataBuffer, c_unBufferSize);

            return a_result;
        }

        public override bool GetHttpStreamingResponseBodyData(uint c_hRequest, uint c_cOffset, IntPtr c_pBodyDataBuffer, uint c_unBufferSize)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamHTTP_GetHTTPStreamingResponseBodyData(m_instancePtr, c_hRequest, c_cOffset, c_pBodyDataBuffer, c_unBufferSize);

            return a_result;
        }

        public override bool ReleaseHttpRequest(uint c_hRequest)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamHTTP_ReleaseHTTPRequest(m_instancePtr, c_hRequest);

            return a_result;
        }

        public override bool GetHttpDownloadProgressPct(uint c_hRequest, ref float c_pflPercentOut)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamHTTP_GetHTTPDownloadProgressPct(m_instancePtr, c_hRequest, ref c_pflPercentOut);

            return a_result;
        }

        public override bool SetHttpRequestRawPostBody(uint c_hRequest, string c_pchContentType, IntPtr c_pubBody, uint c_unBodyLen)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamHTTP_SetHTTPRequestRawPostBody(m_instancePtr, c_hRequest, new SafeUtf8String(c_pchContentType), c_pubBody, c_unBodyLen);

            return a_result;
        }

        public override uint CreateCookieContainer(bool c_bAllowResponsesToModify)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamHTTP_CreateCookieContainer(m_instancePtr, c_bAllowResponsesToModify);

            return a_result;
        }

        public override bool ReleaseCookieContainer(uint c_hCookieContainer)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamHTTP_ReleaseCookieContainer(m_instancePtr, c_hCookieContainer);

            return a_result;
        }

        public override bool SetCookie(uint c_hCookieContainer, string c_pchHost, string c_pchUrl, string c_pchCookie)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamHTTP_SetCookie(m_instancePtr, c_hCookieContainer, new SafeUtf8String(c_pchHost), new SafeUtf8String(c_pchUrl), new SafeUtf8String(c_pchCookie));

            return a_result;
        }

        public override bool SetHttpRequestCookieContainer(uint c_hRequest, uint c_hCookieContainer)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamHTTP_SetHTTPRequestCookieContainer(m_instancePtr, c_hRequest, c_hCookieContainer);

            return a_result;
        }

        public override bool SetHttpRequestUserAgentInfo(uint c_hRequest, string c_pchUserAgentInfo)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamHTTP_SetHTTPRequestUserAgentInfo(m_instancePtr, c_hRequest, new SafeUtf8String(c_pchUserAgentInfo));

            return a_result;
        }

        public override bool SetHttpRequestRequiresVerifiedCertificate(uint c_hRequest, bool c_bRequireVerifiedCertificate)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamHTTP_SetHTTPRequestRequiresVerifiedCertificate(m_instancePtr, c_hRequest, c_bRequireVerifiedCertificate);

            return a_result;
        }

        public override bool SetHttpRequestAbsoluteTimeoutMs(uint c_hRequest, uint c_unMilliseconds)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamHTTP_SetHTTPRequestAbsoluteTimeoutMS(m_instancePtr, c_hRequest, c_unMilliseconds);

            return a_result;
        }

        public override bool GetHttpRequestWasTimedOut(uint c_hRequest, ref bool c_pbWasTimedOut)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamHTTP_GetHTTPRequestWasTimedOut(m_instancePtr, c_hRequest, ref c_pbWasTimedOut);

            return a_result;
        }

        #endregion
    }

    public abstract class ISteamHTTP
    {
        public abstract IntPtr GetIntPtr();
        public abstract uint CreateHttpRequest(uint c_eHttpRequestMethod, string c_pchAbsoluteUrl);
        public abstract bool SetHttpRequestContextValue(uint c_hRequest, ulong c_ulContextValue);
        public abstract bool SetHttpRequestNetworkActivityTimeout(uint c_hRequest, uint c_unTimeoutSeconds);
        public abstract bool SetHttpRequestHeaderValue(uint c_hRequest, string c_pchHeaderName, string c_pchHeaderValue);
        public abstract bool SetHttpRequestGetOrPostParameter(uint c_hRequest, string c_pchParamName, string c_pchParamValue);
        public abstract bool SendHttpRequest(uint c_hRequest, ref ulong c_pCallHandle);
        public abstract bool SendHttpRequestAndStreamResponse(uint c_hRequest, ref ulong c_pCallHandle);
        public abstract bool DeferHttpRequest(uint c_hRequest);
        public abstract bool PrioritizeHttpRequest(uint c_hRequest);
        public abstract bool GetHttpResponseHeaderSize(uint c_hRequest, string c_pchHeaderName, ref uint c_unResponseHeaderSize);
        public abstract bool GetHttpResponseHeaderValue(uint c_hRequest, string c_pchHeaderName, IntPtr c_pHeaderValueBuffer, uint c_unBufferSize);
        public abstract bool GetHttpResponseBodySize(uint c_hRequest, ref uint c_unBodySize);
        public abstract bool GetHttpResponseBodyData(uint c_hRequest, IntPtr c_pBodyDataBuffer, uint c_unBufferSize);
        public abstract bool GetHttpStreamingResponseBodyData(uint c_hRequest, uint c_cOffset, IntPtr c_pBodyDataBuffer, uint c_unBufferSize);
        public abstract bool ReleaseHttpRequest(uint c_hRequest);
        public abstract bool GetHttpDownloadProgressPct(uint c_hRequest, ref float c_pflPercentOut);
        public abstract bool SetHttpRequestRawPostBody(uint c_hRequest, string c_pchContentType, IntPtr c_pubBody, uint c_unBodyLen);
        public abstract uint CreateCookieContainer(bool c_bAllowResponsesToModify);
        public abstract bool ReleaseCookieContainer(uint c_hCookieContainer);
        public abstract bool SetCookie(uint c_hCookieContainer, string c_pchHost, string c_pchUrl, string c_pchCookie);
        public abstract bool SetHttpRequestCookieContainer(uint c_hRequest, uint c_hCookieContainer);
        public abstract bool SetHttpRequestUserAgentInfo(uint c_hRequest, string c_pchUserAgentInfo);
        public abstract bool SetHttpRequestRequiresVerifiedCertificate(uint c_hRequest, bool c_bRequireVerifiedCertificate);
        public abstract bool SetHttpRequestAbsoluteTimeoutMs(uint c_hRequest, uint c_unMilliseconds);
        public abstract bool GetHttpRequestWasTimedOut(uint c_hRequest, ref bool c_pbWasTimedOut);
    }
}