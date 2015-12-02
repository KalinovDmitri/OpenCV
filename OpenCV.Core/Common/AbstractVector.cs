using System;

namespace OpenCV
{
    /// <summary>
    /// Представляет абстрактную оболочку неуправляемого класса <see cref="T:vector&lt;T&gt;"/>
    /// </summary>
    public abstract class AbstractVector : UnmanagedObject, IInputArray, IOutputArray, IInputOutputArray
    {
        #region Fields and properties
        /// <summary>
        /// Представляет делегат, выполняющий получение указателя на массив <see cref="InputArray"/> для данного вектора
        /// </summary>
        protected VectorArray GetAsInputArray;
        /// <summary>
        /// 
        /// </summary>
        protected VectorArray GetAsOutputArray;
        /// <summary>
        /// 
        /// </summary>
        protected VectorArray GetAsInputOutputArray;
        /// <summary>
        /// Представляет делегат, выполняющий получение размера текущего экземпляра вектора
        /// </summary>
        protected VectorSize GetSize;
        /// <summary>
        /// Представляет делегат, выполняющий получение начального адреса неуправляемого вектора
        /// </summary>
        protected VectorStartAddress GetStartAddress;
        /// <summary>
        /// Представляет делегат, выполняющий очистку текущего экземпляра вектора
        /// </summary>
        protected VectorClear ClearData;
        /// <summary>
        /// Представляет делегат, выполняющий освобождение занимаемых ресурсов
        /// </summary>
        protected VectorRelease Release;
        /// <summary>
        /// Возвращает текущий размер вектора
        /// </summary>
        public int Size => GetSize(InnerPointer);
        /// <summary>
        /// Возвращает начальный адрес неуправляемого вектора
        /// </summary>
        public readonly IntPtr StartAddress;
        #endregion

        #region Constructors
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="AbstractVector"/> с помощью указателя <paramref name="vectorPtr"/>
        /// </summary>
        /// <param name="vectorPtr">Структура <see cref="IntPtr"/>, представляющая указатель на неуправляемый вектор</param>
        /// <param name="needDispose">Значение <see cref="bool"/>, определяющее необходимость автоматического освобождения ресурсов</param>
        protected internal AbstractVector(IntPtr vectorPtr, bool needDispose) : base(needDispose)
        {
            InnerPointer = vectorPtr;

            FinalizeCreation();

            StartAddress = (GetStartAddress != null) ? GetStartAddress(InnerPointer) : IntPtr.Zero;
        }
        #endregion

        #region Class methods
        /// <summary>
        /// Выполняет удаление всех элементов из текущего экземпляра вектора
        /// </summary>
        public void Clear()
        {
            ClearData(InnerPointer);
        }
        /// <summary>
        /// Возвращает экземпляр класса <see cref="InputArray"/> для передачи в неуправляемые функции OpenCV
        /// </summary>
        /// <returns>Экземпляр класса <see cref="InputArray"/></returns>
        public InputArray GetInputArray()
        {
            IntPtr arrayPtr = GetAsInputArray(InnerPointer);
            return new InputArray(arrayPtr);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public OutputArray GetOutputArray()
        {
            IntPtr arrayPtr = GetAsOutputArray(InnerPointer);
            return new OutputArray(arrayPtr);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public InputOutputArray GetInputOutputArray()
        {
            IntPtr arrayPtr = GetAsInputOutputArray(InnerPointer);
            return new InputOutputArray(arrayPtr);
        }
        /// <summary>
        /// Завершает инициализацию текущего экземпляра вектора
        /// </summary>
        /// <remarks>
        /// При переопределении в производном классе в данном методе необходимо инициализировать
        /// экземпляры делегатов для получения размера и удаления вектора
        /// </remarks>
        protected abstract void FinalizeCreation();
        /// <summary>
        /// Выполняет освобождение неуправляемых ресурсов, занимаемых данным объектом
        /// </summary>
        protected override void DisposeObject()
        {
            if (NeedDispose && InnerPointer != IntPtr.Zero)
            {
                Release(ref InnerPointer);
            }
        }
        #endregion
    }
}