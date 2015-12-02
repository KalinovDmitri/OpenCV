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
        public static extern IntPtr cveMatGetDataPointer(IntPtr mat);

        [DllImport(ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cveMatGetElementSize(IntPtr mat);

        [DllImport(ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        public static extern Size cveMatGetSize(IntPtr mat);

        [DllImport(ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cveMatNumberOfChannels(IntPtr mat);

        [DllImport(ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr cveMatGetStep(IntPtr mat);

        [DllImport(ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cveInputArrayFromMat(IntPtr mat);

        [DllImport(ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cveInputOutputArrayFromMat(IntPtr mat);

        [DllImport(ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cveOutputArrayFromMat(IntPtr mat);

        [DllImport(ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cvMatSetTo(IntPtr mat, IntPtr value, IntPtr mask);

        [DllImport(ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cveMatRelease(ref IntPtr mat);
        #endregion
    }
}