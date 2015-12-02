using System;

namespace OpenCV
{
    /// <summary>
    /// Предоставляет способы взаимодействия с изображением, загруженным в память
    /// </summary>
    public interface IImage : IInputArrayOfArrays, IInputOutputArray, IOutputArray, IInputArray, IDisposable
    {
        #region Properties
        /// <summary>
        /// Возвращает структуру <see cref="IntPtr"/>, представляющую указатель на неуправляемое изображение
        /// </summary>
        IntPtr Pointer { get; }
        /// <summary>
        /// Возвращает структуру <see cref="Size"/>, представляющую размер изображения
        /// </summary>
        Size ImageSize { get; }
        /// <summary>
        /// Возвращает количество каналов изображения
        /// </summary>
        int NumberOfChannels { get; }
        #endregion

        #region Methods


        #endregion
    }
}