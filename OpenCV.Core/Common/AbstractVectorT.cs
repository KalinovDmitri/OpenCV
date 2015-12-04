using System;
using System.Runtime.InteropServices;

namespace OpenCV.NonStable
{
    public delegate void VectorCopy(IntPtr vectorPtr, IntPtr destPtr);

    public delegate void VectorGet<T>(IntPtr vectorPtr, int index, ref T value);

    public delegate void VectorPush<T>(IntPtr vectorPtr, ref T item);

    public delegate void VectorPushMulti(IntPtr vectorPtr, IntPtr valuesPtr, int count);

    /// <summary>
    /// Представляет абстрактную управляемую оболочку неуправляемого класса <see cref="T:vector&lt;T&gt;"/>
    /// </summary>
    /// <typeparam name="T">Тип элементов, содержащихся в векторе</typeparam>
    public abstract class AbstractVector<T> : UnmanagedObject
    {
        #region Static members

        protected static readonly Type ArrayType;
        #endregion

        #region Fields

        protected VectorSize GetSize;

        protected VectorGet<T> InternalGet;

        protected VectorCopy DataCopy;

        protected VectorPush<T> InternalPush;

        protected VectorPushMulti InternalPushMulti;

        protected VectorRelease Release;
        #endregion

        #region Properties

        public int Count => GetSize(InnerPointer);

        public T this[int index]
        {
            get
            {
                T result = default(T);
                InternalGet(InnerPointer, index, ref result);
                return result;
            }
            protected internal set
            {

            }
        }
        #endregion

        #region Constructors

        static AbstractVector()
        {
            ArrayType = typeof(T[]);
        }

        protected internal AbstractVector(IntPtr vectorPtr, bool needDispose) : base(needDispose)
        {
            FinalizeCreation();

            InnerPointer = vectorPtr;

        }
        #endregion

        #region Class methods

        public void Push(T value)
        {
            InternalPush(InnerPointer, ref value);
        }

        public void PushMulti(T[] values)
        {
            using (DisposableHandle valuesHandle = DisposableHandle.Alloc(values))
            {
                InternalPushMulti(InnerPointer, valuesHandle, values.Length);
            }
        }

        public T[] ToArray()
        {
            T[] data = new T[Count];

            using (DisposableHandle arrayHandle = DisposableHandle.Alloc(data))
            {
                DataCopy(InnerPointer, arrayHandle);
            }

            return data;
        }

        protected override void DisposeObject()
        {
            if (NeedDispose && InnerPointer != IntPtr.Zero)
            {
                Release(ref InnerPointer);
            }
        }

        protected abstract void FinalizeCreation();
        #endregion
    }
}