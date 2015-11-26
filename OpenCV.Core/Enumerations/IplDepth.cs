using System;

namespace OpenCV.Core.Enumerations
{
    /// <summary>
    /// Предоставляет перечислимые константы, определяющие глубину инициализируемого изображения
    /// </summary>
    public enum IplDepth : uint
    {
        /// <summary>
        /// Указывает, что представляемое значение содержит знак
        /// </summary>
        IplDepthSign = 2147483648u,
        /// <summary>
        /// Глубина 1 беззнаковый бит
        /// </summary>
        IplDepth_1U = 1u,
        /// <summary>
        /// Глубина 8 бит без знака (byte)
        /// </summary>
        IplDepth_8U = 8u,
        /// <summary>
        /// Глубина 16 бит без знака (ushort)
        /// </summary>
        IplDepth16U = 16u,
        /// <summary>
        /// Глубина 32 бит с плавающей точкой (float)
        /// </summary>
        IplDepth32F = 32u,
        /// <summary>
        /// Глубина 8 бит со знаком (sbyte)
        /// </summary>
        IplDepth_8S = 2147483656u,
        /// <summary>
        /// Глубина 16 бит со знаком (short)
        /// </summary>
        IplDepth16S = 2147483664u,
        /// <summary>
        /// Глубина 32 бит со знаком (int)
        /// </summary>
        IplDepth32S = 2147483680u,
        /// <summary>
        /// Глубина 64 бит с плавающей точкой (double)
        /// </summary>
        IplDepth64F = 64u
    }
}