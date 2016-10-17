//   !!  // Steamworks.Core - SafeUtf8String.cs
// *.-". // Created: 2016-10-16 [3:01 PM]
//  | |  // Copyright 2016 // MIT License // The Fox Council 
// Modified by: Fox Diller on 2016-10-16 @ 3:16 PM

#region Usings

using System;
using System.Runtime.InteropServices;
using System.Text;

#endregion

namespace Steamworks.Core
{
    public class SafeUtf8String : SafeHandle
    {
        public SafeUtf8String(string c_sourceString) : base(IntPtr.Zero, true)
        {
            if (c_sourceString == null)
            {
                SetHandle(IntPtr.Zero);
                return;
            }

            var a_byteArray = new byte[Encoding.UTF8.GetByteCount(c_sourceString) + 1];

            Encoding.UTF8.GetBytes(c_sourceString, 0, c_sourceString.Length, a_byteArray, 0);

            var a_byteBuffer = Marshal.AllocHGlobal(a_byteArray.Length);

            Marshal.Copy(a_byteArray, 0, a_byteBuffer, a_byteArray.Length);

            SetHandle(a_byteBuffer);
        }

        #region Overrides of SafeHandle

        protected override bool ReleaseHandle()
        {
            if (!IsInvalid)
            {
                Marshal.FreeHGlobal(handle);
            }

            return true;
        }

        public override bool IsInvalid { get; }

        #endregion
    }
}