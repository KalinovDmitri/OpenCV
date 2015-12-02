using System;

namespace OpenCV
{
    /// <summary>
    /// Представляет прокси - класс для передачи массивов в качестве входных / выходных параметров в функции OpenCV
    /// </summary>
    public class InputOutputArray : OutputArray
    {
        #region Constructors
        /// <summary>
        /// Инициализирует новый пустой экземпляр класса <see cref="InputOutputArray"/>
        /// </summary>
        public InputOutputArray() : base() { }
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="InputOutputArray"/> с использованием указателя на неуправляемый массив
        /// </summary>
        /// <param name="arrayPtr">Структура <see cref="IntPtr"/>, представляющая указатель на неуправляемый массив</param>
        public InputOutputArray(IntPtr arrayPtr) : base(arrayPtr) { }
        #endregion

        #region Class methods

        protected override void DisposeObject()
        {
            if (InnerPointer != IntPtr.Zero)
            {
                CvInvoke.cveInputOutputArrayRelease(ref InnerPointer);
            }
        }
        #endregion
    }
}