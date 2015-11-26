using System;
using System.Runtime.InteropServices;

namespace OpenCV.Core
{
    using Vectors;

    public static partial class CvInvoke
    {
        #region Image encoding / decoding

        public static void Imencode(string extension, IInputArray image, VectorOfByte buffer, params int[] parameters)
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

        [DllImport(ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void cveImencode(IntPtr ext, IntPtr image, IntPtr buffer, IntPtr parameters);
        #endregion
    }
}