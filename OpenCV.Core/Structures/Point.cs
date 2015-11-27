using System;
using System.Runtime.InteropServices;

namespace OpenCV
{
    /// <summary>
    /// Представляет упорядоченную пару целых чисел - координат X и Y, определяющих точку на двумерной плоскости
    /// </summary>
    [Serializable, ComVisible(true)]
    public struct Point : IEquatable<Point>
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

        public static Point Add(Point pt, Size sz)
        {
            return new Point(pt.x + sz.width, pt.y + sz.height);
        }

        public static Point Subtract(Point pt, Size sz)
        {
            return new Point(pt.x - sz.width, pt.y - sz.height);
        }

        public static Point Ceiling(PointF value)
        {
            int x = (int)Math.Ceiling(value.x);
            int y = (int)Math.Ceiling(value.y);
            return new Point(x, y);
        }

        public static Point Truncate(PointF value)
        {
            return new Point((int)value.X, (int)value.Y);
        }

        public static Point Round(PointF value)
        {
            int x = (int)Math.Round(value.x);
            int y = (int)Math.Round(value.y);
            return new Point(x, y);
        }
        #endregion

        #region Operators overloading

        public static implicit operator PointF(Point p)
        {
            return new PointF(p.x, p.y);
        }
        
        public static explicit operator Size(Point p)
        {
            return new Size(p.x, p.y);
        }
        
        public static Point operator +(Point pt, Size sz)
        {
            return Point.Add(pt, sz);
        }
        
        public static Point operator -(Point pt, Size sz)
        {
            return Point.Subtract(pt, sz);
        }
        
        public static bool operator ==(Point left, Point right)
        {
            return left.x == right.x && left.y == right.y;
        }
        
        public static bool operator !=(Point left, Point right)
        {
            return !(left == right);
        }
        #endregion

        #region Fields and properties

        internal int x, y;

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

        public Point(int x, int y)
        {
            this.x = x; this.y = y;
        }

        public Point(int dw)
        {
            x = LOWORD(dw); y = HIWORD(dw);
        }
        #endregion

        #region Methods

        public bool Equals(Point other)
        {
            return this == other;
        }

        public override int GetHashCode()
        {
            return x ^ y;
        }

        public override string ToString()
        {
            return string.Format("{{X = {0}, Y = {1}}}", x, y);
        }
        #endregion
    }
}