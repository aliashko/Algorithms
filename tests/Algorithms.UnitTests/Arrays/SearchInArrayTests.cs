using Algorithms.Arrays;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests.Arrays
{
    [TestClass]
    public class SearchInArrayTests
    {
        [TestMethod]
        public void TestBinarySearch()
        {
            var random = new Random();
            for (int t = 0; t < 100000; t++)
            {
                var array = CommonArrayFunctions.InitIntArray(random.Next(50, 150), 0, random.Next(50, 150));
                var sortedArray = new int[array.Length];
                array.CopyTo(sortedArray, 0);
                SortArray.SelectionSort(sortedArray);

                for (int t2 = 0; t2 < array.Length; t2++)
                {
                    var result = SearchInArray.BinarySearchRecursive(sortedArray, 0, array.Length, array[t2]);

                    Assert.IsTrue(array[t2] == sortedArray[result]);
                }
            }
        }
    }
}
