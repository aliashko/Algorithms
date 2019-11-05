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

        public static void PrintArray(int[] array)
        {
            Console.WriteLine($"Array[{array.Length}] = [{string.Join(',', array)}]");
        }

        public static void PrintArrayElement(ArrayElement arrayElement)
        {
            Console.WriteLine($"array[{arrayElement.ElementIndex}] = {arrayElement.ElementValue}");
        }
    }
}
