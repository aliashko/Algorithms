namespace Algorithms.Arrays
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
        /// space complexity - O(n log(n))
        /// </summary>
        public static void QuickSort(int[] array, int? endIndex = null)
        {
            if (endIndex == null) endIndex = array.Length;

            if (endIndex < 2)
            {
                return;
            }

            var pivot = array[endIndex.Value / 2];
            int[] left = new int[endIndex.Value];
            int leftLength = 0;
            int[] center = new int[endIndex.Value];
            int centerLength = 0;
            int[] right = new int[endIndex.Value];
            int rightLength = 0;

            for (int i = 0; i < endIndex; i++)
            {
                if (array[i] < pivot)
                {
                    left[leftLength] = array[i];
                    leftLength++;
                }
                else if (array[i] > pivot)
                {
                    right[rightLength] = array[i];
                    rightLength++;
                }
                else
                {
                    center[centerLength] = array[i];
                    centerLength++;
                }
            }

            QuickSort(left, leftLength);
            QuickSort(right, rightLength);

            for(int i=0; i< endIndex; i++)
            {
                if (i < leftLength)
                {
                    array[i] = left[i];
                }
                else if (i < leftLength + centerLength)
                {
                    array[i] = center[i-leftLength];
                }
                else
                {
                    array[i] = right[i - leftLength - centerLength];
                }
            }
        }
    }
}
