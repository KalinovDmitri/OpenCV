using System;
using System.IO;
using System.Windows.Media;

using OpenCV.Imaging;

namespace OpenCV.Test
{
    internal class EntryPoint
    {
        [STAThread]
        internal unsafe static void Main(string[] args)
        {
            try
            {
                using (PresentationImage image = new PresentationImage(256, 256))
                {
                    image.SetPixel(10, 10, Colors.Red);

                    Color pixel = image.GetPixel(10, 10);
                }
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