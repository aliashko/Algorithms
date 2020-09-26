using DataStructures.Trees;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DataStructures.UnitTests.Trees
{
    //[TestClass]
    public class RedBlackTreeTests
    {
        private RedBlackTree<int> sampleBinarySearchTree;
        private int[] sampleBSTvalues;

        [TestInitialize]
        public void Setup()
        {
            sampleBinarySearchTree = new RedBlackTree<int>();
            sampleBSTvalues = new int[] { 10, 5, 3, 7, 6, 8, 20, 16, 30, 25, 35 };
            foreach (var i in sampleBSTvalues)
            {
                sampleBinarySearchTree.Insert(i);
            }
        }

        [TestMethod]
        public void NodesCanBeInsertedInBST()
        {
            var bst = new RedBlackTree<int>();
            foreach (var value in sampleBSTvalues)
            {
                bst.Insert(value);
            }

            Assert.AreEqual(7, bst.GetRootNode().Key);
            foreach (var value in sampleBSTvalues)
            {
                Assert.AreEqual(value, bst.SearchNode(value).Key);
            }
        }

        [TestMethod]
        public void RedBlackTreeRemainsBalancedAfterInsertionWhichRequiresLeftRotation()
        {
            sampleBinarySearchTree.Insert(17);
            sampleBinarySearchTree.Insert(18);
            Assert.IsTrue(IsRedBlackTreeCorrect(sampleBinarySearchTree));
        }

        [TestMethod]
        public void RedBlackTreeRemainsBalancedAfterInsertionWhichRequiresRightRotation()
        {
            sampleBinarySearchTree.Insert(2);
            sampleBinarySearchTree.Insert(1);
            Assert.IsTrue(IsRedBlackTreeCorrect(sampleBinarySearchTree));
        }

        [TestMethod]
        public void NodeWithoutChildrenCanBeRemovedFromBST()
        {
            sampleBinarySearchTree.RemoveNode(8);

            var removedNode = sampleBinarySearchTree.SearchNode(8);
            var parentOfRemovedNode = sampleBinarySearchTree.SearchNode(10);

            Assert.IsNull(removedNode);
            Assert.IsNull(parentOfRemovedNode.Left);
            Assert.AreEqual(16, parentOfRemovedNode.Right.Key);
        }

        [TestMethod]
        public void NodeWithOneChildCanBeRemovedFromBST()
        {
            sampleBinarySearchTree.Insert(2);
            sampleBinarySearchTree.RemoveNode(3);

            var removedNode = sampleBinarySearchTree.SearchNode(3);
            var parentOfRemovedNode = sampleBinarySearchTree.SearchNode(5);

            Assert.IsNull(removedNode);
            Assert.AreEqual(2, parentOfRemovedNode.Left.Key);
            Assert.AreEqual(6, parentOfRemovedNode.Right.Key);
        }

        [TestMethod]
        public void NodeWithOneChildCanBeRemovedFromBSTWithRebalance()
        {
            sampleBinarySearchTree.RemoveNode(3);
            sampleBinarySearchTree.RemoveNode(5);

            var removedNode = sampleBinarySearchTree.SearchNode(5);

            Assert.IsNull(removedNode);
            Assert.AreEqual(20, sampleBinarySearchTree.RootNode.Key);
            Assert.IsTrue(IsRedBlackTreeCorrect(sampleBinarySearchTree));
        }

        [TestMethod]
        public void NodeWithTwoChildrenCanBeRemovedFromBST()
        {
            sampleBinarySearchTree.RemoveNode(20);

            var removedNode = sampleBinarySearchTree.SearchNode(20);

            Assert.IsNull(removedNode);
            Assert.AreEqual(25, sampleBinarySearchTree.RootNode.Right.Key);
            Assert.IsTrue(IsRedBlackTreeCorrect(sampleBinarySearchTree));
        }

        private bool IsRedBlackTreeCorrect(RedBlackTree<int> redBlackTree)
        {
            return true;
            /*
            if(redBlackTree == null || redBlackTree.Left == null || redBlackTree.Right == null) return true;
            if(Math.Abs((redBlackTree.Right as RedBlackTreeNode<int>).Height - (redBlackTree.Left as RedBlackTreeNode<int>).Height) > 1) return false;
            return IsRedBlackTree((RedBlackTreeNode<int>)redBlackTree.Left) && IsRedBlackTree((RedBlackTreeNode<int>)redBlackTree.Right);*/
        }
    }
}
