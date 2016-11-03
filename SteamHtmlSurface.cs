using System;
using System.Runtime.InteropServices;

namespace Steamworks.Core
{
    public class SteamHtmlSurface : ISteamHtmlSurface
    {
        private readonly IntPtr m_instancePtr;

        public SteamHtmlSurface(IntPtr c_instancePtr)
        {
            m_instancePtr = c_instancePtr;
        }

        private void CheckIfUsable()
        {
            if (m_instancePtr == IntPtr.Zero)
            {
                throw new InvalidOperationException("Steam Html Surface Not Initialized!");
            }
        }

        #region Native Methods

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamHTMLSurface_DestructISteamHTMLSurface")]
        private static extern void SteamAPI_ISteamHTMLSurface_DestructISteamHTMLSurface(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamHTMLSurface_Init")]
        private static extern bool SteamAPI_ISteamHTMLSurface_Init(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamHTMLSurface_Shutdown")]
        private static extern bool SteamAPI_ISteamHTMLSurface_Shutdown(IntPtr c_instancePtr);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamHTMLSurface_CreateBrowser")]
        private static extern ulong SteamAPI_ISteamHTMLSurface_CreateBrowser(IntPtr c_instancePtr, SafeUtf8String c_pchUserAgent, SafeUtf8String c_pchUserCss);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamHTMLSurface_RemoveBrowser")]
        private static extern void SteamAPI_ISteamHTMLSurface_RemoveBrowser(IntPtr c_instancePtr, uint c_unBrowserHandle);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamHTMLSurface_LoadURL")]
        private static extern void SteamAPI_ISteamHTMLSurface_LoadURL(IntPtr c_instancePtr, uint c_unBrowserHandle, SafeUtf8String c_pchUrl, SafeUtf8String c_pchPostData);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamHTMLSurface_SetSize")]
        private static extern void SteamAPI_ISteamHTMLSurface_SetSize(IntPtr c_instancePtr, uint c_unBrowserHandle, uint c_unWidth, uint c_unHeight);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamHTMLSurface_StopLoad")]
        private static extern void SteamAPI_ISteamHTMLSurface_StopLoad(IntPtr c_instancePtr, uint c_unBrowserHandle);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamHTMLSurface_Reload")]
        private static extern void SteamAPI_ISteamHTMLSurface_Reload(IntPtr c_instancePtr, uint c_unBrowserHandle);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamHTMLSurface_GoBack")]
        private static extern void SteamAPI_ISteamHTMLSurface_GoBack(IntPtr c_instancePtr, uint c_unBrowserHandle);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamHTMLSurface_GoForward")]
        private static extern void SteamAPI_ISteamHTMLSurface_GoForward(IntPtr c_instancePtr, uint c_unBrowserHandle);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamHTMLSurface_AddHeader")]
        private static extern void SteamAPI_ISteamHTMLSurface_AddHeader(IntPtr c_instancePtr, uint c_unBrowserHandle, SafeUtf8String c_pchKey, SafeUtf8String c_pchValue);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamHTMLSurface_ExecuteJavascript")]
        private static extern void SteamAPI_ISteamHTMLSurface_ExecuteJavascript(IntPtr c_instancePtr, uint c_unBrowserHandle, SafeUtf8String c_pchScript);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamHTMLSurface_MouseUp")]
        private static extern void SteamAPI_ISteamHTMLSurface_MouseUp(IntPtr c_instancePtr, uint c_unBrowserHandle, uint c_eMouseButton);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamHTMLSurface_MouseDown")]
        private static extern void SteamAPI_ISteamHTMLSurface_MouseDown(IntPtr c_instancePtr, uint c_unBrowserHandle, uint c_eMouseButton);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamHTMLSurface_MouseDoubleClick")]
        private static extern void SteamAPI_ISteamHTMLSurface_MouseDoubleClick(IntPtr c_instancePtr, uint c_unBrowserHandle, uint c_eMouseButton);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamHTMLSurface_MouseMove")]
        private static extern void SteamAPI_ISteamHTMLSurface_MouseMove(IntPtr c_instancePtr, uint c_unBrowserHandle, int c_x, int c_y);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamHTMLSurface_MouseWheel")]
        private static extern void SteamAPI_ISteamHTMLSurface_MouseWheel(IntPtr c_instancePtr, uint c_unBrowserHandle, int c_nDelta);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamHTMLSurface_KeyDown")]
        private static extern void SteamAPI_ISteamHTMLSurface_KeyDown(IntPtr c_instancePtr, uint c_unBrowserHandle, uint c_nNativeKeyCode, uint c_eHtmlKeyModifiers);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamHTMLSurface_KeyUp")]
        private static extern void SteamAPI_ISteamHTMLSurface_KeyUp(IntPtr c_instancePtr, uint c_unBrowserHandle, uint c_nNativeKeyCode, uint c_eHtmlKeyModifiers);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamHTMLSurface_KeyChar")]
        private static extern void SteamAPI_ISteamHTMLSurface_KeyChar(IntPtr c_instancePtr, uint c_unBrowserHandle, uint c_cUnicodeChar, uint c_eHtmlKeyModifiers);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamHTMLSurface_SetHorizontalScroll")]
        private static extern void SteamAPI_ISteamHTMLSurface_SetHorizontalScroll(IntPtr c_instancePtr, uint c_unBrowserHandle, uint c_nAbsolutePixelScroll);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamHTMLSurface_SetVerticalScroll")]
        private static extern void SteamAPI_ISteamHTMLSurface_SetVerticalScroll(IntPtr c_instancePtr, uint c_unBrowserHandle, uint c_nAbsolutePixelScroll);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamHTMLSurface_SetKeyFocus")]
        private static extern void SteamAPI_ISteamHTMLSurface_SetKeyFocus(IntPtr c_instancePtr, uint c_unBrowserHandle, bool c_bHasKeyFocus);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamHTMLSurface_ViewSource")]
        private static extern void SteamAPI_ISteamHTMLSurface_ViewSource(IntPtr c_instancePtr, uint c_unBrowserHandle);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamHTMLSurface_CopyToClipboard")]
        private static extern void SteamAPI_ISteamHTMLSurface_CopyToClipboard(IntPtr c_instancePtr, uint c_unBrowserHandle);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamHTMLSurface_PasteFromClipboard")]
        private static extern void SteamAPI_ISteamHTMLSurface_PasteFromClipboard(IntPtr c_instancePtr, uint c_unBrowserHandle);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamHTMLSurface_Find")]
        private static extern void SteamAPI_ISteamHTMLSurface_Find(IntPtr c_instancePtr, uint c_unBrowserHandle, SafeUtf8String c_pchSearchStr, bool c_bCurrentlyInFind, bool c_bReverse);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamHTMLSurface_StopFind")]
        private static extern void SteamAPI_ISteamHTMLSurface_StopFind(IntPtr c_instancePtr, uint c_unBrowserHandle);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamHTMLSurface_GetLinkAtPosition")]
        private static extern void SteamAPI_ISteamHTMLSurface_GetLinkAtPosition(IntPtr c_instancePtr, uint c_unBrowserHandle, int c_x, int c_y);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamHTMLSurface_SetCookie")]
        private static extern void SteamAPI_ISteamHTMLSurface_SetCookie(IntPtr c_instancePtr, SafeUtf8String c_pchHostname, SafeUtf8String c_pchKey, SafeUtf8String c_pchValue, SafeUtf8String c_pchPath, ulong c_nExpires, bool c_bSecure, bool c_bHttpOnly);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamHTMLSurface_SetPageScaleFactor")]
        private static extern void SteamAPI_ISteamHTMLSurface_SetPageScaleFactor(IntPtr c_instancePtr, uint c_unBrowserHandle, float c_flZoom, int c_nPointX, int c_nPointY);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamHTMLSurface_SetBackgroundMode")]
        private static extern void SteamAPI_ISteamHTMLSurface_SetBackgroundMode(IntPtr c_instancePtr, uint c_unBrowserHandle, bool c_bBackgroundMode);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamHTMLSurface_AllowStartRequest")]
        private static extern void SteamAPI_ISteamHTMLSurface_AllowStartRequest(IntPtr c_instancePtr, uint c_unBrowserHandle, bool c_bAllowed);

        [DllImport(SteamApi.STEAMWORKS_MODULE_NAME, EntryPoint = "SteamAPI_ISteamHTMLSurface_JSDialogResponse")]
        private static extern void SteamAPI_ISteamHTMLSurface_JSDialogResponse(IntPtr c_instancePtr, uint c_unBrowserHandle, bool c_bResult);

        #endregion

        #region Overrides of ISteamHtmlSurface

        public override IntPtr GetIntPtr()
        {
            return m_instancePtr;
        }

        public override void DestructISteamHtmlSurface()
        {
            CheckIfUsable();

            SteamAPI_ISteamHTMLSurface_DestructISteamHTMLSurface(m_instancePtr);
        }

        public override bool Init()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamHTMLSurface_Init(m_instancePtr);

            return a_result;
        }

        public override bool Shutdown()
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamHTMLSurface_Shutdown(m_instancePtr);

            return a_result;
        }

