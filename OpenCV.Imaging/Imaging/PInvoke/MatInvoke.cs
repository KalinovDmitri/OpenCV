using System;
using System.Runtime.InteropServices;

using OpenCV.Core;

namespace OpenCV.Imaging
{
    internal static class MatInvoke
    {
        #region Mat interaction

        [DllImport(CvInvoke.ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cveMatCreate();

        [DllImport(CvInvoke.ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cveMatCreateData(IntPtr mat, int rows, int cols, int type);

        [DllImport(CvInvoke.ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cveMatGetDataPointer(IntPtr mat);

        [DllImport(CvInvoke.ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cveMatGetStep(IntPtr mat);

        [DllImport(CvInvoke.ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cveInputArrayFromMat(IntPtr mat);

        [DllImport(CvInvoke.ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cveMatRelease(ref IntPtr mat);
        #endregion
    }
}