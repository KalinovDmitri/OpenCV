using System;

using OpenCV.Enumerations;

namespace OpenCV.Imaging
{
    using WinColor = System.Windows.Media.Color;

    /// <summary>
    /// 
    /// </summary>
    public class PresentationImage : Mat
    {
        #region Fields and properties

        private readonly int Step;

        private readonly IntPtr RawDataPtr = IntPtr.Zero;

        private unsafe Color32* this[int x, int y]
        {
            get
            {
                int offset = y * Step + x * 4;
                return (Color32*)(RawDataPtr + offset);
            }
        }
        #endregion

        #region Constructors
        
        public PresentationImage(int width, int height) : base(height, width, DepthType.Cv8U, 4)
        {
            RawDataPtr = MatInvoke.cveMatGetDataPointer(InnerPointer);
            Step = MatInvoke.cveMatGetStep(InnerPointer).ToInt32();
        }
        #endregion

        #region Class methods

        public WinColor GetPixel(int x, int y)
        {
            return GetPixelCore(x, y);
        }

        public void SetPixel(int x, int y, WinColor pixelColor)
        {
            SetPixelCore(x, y, ref pixelColor);
        }

        private unsafe WinColor GetPixelCore(int x, int y)
        {
            Color32* pixelPtr = this[x, y];
            return WinColor.FromArgb(pixelPtr->A, pixelPtr->R, pixelPtr->G, pixelPtr->B);
        }

        private unsafe void SetPixelCore(int x, int y, ref WinColor pixelColor)
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