        public override ulong CreateBrowser(string c_pchUserAgent, string c_pchUserCss)
        {
            CheckIfUsable();

            var a_result = SteamAPI_ISteamHTMLSurface_CreateBrowser(m_instancePtr, new SafeUtf8String(c_pchUserAgent), new SafeUtf8String(c_pchUserCss));

            return a_result;
        }

        public override void RemoveBrowser(uint c_unBrowserHandle)
        {
            CheckIfUsable();

            SteamAPI_ISteamHTMLSurface_RemoveBrowser(m_instancePtr, c_unBrowserHandle);
        }

        public override void LoadUrl(uint c_unBrowserHandle, string c_pchUrl, string c_pchPostData)
        {
            CheckIfUsable();

            SteamAPI_ISteamHTMLSurface_LoadURL(m_instancePtr, c_unBrowserHandle, new SafeUtf8String(c_pchUrl), new SafeUtf8String(c_pchPostData));
        }

        public override void SetSize(uint c_unBrowserHandle, uint c_unWidth, uint c_unHeight)
        {
            CheckIfUsable();

            SteamAPI_ISteamHTMLSurface_SetSize(m_instancePtr, c_unBrowserHandle, c_unWidth, c_unHeight);
        }

        public override void StopLoad(uint c_unBrowserHandle)
        {
            CheckIfUsable();

            SteamAPI_ISteamHTMLSurface_StopLoad(m_instancePtr, c_unBrowserHandle);
        }

