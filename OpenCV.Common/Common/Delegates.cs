using System;

namespace OpenCV
{
    /// <summary>
    /// Инкапсулирует метод, возвращающий указатель на массив, представленный вектором, для передачи в неуправляемые функции OpenCV
    /// </summary>
    /// <param name="vectorPtr">Структура <see cref="IntPtr"/>, представляющая указатель на вектор</param>
    /// <returns>Структура <see cref="IntPtr"/>, представляющая указатель на массив</returns>
    public delegate IntPtr VectorArray(IntPtr vectorPtr);

    /// <summary>
    /// Инкапсулирует метод, выполняющий получение адреса первого элемента вектора
    /// </summary>
    /// <param name="vectorPtr">Структура <see cref="IntPtr"/>, представляющая указатель на вектор</param>
    /// <returns>Структура <see cref="IntPtr"/>, представляющая указатель на первый элемент</returns>
    public delegate IntPtr VectorStartAddress(IntPtr vectorPtr);

    /// <summary>
    /// Инкапсулирует метод, выполняющий получение текущего размера вектора
    /// </summary>
    /// <param name="vectorPtr">Структура <see cref="IntPtr"/>, представляющая указатель на вектор</param>
    /// <returns>Значение <see cref="int"/>, представляющее текущий размер вектора</returns>
    public delegate int VectorSize(IntPtr vectorPtr);

    /// <summary>
    /// Инкапсулирует метод, выполняющий очистку вектора
    /// </summary>
    /// <param name="vectorPtr">Структура <see cref="IntPtr"/>, представляющая указатель на вектор</param>
    public delegate void VectorClear(IntPtr vectorPtr);

    /// <summary>
    /// Инкапсулирует метод, выполняющий корректное освобождение ресурсов, занимаемых вектором
    /// </summary>
    /// <param name="vectorPtr">Структура <see cref="IntPtr"/>, представляющая указатель на вектор</param>
    public delegate void VectorRelease(ref IntPtr vectorPtr);
}