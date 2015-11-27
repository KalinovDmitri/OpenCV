using System;
using System.Runtime.InteropServices;

namespace OpenCV
{
    public static partial class CvInvoke
    {
        #region Mat interaction

        [DllImport(ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cveMatCreate();

        [DllImport(ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cveMatCreateData(IntPtr mat, int rows, int cols, int type);

        [DllImport(ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cveMatGetDataPointer(IntPtr mat);

        [DllImport(ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cveMatGetStep(IntPtr mat);

        [DllImport(ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cveInputArrayFromMat(IntPtr mat);

        [DllImport(ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cveMatRelease(ref IntPtr mat);
        #endregion
    }
}