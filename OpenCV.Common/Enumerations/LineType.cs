using System;

namespace OpenCV.Enumerations
{
    /// <summary>
    /// Определяет перечислимые константы, представляющие тип начертания линии
    /// </summary>
    public enum LineType
    {
        /// <summary>
        /// 8 - соединённая линия
        /// </summary>
        EightConnected = 8,
        /// <summary>
        /// 4 - соединённая линия
        /// </summary>
        FourConnected = 4,
        /// <summary>
        /// Линия со сглаживанием
        /// </summary>
        AntiAlias = 16
    }
}