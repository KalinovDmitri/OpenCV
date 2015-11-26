using System;
using System.Runtime.InteropServices;

namespace OpenCV.Core
{
    /// <summary>
    /// Представляет упорядоченную пару целых чисел - координат X и Y, определяющих точку на двумерной плоскости
    /// </summary>
    [Serializable, ComVisible(true)]
    public struct Point
    {
        #region Static members
        /// <summary>
        /// Представляет объект <see cref="Point"/>, у которого значения <see cref="X"/> и <see cref="Y"/> установлены равными нулю
        /// </summary>
        public static readonly Point Empty;

        private static int HIWORD(int value)
        {
            return value >> 16 & 65535;
        }

        private static int LOWORD(int value)
        {
            return value & 65535;
        }
        #endregion

        #region Operators overloading
        #endregion

        #region Fields and properties

        private int x, y;

        public bool IsEmpty
        {
            get { return x == 0 && y == 0; }
        }

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        #endregion

        #region Constructors
        #endregion

        #region Methods

        public Point(int x, int y)
        {
            this.x = x; this.y = y;
        }

        public Point(int dw)
        {
            x = LOWORD(dw); y = HIWORD(dw);
        }
        #endregion
    }
}