        public override void Reload(uint c_unBrowserHandle)
        {
            CheckIfUsable();

            SteamAPI_ISteamHTMLSurface_Reload(m_instancePtr, c_unBrowserHandle);
        }

        public override void GoBack(uint c_unBrowserHandle)
        {
            CheckIfUsable();

            SteamAPI_ISteamHTMLSurface_GoBack(m_instancePtr, c_unBrowserHandle);
        }

        public override void GoForward(uint c_unBrowserHandle)
        {
            CheckIfUsable();

            SteamAPI_ISteamHTMLSurface_GoForward(m_instancePtr, c_unBrowserHandle);
        }

        public override void AddHeader(uint c_unBrowserHandle, string c_pchKey, string c_pchValue)
        {
            CheckIfUsable();

            SteamAPI_ISteamHTMLSurface_AddHeader(m_instancePtr, c_unBrowserHandle, new SafeUtf8String(c_pchKey), new SafeUtf8String(c_pchValue));
        }

        public override void ExecuteJavascript(uint c_unBrowserHandle, string c_pchScript)
        {
            CheckIfUsable();

            SteamAPI_ISteamHTMLSurface_ExecuteJavascript(m_instancePtr, c_unBrowserHandle, new SafeUtf8String(c_pchScript));
        }

        public override void MouseUp(uint c_unBrowserHandle, uint c_eMouseButton)
        {
            CheckIfUsable();

            SteamAPI_ISteamHTMLSurface_MouseUp(m_instancePtr, c_unBrowserHandle, c_eMouseButton);
        }

        public override void MouseDown(uint c_unBrowserHandle, uint c_eMouseButton)
        {
            CheckIfUsable();

            SteamAPI_ISteamHTMLSurface_MouseDown(m_instancePtr, c_unBrowserHandle, c_eMouseButton);
        }

        public override void MouseDoubleClick(uint c_unBrowserHandle, uint c_eMouseButton)
        {
            CheckIfUsable();

            SteamAPI_ISteamHTMLSurface_MouseDoubleClick(m_instancePtr, c_unBrowserHandle, c_eMouseButton);
        }

        public override void MouseMove(uint c_unBrowserHandle, int c_x, int c_y)
        {
            CheckIfUsable();

            SteamAPI_ISteamHTMLSurface_MouseMove(m_instancePtr, c_unBrowserHandle, c_x, c_y);
        }

        public override void MouseWheel(uint c_unBrowserHandle, int c_nDelta)
        {
            CheckIfUsable();

            SteamAPI_ISteamHTMLSurface_MouseWheel(m_instancePtr, c_unBrowserHandle, c_nDelta);
        }

