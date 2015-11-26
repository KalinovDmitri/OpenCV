using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace OpenCV.Core.Vectors
{
    /// <summary>
    /// Представляет вектор типа int
    /// </summary>
    public class VectorOfInt : AbstractVector
    {
        #region Constructors
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="VectorOfInt"/> с нулевым размером
        /// </summary>
        public VectorOfInt() : base(VectorOfIntCreate(), true) { }
        #endregion

        #region Class methods

        public void Push(int[] values)
        {
            if (values != null && values.Length > 0)
            {
                GCHandle valueHandle = GCHandle.Alloc(values, GCHandleType.Pinned);
                VectorOfIntPushMulti(InnerPointer, valueHandle.AddrOfPinnedObject(), values.Length);
                valueHandle.Free();
            }
        }
        /// <summary>
        /// Завершает инициализацию текущего экземпляра вектора
        /// </summary>
        protected override void FinalizeCreation()
        {
            GetSize = new VectorSize(VectorOfIntGetSize);
            GetStartAddress = new VectorStartAddress(VectorOfIntGetStartAddress);
            ClearData = new VectorClear(VectorOfIntClear);
            Release = new VectorRelease(VectorOfIntRelease);
        }
        #endregion

        #region CvExtern PInvoke importing

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
        internal static extern IntPtr cvInputArrayFromVectorOfInt(IntPtr vector);

        [DllImport(CvInvoke.ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvOutputArrayFromVectorOfInt(IntPtr vector);

        [DllImport(CvInvoke.ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvInputOutputArrayFromVectorOfInt(IntPtr vector);

        [DllImport(CvInvoke.ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void VectorOfIntRelease(ref IntPtr vector);
        #endregion
    }
}