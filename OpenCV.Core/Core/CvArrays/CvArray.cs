using System;
using System.Runtime.InteropServices;

namespace OpenCV
{
    /// <summary>
    /// Представляет управляемую оболочку для класса CvArr
    /// </summary>
    /// <typeparam name="TDepth">Тип элементов массива</typeparam>
    public abstract class CvArray<TDepth> : UnmanagedObject where TDepth : struct
    {
        #region Static members
        /// <summary>
        /// Представляет значение, определяющее размер отдельного элемента массива
        /// </summary>
        public static readonly int ElementSize;
        #endregion

        #region Constructors
        /// <summary>
        /// Инициализирует статические поля класса <see cref="CvArray{TDepth}"/>
        /// </summary>
        static CvArray()
        {
            ElementSize = Marshal.SizeOf(typeof(TDepth));
        }
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="CvArray{TDepth}"/>
        /// </summary>
        protected internal CvArray() : base(true) { }
        #endregion

        #region Class methods
        #endregion
    }
}