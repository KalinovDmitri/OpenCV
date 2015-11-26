using System;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCV.Core
{
    /// <summary>
    /// Представляет управляемую оболочку класса cv:String. Данный класс поддерживает символы в кодировке UTF-8.
    /// </summary>
    public class CvString : AbstractVector
    {
        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        public CvString() : base(cveStringCreate(), true) { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        public CvString(string str) : base(cvStringCreateFromStr(str), true) { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strPointer"></param>
        /// <param name="needDispose"></param>
        internal CvString(IntPtr strPointer, bool needDispose) : base(strPointer, needDispose) { }
        #endregion

        #region Class methods
        /// <summary>
        /// 
        /// </summary>
        protected override void FinalizeCreation()
        {
            GetSize = new VectorSize(cveStringGetLength);
            Release = new VectorRelease(cveStringRelease);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            IntPtr destPtr = IntPtr.Zero; int count = 0;
            cveStringGetCStr(InnerPointer, ref destPtr, ref count);

            byte[] array = new byte[count];
            Marshal.Copy(destPtr, array, 0, count);
            return Encoding.UTF8.GetString(array);
        }
        #endregion

        #region CvExtern PInvoke importing

        [DllImport(CvInvoke.ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cveStringCreate();

        internal static IntPtr cvStringCreateFromStr(string source)
        {
            byte[] array = Encoding.UTF8.GetBytes(source);
            Array.Resize(ref array, array.Length + 1);
            //array[array.Length - 1] = 0;

            GCHandle arrayHandle = GCHandle.Alloc(array, GCHandleType.Pinned);
            IntPtr result = cveStringCreateFromStr(arrayHandle.AddrOfPinnedObject());
            arrayHandle.Free();
            return result;
        }

        [DllImport(CvInvoke.ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr cveStringCreateFromStr(IntPtr strPtr);

        [DllImport(CvInvoke.ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cveStringGetCStr(IntPtr strPtr, ref IntPtr cStr, ref int size);

        [DllImport(CvInvoke.ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int cveStringGetLength(IntPtr strPtr);

        [DllImport(CvInvoke.ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cveStringRelease(ref IntPtr strPtr);
        #endregion
    }
}