using DataStructures.Trees;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructures.UnitTests.Trees
{
    [TestClass]
    public class BinarySearchTreeTests
    {
        protected BinarySearchTree<int> sampleBinarySearchTree;
        protected int[] sampleBSTvalues;

        [TestInitialize]
        public void Setup()
        {
            sampleBinarySearchTree = new BinarySearchTree<int>(10);
            sampleBinarySearchTree.GetRootNode().AddLeftNode(5);
            sampleBinarySearchTree.GetRootNode().Left.AddLeftNode(2);
            sampleBinarySearchTree.GetRootNode().Left.AddRightNode(7);
            sampleBinarySearchTree.GetRootNode().Left.Right.AddLeftNode(6);
            sampleBinarySearchTree.GetRootNode().Left.Right.AddRightNode(8);

            sampleBinarySearchTree.GetRootNode().AddRightNode(20);
            sampleBinarySearchTree.GetRootNode().Right.AddRightNode(30);
            sampleBinarySearchTree.GetRootNode().Right.Right.AddLeftNode(25);
            sampleBinarySearchTree.GetRootNode().Right.Right.AddRightNode(35);

            sampleBSTvalues = new int[] { 35, 25, 30, 20, 8, 6, 7, 2, 5, 10 };
        }

        [TestMethod]
        public void NodeCanBeFoundInBST()
        {
            foreach(var value in sampleBSTvalues)
            {
                Assert.AreEqual(value, sampleBinarySearchTree.SearchNode(value).Key);
            }            
        }

        [TestMethod]
        public void NodeCanBeFoundInBSTIterative()
        {
            foreach (var value in sampleBSTvalues)
            {
                Assert.AreEqual(value, sampleBinarySearchTree.SearchNodeIterative(value).Key);
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

            Assert.AreEqual(15, bst.GetRootNode().Key);
            foreach (var value in sampleBSTvalues)
            {
                Assert.AreEqual(value, bst.SearchNode(value).Key);
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
            Assert.AreEqual(6, parentOfRemovedNode.Left.Key);
        }

        [TestMethod]
        public void NodeWithOneChildCanBeRemovedFromBST()
        {
            sampleBinarySearchTree.RemoveNode(20);

            var removedNode = sampleBinarySearchTree.SearchNode(20);
            var parentOfRemovedNode = sampleBinarySearchTree.SearchNode(10);

            Assert.IsNull(removedNode);
            Assert.AreEqual(30, parentOfRemovedNode.Right.Key);
            Assert.AreEqual(25, parentOfRemovedNode.Right.Left.Key);
        }

        [TestMethod]
        public void NodeWithTwoChildrenCanBeRemovedFromBST()
        {
            sampleBinarySearchTree.RemoveNode(5);

            var removedNode = sampleBinarySearchTree.SearchNode(5);
            var parentOfRemovedNode = sampleBinarySearchTree.SearchNode(10);

            Assert.IsNull(removedNode);
            Assert.AreEqual(6, parentOfRemovedNode.Left.Key);
            Assert.AreEqual(20, parentOfRemovedNode.Right.Key);
            Assert.AreEqual(2, parentOfRemovedNode.Left.Left.Key);
            Assert.AreEqual(7, parentOfRemovedNode.Left.Right.Key);
            Assert.IsNull(parentOfRemovedNode.Left.Right.Left);
        }

        [TestMethod]
        public void RootNodeCanBeRemovedFromBST()
        {
            sampleBinarySearchTree.RemoveNode(10);

            var removedNode = sampleBinarySearchTree.SearchNode(10);

            Assert.IsNull(removedNode);
            Assert.AreEqual(20, sampleBinarySearchTree.GetRootNode().Key);
            Assert.AreEqual(5, sampleBinarySearchTree.GetRootNode().Left.Key);
            Assert.AreEqual(30, sampleBinarySearchTree.GetRootNode().Right.Key);
        }
    }
}
