using DataStructures.Trees;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructures.UnitTests.Trees
{
    [TestClass]
    public class TreeTests
    {
        private Tree<int> sampleTree;

        [TestInitialize]
        public void Setup()
        {
            sampleTree = new Tree<int>(1000);
            var childNodeL1 = sampleTree.RootNode.AddChild(100);
                var childNodeL2 = childNodeL1.AddChild(10);
                    childNodeL2.AddChild(1);
                    childNodeL2.AddChild(2);
                    childNodeL2.AddChild(3);
                childNodeL2 = childNodeL1.AddChild(20);
                    childNodeL2.AddChild(11);
                    childNodeL2.AddChild(12);
                childNodeL1.AddChild(30);

            childNodeL1 = sampleTree.RootNode.AddChild(200);
                childNodeL1.AddChild(220);
                childNodeL2 = childNodeL1.AddChild(230);
                    childNodeL2.AddChild(231);
                    childNodeL2.AddChild(232);

            sampleTree.RootNode.AddChild(300);

            childNodeL1 = sampleTree.RootNode.AddChild(400);
                childNodeL2 = childNodeL1.AddChild(410);
                    childNodeL2.AddChild(411);
                    childNodeL2.AddChild(412);
        }

        [TestMethod]
        public void PostOrderTraversalReturnsCorrectNodesOrder()
        {
            var nodes = Tree<int>.TraverseTreePostorder(sampleTree.RootNode);
            CollectionAssert.AreEqual(new int[] { 1, 2, 3, 10, 11, 12, 20, 30, 100, 220, 231, 232, 230, 200, 300, 411, 412, 410, 400, 1000 }, nodes);
        }

        [TestMethod]
        public void PreorderTraversalReturnsCorrectNodesOrder()
        {
            var nodes = Tree<int>.TraverseTreePreorder(sampleTree.RootNode);
            CollectionAssert.AreEqual(new int[] { 1000, 100, 10, 1, 2, 3, 20, 11, 12, 30, 200, 220, 230, 231, 232, 300, 400, 410, 411, 412 }, nodes);
        }

        [TestMethod]
        public void LevelOrderTraversalReturnsCorrectNodesOrder()
        {
            var nodes = Tree<int>.TraverseTreeLevelOrder(sampleTree.RootNode);
            CollectionAssert.AreEqual(new int[] { 1000, 100, 200, 300, 400, 10, 20, 30, 220, 230, 410, 1, 2, 3, 11, 12, 231, 232, 411, 412 }, nodes);
        }
    }
}
