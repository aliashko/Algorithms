using Algorithms.Arrays;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace UnitTests.Arrays
{
    [TestClass]
    public class SortArrayTests
    {
        [TestMethod]
        public void MergeSort()
        {
            var random = new Random();
            for (int t = 0; t < 10000; t++)
            {
                var array = CommonArrayFunctions.InitIntArray(random.Next(50, 250), 0, random.Next(50, 250));
                var sortedArray = SortArray.MergeSort(array);

                Assert.IsTrue(IsArraysEqual(sortedArray, array.OrderBy(x => x).ToArray()));
            }
        }

        private bool IsArraysEqual(int[] array1, int[] array2)
        {
            if(array1.Length != array2.Length)
            {
                return false;
            }

            for(int i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
