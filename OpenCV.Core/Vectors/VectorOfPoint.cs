using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace OpenCV.Vectors
{
    /// <summary>
    /// Представляет управляемую оболочку класса <see cref="T:vector&lt;Point&gt;"/>
    /// </summary>
    [Serializable, DebuggerTypeProxy(typeof(DebuggerProxy))]
    public class VectorOfPoint : AbstractVector
    {
        #region Properties
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Point this[int index]
        {
            get
            {
                Point result = default(Point);
                VectorOfPointGetItem(InnerPointer, index, ref result);
                return result;
            }
            set
            {
                unsafe
                {
                    IntPtr dataPtr = StartAddress;
                    Point* dstPtr = (Point*)dataPtr;
                    dstPtr += index;
                    *dstPtr = value;
                }
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        public VectorOfPoint() : base(VectorOfPointCreate(), true) { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        public VectorOfPoint(int size) : base(VectorOfPointCreateSize(size), true) { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="values"></param>
        public VectorOfPoint(Point[] values) : this()
        {
            Push(values);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public VectorOfPoint(SerializationInfo info, StreamingContext context) : this()
        {
            Point[] values = info.GetValue("PointArray", typeof(Point[])) as Point[];
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
            Point[] array = ToArray();
            info.AddValue("PointArray", array);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void Push(Point value)
        {
            VectorOfPointPush(InnerPointer, ref value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="values"></param>
        public void Push(Point[] values)
        {
            if (values != null && values.Length > 0)
            {
                using (DisposableHandle valueHandle = DisposableHandle.Alloc(values))
                {
                    VectorOfPointPushMulti(InnerPointer, valueHandle, values.Length);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Point[] ToArray()
        {
            Point[] pointsArray = new Point[Count];
            using (DisposableHandle arrayHandle = DisposableHandle.Alloc(pointsArray))
            {
                VectorOfPointCopyData(InnerPointer, arrayHandle);
            }
            return pointsArray;
        }
        /// <summary>
        /// Завершает инициализацию текущего экземпляра вектора
        /// </summary>
        protected override void FinalizeCreation()
        {
            GetAsInputArray = new VectorArray(cvInputArrayFromVectorOfPoint);
            GetAsInputOutputArray = new VectorArray(cvInputOutputArrayFromVectorOfPoint);
            GetAsOutputArray = new VectorArray(cvOutputArrayFromVectorOfPoint);
            GetSize = new VectorSize(VectorOfPointGetSize);
            GetStartAddress = new VectorStartAddress(VectorOfPointGetStartAddress);
            ClearData = new VectorClear(VectorOfPointClear);
            Release = new VectorRelease(VectorOfPointRelease);
        }
        #endregion

        #region CvExtern PInvoke importing

        [DllImport(CvInvoke.ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvInputArrayFromVectorOfPoint(IntPtr vector);

        [DllImport(CvInvoke.ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvOutputArrayFromVectorOfPoint(IntPtr vector);

        [DllImport(CvInvoke.ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cvInputOutputArrayFromVectorOfPoint(IntPtr vector);

        [DllImport(CvInvoke.ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr VectorOfPointCreate();

        [DllImport(CvInvoke.ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr VectorOfPointCreateSize(int size);

        [DllImport(CvInvoke.ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void VectorOfPointCopyData(IntPtr vector, IntPtr data);

        [DllImport(CvInvoke.ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int VectorOfPointGetSize(IntPtr vector);

        [DllImport(CvInvoke.ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr VectorOfPointGetStartAddress(IntPtr vector);

        [DllImport(CvInvoke.ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void VectorOfPointPush(IntPtr vector, ref Point value);

        [DllImport(CvInvoke.ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void VectorOfPointPushMulti(IntPtr vector, IntPtr values, int count);

        [DllImport(CvInvoke.ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void VectorOfPointClear(IntPtr vector);

        [DllImport(CvInvoke.ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void VectorOfPointRelease(ref IntPtr vector);

        [DllImport(CvInvoke.ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void VectorOfPointGetItem(IntPtr vector, int index, ref Point element);
        #endregion

        #region Nested types

        internal class DebuggerProxy
        {
            private VectorOfPoint SourceVector;

            public Point[] Values => SourceVector.ToArray();

            public DebuggerProxy(VectorOfPoint vector)
            {
                SourceVector = vector;
            }
        }
        #endregion
    }
}