using Algorithms.Arrays;
using Algorithms.MathOperations;
using System;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            TestBinarySearch();
            Console.ReadLine();
        }

        static void TestBinarySearch()
        {
            var random = new Random();
            for(int t = 0; t < 100000; t++)
            {
                var array = CommonArrayFunctions.InitIntArray(random.Next(50,150), 0, random.Next(50, 150));
                var sortedArray = SortArray.SelectionSort(array);

                for (int t2 = 0; t2 < array.Length; t2++)
                {
                    var result = SearchInArray.BinarySearchRecursive(sortedArray, 0, array.Length, array[t2]);

                    if (array[t2] != sortedArray[result])
                    {
                        throw new Exception("Incorrect calculation");
                    }
                }
            }
            Console.WriteLine("Test done");
        }
    }
}
