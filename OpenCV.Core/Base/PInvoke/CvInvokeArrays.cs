using System;
using System.Runtime.InteropServices;

namespace OpenCV.Core
{
    using Enumerations;

    public static partial class CvInvoke
    {
        #region Input array

        [DllImport(ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool cveInputArrayIsEmpty(IntPtr arrayPtr);

        [DllImport(ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cveInputArrayGetChannels(IntPtr arrayPtr, int idx);

        [DllImport(ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern DepthType cveInputArrayGetDepth(IntPtr arrayPtr, int idx);

        [DllImport(ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cveInputArrayGetSize(IntPtr arrayPtr, ref Size size, int idx);

        [DllImport(ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cveInputArrayRelease(ref IntPtr arrayPtr);
        #endregion

        #region Output array

        [DllImport(ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool cveOutputArrayFixedSize(IntPtr arrayPtr);

        [DllImport(ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool cveOutputArrayFixedType(IntPtr arrayPtr);

        [DllImport(ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool cveOutputArrayNeeded(IntPtr arrayPtr);

        [DllImport(ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cveOutputArrayRelease(ref IntPtr arrayPtr);
        #endregion

        #region Input output array

        [DllImport(ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cveInputOutputArrayRelease(ref IntPtr arr);
        #endregion
    }
}