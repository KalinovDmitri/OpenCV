using System;
using System.Runtime.InteropServices;

namespace OpenCV.Core
{
    /// <summary>
    /// Представляет данные отдельного пикселя четырёхканального (ARGB) изображения
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct Color32
    {
        #region Fields
        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(0)]
        public uint Argb;
        /// <summary>
        /// Представляет B - компонент цвета
        /// </summary>
        [FieldOffset(0)]
        public byte B;
        /// <summary>
        /// Представляет G - компонент цвета
        /// </summary>
        [FieldOffset(1)]
        public byte G;
        /// <summary>
        /// Представляет R - компонент цвета
        /// </summary>
        [FieldOffset(2)]
        public byte R;
        /// <summary>
        /// Представляет A - компонент цвета
        /// </summary>
        [FieldOffset(3)]
        public byte A;
        #endregion

        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="alpha"></param>
        /// <param name="red"></param>
        /// <param name="green"></param>
        /// <param name="blue"></param>
        public Color32(byte alpha, byte red, byte green, byte blue)
        {
            this = default(Color32);
            A = alpha;
            R = red;
            G = green;
            B = blue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="argb"></param>
        public Color32(uint argb)
        {
            this = default(Color32);
            Argb = argb;
        }
        #endregion
    }
}