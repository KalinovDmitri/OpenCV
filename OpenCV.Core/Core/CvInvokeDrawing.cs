using System;
using System.Runtime.InteropServices;

namespace OpenCV
{
    using Enumerations;

    public static partial class CvInvoke
    {
        #region Public methods

        public static void DrawCircle(IInputOutputArray image,
            Point center,
            int radius,
            MCvScalar color,
            int thickness = 1,
            LineType lineType = LineType.EightConnected,
            int shift = 0)
        {
            using (InputOutputArray array = image.GetInputOutputArray())
            {
                cveCircle(array, ref center, radius, ref color, thickness, lineType, shift);
            }
        }

        public static void DrawContours(IInputOutputArray image,
            IInputArray contours,
            int contourIdx,
            MCvScalar color,
            int thickness = 1,
            LineType lineType = LineType.EightConnected,
            IInputArray hierarchy = null,
            int maxLevel = int.MaxValue,
            Point offset = default(Point))
        {
            using (InputOutputArray imageArray = image.GetInputOutputArray())
            {
                using (InputArray contoursArray = contours.GetInputArray())
                {
                    using (InputArray hierarchyArray = (hierarchy != null) ? hierarchy.GetInputArray() : EmptyArray<InputArray>.Value)
                    {
                        cveDrawContours(imageArray, contoursArray, contourIdx, ref color, thickness, lineType, hierarchyArray, maxLevel, ref offset);
                    }
                }
            }
        }

        public static void DrawEllipse(IInputOutputArray image,
            RotatedRect box,
            MCvScalar color,
            int thickness = 1,
            LineType lineType = LineType.EightConnected,
            int shift = 0)
        {
            int width = (int)Math.Round(box.Size.Height * 0.5F);
            int height = (int)Math.Round(box.Size.Width * 0.5F);
            Size axesSize = new Size(width, height);
            Point center = Point.Round(box.Center);

            DrawEllipse(image, center, axesSize, box.Angle, 0.0D, 360.0D, color, thickness, lineType, shift);
        }

        public static void DrawEllipse(IInputOutputArray image,
            Point center,
            Size axes,
            double angle,
            double startAngle,
            double endAngle,
            MCvScalar color,
            int thickness = 1,
            LineType lineType = LineType.EightConnected,
            int shift = 0)
        {
            using (InputOutputArray array = image.GetInputOutputArray())
            {
                cveEllipse(array, ref center, ref axes, angle, startAngle, endAngle, ref color, thickness, lineType, shift);
            }
        }

        public static void DrawLine(IInputOutputArray image,
            Point start,
            Point end,
            MCvScalar color,
            int thickness = 1,
            LineType lineType = LineType.EightConnected,
            int shift = 0)
        {
            using (InputOutputArray array = image.GetInputOutputArray())
            {
                cveLine(array, ref start, ref end, ref color, thickness, lineType, shift);
            }
        }

        public static void DrawText(IInputOutputArray image,
            string text,
            Point position,
            FontFace fontFace,
            double fontScale,
            MCvScalar color,
            int thickness = 1,
            LineType lineType = LineType.EightConnected,
            bool bottomLeftOrigin = false)
        {
            using (CvString cvString = new CvString(text))
            {
                using (InputOutputArray array = image.GetInputOutputArray())
                {
                    cvePutText(array, cvString, ref position, fontFace, fontScale, ref color, thickness, lineType, bottomLeftOrigin);
                }
            }
        }
        #endregion

        #region PInvoke & private methods

        [DllImport(ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        private static extern void cveCircle(IntPtr imagePtr,
            ref Point center,
            int radius,
            ref MCvScalar color,
            int thickness,
            LineType lineType,
            int shift);

        [DllImport(ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        private static extern void cveEllipse(IntPtr imagePtr,
            ref Point center,
            ref Size axes,
            double angle,
            double startAngle,
            double endAngle,
            ref MCvScalar color,
            int thickness,
            LineType lineType,
            int shift);

        [DllImport(ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        private static extern void cveDrawContours(IntPtr imagePtr,
            IntPtr contourPtr,
            int coutourIdx,
            ref MCvScalar color,
            int thickness,
            LineType lineType,
            IntPtr hierarchy,
            int maxLevel,
            ref Point offset);

        [DllImport(ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        private static extern void cveLine(IntPtr imagePtr,
            ref Point start,
            ref Point end,
            ref MCvScalar color,
            int thickness,
            LineType lineType,
            int shift);

        [DllImport(ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        private static extern void cvePutText(IntPtr imagePtr,
            IntPtr text,
            ref Point position,
            FontFace fontFace,
            double fontScale,
            ref MCvScalar color,
            int thickness,
            LineType lineType,
            [MarshalAs(UnmanagedType.U1)] bool bottomLeftOrigin);
        #endregion
    }
}