using System;
using System.Windows.Media;

using OpenCV.Core;
using OpenCV.Core.Enumerations;
using OpenCV.Core.Structures;

namespace OpenCV.Imaging
{
    /// <summary>
    /// 
    /// </summary>
    public class PresentationImage : UnmanagedObject
    {
        #region Fields and properties

        private IntPtr DataPtr = IntPtr.Zero;

        private unsafe Color32* this[int x, int y]
        {
            get
            {
                int offset = x << 2 + y << 1;
                return (Color32*)(DataPtr + offset);
            }
        }
        #endregion

        #region Constructors
        
        public PresentationImage(int width, int height, int channels)
        {
            InnerPointer = CvInvoke.cvCreateImageHeader(new Size(width, height), IplDepth.IplDepth_8U, channels);
            DataPtr = CvInvoke.cveMatCreate();

            int matType = (int)((DepthType.Cv8U & (DepthType)7) + (4 - 1 << 3));

            CvInvoke.cveMatCreateData(DataPtr, 256, 256, matType);
            CvInvoke.cvSetData(InnerPointer, DataPtr, width * channels);
        }
        #endregion

        #region Class methods

        public void SetPixel(int x, int y, Color pixelColor)
        {
            SetPixelCore(x, y, ref pixelColor);
        }

        protected override void DisposeObject()
        {
            CvInvoke.cvReleaseImageHeader(ref InnerPointer);
        }

        private unsafe void SetPixelCore(int x, int y, ref Color pixelColor)
        {
            Color32* pixelPtr = this[x, y];
            pixelPtr->A = pixelColor.A;
            pixelPtr->R = pixelColor.R;
            pixelPtr->G = pixelColor.G;
            pixelPtr->B = pixelColor.B;
        }
        #endregion
    }
}