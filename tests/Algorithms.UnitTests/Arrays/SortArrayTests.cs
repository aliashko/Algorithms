﻿using Algorithms.Arrays;
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
            TestSort((arr) => SortArray.MergeSort(arr, 0, arr.Length - 1));
        }

        [TestMethod]
        public void InsertionSortTest()
        {
            TestSort(SortArray.InsertionSort);
        }

        [TestMethod]
        public void SelectionSortTest()
        {
            TestSort(SortArray.SelectionSort);
        }

        [TestMethod]
        public void QuickSortTest()
        {
            TestSort((arr) => SortArray.QuickSort(arr, 0, arr.Length - 1));
        }

        [TestMethod]
        public void BubbleSortTest()
        {
            TestSort(SortArray.BubbleSort);
        }

        [TestMethod]
        public void ShakerSortTest()
        {
            TestSort(SortArray.ShakerSort);
        }

        [TestMethod]
        public void DutchProblemSortTest()
        {
            var random = new Random();
            for (int i = 0; i < 10000; i++)
            {
                var array = CommonArrayFunctions.InitIntArray(i/100 + 1, 0, 2);
                var sortedArray = new int[array.Length];
                array.CopyTo(sortedArray, 0);

                SortArray.DutchProblemSort(sortedArray);

                Assert.IsTrue(IsArraysEqual(sortedArray, array.OrderBy(x => x).ToArray()));
            }
        }

        [TestMethod]
        public void QuickSelectionSortTest()
        {
            var random = new Random();
            for (int i = 0; i < 10000; i++)
            {
                var array = CommonArrayFunctions.InitIntArray(i / 100 + 1, 0, random.Next(0, i));
                var sortedArray = new int[array.Length];
                array.CopyTo(sortedArray, 0);
                var kIndex = random.Next(0, sortedArray.Length - 1);

                var kValue = SortArray.QuickSelectionSort(sortedArray, kIndex, 0, sortedArray.Length - 1);

                Assert.AreEqual(array.OrderBy(x => x).ElementAt(kIndex), kValue);
            }
        }

        private void TestSort(Action<int[]> sortMethod)
        {
            var random = new Random();
            for (int i = 0; i < 10000; i++)
            {
                var array = CommonArrayFunctions.InitIntArray(i/100+1, 0, random.Next(0, i));
                var sortedArray = new int[array.Length];
                array.CopyTo(sortedArray, 0);

                sortMethod(sortedArray);

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
