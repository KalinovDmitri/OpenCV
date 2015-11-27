using System;
using System.Runtime.InteropServices;

namespace OpenCV
{
    [Serializable, ComVisible(true)]
    public struct SizeF
    {
        #region Static members

        public static readonly SizeF Empty;
        
        public static SizeF Add(SizeF first, SizeF second)
        {
            return new SizeF(first.width + second.width, first.height + second.height);
        }

        public static SizeF Subtract(SizeF first, SizeF second)
        {
            return new SizeF(first.width - second.width, first.height - second.height);
        }
        #endregion

        #region Operators overloading

        public static SizeF operator +(SizeF left, SizeF right)
        {
            return Add(left, right);
        }

        public static SizeF operator -(SizeF left, SizeF right)
        {
            return Subtract(left, right);
        }

        public static bool operator ==(SizeF left, SizeF right)
        {
            return left.Width == right.Width && left.Height == right.Height;
        }

        public static bool operator !=(SizeF left, SizeF right)
        {
            return !(left == right);
        }

        public static explicit operator PointF(SizeF size)
        {
            return new PointF(size.width, size.height);
        }
        #endregion

        #region Fields and properties

        internal float width, height;

        public bool IsEmpty
        {
            get { return width == 0f && height == 0f; }
        }

        public float Width
        {
            get { return width; }
            set { width = value; }
        }

        public float Height
        {
            get { return height; }
            set { height = value; }
        }
        #endregion

        #region Constructors

        public SizeF(SizeF size)
        {
            this.width = size.width;
            this.height = size.height;
        }

        public SizeF(PointF pt)
        {
            width = pt.X; height = pt.Y;
        }

        public SizeF(float width, float height)
        {
            this.width = width;
            this.height = height;
        }
        #endregion
        
        #region Methods

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        
        public PointF ToPointF()
        {
            return (PointF)this;
        }
        
        public Size ToSize()
        {
            return Size.Truncate(this);
        }

        public override string ToString()
        {
            return string.Format("{{Width = {0}, Heigth = {1}}}", width, height);
        }
        #endregion
    }
}