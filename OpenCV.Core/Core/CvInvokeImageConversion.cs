using System;
using System.Runtime.InteropServices;

namespace OpenCV
{
    using Enumerations;
    using Vectors;

    public static partial class CvInvoke
    {
        #region Image encoding / decoding
        /// <summary>
        /// Выполняет кодирование указанного изображения в целевой формат и возвращает результат в виде массива байтов
        /// </summary>
        /// <param name="image">Кодируемое изображение</param>
        /// <param name="encoding">Значение перечисления <see cref="ImageEncoding"/>, определяющее целевой формат</param>
        /// <param name="parameters">Необязательные параметры кодирования</param>
        /// <returns>Массив <see cref="byte"/>, представляющий кодированное изображение</returns>
        public static byte[] Imencode(IInputArray image, ImageEncoding encoding = ImageEncoding.Jpeg, params int[] parameters)
        {
            byte[] result = null;

            string destEncoding = GetEncoding(ref encoding);

            using (VectorOfByte buffer = new VectorOfByte())
            {
                Imencode(destEncoding, image, buffer, parameters);

                result = buffer.ToArray();
            }

            return result;
        }

        /// <summary>
        /// Выполняет кодирование указанного изображения в целевой формат
        /// </summary>
        /// <param name="image">Кодируемое изображение</param>
        /// <param name="buffer">Буфер, в который выполняется сохранение</param>
        /// <param name="encoding">Значение перечисления <see cref="ImageEncoding"/>, определяющее целевой формат</param>
        /// <param name="parameters">Необязательные параметры кодирования</param>
        public static void Imencode(IInputArray image, VectorOfByte buffer, ImageEncoding encoding = ImageEncoding.Jpeg, params int[] parameters)
        {
            string destEncoding = GetEncoding(ref encoding);
            Imencode(destEncoding, image, buffer, parameters);
        }

        private static void Imencode(string extension, IInputArray image, VectorOfByte buffer, params int[] parameters)
        {
            using (CvString cvString = new CvString(extension))
            {
                using (VectorOfInt intVector = new VectorOfInt())
                {
                    if (parameters != null && parameters.Length > 0)
                    {
                        intVector.Push(parameters);
                    }
                    using (InputArray array = image.GetInputArray())
                    {
                        cveImencode(cvString, array, buffer, intVector);
                    }
                }
            }
        }

        private static string GetEncoding(ref ImageEncoding destEncoding)
        {
            string result = null;

            switch (destEncoding)
            {
                case ImageEncoding.Default:
                case ImageEncoding.Jpeg:
                    result = ".jpg"; break;
                case ImageEncoding.Bmp:
                    result = ".bmp"; break;
                default:
                    throw new ArgumentOutOfRangeException("destEncoding");
            }

            return result;
        }

        [DllImport(ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cveImencode(IntPtr ext, IntPtr image, IntPtr buffer, IntPtr parameters);
        #endregion
    }
}