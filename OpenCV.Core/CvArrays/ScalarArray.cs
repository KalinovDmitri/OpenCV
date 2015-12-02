using System;
using System.Runtime.InteropServices;

namespace OpenCV
{
    /// <summary>
    /// Предоставляет реализацию интерфейса <see cref="IInputArray"/> для преобразования структуры в <see cref="IInputArray"/>
    /// </summary>
    public sealed class ScalarArray : UnmanagedObject, IInputArray
    {
        #region Operator overloading
        /// <summary>
        /// Выполняет неявное преобразование указанной структуры <see cref="MCvScalar"/> в скалярный массив <see cref="ScalarArray"/>
        /// </summary>
        /// <param name="scalar">Инициализированный экземпляр <see cref="ScalarArray"/></param>
        public static implicit operator ScalarArray(MCvScalar scalar)
        {
            return new ScalarArray(scalar);
        }
        /// <summary>
        /// Выполняет неявное преобразование указанного значения <see cref="double"/> в скалярный массив <see cref="ScalarArray"/>
        /// </summary>
        /// <param name="scalar">Инициализированный экземпляр <see cref="ScalarArray"/></param>
        public static implicit operator ScalarArray(double scalar)
        {
            return new ScalarArray(scalar);
        }
        #endregion

        #region Fields
        /// <summary>
        /// Представляет тип данного экземпляра скалярного массива
        /// </summary>
        private readonly ArrayType Type;
        #endregion

        #region Constructors
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="ScalarArray"/> с указанием его типа
        /// </summary>
        /// <param name="arrayType">Значение перечисления <see cref="ArrayType"/>, определяющая тип скалярного массива</param>
        private ScalarArray(ArrayType arrayType) : base(true)
        {
            if (arrayType < ArrayType.Scalar || arrayType > ArrayType.Double)
            {
                throw new ArgumentOutOfRangeException("arrayType");
            }

            Type = arrayType;
        }
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="ScalarArray"/> на основе структуры <see cref="MCvScalar"/>
        /// </summary>
        /// <param name="scalar">Структура <see cref="MCvScalar"/>, используемая для инициализации</param>
        public ScalarArray(MCvScalar scalar) : this(ArrayType.Scalar)
        {
            InnerPointer = CvInvoke.cveScalarCreate(ref scalar);
        }
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="ScalarArray"/> на основе значения <see cref="double"/>
        /// </summary>
        /// <param name="scalar">Значение <see cref="double"/>, используемое для инициализации</param>
        public ScalarArray(double scalar) : this(ArrayType.Double)
        {
            InnerPointer = Marshal.AllocHGlobal(8);

            Marshal.Copy(new double[] { scalar }, 0, InnerPointer, 1);
        }
        #endregion

        #region Class methods
        /// <summary>
        /// Возвращает экземпляр класса <see cref="InputArray"/> для передачи в неуправляемые функции OpenCV
        /// </summary>
        /// <returns>Экземпляр класса <see cref="InputArray"/></returns>
        InputArray IInputArray.GetInputArray()
        {
            IntPtr arrayPtr = IntPtr.Zero;

            switch (Type)
            {
                case ArrayType.Scalar:
                    arrayPtr = CvInvoke.cveInputArrayFromScalar(InnerPointer);
                    break;
                case ArrayType.Double:
                    arrayPtr = CvInvoke.cveInputArrayFromDouble(InnerPointer);
                    break;
                default: break;
            }

            return new InputArray(arrayPtr);
        }
        /// <summary>
        /// Выполняет действия по освобождению неуправляемых ресурсов
        /// </summary>
        protected override void DisposeObject()
        {
            if (NeedDispose && InnerPointer != IntPtr.Zero)
            {
                if (Type == ArrayType.Scalar)
                {
                    CvInvoke.cveScalarRelease(ref InnerPointer);
                }
                else if (Type == ArrayType.Double)
                {
                    Marshal.FreeHGlobal(InnerPointer);
                    InnerPointer = IntPtr.Zero;
                }
            }
        }
        #endregion

        #region Nested types
        /// <summary>
        /// Определяет перечислимые константы, представляющие допустимые типы скалярного массива
        /// </summary>
        private enum ArrayType
        {
            Scalar,
            Double
        }
        #endregion
    }
}