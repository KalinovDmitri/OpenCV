using System;

namespace OpenCV
{
    /// <summary>
    /// Представляет выпуклый многоугольник, вершины которого представлены структурами <see cref="PointF"/>
    /// </summary>
    public interface IConvexPolygonF
    {
        /// <summary>
        /// Возвращает массив точек, представляющих координаты вершин данного многоугольника
        /// </summary>
        /// <returns>Массив структур <see cref="PointF"/>, представляющих координаты вершин многоугольника</returns>
        PointF[] GetVertices();
    }
}