        public override void KeyDown(uint c_unBrowserHandle, uint c_nNativeKeyCode, uint c_eHtmlKeyModifiers)
        {
            CheckIfUsable();

            SteamAPI_ISteamHTMLSurface_KeyDown(m_instancePtr, c_unBrowserHandle, c_nNativeKeyCode, c_eHtmlKeyModifiers);
        }

        public override void KeyUp(uint c_unBrowserHandle, uint c_nNativeKeyCode, uint c_eHtmlKeyModifiers)
        {
            CheckIfUsable();

            SteamAPI_ISteamHTMLSurface_KeyUp(m_instancePtr, c_unBrowserHandle, c_nNativeKeyCode, c_eHtmlKeyModifiers);
        }

        public override void KeyChar(uint c_unBrowserHandle, uint c_cUnicodeChar, uint c_eHtmlKeyModifiers)
        {
            CheckIfUsable();

            SteamAPI_ISteamHTMLSurface_KeyChar(m_instancePtr, c_unBrowserHandle, c_cUnicodeChar, c_eHtmlKeyModifiers);
        }

        public override void SetHorizontalScroll(uint c_unBrowserHandle, uint c_nAbsolutePixelScroll)
        {
            CheckIfUsable();

            SteamAPI_ISteamHTMLSurface_SetHorizontalScroll(m_instancePtr, c_unBrowserHandle, c_nAbsolutePixelScroll);
        }

        public override void SetVerticalScroll(uint c_unBrowserHandle, uint c_nAbsolutePixelScroll)
        {
            CheckIfUsable();

            SteamAPI_ISteamHTMLSurface_SetVerticalScroll(m_instancePtr, c_unBrowserHandle, c_nAbsolutePixelScroll);
        }

        public override void SetKeyFocus(uint c_unBrowserHandle, bool c_bHasKeyFocus)
        {
            CheckIfUsable();

            SteamAPI_ISteamHTMLSurface_SetKeyFocus(m_instancePtr, c_unBrowserHandle, c_bHasKeyFocus);
        }

        public override void ViewSource(uint c_unBrowserHandle)
        {
            CheckIfUsable();

            SteamAPI_ISteamHTMLSurface_ViewSource(m_instancePtr, c_unBrowserHandle);
        }

        public override void CopyToClipboard(uint c_unBrowserHandle)
        {
            CheckIfUsable();

            SteamAPI_ISteamHTMLSurface_CopyToClipboard(m_instancePtr, c_unBrowserHandle);
        }

        public override void PasteFromClipboard(uint c_unBrowserHandle)
        {
            CheckIfUsable();

            SteamAPI_ISteamHTMLSurface_PasteFromClipboard(m_instancePtr, c_unBrowserHandle);
        }

        public override void Find(uint c_unBrowserHandle, string c_pchSearchStr, bool c_bCurrentlyInFind, bool c_bReverse)
        {
            CheckIfUsable();

            SteamAPI_ISteamHTMLSurface_Find(m_instancePtr, c_unBrowserHandle, new SafeUtf8String(c_pchSearchStr), c_bCurrentlyInFind, c_bReverse);
        }

        public override void StopFind(uint c_unBrowserHandle)
        {
            CheckIfUsable();

            SteamAPI_ISteamHTMLSurface_StopFind(m_instancePtr, c_unBrowserHandle);
        }

        public override void GetLinkAtPosition(uint c_unBrowserHandle, int c_x, int c_y)
        {
            CheckIfUsable();

            SteamAPI_ISteamHTMLSurface_GetLinkAtPosition(m_instancePtr, c_unBrowserHandle, c_x, c_y);
        }

        public override void SetCookie(string c_pchHostname, string c_pchKey, string c_pchValue, string c_pchPath, ulong c_nExpires, bool c_bSecure, bool c_bHttpOnly)
        {
            CheckIfUsable();

            SteamAPI_ISteamHTMLSurface_SetCookie(m_instancePtr, new SafeUtf8String(c_pchHostname), new SafeUtf8String(c_pchKey), new SafeUtf8String(c_pchValue), new SafeUtf8String(c_pchPath), c_nExpires, c_bSecure, c_bHttpOnly);
        }

        public override void SetPageScaleFactor(uint c_unBrowserHandle, float c_flZoom, int c_nPointX, int c_nPointY)
        {
            CheckIfUsable();

            SteamAPI_ISteamHTMLSurface_SetPageScaleFactor(m_instancePtr, c_unBrowserHandle, c_flZoom, c_nPointX, c_nPointY);
        }

