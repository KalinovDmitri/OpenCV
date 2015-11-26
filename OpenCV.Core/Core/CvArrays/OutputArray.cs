using System;

namespace OpenCV.Core
{
    /// <summary>
    /// Представляет прокси - класс для передачи массивов в качестве выходных параметров в функции OpenCV
    /// </summary>
    public class OutputArray : InputArray
    {
        #region Properties
        /// <summary>
        /// Возвращает значение, определяющее, является ли текущий массив массивом фиксированного размера
        /// </summary>
        public bool IsFixedSize
        {
            get { return CvInvoke.cveOutputArrayFixedSize(InnerPointer); }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsFixedType
        {
            get { return CvInvoke.cveOutputArrayFixedType(InnerPointer); }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsNeeded
        {
            get { return CvInvoke.cveOutputArrayNeeded(InnerPointer); }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="OutputArray"/>
        /// </summary>
        public OutputArray() { }
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="OutputArray"/> с использованием указателя на неуправляемый массив
        /// </summary>
        /// <param name="arrayPtr">Структура <see cref="IntPtr"/>, представляющая указатель на неуправляемый массив</param>
        public OutputArray(IntPtr arrayPtr) : base(arrayPtr) { }
        #endregion

        #region Class methods
        /// <summary>
        /// Выполняет освобождение неуправляемых ресурсов, занимаемых данным объектом
        /// </summary>
        protected override void DisposeObject()
        {
            if (InnerPointer != IntPtr.Zero)
            {
                CvInvoke.cveOutputArrayRelease(ref InnerPointer);
            }
        }
        #endregion
    }
}