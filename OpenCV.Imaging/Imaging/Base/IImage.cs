using System;

namespace OpenCV.Imaging
{
    /// <summary>
    /// Представляет изображение
    /// </summary>
    public interface IImage : IInputArrayOfArrays, IInputOutputArray, IOutputArray, IInputArray, IDisposable
    {
        #region Properties

        IntPtr Pointer { get; }

        Size ImageSize { get; }

        int NumberOfChannels { get; }
        #endregion

        #region Methods

        byte[] GetData(params int[] indices);
        #endregion
    }
}