﻿using Algorithms.Arrays.Models;
using System;

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

        public static void SwapElements(int[] array, int index1, int index2)
        {
            var t = array[index1];
            array[index1] = array[index2];
            array[index2] = t;
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
