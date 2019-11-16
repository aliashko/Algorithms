using Algorithms.Arrays.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Arrays
{
    public static class CommonArrayFunctions
    {
        public static int[] InitIntArray(int capacity, int minValue, int maxValue)
        {
            int[] array = new int[capacity];
            Random rand = new Random();

            for (var i = 0; i < capacity; i++)
            {
                array[i] = rand.Next(minValue, maxValue);
            }

            return array;
        }

        public static int[] ConcatSortedArrays(int[] array1, int[] array2)
        {
            var mergedArray = new int[array1.Length + array2.Length];
            var array1index = 0;
            var array2index = 0;

            for (int i = 0; i < array1.Length + array2.Length; i++)
            {
                if (array2index >= array2.Length || (array1index < array1.Length && array1[array1index] < array2[array2index]))
                {
                    mergedArray[i] = array1[array1index];
                    array1index++;
                }
                else
                {
                    mergedArray[i] = array2[array2index];
                    array2index++;
                }
            }

            return mergedArray;
        }

        #region Output functions
        public static void PrintArray(int[] array)
        {
            Console.WriteLine($"Array[{array.Length}] = [{string.Join(',', array)}]");
        }

        public static void PrintArrayElement(ArrayElement arrayElement)
        {
            Console.WriteLine($"array[{arrayElement.ElementIndex}] = {arrayElement.ElementValue}");
        }
        #endregion
    }
}