        public override void SetBackgroundMode(uint c_unBrowserHandle, bool c_bBackgroundMode)
        {
            CheckIfUsable();

            SteamAPI_ISteamHTMLSurface_SetBackgroundMode(m_instancePtr, c_unBrowserHandle, c_bBackgroundMode);
        }

        public override void AllowStartRequest(uint c_unBrowserHandle, bool c_bAllowed)
        {
            CheckIfUsable();

            SteamAPI_ISteamHTMLSurface_AllowStartRequest(m_instancePtr, c_unBrowserHandle, c_bAllowed);
        }

        public override void JsDialogResponse(uint c_unBrowserHandle, bool c_bResult)
        {
            CheckIfUsable();

            SteamAPI_ISteamHTMLSurface_JSDialogResponse(m_instancePtr, c_unBrowserHandle, c_bResult);
        }

        #endregion
    }

    public abstract class ISteamHtmlSurface
    {
        public abstract IntPtr GetIntPtr();
        public abstract void DestructISteamHtmlSurface();
        public abstract bool Init();
        public abstract bool Shutdown();
        public abstract ulong CreateBrowser(string c_pchUserAgent, string c_pchUserCss);
        public abstract void RemoveBrowser(uint c_unBrowserHandle);
        public abstract void LoadUrl(uint c_unBrowserHandle, string c_pchUrl, string c_pchPostData);
        public abstract void SetSize(uint c_unBrowserHandle, uint c_unWidth, uint c_unHeight);
        public abstract void StopLoad(uint c_unBrowserHandle);
        public abstract void Reload(uint c_unBrowserHandle);
        public abstract void GoBack(uint c_unBrowserHandle);
        public abstract void GoForward(uint c_unBrowserHandle);
        public abstract void AddHeader(uint c_unBrowserHandle, string c_pchKey, string c_pchValue);
        public abstract void ExecuteJavascript(uint c_unBrowserHandle, string c_pchScript);
        public abstract void MouseUp(uint c_unBrowserHandle, uint c_eMouseButton);
        public abstract void MouseDown(uint c_unBrowserHandle, uint c_eMouseButton);
        public abstract void MouseDoubleClick(uint c_unBrowserHandle, uint c_eMouseButton);
        public abstract void MouseMove(uint c_unBrowserHandle, int c_x, int c_y);
        public abstract void MouseWheel(uint c_unBrowserHandle, int c_nDelta);
        public abstract void KeyDown(uint c_unBrowserHandle, uint c_nNativeKeyCode, uint c_eHtmlKeyModifiers);
        public abstract void KeyUp(uint c_unBrowserHandle, uint c_nNativeKeyCode, uint c_eHtmlKeyModifiers);
        public abstract void KeyChar(uint c_unBrowserHandle, uint c_cUnicodeChar, uint c_eHtmlKeyModifiers);
        public abstract void SetHorizontalScroll(uint c_unBrowserHandle, uint c_nAbsolutePixelScroll);
        public abstract void SetVerticalScroll(uint c_unBrowserHandle, uint c_nAbsolutePixelScroll);
        public abstract void SetKeyFocus(uint c_unBrowserHandle, bool c_bHasKeyFocus);
        public abstract void ViewSource(uint c_unBrowserHandle);
        public abstract void CopyToClipboard(uint c_unBrowserHandle);
        public abstract void PasteFromClipboard(uint c_unBrowserHandle);
        public abstract void Find(uint c_unBrowserHandle, string c_pchSearchStr, bool c_bCurrentlyInFind, bool c_bReverse);
        public abstract void StopFind(uint c_unBrowserHandle);
        public abstract void GetLinkAtPosition(uint c_unBrowserHandle, int c_x, int c_y);
        public abstract void SetCookie(string c_pchHostname, string c_pchKey, string c_pchValue, string c_pchPath, ulong c_nExpires, bool c_bSecure, bool c_bHttpOnly);
        public abstract void SetPageScaleFactor(uint c_unBrowserHandle, float c_flZoom, int c_nPointX, int c_nPointY);
        public abstract void SetBackgroundMode(uint c_unBrowserHandle, bool c_bBackgroundMode);
        public abstract void AllowStartRequest(uint c_unBrowserHandle, bool c_bAllowed);
        public abstract void JsDialogResponse(uint c_unBrowserHandle, bool c_bResult);
    }
}