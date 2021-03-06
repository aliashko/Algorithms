﻿using Algorithms.Arrays.Models;
using System;

namespace Algorithms.Arrays
{
    public static class SearchInArray
    {
        /// <summary>
        /// time complexity  - O(n)
        /// space complexity - O(1)
        /// </summary>
        public static ArrayElement GetMaxElement(int[] array)
        {
            var maxElementIndex = 0;
            for(var i = 0; i < array.Length; i++)
            {
                if(array[i] > array[maxElementIndex])
                {
                    maxElementIndex = i;
                }
            }

            return new ArrayElement(maxElementIndex, array[maxElementIndex]);
        }

        /// <summary>
        /// time complexity  - O(log(n))
        /// space complexity - O(1)
        /// </summary>
        public static int BinarySearchRecursive(int[] array, int startIndex, int endIndex, int searchNumber)
        {
            var currentIndex = startIndex + ((endIndex - startIndex) / 2);
            if(startIndex == endIndex && array[currentIndex] != searchNumber)
            {
                throw new InvalidOperationException("There is no number in the array");
            }

            if(array[currentIndex] < searchNumber)
            {
                return BinarySearchRecursive(array, currentIndex + 1, endIndex, searchNumber);
            }

            else if (array[currentIndex] > searchNumber)
            {
                return BinarySearchRecursive(array, startIndex, currentIndex - 1, searchNumber);
            }

            return currentIndex;
        }

    }
}
