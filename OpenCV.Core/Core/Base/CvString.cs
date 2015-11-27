using System;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCV
{
    /// <summary>
    /// Представляет управляемую оболочку класса cv:String. Данный класс поддерживает символы в кодировке UTF-8.
    /// </summary>
    /// <remarks>
    /// В текущей реализации класс представлен как vector&lt;char&gt;
    /// </remarks>
    public class CvString : AbstractVector
    {
        #region Constructors
        /// <summary>
        /// Инициализирует новый пустой экземпляр класса <see cref="CvString"/>
        /// </summary>
        public CvString() : base(cveStringCreate(), true) { }
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="CvString"/> с помощью указанной строки Unicode
        /// </summary>
        /// <param name="str">Объект класса <see cref="string"/>, используемый для инициализации</param>
        public CvString(string str) : base(cvStringCreateFromStr(str), true) { }
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="CvString"/> с помощью указателя на неуправляемую строку
        /// </summary>
        /// <param name="strPointer">Структура <see cref="IntPtr"/>, представляющая указатель на неуправляемую строку</param>
        /// <param name="needDispose">Значение <see cref="bool"/>, определяющее необходимость освобождения занимаемых ресурсов</param>
        internal CvString(IntPtr strPointer, bool needDispose) : base(strPointer, needDispose) { }
        #endregion

        #region Class methods
        /// <summary>
        /// Завершает инициализацию текущего экземпляра вектора
        /// </summary>
        protected override void FinalizeCreation()
        {
            GetSize = new VectorSize(cveStringGetLength);
            Release = new VectorRelease(cveStringRelease);
        }
        /// <summary>
        /// Преобразует данный экземпляр в объект класса <see cref="string"/>
        /// </summary>
        /// <returns>Объект класса <see cref="string"/>, представляющий значение данного экземпляра</returns>
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