using System;

namespace OpenCV
{
    using Enumerations;

    /// <summary>
    /// Представляет прокси - класс для передачи массивов с доступом только для чтения в функции OpenCV
    /// </summary>
    public class InputArray : UnmanagedObject
    {
        #region Constructors
        /// <summary>
        /// Инициализирует новый пустой экземпляр класса <see cref="InputArray"/>
        /// </summary>
        public InputArray() : base() { }
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="InputArray"/> с использованием указателя на неуправляемый массив
        /// </summary>
        /// <param name="arrayPtr">Структура <see cref="IntPtr"/>, представляющая указатель на неуправляемый массив</param>
        public InputArray(IntPtr arrayPtr) : base()
        {
            InnerPointer = arrayPtr;
        }
        #endregion

        #region Class methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public int GetChannels(int idx = -1)
        {
            int result = 0;
            if (InnerPointer != IntPtr.Zero)
            {
                result = CvInvoke.cveInputArrayGetChannels(InnerPointer, idx);
            }
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public DepthType GetDepth(int idx = -1)
        {
            DepthType result = DepthType.Default;
            if (InnerPointer != IntPtr.Zero)
            {
                result = CvInvoke.cveInputArrayGetDepth(InnerPointer, idx);
            }
            return result;
        }
        /// <summary>
        /// Возвращает размер данного экземпляра относительно указанного индекса
        /// </summary>
        /// <param name="idx">Значение <see cref="int"/>, определяющее анализируемый индекс. Этот параметр является необязательным.</param>
        /// <returns>Структура <see cref="Size"/>, определяющая размер данного массива относительно указанного индекса</returns>
        public Size GetSize(int idx = -1)
        {
            Size result = default(Size);
            if (InnerPointer != IntPtr.Zero)
            {
                CvInvoke.cveInputArrayGetSize(InnerPointer, ref result, idx);
            }
            return result;
        }
        /// <summary>
        /// Возвращает значение, определяющее, является ли данный экземпляр массива пустым
        /// </summary>
        /// <returns>Значение <see cref="bool"/>, определяющее, пуст ли данный массив</returns>
        public bool IsEmpty()
        {
            return InnerPointer == IntPtr.Zero || CvInvoke.cveInputArrayIsEmpty(InnerPointer);
        }
        /// <summary>
        /// Выполняет освобождение неуправляемых ресурсов, занимаемых данным объектом
        /// </summary>
        protected override void DisposeObject()
        {
            if (InnerPointer != IntPtr.Zero)
            {
                CvInvoke.cveInputArrayRelease(ref InnerPointer);
            }
        }
        #endregion
    }
}