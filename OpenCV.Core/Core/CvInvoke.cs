using System;

namespace OpenCV
{
    using Enumerations;

    /// <summary>
    /// Предоставляет точку входа для вызова неуправляемых функций библиотеки cvextern.dll
    /// </summary>
    public static partial class CvInvoke
    {
        #region Constants
        /// <summary>
        /// Представляет название импортируемой библиотеки - cvextern.dll
        /// </summary>
        public const string ExternLibrary = "cvextern.dll";
        #endregion

        #region Base methods
        /// <summary>
        /// Возвращает значение <see cref="int"/>, определяющее тип инициализируемого изображения
        /// </summary>
        /// <param name="depth">Значение перечисления <see cref="DepthType"/>, определяющее глубину изображения</param>
        /// <param name="channels">Значение <see cref="int"/>, определяющее количество каналов изображения</param>
        /// <returns>Тип инициализируемого изображения</returns>
        public static int MakeType(DepthType depth, int channels)
        {
            return (int)((depth & (DepthType)7) + (channels - 1 << 3));
        }
        #endregion
    }
}