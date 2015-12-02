using System;

namespace OpenCV
{
    public struct RotatedRect : IEquatable<RotatedRect>
    {
        #region Static members

        public static readonly RotatedRect Empty;
        
        #endregion

        #region Fields
        /// <summary>
        /// 
        /// </summary>
        public PointF Center;
        /// <summary>
        /// 
        /// </summary>
        public SizeF Size;
        /// <summary>
        /// 
        /// </summary>
        public float Angle;
        #endregion

        #region Constructors

        public RotatedRect(PointF center, SizeF size, float angle)
        {
            Center = center; Size = size; Angle = angle;
        }
        #endregion

        #region Methods

        public void Offset(int x, int y)
        {
            Center.X += x;
            Center.Y += y;
        }

        public PointF[] GetVertices()
        {
            return new PointF[4];
            // return CvInvoke.BoxPoints(this);
        }

        public bool Equals(RotatedRect other)
        {
            return Center.Equals(other.Center) && Size.Equals(other.Size) && Angle.Equals(other.Angle);
        }
        #endregion
    }
}