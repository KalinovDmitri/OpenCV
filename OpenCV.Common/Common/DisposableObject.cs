﻿using System;

namespace OpenCV
{
    /// <summary>
    /// Представляет абстрактную оболочку объекта, способного к автоматическому освобождению занимаемых ресурсов
    /// </summary>
    public abstract class DisposableObject : IDisposable
    {
        #region Fields
        /// <summary>
        /// Представляет значение, определяющее, освобождены ли занимаемые объектом ресурсы
        /// </summary>
        private bool IsDisposed = false;
        #endregion

        #region Constructors and destructors
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="DisposableObject"/>
        /// </summary>
        protected internal DisposableObject() { }
        /// <summary>
        /// Освобождает ресурсы, занимаемые данным экземпляром
        /// </summary>
        ~DisposableObject()
        {
            Dispose(false);
        }
        #endregion

        #region Class methods
        /// <summary>
        /// Выполняет действия по освобождению ресурсов, занимаемых объектом
        /// </summary>
        /// <remarks>Данный метод представляет реализацию интерфейса <see cref="IDisposable"/></remarks>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        /// <summary> 
        ///  Dispose(bool disposing) executes in two distinct scenarios.
        ///  If disposing equals true, the method has been called directly
        ///  or indirectly by a user's code. Managed and unmanaged resources
        ///  can be disposed.
        ///  If disposing equals false, the method has been called by the
        ///  runtime from inside the finalizer and you should not reference
        ///  other objects. Only unmanaged resources can be disposed.
        /// </summary>
        ///  <param name="disposing">
        ///  If disposing equals false, the method has been called by the
        ///  runtime from inside the finalizer and you should not reference
        ///  other objects. Only unmanaged resources can be disposed.
        ///  </param>
        private void Dispose(bool disposing)
        {
            if (!IsDisposed)
            {
                IsDisposed = true;
                if (disposing)
                {
                    ReleaseManagedResources();
                }
                DisposeObject();
            }
        }
        /// <summary>
        /// Выполняет освобождение управляемых ресурсов, занимаемых данным экземпляром
        /// </summary>
        protected virtual void ReleaseManagedResources() { }
        /// <summary>
        /// Выполняет освобождение неуправляемых ресурсов, занимаемых данным экземпляром
        /// </summary>
        protected abstract void DisposeObject();
        #endregion
    }
}