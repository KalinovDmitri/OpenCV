using System;

using OpenCV.Core;
using OpenCV.Core.Enumerations;

namespace OpenCV.Imaging
{
    /// <summary>
    /// Представляет управляемую оболочку для неуправляемого класса cv::Mat
    /// </summary>
    public class Mat : AbstractVector
    {
        #region Constructors

        public Mat() : base(MatInvoke.cveMatCreate(), true) { }

        public Mat(int rows, int cols, DepthType type, int channels) : this()
        {
            Create(rows, cols, type, channels);
        }
        #endregion

        #region Class methods

        public void Create(int rows, int cols, DepthType depth, int channels)
        {
            int matType = CvInvoke.MakeType(depth, channels);
            MatInvoke.cveMatCreateData(InnerPointer, rows, cols, matType);
        }

        protected override void FinalizeCreation()
        {
            Release = new VectorRelease(MatInvoke.cveMatRelease);
        }
        #endregion
    }
}