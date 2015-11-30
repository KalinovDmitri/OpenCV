using System;
using System.Runtime.InteropServices;

using OpenCV.Enumerations;

namespace OpenCV.Imaging
{
    using WinColor = System.Windows.Media.Color;

    /// <summary>
    /// Представляет четырёхканальное изображение, способное взаимодействовать с цветовой схемой Windows Presentation Foundation
    /// </summary>
    public class PresentationImage : UnmanagedObject, IImage, IInputArray, IInputOutputArray, IOutputArray
    {
        #region Constants and static members
        /// <summary>
        /// Представляет количество каналов изображения
        /// </summary>
        public const int Channels = 4;
        #endregion

        #region Fields and properties

        private readonly Mat InnerImage;

        private readonly int Step;

        private readonly IntPtr RawDataPtr = IntPtr.Zero;

        private unsafe Color32* this[int x, int y]
        {
            get
            {
                // Little optimization: x << 2 == x * 4, i. e. number of channels (see constant Channels ^^^^)

                int offset = y * Step + x << 2;
                IntPtr destPtr = RawDataPtr + offset;

                return (Color32*)destPtr;
            }
        }

        public Size ImageSize => InnerImage.ImageSize;

        public int NumberOfChannels => InnerImage.NumberOfChannels;
        #endregion

        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public PresentationImage(int width, int height) : base(true)
        {
            InnerImage = new Mat(height, width, DepthType.Cv8U, Channels);

            InnerPointer = InnerImage;
            RawDataPtr = CvInvoke.cveMatGetDataPointer(InnerPointer);
            Step = CvInvoke.cveMatGetStep(InnerPointer).ToInt32();
        }
        #endregion

        #region IImage implementation

        public InputArray GetInputArray()
        {
            return InnerImage.GetInputArray();
        }

        public OutputArray GetOutputArray()
        {
            return InnerImage.GetOutputArray();
        }

        public InputOutputArray GetInputOutputArray()
        {
            return InnerImage.GetInputOutputArray();
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

        public void WritePixels(Array pixelsArray)
        {
            if (pixelsArray == null)
            {
                throw new ArgumentNullException("pixelsArray");
            }

            Type itemType = pixelsArray.GetType().GetElementType();
            int itemSize = Marshal.SizeOf(itemType);

            int arrayRank = pixelsArray.Rank, counter = 0, bytesCount = 0, arraySize = 0;
            for (; counter < arrayRank; counter += 1)
            {
                arraySize = pixelsArray.GetLength(counter);
                bytesCount += arraySize * itemSize;
            }

            using (DisposableHandle arrayHandle = DisposableHandle.Alloc(pixelsArray))
            {
                NTInvoke.CopyUnmanagedMemory(RawDataPtr, arrayHandle, bytesCount);
            }
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

        protected override void DisposeObject()
        {
            InnerImage.Dispose();
        }
        #endregion
    }
}