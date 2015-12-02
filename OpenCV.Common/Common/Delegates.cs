using System;

namespace OpenCV
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="vectorPtr"></param>
    /// <returns></returns>
    public delegate IntPtr VectorArray(IntPtr vectorPtr);
    /// <summary>
    /// Инкапсулирует метод, выполняющий получение начального адреса текущего экземпляра неуправляемого вектора
    /// </summary>
    /// <param name="vectorPtr">Структура <see cref="IntPtr"/>, представляющая указатель на вектор</param>
    /// <returns></returns>
    public delegate IntPtr VectorStartAddress(IntPtr vectorPtr);
    /// <summary>
    /// Инкапсулирует метод, выполняющий получение текущего размера неуправляемого вектора
    /// </summary>
    /// <param name="vectorPtr">Структура <see cref="IntPtr"/>, представляющая указатель на вектор</param>
    /// <returns>Значение <see cref="int"/>, представляющее текущий размер вектора</returns>
    public delegate int VectorSize(IntPtr vectorPtr);
    /// <summary>
    /// Инкапсулирует метод, выполняющий очистку неуправляемого вектора
    /// </summary>
    /// <param name="vectorPtr">Структура <see cref="IntPtr"/>, представляющая указатель на вектор</param>
    public delegate void VectorClear(IntPtr vectorPtr);
    /// <summary>
    /// Инкапсулирует метод, выполняющий корректное освобождение ресурсов, занимаемых неуправляемым вектором
    /// </summary>
    /// <param name="vectorPtr">Структура <see cref="IntPtr"/>, представляющая указатель на вектор</param>
    public delegate void VectorRelease(ref IntPtr vectorPtr);
}