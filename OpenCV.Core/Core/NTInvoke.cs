using System;
using System.Runtime.InteropServices;

namespace OpenCV
{
    /// <summary>
    /// Предоставляет точку входа для вызова неуправляемых функций библиотеки ntdll.dll
    /// </summary>
    public static class NTInvoke
    {
        #region Public methods
        /// <summary>
        /// Выполняет копирование блока неуправляемой памяти указанного размера
        /// </summary>
        /// <param name="dst">Структура <see cref="IntPtr"/>, представляющая указатель на область назначения</param>
        /// <param name="src">Структура <see cref="IntPtr"/>, представляющая указатель на область источника</param>
        /// <param name="count">Значение <see cref="int"/>, представляющее количество копируемых байтов</param>
        /// <returns></returns>
        public static IntPtr CopyUnmanagedMemory(IntPtr dst, IntPtr src, int count)
        {
            return InternalCopyUnmanagedMemory(dst, src, count);
        }
        /// <summary>
        /// Выполняет установку блока неуправляемой памяти в указанное значение
        /// </summary>
        /// <param name="dst">Структура <see cref="IntPtr"/>, представляющая указатель на область назначения</param>
        /// <param name="value">Значение <see cref="int"/>, используемое для заполнения области памяти</param>
        /// <param name="count">Значение <see cref="int"/>, представляющее количество устанавливаемых байтов</param>
        /// <returns></returns>
        public static IntPtr SetUnmanagedMemory(IntPtr dst, int value, int count)
        {
            return InternalSetUnmanagedMemory(dst, value, count);
        }
        #endregion

        #region Private methods (unsafe)

        private unsafe static IntPtr InternalCopyUnmanagedMemory(IntPtr dst, IntPtr src, int count)
        {
            byte* internalDst = (byte*)dst.ToPointer();
            byte* internalSrc = (byte*)src.ToPointer();

            memcpy(internalDst, internalSrc, count);

            return dst;
        }

        private unsafe static IntPtr InternalSetUnmanagedMemory(IntPtr dst, int value, int count)
        {
            byte* internalDst = (byte*)dst.ToPointer();

            memset(internalDst, value, count);

            return dst;
        }
        #endregion

        #region Private extern definitions

        private const string ExternLibrary = "ntdll.dll";

        [DllImport(ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        private unsafe static extern byte* memcpy(byte* dst, byte* src, int count);

        [DllImport(ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        private unsafe static extern byte* memset(byte* dst, int value, int count);
        #endregion
    }
}