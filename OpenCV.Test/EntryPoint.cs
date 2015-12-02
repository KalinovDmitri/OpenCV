using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

using OpenCV.Enumerations;
using OpenCV.Imaging;
using OpenCV.Vectors;

namespace OpenCV.Test
{
    internal class EntryPoint
    {
        [STAThread]
        internal unsafe static void Main(string[] args)
        {
            try
            {
                int pixelsCount = 1 << 18;
                uint[] pixelsArray = new uint[65536];

                using (DisposableHandle handle = DisposableHandle.Alloc(pixelsArray))
                {
                    NTInvoke.SetUnmanagedMemory(handle, 255, pixelsCount);
                }

                byte[] outputData = null;

                string outputText = "Output text";
                MCvScalar color = MCvScalarExtensions.FromColor(Colors.Red);

                using (PresentationImage prImage = new PresentationImage(256, 256))
                {
                    prImage.WritePixels(pixelsArray);

                    /*CvInvoke.DrawLine(prImage, new Point(10, 10), new Point(80, 95), color, 1);

                    RotatedRect ellipse = new RotatedRect(new PointF(100.0F, 100.0F), new SizeF(40.0F, 80.0F), 315.0F);

                    CvInvoke.DrawEllipse(prImage, ellipse, color);*/

                    FontFace[] faces = new FontFace[]
                    {
                        FontFace.HersheyComplex,
                        FontFace.HersheyComplexSmall,
                        FontFace.HersheyDuplex,
                        FontFace.HersheyPlain,
                        FontFace.HersheyScriptComplex,
                        FontFace.HersheyScriptSimplex,
                        FontFace.HersheySimplex,
                        FontFace.HersheyTriplex
                    };

                    Parallel.For(0, 8, (int index) =>
                    {
                        Point drawPoint = new Point(10, 10 + 30 * index);
                        FontFace drawFace = faces[index];
                        CvInvoke.DrawText(prImage, outputText, drawPoint, drawFace, 1.0D, color, 1);
                    });

                    using (VectorOfByte buffer = new VectorOfByte())
                    {
                        CvInvoke.Imencode(prImage, buffer, ImageEncoding.Jpeg, new int[] { 95 });

                        outputData = buffer.ToArray();
                    }
                }

                if (outputData != null && outputData.Length > 0)
                {
                    using (MemoryStream dataStream = new MemoryStream(outputData))
                    {
                        JpegBitmapDecoder decoder = new JpegBitmapDecoder(dataStream, BitmapCreateOptions.DelayCreation, BitmapCacheOption.OnLoad);
                        BitmapFrame frame = decoder.Frames[0];

                        Window imageWindow = new Window()
                        {
                            Height = 300.0D,
                            Width = 500.0D,
                            Title = "Image window",
                            ResizeMode = ResizeMode.CanResize,
                            WindowStartupLocation = WindowStartupLocation.CenterScreen
                        };
                        imageWindow.Content = new Image()
                        {
                            Source = frame
                        };
                        new Application().Run(imageWindow);
                    }
                }
            }
            catch (Exception exc)
            {
                Debug.WriteLine("\tCatched exception: {0}\r\n{1}", exc.Message, exc);
            }
            finally
            {
                Debug.WriteLine("\tData released succesfully.");
            }
        }
    }
}