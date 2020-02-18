﻿namespace Algorithms.Arrays
{
    public static class SortArray
    {
        /// <summary>
        /// time complexity  - O(n^2)
        /// space complexity - O(n)
        /// </summary>
        public static void SelectionSort(int[] array)
        {
            var unsortedArray = new int[array.Length];
            array.CopyTo(unsortedArray, 0);

            for(var i = 0; i < unsortedArray.Length; i++)
            {
                var minValue = int.MaxValue;
                var minElement = -1;
                for(var j = 0; j < unsortedArray.Length; j++)
                {
                    if(unsortedArray[j] < minValue)
                    {
                        minValue = unsortedArray[j];
                        minElement = j;
                    }
                }

                array[i] = minValue;
                unsortedArray[minElement] = int.MaxValue;
            }
        }

        /// <summary>
        /// time complexity  - O(n log(n))
        /// space complexity - O(n log(n))
        /// </summary>
        public static void MergeSort(int[] array)
        {
            var array1 = new int[array.Length / 2];
            var array2 = new int[array.Length - array1.Length];
            for (int i = 0; i < array.Length; i++)
            {
                if (i < array1.Length)
                {
                    array1[i] = array[i];
                }
                else
                {
                    array2[i - array1.Length] = array[i];
                }
            }

            MergeSort(array1);
            MergeSort(array2);

            CommonArrayFunctions.ConcatSortedArrays(array, array1, array2);
        }

        /// <summary>
        /// time complexity  - average - O(n^2); best - O(n);
        /// space complexity - O(1)
        /// </summary>
        public static void InsertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++) 
            {    
                var movingElement = array[i];
                var moveToIndex = i - 1;

                while(moveToIndex >= 0 && array[moveToIndex] > movingElement)
                {
                    array[moveToIndex + 1] = array[moveToIndex];
                    moveToIndex--;
                }

                array[moveToIndex + 1] = movingElement;                
            }
        }

        /// <summary>
        /// time complexity  - average - O(n log(n)); best - O(n log(n)); worst - O(n^2)
        /// space complexity - O(n)
        /// </summary>
        public static void QuickSort(int[] array, int fromIndex, int toIndex)
        {
            var subArrayLength = toIndex - fromIndex;
            if (subArrayLength < 1) return;

            var pivotIndex = fromIndex + subArrayLength / 2;
            CommonArrayFunctions.SwapElements(array, pivotIndex, toIndex);

            var swapPointer = fromIndex;
            for(int i = fromIndex; i < toIndex; i++)
            {
                if(array[i] < array[toIndex])
                {
                    CommonArrayFunctions.SwapElements(array, swapPointer, i);
                    swapPointer++;
                }
            }

            CommonArrayFunctions.SwapElements(array, swapPointer, toIndex);

            QuickSort(array, fromIndex, swapPointer-1);
            QuickSort(array, swapPointer+1, toIndex);
        }

    }
}
