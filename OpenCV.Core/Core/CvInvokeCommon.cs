using System;
using System.Runtime.InteropServices;

namespace OpenCV
{
    using Enumerations;

    public static partial class CvInvoke
    {
        #region Common structures interaction

        public static PointF[] BoxPoints(RotatedRect box)
        {
            PointF[] pointsArray = new PointF[4];

            using (DisposableHandle arrayHandle = DisposableHandle.Alloc(pointsArray))
            {
                using (Mat arrayMat = new Mat(4, 2, DepthType.Cv32F, 1, arrayHandle, 8))
                {
                    using (OutputArray outArray = arrayMat.GetOutputArray())
                    {
                        cveBoxPoints(ref box, outArray);
                    }
                }
            }

            return pointsArray;
        }

        [DllImport(ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        private static extern void cveBoxPoints(ref RotatedRect box, IntPtr arrayPtr);
        #endregion
    }
}