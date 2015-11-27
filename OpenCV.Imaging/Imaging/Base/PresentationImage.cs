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
                int offset = x << 2 + y << 1;
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

        public void SetPixel(int x, int y, WinColor pixelColor)
        {
            SetPixelCore(x, y, ref pixelColor);
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