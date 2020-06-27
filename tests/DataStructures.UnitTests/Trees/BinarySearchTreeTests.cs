using DataStructures.Trees;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructures.UnitTests.Trees
{
    [TestClass]
    public class BinarySearchTreeTests
    {
        private BinarySearchTree<int> sampleBinarySearchTree;
        int[] sampleBSTvalues;

        [TestInitialize]
        public void Setup()
        {
            sampleBinarySearchTree = new BinarySearchTree<int>(10);
            sampleBinarySearchTree.RootNode.SetLeftNode(5);
            sampleBinarySearchTree.RootNode.Left.SetLeftNode(2);
            sampleBinarySearchTree.RootNode.Left.SetRightNode(7);
            sampleBinarySearchTree.RootNode.Left.Right.SetLeftNode(6);
            sampleBinarySearchTree.RootNode.Left.Right.SetRightNode(8);

            sampleBinarySearchTree.RootNode.SetRightNode(20);
            sampleBinarySearchTree.RootNode.Right.SetRightNode(30);
            sampleBinarySearchTree.RootNode.Right.Right.SetLeftNode(25);
            sampleBinarySearchTree.RootNode.Right.Right.SetRightNode(35);

            sampleBSTvalues = new int[] { 35, 25, 30, 20, 8, 6, 7, 2, 5, 10 };
        }

        [TestMethod]
        public void NodeCanBeFoundInBST()
        {
            foreach(var value in sampleBSTvalues)
            {
                Assert.AreEqual(value, sampleBinarySearchTree.SearchNode(value).Value);
            }            
        }

        [TestMethod]
        public void NodeCanBeFoundInBSTIterative()
        {
            foreach (var value in sampleBSTvalues)
            {
                Assert.AreEqual(value, sampleBinarySearchTree.SearchNodeIterative(value).Value);
            }
        }

        [TestMethod]
        public void UnexistingNodeCannotBeFoundInBST()
        {
            foreach (var value in sampleBSTvalues)
            {
                Assert.IsNull(sampleBinarySearchTree.SearchNode(value + 100));
            }
        }

        [TestMethod]
        public void NodesCanBeInsertedInBST()
        {
            var bst = new BinarySearchTree<int>(15);
            foreach (var value in sampleBSTvalues)
            {
                bst.Insert(value);
            }

            Assert.AreEqual(15, bst.RootNode.Value);
            foreach (var value in sampleBSTvalues)
            {
                Assert.AreEqual(value, bst.SearchNode(value).Value);
            }
        }

        [TestMethod]
        public void NodeWithoutChildrenCanBeRemovedFromBST()
        {
            sampleBinarySearchTree.RemoveNode(8);

            var removedNode = sampleBinarySearchTree.SearchNode(8);
            var parentOfRemovedNode = sampleBinarySearchTree.SearchNode(7);

            Assert.IsNull(removedNode);
            Assert.IsNull(parentOfRemovedNode.Right);
            Assert.AreEqual(6, parentOfRemovedNode.Left.Value);
        }

        [TestMethod]
        public void NodeWithOneChildCanBeRemovedFromBST()
        {
            sampleBinarySearchTree.RemoveNode(20);

            var removedNode = sampleBinarySearchTree.SearchNode(20);
            var parentOfRemovedNode = sampleBinarySearchTree.SearchNode(10);

            Assert.IsNull(removedNode);
            Assert.AreEqual(30, parentOfRemovedNode.Right.Value);
            Assert.AreEqual(25, parentOfRemovedNode.Right.Left.Value);
        }

        [TestMethod]
        public void NodeWithTwoChildrenCanBeRemovedFromBST()
        {
            sampleBinarySearchTree.RemoveNode(5);

            var removedNode = sampleBinarySearchTree.SearchNode(5);
            var parentOfRemovedNode = sampleBinarySearchTree.SearchNode(10);

            Assert.IsNull(removedNode);
            Assert.AreEqual(6, parentOfRemovedNode.Left.Value);
            Assert.AreEqual(20, parentOfRemovedNode.Right.Value);
            Assert.AreEqual(2, parentOfRemovedNode.Left.Left.Value);
            Assert.AreEqual(7, parentOfRemovedNode.Left.Right.Value);
            Assert.IsNull(parentOfRemovedNode.Left.Right.Left);
        }

        [TestMethod]
        public void RootNodeCanBeRemovedFromBST()
        {
            sampleBinarySearchTree.RemoveNode(10);

            var removedNode = sampleBinarySearchTree.SearchNode(10);

            Assert.IsNull(removedNode);
            Assert.AreEqual(20, sampleBinarySearchTree.RootNode.Value);
            Assert.AreEqual(5, sampleBinarySearchTree.RootNode.Left.Value);
            Assert.AreEqual(30, sampleBinarySearchTree.RootNode.Right.Value);
        }
    }
}
