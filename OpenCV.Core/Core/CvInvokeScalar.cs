using System;
using System.Runtime.InteropServices;

namespace OpenCV
{
    public static partial class CvInvoke
    {
        [DllImport(ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cveScalarCreate(ref MCvScalar scalar);

        [DllImport(ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cveScalarRelease(ref IntPtr scalar);

        [DllImport(ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cveInputArrayFromScalar(IntPtr scalar);

        [DllImport(ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cveInputArrayFromDouble(IntPtr scalar);
    }
}