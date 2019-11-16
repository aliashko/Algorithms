namespace Algorithms.Arrays
{
    public static class SortArray
    {
        /// <summary>
        /// time complexity  - O(n^2)
        /// space complexity - O(n)
        /// </summary>
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

        /// <summary>
        /// time complexity  - O(n log(n))
        /// space complexity - O(n log(n))
        /// </summary>
        public static int[] MergeSort(int[] array)
        {
            if(array.Length == 1)
            {
                return array;
            }

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

            var sortedArray = CommonArrayFunctions.ConcatSortedArrays(MergeSort(array1), MergeSort(array2));
            return sortedArray;
        }

    }
}
