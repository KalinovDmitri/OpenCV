using System;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace OpenCV
{
    /// <summary>
    /// Представляет абстрактную оболочку неуправляемого класса <see cref="T:vector&lt;T&gt;"/>
    /// </summary>
    public abstract class AbstractVector : UnmanagedObject, IInputArray, IOutputArray, IInputOutputArray, ISerializable
    {
        #region Fields and properties
        /// <summary>
        /// Представляет делегат, выполняющий получение указателя на массив <see cref="InputArray"/> для текущего экземпляра
        /// </summary>
        protected VectorArray GetAsInputArray;
        /// <summary>
        /// Представляет делегат, выполняющий получение указателя на массив <see cref="OutputArray"/> для текущего экземпляра
        /// </summary>
        protected VectorArray GetAsOutputArray;
        /// <summary>
        /// Представляет делегат, выполняющий получение указателя на массив <see cref="InputOutputArray"/> для текущего экземпляра
        /// </summary>
        protected VectorArray GetAsInputOutputArray;
        /// <summary>
        /// Представляет делегат, выполняющий получение количества элементов в неуправляемом векторе
        /// </summary>
        protected VectorSize GetSize;
        /// <summary>
        /// Представляет делегат, выполняющий получение адреса первого элемента неуправляемого вектора
        /// </summary>
        protected VectorStartAddress GetStartAddress;
        /// <summary>
        /// Представляет делегат, выполняющий очистку неуправляемого вектора
        /// </summary>
        protected VectorClear ClearData;
        /// <summary>
        /// Представляет делегат, выполняющий освобождение ресурсов, занимаемых неуправляемым вектором
        /// </summary>
        protected VectorRelease Release;
        /// <summary>
        /// Возвращает начальный адрес неуправляемого вектора
        /// </summary>
        protected internal readonly IntPtr StartAddress;
        /// <summary>
        /// Возвращает текущий размер вектора
        /// </summary>
        public int Count => GetSize(InnerPointer);
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
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public abstract void GetObjectData(SerializationInfo info, StreamingContext context);
        /// <summary>
        /// Выполняет удаление всех элементов из текущего экземпляра
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
        /// Возвращает экземпляр класса <see cref="OutputArray"/> для передачи в неуправляемые функции OpenCV
        /// </summary>
        /// <returns>Экземпляр класса <see cref="OutputArray"/></returns>
        public OutputArray GetOutputArray()
        {
            IntPtr arrayPtr = GetAsOutputArray(InnerPointer);
            return new OutputArray(arrayPtr);
        }
        /// <summary>
        /// Возвращает экземпляр класса <see cref="InputOutputArray"/> для передачи в неуправляемые функции OpenCV
        /// </summary>
        /// <returns>Экземпляр класса <see cref="InputOutputArray"/></returns>
        public InputOutputArray GetInputOutputArray()
        {
            IntPtr arrayPtr = GetAsInputOutputArray(InnerPointer);
            return new InputOutputArray(arrayPtr);
        }
        /// <summary>
        /// Завершает инициализацию текущего экземпляра
        /// </summary>
        /// <remarks>
        /// При переопределении в производном классе в данном методе необходимо инициализировать экземпляры делегатов
        /// для обеспечения взаимодействия с неуправляемым вектором
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