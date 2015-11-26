using System;
using System.Runtime.InteropServices;

namespace OpenCV.Core
{
    using Enumerations;

    /// <summary>
    /// Предоставляет точку входа для вызова неуправляемых функций библиотеки cvextern.dll
    /// </summary>
    public static class CvInvoke
    {
        #region Constants

        public const string ExternLibrary = "cvextern.dll";
        #endregion

        #region Imaging

        public static IntPtr cvCreateImageHeader(Size size, IplDepth depth, int channels)
        {
            return cveCreateImageHeader(ref size, depth, channels);
        }

        [DllImport(ExternLibrary, CallingConvention = CallingConvention.Cdecl, EntryPoint = "cveReleaseImageHeader")]
        public static extern void cvReleaseImageHeader(ref IntPtr imagePtr);

        [DllImport(ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr cveCreateImageHeader(ref Size size, IplDepth depth, int channels);
        #endregion
    }
}