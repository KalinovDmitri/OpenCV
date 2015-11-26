using System;
using System.Runtime.InteropServices;

namespace OpenCV.Core
{
    [Serializable, ComVisible(true)]
    public struct Size
    {
        #region Static members

        public static readonly Size Empty;
        #endregion

        #region Fields and properties

        private int width, height;

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
    }
}