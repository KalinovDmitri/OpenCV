using System;
using System.Runtime.InteropServices;

namespace OpenCV
{
    using Enumerations;
    using Vectors;

    public static partial class CvInvoke
    {
        #region Image encoding / decoding

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