using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace OpenCV.Vectors
{
    /// <summary>
    /// Представляет управляемую оболочку класса <see cref="T:vector&lt;int&gt;"/>
    /// </summary>
    [Serializable, DebuggerTypeProxy(typeof(DebuggerProxy))]
    public class VectorOfInt : AbstractVector
    {
        #region Properties
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public int this[int index]
        {
            get
            {
                int result = 0;
                VectorOfIntGetItem(InnerPointer, index, ref result);
                return result;
            }
            set
            {
                unsafe
                {
                    IntPtr dataPtr = StartAddress;
                    int* dstPtr = (int*)dataPtr;
                    dstPtr += index;
                    *dstPtr = value;
                }
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="VectorOfInt"/> с нулевым размером
        /// </summary>
        public VectorOfInt() : base(VectorOfIntCreate(), true) { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        public VectorOfInt(int size) : base(VectorOfIntCreateSize(size), true) { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="values"></param>
        public VectorOfInt(int[] values) : this()
        {
            Push(values);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public VectorOfInt(SerializationInfo info, StreamingContext context) : this()
        {
            int[] values = info.GetValue("IntArray", typeof(int[])) as int[];
            Push(values);
        }
        #endregion

        #region Class methods

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            int[] array = ToArray();
            info.AddValue("IntArray", array);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="values"></param>
        public void Push(int[] values)
        {
            if (values != null && values.Length > 0)
            {
                using (DisposableHandle valueHandle = DisposableHandle.Alloc(values))
                {
                    VectorOfIntPushMulti(InnerPointer, valueHandle, values.Length);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int[] ToArray()
        {
            int[] outputArray = new int[Count];
            if (outputArray.Length > 0)
            {
                using (DisposableHandle arrayHandle = DisposableHandle.Alloc(outputArray))
                {
                    VectorOfIntCopyData(InnerPointer, arrayHandle);
                }
            }
            return outputArray;
        }
        /// <summary>
        /// Завершает инициализацию текущего экземпляра вектора
        /// </summary>
        protected override void FinalizeCreation()
        {
            GetAsInputArray = new VectorArray(cvInputArrayFromVectorOfInt);
            GetAsInputOutputArray = new VectorArray(cvInputOutputArrayFromVectorOfInt);
            GetAsOutputArray = new VectorArray(cvOutputArrayFromVectorOfInt);
            GetSize = new VectorSize(VectorOfIntGetSize);
            GetStartAddress = new VectorStartAddress(VectorOfIntGetStartAddress);
            ClearData = new VectorClear(VectorOfIntClear);
            Release = new VectorRelease(VectorOfIntRelease);
        }
        #endregion

        #region CvExtern PInvoke importing

        [DllImport(CvInvoke.ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvInputArrayFromVectorOfInt(IntPtr vector);

        [DllImport(CvInvoke.ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvOutputArrayFromVectorOfInt(IntPtr vector);

        [DllImport(CvInvoke.ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvInputOutputArrayFromVectorOfInt(IntPtr vector);

        [DllImport(CvInvoke.ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr VectorOfIntCreate();

        [DllImport(CvInvoke.ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr VectorOfIntCreateSize(int size);

        [DllImport(CvInvoke.ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int VectorOfIntGetSize(IntPtr vector);

        [DllImport(CvInvoke.ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void VectorOfIntCopyData(IntPtr vector, IntPtr data);

        [DllImport(CvInvoke.ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr VectorOfIntGetStartAddress(IntPtr vector);

        [DllImport(CvInvoke.ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void VectorOfIntPushMulti(IntPtr vector, IntPtr values, int count);

        [DllImport(CvInvoke.ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void VectorOfIntClear(IntPtr vector);

        [DllImport(CvInvoke.ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void VectorOfIntGetItem(IntPtr vector, int index, ref int element);

        [DllImport(CvInvoke.ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void VectorOfIntRelease(ref IntPtr vector);
        #endregion

        #region Nested types

        internal class DebuggerProxy
        {
            private VectorOfInt SourceVector;

            public int[] Values => SourceVector.ToArray();

            public DebuggerProxy(VectorOfInt vector)
            {
                SourceVector = vector;
            }
        }
        #endregion
    }
}