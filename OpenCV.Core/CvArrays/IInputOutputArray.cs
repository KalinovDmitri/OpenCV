using System;

namespace OpenCV
{
    /// <summary>
    /// Позволяет реализующему классу предоставить экземпляр <see cref="InputOutputArray"/> для передачи в неуправляемые функции OpenCV
    /// </summary>
    public interface IInputOutputArray
    {
        /// <summary>
        /// Возвращает экземпляр класса <see cref="InputOutputArray"/> для передачи в неуправляемые функции OpenCV
        /// </summary>
        /// <returns>Экземпляр класса <see cref="InputOutputArray"/></returns>
        InputOutputArray GetInputOutputArray();
    }
}