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
                
                MCvScalar redColor = MCvScalarExtensions.FromColor(Colors.Red);
                MCvScalar greenColor = MCvScalarExtensions.FromColor(Colors.Green);

                using (PresentationImage prImage = new PresentationImage(256, 256))
                {
                    prImage.WritePixels(pixelsArray);
                    
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
                        Point drawPoint = new Point(10, 30 + 30 * index);
                        FontFace drawFace = faces[index];

                        string outputText = Enum.GetName(typeof(FontFace), drawFace);

                        CvInvoke.DrawText(prImage, outputText, drawPoint, drawFace, 1.0D, redColor, 1);
                    });
                    
                    outputData = CvInvoke.Imencode(prImage, ImageEncoding.Jpeg, new int[] { 95 });
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