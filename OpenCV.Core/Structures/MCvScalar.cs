using System;

namespace OpenCV
{
    /// <summary>
    /// Представляет управляемый эквивалент структуры CvScalar
    /// </summary>
    public struct MCvScalar : IEquatable<MCvScalar>
    {
        #region Fields
        /// <summary>
        /// Значение V0
        /// </summary>
        public double V0;
        /// <summary>
        /// Значение V1
        /// </summary>
        public double V1;
        /// <summary>
        /// Значение V2
        /// </summary>
        public double V2;
        /// <summary>
        /// Значение V3
        /// </summary>
        public double V3;
        #endregion

        #region Constructors

        public MCvScalar(double value0)
        {
            this = default(MCvScalar);
            V0 = value0;
        }

        public MCvScalar(double value0, double value1)
        {
            this = default(MCvScalar);
            V0 = value0; V1 = value1;
        }

        public MCvScalar(double value0, double value1, double value2)
        {
            V0 = value0; V1 = value1; V2 = value2; V3 = 0.0D;
        }

        public MCvScalar(double value0, double value1, double value2, double value3)
        {
            V0 = value0; V1 = value1; V2 = value2; V3 = value3;
        }
        #endregion

        #region Methods

        public bool Equals(MCvScalar other)
        {
            return (V0 == other.V0) && (V1 == other.V1) && (V2 == other.V2) && (V3 == other.V3);
        }

        public double[] ToArray()
        {
            return new double[] { V0, V1, V2, V3  };
        }
        #endregion
    }
}