using System;

namespace OpenCV.Core
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TArray"></typeparam>
    public static class EmptyArray<TArray> where TArray : InputArray, new()
    {
        /// <summary>
        /// 
        /// </summary>
        public static TArray Value = new TArray();
    }
}