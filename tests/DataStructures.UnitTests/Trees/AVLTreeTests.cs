using DataStructures.Trees;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DataStructures.UnitTests.Trees
{
    [TestClass]
    public class AVLTreeTests
    {
        private AVLTree<int> sampleBinarySearchTree;
        private int[] sampleBSTvalues;

        [TestInitialize]
        public void Setup()
        {
            sampleBinarySearchTree = new AVLTree<int>();
            sampleBSTvalues = new int[] { 10, 5, 3, 7, 6, 8, 20, 16, 30, 25, 35 };
            foreach (var i in sampleBSTvalues)
            {
                sampleBinarySearchTree.Insert(i);
            }
        }

        [TestMethod]
        public void NodesCanBeInsertedInBST()
        {
            var bst = new AVLTree<int>();
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
        public void AVLTreeRemainsBalancedAfterInsertionWhichRequiresLeftRotation()
        {
            sampleBinarySearchTree.Insert(17);
            sampleBinarySearchTree.Insert(18);
            Assert.IsTrue(IsTreeBalanced((AVLTreeNode<int>)sampleBinarySearchTree.GetRootNode()));
        }

        [TestMethod]
        public void AVLTreeRemainsBalancedAfterInsertionWhichRequiresRightRotation()
        {
            sampleBinarySearchTree.Insert(2);
            sampleBinarySearchTree.Insert(1);
            Assert.IsTrue(IsTreeBalanced((AVLTreeNode<int>)sampleBinarySearchTree.GetRootNode()));
        }

        private bool IsTreeBalanced(AVLTreeNode<int> alvTreeNode)
        {
            if(alvTreeNode == null || alvTreeNode.Left == null || alvTreeNode.Right == null) return true;
            if(Math.Abs((alvTreeNode.Right as AVLTreeNode<int>).Height - (alvTreeNode.Left as AVLTreeNode<int>).Height) > 1) return false;
            return IsTreeBalanced((AVLTreeNode<int>)alvTreeNode.Left) && IsTreeBalanced((AVLTreeNode<int>)alvTreeNode.Right);
        }
    }
}
