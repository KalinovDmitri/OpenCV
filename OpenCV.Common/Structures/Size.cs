using System;
using System.Runtime.InteropServices;

namespace OpenCV
{
    [Serializable, ComVisible(true)]
    public struct Size : IEquatable<Size>
    {
        #region Static members

        public static readonly Size Empty;
        
        public static Size Add(Size first, Size second)
        {
            return new Size(first.width + second.width, first.height + second.height);
        }
        
        public static Size Ceiling(SizeF value)
        {
            int width = (int)Math.Ceiling(value.width);
            int height = (int)Math.Ceiling(value.height);
            return new Size(width, height);
        }

        public static Size Subtract(Size first, Size second)
        {
            return new Size(first.width - second.width, first.height - second.height);
        }
        
        public static Size Truncate(SizeF value)
        {
            return new Size((int)value.width, (int)value.height);
        }
        
        public static Size Round(SizeF value)
        {
            int width = (int)Math.Round(value.width);
            int height = (int)Math.Round(value.height);
            return new Size(width, height);
        }
        #endregion

        #region Operators overloading
        
        public static implicit operator SizeF(Size p)
        {
            return new SizeF(p.width, p.height);
        }
        
        public static Size operator +(Size left, Size right)
        {
            return Add(left, right);
        }
        
        public static Size operator -(Size left, Size right)
        {
            return Subtract(left, right);
        }
        
        public static bool operator ==(Size left, Size right)
        {
            return left.width == right.width && left.height == right.height;
        }
        
        public static bool operator !=(Size left, Size right)
        {
            return !(left == right);
        }
        
        public static explicit operator Point(Size size)
        {
            return new Point(size.width, size.height);
        }
        #endregion

        #region Fields and properties

        internal int width, height;

        public bool IsEmpty
        {
            get { return width == 0 && height == 0; }
        }

        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        public int Height
        {
            get { return height; }
            set { height = value; }
        }
        #endregion

        #region Constructors

        public Size(Point point)
        {
            width = point.X;
            height = point.Y;
        }

        public Size(int width, int height)
        {
            this.width = width; this.height = height;
        }
        #endregion

        #region Methods

        public bool Equals(Size other)
        {
            return this == other;
        }

        public override int GetHashCode()
        {
            return width ^ height;
        }

        public override string ToString()
        {
            return string.Format("{{Width = {0}, Height = {1}}}", width, height);
        }
        #endregion
    }
}