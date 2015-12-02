using System;

namespace OpenCV
{
    public struct RectangleF : IEquatable<RectangleF>
    {
        #region Static members
        /// <summary>
        /// Представляет структуру <see cref="RectangleF"/>, параметры которой не инициализированы
        /// </summary>
        public static readonly RectangleF Empty;

        public static RectangleF FromLTRB(float left, float top, float right, float bottom)
        {
            return new RectangleF(left, top, right - left, bottom - top);
        }

        public static RectangleF Intersect(RectangleF left, RectangleF right)
        {
            float xMin = Math.Max(left.x, right.x);
            float xMax = Math.Min(left.x + left.width, right.x + right.width);
            float yMin = Math.Max(left.y, right.y);
            float yMax = Math.Min(left.y + left.height, right.y + right.height);

            if (xMax >= xMin && yMax >= yMin)
            {
                return new RectangleF(xMin, yMin, xMax - xMin, yMax - yMin);
            }

            return Empty;
        }

        public static RectangleF Union(RectangleF left, RectangleF right)
        {
            float xMin = Math.Min(left.x, right.x);
            float yMin = Math.Min(left.y, right.y);

            float xMax = Math.Max(left.x + left.width, right.x + right.width);
            float yMax = Math.Max(left.y + left.height, right.y + right.height);

            return new RectangleF(xMin, yMin, xMax - xMin, yMax - yMin);
        }
        #endregion

        #region Operators overloading

        public static bool operator ==(RectangleF left, RectangleF right)
        {
            return left.x == right.x && left.y == right.y && left.width == right.width && left.height == right.height;
        }

        public static bool operator !=(RectangleF left, RectangleF right)
        {
            return !(left == right);
        }

        public static implicit operator RectangleF(Rectangle source)
        {
            return new RectangleF(source.x, source.y, source.width, source.height);
        }
        #endregion

        #region Fields
        internal float x;

        internal float y;

        internal float width;

        internal float height;
        #endregion

        #region Properties
        /// <summary>
        /// Возвращает значение, определяющее, все ли параметры прямоугольника имеют нулевые значения
        /// </summary>
        public bool IsEmpty
        {
            get { return height == 0 && width == 0 && x == 0 && y == 0; }
        }
        /// <summary>
        /// 
        /// </summary>
        public float X => x;
        /// <summary>
        /// 
        /// </summary>
        public float Y => y;
        /// <summary>
        /// 
        /// </summary>
        public float Width => width;
        /// <summary>
        /// 
        /// </summary>
        public float Height => height;
        /// <summary>
        /// 
        /// </summary>
        public float Left => x;
        /// <summary>
        /// 
        /// </summary>
        public float Top => y;
        /// <summary>
        /// 
        /// </summary>
        public float Right => x + width;
        /// <summary>
        /// 
        /// </summary>
        public float Bottom => y + height;
        /// <summary>
        /// 
        /// </summary>
        public PointF Location
        {
            get { return new PointF(x, y); }
            set
            {
                x = value.x;
                y = value.y;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public SizeF Size
        {
            get { return new SizeF(width, height); }
            set
            {
                width = value.width;
                height = value.height;
            }
        }
        #endregion

        #region Constructors

        public RectangleF(float x, float y, float width, float height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        public RectangleF(PointF location, SizeF size)
        {
            x = location.x;
            y = location.y;
            width = size.width;
            height = size.height;
        }
        #endregion

        #region Methods

        public bool Contains(float x, float y)
        {
            return this.x <= x && x < this.x + this.width && this.y <= y && y < this.y + this.height;
        }

        public bool Contains(PointF point)
        {
            return this.Contains(point.x, point.y);
        }

        public bool Contains(RectangleF other)
        {
            return x <= other.x && other.x + other.width <= x + width && y <= other.y && other.y + other.height <= y + height;
        }

        public void Inflate(float x, float y)
        {
            this.x -= x;
            this.y -= y;
            this.width += 2f * x;
            this.height += 2f * y;
        }

        public void Inflate(SizeF size)
        {
            Inflate(size.width, size.height);
        }

        public void Intersect(RectangleF other)
        {
            RectangleF rectangleF = Intersect(other, this);
            x = rectangleF.x;
            y = rectangleF.y;
            width = rectangleF.width;
            height = rectangleF.height;
        }

        public bool IntersectsWith(RectangleF other)
        {
            return other.x < x + width && x < other.x + other.width && other.y < y + height && y < other.Y + other.Height;
        }

        public void Offset(float x, float y)
        {
            this.x += x;
            this.y += y;
        }

        public void Offset(PointF shift)
        {
            Offset(shift.x, shift.y);
        }

        public bool Equals(RectangleF other)
        {
            return false;
        }

        public override bool Equals(object obj)
        {
            return (obj is RectangleF) && (this == (RectangleF)obj);
        }

        public override int GetHashCode()
        {
            return (int)((uint)x ^ ((uint)y << 13 | (uint)y >> 19) ^ ((uint)width << 26 | (uint)width >> 6) ^ ((uint)height << 7 | (uint)height >> 25));
        }

        public override string ToString()
        {
            return string.Format("{{X = {0}, Y = {1}, Width = {2}, Height = {3}}}", x, y, width, height);
        }
        #endregion
    }
}