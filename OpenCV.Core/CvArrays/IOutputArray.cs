using System;

namespace OpenCV
{
    /// <summary>
    /// Позволяет реализующему классу предоставить экземпляр <see cref="OutputArray"/> для передачи в неуправляемые функции OpenCV
    /// </summary>
    public interface IOutputArray
    {
        /// <summary>
        /// Возвращает экземпляр класса <see cref="OutputArray"/> для передачи в неуправляемые функции OpenCV
        /// </summary>
        /// <returns>Экземпляр класса <see cref="OutputArray"/></returns>
        OutputArray GetOutputArray();
    }
}