using System;

namespace OpenCV.Enumerations
{
    /// <summary>
	/// Предоставляет перечислимые константы, определяющие глубину инициализируемой матрицы
	/// </summary>
	public enum DepthType
    {
        /// <summary>
        /// Глубина по умолчанию
        /// </summary>
        Default = -1,
        /// <summary>
        /// Byte
        /// </summary>
        Cv8U,
        /// <summary>
        /// SByte
        /// </summary>
        Cv8S,
        /// <summary>
        /// UInt16
        /// </summary>
        Cv16U,
        /// <summary>
        /// Int16
        /// </summary>
        Cv16S,
        /// <summary>
        /// Int32
        /// </summary>
        Cv32S,
        /// <summary>
        /// Float
        /// </summary>
        Cv32F,
        /// <summary>
        /// Double
        /// </summary>
        Cv64F
    }
}