using System;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

using OpenCV.Core;
using OpenCV.Core.Enumerations;
using OpenCV.Core.Vectors;

namespace OpenCV.Test
{
    internal class EntryPoint
    {
        [STAThread]
        internal unsafe static void Main(string[] args)
        {
            //IntPtr imagePtr = IntPtr.Zero, dataPtr = IntPtr.Zero;
            try
            {
                int size = CvArray<byte>.ElementSize;

                InputArray array = EmptyArray<InputArray>.Value;

                Console.WriteLine("\tArray element size is {0}", size);

                /*imagePtr = CvInvoke.cvCreateImageHeader(new Size(256, 256), IplDepth.IplDepth_8U, 4);
                dataPtr = CvInvoke.cveMatCreate();

                int matType = (int)((DepthType.Cv8U & (DepthType)7) + (4 - 1 << 3));

                CvInvoke.cveMatCreateData(dataPtr, 256, 256, matType);
                
                CvInvoke.cvSetData(imagePtr, dataPtr, 1024);

                IntPtr arrayPtr = CvInvoke.cveInputArrayFromMat(dataPtr);

                using (InputArray array = new InputArray(arrayPtr))
                {

                }*/
            }
            catch (Exception exc)
            {
                Console.WriteLine("\tCatched exception: {0}\r\n{1}", exc.Message, exc);
            }
            finally
            {
                //CvInvoke.cvReleaseImageHeader(ref imagePtr);

                Console.WriteLine("\tData released succesfully.");
                Console.ReadKey(true);
            }
        }
    }
}