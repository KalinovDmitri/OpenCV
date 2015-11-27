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

        public const string ExternLibrary = "cvextern.dll";
        #endregion

        #region Base methods

        public static int MakeType(DepthType depth, int channels)
        {
            return (int)((depth & (DepthType)7) + (channels - 1 << 3));
        }
        #endregion
    }
}