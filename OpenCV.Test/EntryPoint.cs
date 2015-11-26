using System;

using OpenCV.Core;
using OpenCV.Core.Enumerations;

namespace OpenCV.Test
{
    internal class EntryPoint
    {
        internal static void Main(string[] args)
        {
            IntPtr imagePtr = IntPtr.Zero;
            try
            {
                imagePtr = CvInvoke.cvCreateImageHeader(new Size(256, 256), IplDepth.IplDepth_8U, 4);
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