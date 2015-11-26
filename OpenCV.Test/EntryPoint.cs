using System;
using System.Runtime.InteropServices;

using OpenCV.Core;
using OpenCV.Core.Enumerations;
using OpenCV.Core.Structures;

namespace OpenCV.Test
{
    internal class EntryPoint
    {
        internal static void Main(string[] args)
        {
            IntPtr imagePtr = IntPtr.Zero, dataPtr = IntPtr.Zero;
            try
            {
                int step = 0; Size imageSize = new Size(256, 256);

                imagePtr = CvInvoke.cvCreateImageHeader(imageSize, IplDepth.IplDepth_8U, 4);

                dataPtr = CvInvoke.cvCreateMat(256, 256, DepthType.Cv8U);

                CvInvoke.cvSetData(imagePtr, dataPtr, 1024);

                Size rawSize;

                IntPtr rawDataPtr;

                CvInvoke.cvGetRawData(imagePtr, out rawDataPtr, out step, out rawSize);
                
                Console.WriteLine("\tImage ptr = {0}, data ptr = {1}, step = {2}, size = {3}", imagePtr, dataPtr, step, rawSize);
            }
            catch (Exception exc)
            {
                Console.WriteLine("\tCatched exception: {0}\r\n{1}", exc.Message, exc);
            }
            finally
            {
                CvInvoke.cvReleaseImageHeader(ref imagePtr);
                Console.ReadKey(true);
            }
        }
    }
}