using System;

namespace OpenCV
{
    /// <summary>
    /// Содержит набор из четырёх целых чисел, определяющих положение и размер прямоугольника
    /// </summary>
    public struct Rectangle : IEquatable<Rectangle>
    {
        #region Static members
        /// <summary>
        /// Представляет структуру <see cref="Rectangle"/>, параметры которой не инициализированы
        /// </summary>
        public static readonly Rectangle Empty;

        public static Rectangle FromLTRB(int left, int top, int right, int bottom)
        {
            return new Rectangle(left, top, right - left, bottom - top);
        }

        public static Rectangle Inflate(Rectangle source, int x, int y)
        {
            Rectangle result = source;
            result.Inflate(x, y);
            return result;
        }

        public static Rectangle Intersect(Rectangle left, Rectangle right)
        {
            int xMin = Math.Max(left.x, right.x);
            int xMax = Math.Min(left.x + left.width, right.x + right.width);
            int yMin = Math.Max(left.y, right.y);
            int yMax = Math.Min(left.y + left.height, right.y + right.height);

            if (xMax >= xMin && yMax >= yMin)
            {
                return new Rectangle(xMin, yMin, xMax - xMin, yMax - yMin);
            }

            return Empty;
        }

        public static Rectangle Union(Rectangle left, Rectangle right)
        {
            int xMin = Math.Min(left.x, right.x);
            int yMin = Math.Min(left.y, right.y);

            int wMax = Math.Max(left.x + left.width, right.x + right.width);
            int hMax = Math.Max(left.y + left.height, right.y + right.height);

            return new Rectangle(xMin, yMin, wMax - xMin, hMax - yMin);
        }
        #endregion

        #region Operators overloading

        public static bool operator ==(Rectangle left, Rectangle right)
        {
            return left.x == right.x && left.y == right.y && left.width == right.width && left.height == right.height;
        }

        public static bool operator !=(Rectangle left, Rectangle right)
        {
            return !(left == right);
        }
        #endregion

        #region Fields
        /// <summary>
        /// Представляет координату по оси X верхнего левого угла прямоугольника
        /// </summary>
        internal int x;
        /// <summary>
        /// Представляет координату по оси Y верхнего левого угла прямоугольника
        /// </summary>
        internal int y;
        /// <summary>
        /// Представляет ширину прямоугольника
        /// </summary>
        internal int width;
        /// <summary>
        /// Представляет высоту прямоугольника
        /// </summary>
        internal int height;
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
        public int X => x;
        /// <summary>
        /// 
        /// </summary>
        public int Y => y;
        /// <summary>
        /// 
        /// </summary>
        public int Width => width;
        /// <summary>
        /// 
        /// </summary>
        public int Height => height;
        /// <summary>
        /// 
        /// </summary>
        public int Left => x;
        /// <summary>
        /// 
        /// </summary>
        public int Top => y;
        /// <summary>
        /// 
        /// </summary>
        public int Right => x + width;
        /// <summary>
        /// 
        /// </summary>
        public int Bottom => y + height;
        /// <summary>
        /// Возвращает или задаёт координаты левого верхнего угла прямоугольника
        /// </summary>
        public Point Location
        {
            get { return new Point(x, y); }
            set
            {
                x = value.x;
                y = value.y;
            }
        }
        /// <summary>
        /// Возвращает или задаёт размер прямоугольника
        /// </summary>
        public Size Size
        {
            get { return new Size(width, height); }
            set
            {
                width = value.width;
                height = value.height;
            }
        }
        #endregion

        #region Constructors

        public Rectangle(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        public Rectangle(Point location, Size size)
        {
            x = location.x;
            y = location.y;
            width = size.width;
            height = size.height;
        }
        #endregion

        #region Methods

        public bool Contains(int x, int y)
        {
            return this.x <= x && x < this.x + this.width && this.y <= y && y < this.y + this.height;
        }

        public bool Contains(Point point)
        {
            return Contains(point.x, point.y);
        }

        public bool Contains(Rectangle other)
        {
            return x <= other.x && other.x + other.width <= x + width && y <= other.y && other.y + other.height <= y + height;
        }

        public void Inflate(int width, int height)
        {
            x -= width;
            y -= height;
            this.width += (width << 1);
            this.height += (height << 1);
        }

        public void Inflate(Size size)
        {
            Inflate(size.width, size.height);
        }
        public void Intersect(Rectangle other)
        {
            Rectangle rectangle = Intersect(other, this);
            x = rectangle.X;
            y = rectangle.Y;
            width = rectangle.Width;
            height = rectangle.Height;
        }

        public bool IntersectsWith(Rectangle other)
        {
            return other.x < x + width && x < other.x + other.width && other.y < y + height && y < other.y + other.height;
        }

        public void Offset(int x, int y)
        {
            this.x += x;
            this.y += y;
        }

        public void Offset(Point pos)
        {
            Offset(pos.x, pos.y);
        }

        public bool Equals(Rectangle other)
        {
            return this == other;
        }

        public override bool Equals(object obj)
        {
            return (obj is Rectangle) && ((this == (Rectangle)obj));
        }

        public override int GetHashCode()
        {
            return x ^ (y << 13 | y >> 19) ^ (width << 26 | width >> 6) ^ (height << 7 | height >> 25);
        }

        public override string ToString()
        {
            return string.Format("{{X = {0}, Y = {1}, Width = {2}, Height = {3}}}", x, y, width, height);
        }
        #endregion
    }
}