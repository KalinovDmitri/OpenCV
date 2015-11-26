using System;

namespace OpenCV.Core
{
    /// <summary>
    /// Представляет абстрактную оболочку неуправляемого объекта, предоставляя к нему доступ через указатель <see cref="IntPtr"/>
    /// </summary>
    public abstract class UnmanagedObject : DisposableObject
    {
        #region Operators overloading
        /// <summary>
        /// Оператор неявного приведения к указателю на неуправляемый объект
        /// </summary>
        /// <param name="obj">Экземпляр класса <see cref="UnmanagedObject"/></param>
        public static implicit operator IntPtr(UnmanagedObject obj)
        {
            return (obj != null) ? obj.InnerPointer : IntPtr.Zero;
        }
        #endregion

        #region Fields and properties
        /// <summary>
        /// Представляет указатель на неуправляемый объект
        /// </summary>
        protected IntPtr InnerPointer;
        /// <summary>
        /// Возвращает указатель на неуправляемый объект
        /// </summary>
        public IntPtr Pointer => InnerPointer;
        #endregion

        #region Constructors
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="UnmanagedObject"/>
        /// </summary>
        protected internal UnmanagedObject() : base() { }
        #endregion
    }
}