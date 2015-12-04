using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace OpenCV.Vectors
{
    /// <summary>
    /// Представляет управляемую оболочку класса <see cref="T:vector&lt;uchar&gt;"/> (byte)
    /// </summary>
    [Serializable, DebuggerTypeProxy(typeof(DebuggerProxy))]
    public class VectorOfByte : AbstractVector
    {
        #region Fields and properties
        /// <summary>
        /// Возвращает значение по указанному индексу
        /// </summary>
        /// <param name="index">Значение <see cref="int"/>, представляющее индекс элемента</param>
        public byte this[int index]
        {
            get
            {
                byte result = 0;
                VectorOfByteGetItem(InnerPointer, index, ref result);
                return result;
            }
            set
            {
                unsafe
                {
                    IntPtr dataPtr = StartAddress;
                    byte* dstPtr = (byte*)dataPtr;
                    dstPtr += index;
                    *dstPtr = value;
                }
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="VectorOfByte"/> с нулевым размером
        /// </summary>
        public VectorOfByte() : base(VectorOfByteCreate(), true) { }
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="VectorOfByte"/> с указанным начальным размером
        /// </summary>
        /// <param name="size"></param>
        public VectorOfByte(int size) : base(VectorOfByteCreateSize(size), true) { }
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="VectorOfByte"/> указанным массивом значений
        /// </summary>
        /// <param name="values">Массив значений <see cref="byte"/>, помещаемый в вектор</param>
        public VectorOfByte(byte[] values) : this()
        {
            Push(values);
        }
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="VectorOfByte"/>, используя указанные данные сериализации в качестве источника данных
        /// </summary>
        /// <param name="info">Объект <see cref="SerializationInfo"/>, представляющий данные сериализации</param>
        /// <param name="context">Структура <see cref="StreamingContext"/>, представляющая контекст сериализации</param>
        public VectorOfByte(SerializationInfo info, StreamingContext context) : this()
        {
            byte[] values = info.GetValue("ByteArray", typeof(byte[])) as byte[];
            Push(values);
        }
        #endregion

        #region Class methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            byte[] array = ToArray();
            info.AddValue("ByteArray", array);
        }
        /// <summary>
        /// Копирует указанный массив байтов в конец вектора
        /// </summary>
        /// <param name="values">Массив структур <see cref="byte"/>, копируемый в вектор</param>
        public void Push(byte[] values)
        {
            if (values != null && values.Length > 0)
            {
                using (DisposableHandle valueHandle = DisposableHandle.Alloc(values))
                {
                    VectorOfBytePushMulti(InnerPointer, valueHandle, values.Length);
                }
            }
        }
        /// <summary>
        /// Преобразует вектор в массив байтов
        /// </summary>
        /// <returns>Массив структур <see cref="byte"/></returns>
        public byte[] ToArray()
        {
            byte[] outputArray = new byte[Count];
            if (outputArray.Length > 0)
            {
                using (DisposableHandle arrayHandle = DisposableHandle.Alloc(outputArray))
                {
                    VectorOfByteCopyData(InnerPointer, arrayHandle);
                }
            }
            return outputArray;
        }
        /// <summary>
        /// Завершает инициализацию текущего экземпляра вектора
        /// </summary>
        protected override void FinalizeCreation()
        {
            GetAsInputArray = new VectorArray(cvInputArrayFromVectorOfByte);
            GetAsOutputArray = new VectorArray(cvOutputArrayFromVectorOfByte);
            GetAsInputOutputArray = new VectorArray(cvInputOutputArrayFromVectorOfByte);
            GetSize = new VectorSize(VectorOfByteGetSize);
            GetStartAddress = new VectorStartAddress(VectorOfByteGetStartAddress);
            ClearData = new VectorClear(VectorOfByteClear);
            Release = new VectorRelease(VectorOfByteRelease);
        }
        #endregion

        #region CvExtern PInvoke importing

        [DllImport(CvInvoke.ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvInputArrayFromVectorOfByte(IntPtr vector);

        [DllImport(CvInvoke.ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvOutputArrayFromVectorOfByte(IntPtr vector);

        [DllImport(CvInvoke.ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvInputOutputArrayFromVectorOfByte(IntPtr vector);

        [DllImport(CvInvoke.ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr VectorOfByteCreate();

        [DllImport(CvInvoke.ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr VectorOfByteCreateSize(int size);

        [DllImport(CvInvoke.ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void VectorOfByteGetItem(IntPtr vector, int index, ref byte element);

        [DllImport(CvInvoke.ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int VectorOfByteGetSize(IntPtr vector);

        [DllImport(CvInvoke.ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr VectorOfByteGetStartAddress(IntPtr vector);

        [DllImport(CvInvoke.ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void VectorOfBytePush(IntPtr vector, ref byte value);

        [DllImport(CvInvoke.ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void VectorOfBytePushMulti(IntPtr vector, IntPtr values, int count);

        [DllImport(CvInvoke.ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void VectorOfByteCopyData(IntPtr vector, IntPtr array);

        [DllImport(CvInvoke.ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void VectorOfByteClear(IntPtr vector);

        [DllImport(CvInvoke.ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void VectorOfByteRelease(ref IntPtr vector);
        #endregion

        #region Nested types

        internal class DebuggerProxy
        {
            private VectorOfByte SourceVector;
            public byte[] Values => SourceVector.ToArray();
            public DebuggerProxy(VectorOfByte vector)
            {
                SourceVector = vector;
            }
        }
        #endregion
    }
}