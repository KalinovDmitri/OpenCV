using System;

namespace OpenCV.Core
{
    /// <summary>
    /// Позволяет реализующему классу предоставить экземпляр <see cref="InputArray"/> для передачи в неуправляемые функции OpenCV
    /// </summary>
    public interface IInputArray
    {
        /// <summary>
        /// Возвращает экземпляр класса <see cref="InputArray"/> для передачи в неуправляемые функции OpenCV
        /// </summary>
        /// <returns>Экземпляр класса <see cref="InputArray"/></returns>
        InputArray GetInputArray();
    }
}