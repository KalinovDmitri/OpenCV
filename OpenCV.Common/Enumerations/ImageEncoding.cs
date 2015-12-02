using System;

namespace OpenCV.Enumerations
{
    /// <summary>
    /// Определяет перечислимые константы, представляющие целевой формат кодирования изображения
    /// </summary>
    public enum ImageEncoding
    {
        /// <summary>
        /// Целевой формат кодирования - JPEG. Это значение по умолчанию.
        /// </summary>
        Default = 0,
        /// <summary>
        /// Целевой формат кодирования - JPEG. Это значение эквивалентно <see cref="Default"/>.
        /// </summary>
        Jpeg = 1,
        /// <summary>
        /// Целевой формат кодирования - BMP
        /// </summary>
        Bmp = 2
    }
}