using System;
using System.Runtime.InteropServices;

using OpenCV.Core;
using OpenCV.Core.Enumerations;
using OpenCV.Core.Structures;
using OpenCV.Core.Vectors;

namespace OpenCV.Test
{
    internal class EntryPoint
    {
        internal unsafe static void Main(string[] args)
        {
            IntPtr imagePtr = IntPtr.Zero, dataPtr = IntPtr.Zero;
            try
            {
                /*imagePtr = CvInvoke.cvCreateImageHeader(new Size(256, 256), IplDepth.IplDepth_8U, 4);
                dataPtr = CvInvoke.cvCreateMat(256, 256, DepthType.Cv8U);

                CvInvoke.cvSetData(imagePtr, dataPtr, 1024);

                NTInvoke.SetUnmanagedMemory(dataPtr, 0, 262144);*/

                using (CvString @obj = new CvString(".bmp"))
                {
                    Console.WriteLine(@obj.ToString());
                }

                /*using (CvString wrapper = new CvString())
                {
                    Console.WriteLine(wrapper.ToString());
                }*/
            }
            catch (Exception exc)
            {
                Console.WriteLine("\tCatched exception: {0}\r\n{1}", exc.Message, exc);
            }
            finally
            {
                /*CvInvoke.cvReleaseMat(ref dataPtr);
                CvInvoke.cvReleaseImageHeader(ref imagePtr);*/

                Console.WriteLine("\tData released succesfully.");
                Console.ReadKey(true);
            }
        }
    }
}