using System;

namespace OpenCV
{
    /// <summary>
    /// Содержит координаты центра и радиуса окружности
    /// </summary>
    public struct CircleF : IEquatable<CircleF>
    {
        #region Fields and properties
        /// <summary>
        /// Представляет координаты центра окружности
        /// </summary>
        public PointF Center;
        /// <summary>
        /// Представляет радиус окружности
        /// </summary>
        public float Radius;
        /// <summary>
        /// Возвращает площадь круга, ограниченного данной окружностью
        /// </summary>
        public double Area
        {
            get
            {
                return (Radius * Radius) * Math.PI;
            }
        }
        /// <summary>
        /// Возвращает периметр данной окружности
        /// </summary>
        public double Perimeter
        {
            get
            {
                return 2 * Radius * Math.PI;
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="CircleF"/> с указанием центра и радиуса
        /// </summary>
        /// <param name="center">Структура <see cref="PointF"/>, представляющая центр окружности</param>
        /// <param name="radius">Значение <see cref="float"/>, представляющее радиус окружности</param>
        public CircleF(PointF center, float radius)
        {
            Center = center;
            Radius = radius;
        }
        #endregion

        #region Methods

        public bool Equals(CircleF other)
        {
            return Center == other.Center && Radius == other.Radius;
        }
        #endregion
    }
}