using System;

namespace OpenCV.Core
{
    /// <summary>
    /// Представляет статический класс для инициализации пустых массивов при передаче ссылки null в неуправляемые функции OpenCV
    /// </summary>
    /// <typeparam name="TArray">Тип инициализируемого массива</typeparam>
    public static class EmptyArray<TArray> where TArray : InputArray, new()
    {
        /// <summary>
        /// Представляет пустой массив соответствующего типа. Это поле доступно только для чтения.
        /// </summary>
        public static readonly TArray Value = new TArray();
    }
}