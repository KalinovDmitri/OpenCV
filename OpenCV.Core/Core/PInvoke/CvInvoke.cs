using System;
using System.Runtime.InteropServices;

namespace OpenCV.Core
{
    /// <summary>
    /// Предоставляет точку входа для вызова неуправляемых функций библиотеки cvextern.dll
    /// </summary>
    public static partial class CvInvoke
    {
        #region Constants

        public const string ExternLibrary = "cvextern.dll";
        #endregion
    }
}