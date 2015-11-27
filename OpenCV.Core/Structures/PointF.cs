using System;
using System.Runtime.InteropServices;

namespace OpenCV
{
    [Serializable, ComVisible(true)]
    public struct PointF : IEquatable<PointF>
    {
        #region Static members

        public static readonly PointF Empty;

        public static PointF Add(PointF point, Size size)
        {
            return new PointF(point.x + size.width, point.Y + size.height);
        }

        public static PointF Subtract(PointF point, Size size)
        {
            return new PointF(point.x - size.width, point.y - size.height);
        }

        public static PointF Add(PointF point, SizeF size)
        {
            return new PointF(point.x + size.width, point.y + size.height);
        }

        public static PointF Subtract(PointF point, SizeF size)
        {
            return new PointF(point.x - size.width, point.y - size.height);
        }
        #endregion

        #region Operators overloading

        public static PointF operator +(PointF point, Size size)
        {
            return Add(point, size);
        }

        public static PointF operator -(PointF point, Size size)
        {
            return Subtract(point, size);
        }

        public static PointF operator +(PointF point, SizeF size)
        {
            return Add(point, size);
        }

        public static PointF operator -(PointF point, SizeF size)
        {
            return Subtract(point, size);
        }

        public static PointF operator +(PointF left, PointF right)
        {
            return new PointF(left.x + right.x, left.y + right.y);
        }

        public static PointF operator -(PointF left, PointF right)
        {
            return new PointF(left.x - right.x, left.y - right.y);
        }

        public static bool operator ==(PointF left, PointF right)
        {
            return left.x == right.x && left.y == right.y;
        }

        public static bool operator !=(PointF left, PointF right)
        {
            return !(left == right);
        }
        #endregion

        #region Fields and properties
        internal float x, y;
        
        public bool IsEmpty
        {
            get{return x == 0f && y == 0f;}
        }
        
        public float X
        {
            get { return x; }
            set { x = value; }
        }
        
        public float Y
        {
            get { return y; }
            set { y = value; }
        }
        #endregion

        #region Constructors

        public PointF(float x, float y)
        {
            this.x = x; this.y = y;
        }

        #endregion

        #region Methods

        public bool Equals(PointF other)
        {
            return this == other;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        
        public override string ToString()
        {
            return string.Format("{{X = {0}, Y = {1}}}", x, y);
        }
        #endregion
    }
}