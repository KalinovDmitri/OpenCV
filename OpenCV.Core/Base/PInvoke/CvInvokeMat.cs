using System;
using System.Runtime.InteropServices;

namespace OpenCV.Core
{
    public static partial class CvInvoke
    {
        #region Mat interaction

        [DllImport(ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cveMatCreate();

        [DllImport(ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cveMatCreateData(IntPtr mat, int row, int cols, int type);

        [DllImport(ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cveInputArrayFromMat(IntPtr mat);
        #endregion
    }
}