using DataStructures.Trees;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures.UnitTests.Trees
{
    [TestClass]
    public class MinBinaryHeapTests
    {
        private MinBinaryHeap<int> sampleBinaryHeap;

        [TestInitialize]
        public void Setup()
        {
            sampleBinaryHeap = new MinBinaryHeap<int>();
            sampleBinaryHeap.Insert(5);
            sampleBinaryHeap.Insert(2);
            sampleBinaryHeap.Insert(7);
            sampleBinaryHeap.Insert(6);
            sampleBinaryHeap.Insert(8);
            sampleBinaryHeap.Insert(20);
            sampleBinaryHeap.Insert(30);
            sampleBinaryHeap.Insert(25);
            sampleBinaryHeap.Insert(35);
            sampleBinaryHeap.Insert(1);
            sampleBinaryHeap.Insert(3);
            sampleBinaryHeap.Insert(4);
            sampleBinaryHeap.Insert(9);
        }

        [TestMethod]
        public void MinimalNodeCanBeReturned()
        {
            var minNode = sampleBinaryHeap.GetMinKeyOrDefault();
            Assert.AreEqual(minNode, 1);
        }

        [TestMethod]
        public void DefaultIsReturnedAsMinimalNodeIfHeapIsEmpty()
        {
            var binaryHeap = new MinBinaryHeap<int>();
            var minNode = binaryHeap.GetMinKeyOrDefault();
            Assert.AreEqual(minNode, default(int));
        }

        [TestMethod]
        public void MinimalNodeCanBeExtracted()
        {
            var heapInitialLength = sampleBinaryHeap.GetLength();
            var minNode = sampleBinaryHeap.PopMinKey();
            var minNodeAfterExtraction = sampleBinaryHeap.GetMinKeyOrDefault();

            Assert.AreEqual(minNode, 1);
            Assert.AreEqual(minNodeAfterExtraction, 2);
            Assert.AreEqual(heapInitialLength, sampleBinaryHeap.GetLength() + 1);
        }

        [TestMethod]
        public void AllMinimalNodesAreExtractedInAscendingOrder()
        {
            var minNodes = new List<int>();

            for(var i = 0; i < sampleBinaryHeap.GetLength(); i++)
            {
                var minNode = sampleBinaryHeap.PopMinKey();
                minNodes.Add(minNode);
            }

            Assert.IsTrue(minNodes.SequenceEqual(minNodes.OrderBy(x=>x)));
        }
    }
}
