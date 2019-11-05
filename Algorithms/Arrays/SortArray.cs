using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Arrays
{
    public static class SortArray
    {
        public static int[] SelectionSort(int[] array)
        {
            var unsortedArray = new int[array.Length];
            array.CopyTo(unsortedArray, 0);

            var sortedArray = new int[unsortedArray.Length];
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

                sortedArray[i] = minValue;
                unsortedArray[minElement] = int.MaxValue;
            }

            return sortedArray;
        }

    }
}
