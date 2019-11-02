using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Arrays
{
    public static class SortArray
    {
        public static void SelectionSort()
        {
            var array = CommonFunctions.InitIntArray(100, 0, 100);

            var sortedArray = new int[array.Length];
            for(var i = 0; i < array.Length; i++)
            {
                var minValue = int.MaxValue;
                var minElement = -1;
                for(var j = 0; j < array.Length; j++)
                {
                    if(array[j] < minValue)
                    {
                        minValue = array[j];
                        minElement = j;
                    }
                }

                sortedArray[i] = minValue;
                array[minElement] = int.MaxValue;
            }

            CommonFunctions.PrintArray(sortedArray);
        }

    }
}
