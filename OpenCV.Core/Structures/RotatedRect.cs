using System;

namespace OpenCV
{
    /// <summary>
    /// Представляет управляемый эквивалент структуры CvBox2D
    /// </summary>
    public struct RotatedRect : IEquatable<RotatedRect>
    {
        #region Static members
        /// <summary>
        /// Представляет структуру <see cref="RotatedRect"/>, параметры которой не инициализированы
        /// </summary>
        public static readonly RotatedRect Empty;
        #endregion

        #region Operators overloading
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rectangle"></param>
        public static implicit operator RotatedRect(RectangleF rectangle)
        {
            return new RotatedRect(new PointF(rectangle.X + rectangle.Width * 0.5F, rectangle.Y + rectangle.Height * 0.5F), rectangle.Size, 0.0F);
        }
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

        public Rectangle GetMinAreaRectangle()
        {
            PointF[] pointsArray = CvInvoke.BoxPoints(this);

            int xMin = 0;
            int xMax = 0;
            int yMin = 0;
            int yMax = 0;

            return new Rectangle(xMin, yMin, xMax - xMin, yMax - yMin);
        }

        public PointF[] GetVertices()
        {
            return CvInvoke.BoxPoints(this);
        }

        public bool Equals(RotatedRect other)
        {
            return Center.Equals(other.Center) && Size.Equals(other.Size) && Angle.Equals(other.Angle);
        }
        #endregion
    }
}