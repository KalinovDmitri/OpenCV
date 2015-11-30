using System;
using System.Windows.Media;

namespace OpenCV.Imaging
{
    public static class MCvScalarExtensions
    {
        public static MCvScalar FromColor(Color color)
        {
            return new MCvScalar(color.B, color.G, color.R, color.A);
        }
    }
}