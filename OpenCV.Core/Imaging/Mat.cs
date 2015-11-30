﻿using System;

using OpenCV.Enumerations;

namespace OpenCV.Imaging
{
    /// <summary>
    /// Представляет управляемую оболочку для неуправляемого класса cv::Mat
    /// </summary>
    public class Mat : UnmanagedObject, IImage, IInputArray, IInputOutputArray, IOutputArray
    {
        #region Fields and properties
        /// <summary>
        /// 
        /// </summary>
        public Size ImageSize => CvInvoke.cveMatGetSize(InnerPointer);
        /// <summary>
        /// 
        /// </summary>
        public int NumberOfChannels => CvInvoke.cveMatNumberOfChannels(InnerPointer);
        #endregion

        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pointer"></param>
        /// <param name="needDispose"></param>
        private Mat(IntPtr pointer, bool needDispose) : base(needDispose)
        {
            InnerPointer = pointer;
        }
        /// <summary>
        /// 
        /// </summary>
        public Mat() : this(CvInvoke.cveMatCreate(), true) { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        /// <param name="depthType"></param>
        /// <param name="channels"></param>
        public Mat(int rows, int cols, DepthType depthType, int channels) : this()
        {
            Create(rows, cols, depthType, channels);
        }
        #endregion

        #region IImage implementation

        public InputArray GetInputArray()
        {
            IntPtr arrayPtr = CvInvoke.cveInputArrayFromMat(InnerPointer);
            return new InputArray(arrayPtr);
        }

        public OutputArray GetOutputArray()
        {
            IntPtr arrayPtr = CvInvoke.cveOutputArrayFromMat(InnerPointer);
            return new OutputArray(arrayPtr);
        }

        public InputOutputArray GetInputOutputArray()
        {
            IntPtr arrayPtr = CvInvoke.cveInputOutputArrayFromMat(InnerPointer);
            return new InputOutputArray(arrayPtr);
        }
        
        protected override void DisposeObject()
        {
            if (NeedDispose && InnerPointer != IntPtr.Zero)
            {
                CvInvoke.cveMatRelease(ref InnerPointer);
            }
        }
        #endregion

        #region Class methods

        public void Create(int rows, int cols, DepthType depthType, int channels)
        {
            int matType = CvInvoke.MakeType(depthType, channels);
            CvInvoke.cveMatCreateData(InnerPointer, rows, cols, matType);
        }
        #endregion
    }
}