using System;
using System.Runtime.InteropServices;

namespace OpenCV.Core
{
    public static partial class CvInvoke
    {
        #region Arrays

        [DllImport(ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool cveInputArrayIsEmpty(IntPtr arrayPtr);
        #endregion
    }
}