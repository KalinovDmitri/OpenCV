using System;

namespace OpenCV.Enumerations
{
    /// <summary>
    /// Определяет перечислимые константы, представляющие тип начертания линии
    /// </summary>
    public enum LineType
    {
        /// <summary>
        /// 8 - соединённая
        /// </summary>
        EightConnected = 8,
        /// <summary>
        /// 4 - соединённая
        /// </summary>
        FourConnected = 4,
        /// <summary>
        /// Со сглаживанием
        /// </summary>
        AntiAlias = 16
    }
}