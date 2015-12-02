using System;

namespace OpenCV
{
    /// <summary>
    /// Представляет абстрактную оболочку неуправляемого объекта, предоставляя к нему доступ через указатель <see cref="IntPtr"/>
    /// </summary>
    public abstract class UnmanagedObject : DisposableObject
    {
        #region Operators overloading
        /// <summary>
        /// Выполняет неявное преобразование указанного объекта <see cref="DisposableHandle"/> в эквивалентную структуру <see cref="IntPtr"/>,
        /// представляющую адрес неуправляемого объекта
        /// </summary>
        /// <param name="obj">Преобразуемый объект <see cref="UnmanagedObject"/></param>
        public static implicit operator IntPtr(UnmanagedObject obj)
        {
            return (obj != null) ? obj.InnerPointer : IntPtr.Zero;
        }
        #endregion

        #region Fields and properties
        /// <summary>
        /// Представляет значение, определяющее необходимость автоматического освобождения ресурсов
        /// </summary>
        protected readonly bool NeedDispose;
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
        /// <param name="needDispose">Значение <see cref="bool"/>, определяющее необходимость автоматического освобождения ресурсов</param>
        protected internal UnmanagedObject(bool needDispose) : base()
        {
            NeedDispose = needDispose;
        }
        #endregion
    }
}