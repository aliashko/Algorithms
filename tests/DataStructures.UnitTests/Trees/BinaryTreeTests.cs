using DataStructures.Trees;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructures.UnitTests.Trees
{
    [TestClass]
    public class BinaryTreeTests
    {
        private BinaryTree<int> sampleBinaryTree;

        [TestInitialize]
        public void Setup()
        {
            sampleBinaryTree = new BinaryTree<int>(10);
            sampleBinaryTree.RootNode.SetLeftNode(5);
            sampleBinaryTree.RootNode.Left.SetLeftNode(2);
            sampleBinaryTree.RootNode.Left.SetRightNode(7);
            sampleBinaryTree.RootNode.Left.Right.SetLeftNode(6);
            sampleBinaryTree.RootNode.Left.Right.SetRightNode(8);

            sampleBinaryTree.RootNode.SetRightNode(20);
            sampleBinaryTree.RootNode.Right.SetRightNode(30);
            sampleBinaryTree.RootNode.Right.Right.SetLeftNode(25);
            sampleBinaryTree.RootNode.Right.Right.SetRightNode(35);
        }

        [TestMethod]
        public void PostOrderTraversalReturnsCorrectNodesOrder()
        {
            var nodes = BinaryTree<int>.TraverseTreePostorder(sampleBinaryTree.RootNode);
            CollectionAssert.AreEqual(new int[] { 2,6,8,7,5,25,35,30,20,10 }, nodes);
        }

        [TestMethod]
        public void InorderTraversalReturnsCorrectNodesOrder()
        {
            var nodes = BinaryTree<int>.TraverseTreeInorder(sampleBinaryTree.RootNode);
            CollectionAssert.AreEqual(new int[] { 2,5,6,7,8,10,20,25,30,35 }, nodes);
        }

        [TestMethod]
        public void PreorderTraversalReturnsCorrectNodesOrder()
        {
            var nodes = BinaryTree<int>.TraverseTreePreorder(sampleBinaryTree.RootNode);
            CollectionAssert.AreEqual(new int[] { 10,5,2,7,6,8,20,30,25,35 }, nodes);
        }

        [TestMethod]
        public void LevelOrderTraversalReturnsCorrectNodesOrder()
        {
            var nodes = BinaryTree<int>.TraverseTreeLevelOrder(sampleBinaryTree.RootNode);
            CollectionAssert.AreEqual(new int[] { 10, 5, 20, 2, 7, 30, 6, 8, 25, 35 }, nodes);
        }
    }
}
