using DataStructures.Trees;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures.UnitTests.Trees
{
    // [TestClass]
    public class TernarySearchTreeTests
    {
        private TernarySearchTree sampleTree;
        private List<string> sampleKeys = new List<string> {
            "a", "abc", "z", "zoo", "zoopark", "zoobarn", "zooshop",
            "trie", "is", "an", "efficient", "information", "retrieval", "data", "structure"
        };

        [TestInitialize]
        public void Setup()
        {
            sampleTree = new TernarySearchTree();
            sampleKeys.ForEach(key => sampleTree.Insert(key));
        }

        [TestMethod]
        public void AddedKeysCanBeFoundInTree()
        {
            foreach(var key in sampleKeys)
            {
                var node = sampleTree.FindNodeByKey(key);
                Assert.IsNotNull(node);
                Assert.AreEqual(key.Last(), node.Key);
                Assert.IsTrue(node.IsEndOfWord);
            }
        }

        [TestMethod]
        public void UnknownKeysCannotBeFoundInTree()
        {
            var unknownKeys = new List<string> { "b", "abd", "informatiom", "ant", "antic", "tri", "retrie" };
            foreach (var key in unknownKeys)
            {
                var node = sampleTree.FindNodeByKey(key);
                Assert.IsNull(node);
            }
        }

        [TestMethod]
        public void StringKeyCanBeInsertedInTree()
        {
            var newKeys = new List<string> { "zoom", "antic", "b" };
            foreach (var key in newKeys)
            {
                var node = sampleTree.Insert(key);
                Assert.IsNotNull(node);
                Assert.AreEqual(key.Last(), node.Key);
                Assert.IsTrue(node.IsEndOfWord);
            }
        }

        [TestMethod]
        public void DuplicatedKeyCannotBeInsertedInTree()
        {
            foreach (var key in sampleKeys)
            {
                Assert.ThrowsException<ArgumentException>(() => sampleTree.Insert(key));
            }            
        }

        [TestMethod]
        public void ExistingNodeCanBeRemovedFromTree()
        {
            foreach (var key in sampleKeys)
            {
                sampleTree.Remove(key);
                var node = sampleTree.FindNodeByKey(key);
                Assert.IsNull(node);
            }

            Assert.IsNull(sampleTree.RootNode.LeftNode);
            Assert.IsNull(sampleTree.RootNode.RightNode);
            Assert.IsNull(sampleTree.RootNode.EqualNode);
        }

        [TestMethod]
        public void NonexistingNodeCannotBeRemovedFromTree()
        {
            var unknownKeys = new List<string> { "b", "abd", "informatiom", "ant", "antic", "tri", "retrie" };
            foreach (var key in unknownKeys)
            {
                Assert.ThrowsException<ArgumentException>(() => sampleTree.Remove(key));
            }
        }
    }
}
