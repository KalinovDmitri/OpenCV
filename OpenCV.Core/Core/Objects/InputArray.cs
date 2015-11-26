using System;
using System.Runtime.InteropServices;

namespace OpenCV.Core
{
    /// <summary>
    /// Представляет прокси - класс для передачи массивов с доступом только для чтения в функции OpenCV
    /// </summary>
    public class InputArray : UnmanagedObject
    {
        #region Constructors
        /// <summary>
        /// Инициализирует новый пустой экземпляр класса <see cref="InputArray"/>
        /// </summary>
        public InputArray() { }
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="InputArray"/> с использованием указателя на неуправляемый массив
        /// </summary>
        /// <param name="arrayPtr">Структура <see cref="IntPtr"/>, представляющая указатель на неуправляемый массив</param>
        public InputArray(IntPtr arrayPtr)
        {
            InnerPointer = arrayPtr;
        }
        #endregion

        #region Class methods

        protected override void DisposeObject()
        {
            if (InnerPointer != IntPtr.Zero)
            {

            }
        }
        #endregion
    }
}