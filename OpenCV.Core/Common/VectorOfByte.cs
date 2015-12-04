using System;
using System.Runtime.InteropServices;

namespace OpenCV.NonStable
{
    public sealed class VectorOfByte : AbstractVector<byte>
    {
        #region Constructors

        public VectorOfByte() : base(VectorOfByteCreate(), true) { }

        public VectorOfByte(int count) : base(VectorOfByteCreateSize(count), true) { }
        #endregion

        #region Class methods

        protected override void FinalizeCreation()
        {
            InternalPush = VectorOfBytePush;
            InternalPushMulti = VectorOfBytePushMulti;
        }
        #endregion

        #region CvExtern PInvoke import

        [DllImport(CvInvoke.ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr VectorOfByteCreate();

        [DllImport(CvInvoke.ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr VectorOfByteCreateSize(int count);

        [DllImport(CvInvoke.ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void VectorOfBytePush(IntPtr vector, ref byte value);

        [DllImport(CvInvoke.ExternLibrary, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void VectorOfBytePushMulti(IntPtr vector, IntPtr values, int count);
        #endregion
    }
}