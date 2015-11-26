using System;
using System.Runtime.InteropServices;

namespace OpenCV.Core
{
    using Enumerations;

    public static partial class CvInvoke
    {
        #region Imaging fuctions import

        public static IntPtr cvCreateImageHeader(Size size, IplDepth depth, int channels)
        {
            return cveCreateImageHeader(ref size, depth, channels);
        }

        public static IntPtr cvInitImageHeader(IntPtr image, Size size, IplDepth depth, int channels, int origin = 0, int align = 4)
        {
            return cveInitImageHeader(image, ref size, depth, channels, origin, align);
        }

        [DllImport(ExternLibrary, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cveCreateMat")]
        public static extern IntPtr cvCreateMat(int rows, int cols, DepthType type);

        [DllImport(ExternLibrary, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cveGetRawData")]
        public static extern void cvGetRawData(IntPtr arr, out IntPtr data, out int step, out Size roiSize);

        [DllImport(ExternLibrary, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cveSetData")]
        public static extern void cvSetData(IntPtr arr, IntPtr data, int step);

        [DllImport(ExternLibrary, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cveReleaseImageHeader")]
        public static extern void cvReleaseImageHeader(ref IntPtr imagePtr);

        [DllImport(ExternLibrary, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cveReleaseMat")]
        public static extern void cvReleaseMat(ref IntPtr mat);

        [DllImport(ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr cveInitImageHeader(IntPtr image, ref Size size, IplDepth depth, int channels, int origin, int align);

        [DllImport(ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr cveCreateImageHeader(ref Size size, IplDepth depth, int channels);
        #endregion
    }
}