using System;
using System.Runtime.InteropServices;

namespace OpenCV
{
    /// <summary>
    /// Предоставляет способ доступа к управляемому объекту из неуправляемой памяти с возможностью автоматического освобождения выделенного дескриптора.
    /// Данный класс не может наследоваться.
    /// </summary>
    public sealed class DisposableHandle : IDisposable
    {
        #region Static members
        /// <summary>
        /// Выделяет дескриптор указанного типа для указанного объекта
        /// </summary>
        /// <param name="value">Объект, для которого выполняется выделение дескриптора</param>
        /// <param name="handleType">Значение перечисления <see cref="GCHandleType"/>, определяющее тип выделяемого дескриптора</param>
        /// <returns>Выделенный дескриптор <see cref="DisposableHandle"/> для указанного объекта</returns>
        public static DisposableHandle Alloc(object value, GCHandleType handleType = GCHandleType.Pinned)
        {
            return new DisposableHandle(value, handleType);
        }
        /// <summary>
        /// Выполняет неявное преобразование указанного объекта <see cref="DisposableHandle"/> в эквивалентную структуру <see cref="IntPtr"/>,
        /// представляющую адрес выделенного дескриптора
        /// </summary>
        /// <param name="handle">Преобразуемый объект <see cref="DisposableHandle"/></param>
        public static implicit operator IntPtr(DisposableHandle handle)
        {
            return (handle != null) ? handle.Pointer : IntPtr.Zero;
        }
        #endregion

        #region Fields
        /// <summary>
        /// Структура <see cref="GCHandle"/>, представляющая выделенный дескриптор объекта
        /// </summary>
        private readonly GCHandle InnerHandle;
        /// <summary>
        /// Структура <see cref="IntPtr"/>, представляющая адрес выделенного дескриптора
        /// </summary>
        public readonly IntPtr Pointer;
        #endregion

        #region Constructors
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="DisposableHandle"/>
        /// </summary>
        /// <param name="value">Объект, для которого выполняется выделение дескриптора</param>
        /// <param name="handleType">Значение перечисления <see cref="GCHandleType"/>, определяющее тип выделяемого дескриптора</param>
        private DisposableHandle(object value, GCHandleType handleType)
        {
            InnerHandle = GCHandle.Alloc(value, handleType);
            Pointer = InnerHandle.AddrOfPinnedObject();
        }
        #endregion

        #region IDisposable implementation
        /// <summary>
        /// Выполняет освобождение выделенного дескриптора
        /// </summary>
        void IDisposable.Dispose()
        {
            InnerHandle.Free();
        }
        #endregion
    }
}