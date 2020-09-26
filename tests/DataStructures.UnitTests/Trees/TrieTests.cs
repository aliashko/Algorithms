using DataStructures.Trees;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures.UnitTests.Trees
{
    [TestClass]
    public class TrieTests
    {
        private Trie sampleTrie;
        private List<string> sampleKeys = new List<string> {
            "a", "abc", "z", "zoo",
            "trie", "is", "an", "efficient", "information", "retrieval", "data", "structure"
        };

        [TestInitialize]
        public void Setup()
        {
            sampleTrie = new Trie();
            sampleKeys.ForEach(key => sampleTrie.Insert(key));
        }

        [TestMethod]
        public void AddedKeysCanBeFoundInTrie()
        {
            foreach(var key in sampleKeys)
            {
                var node = sampleTrie.FindNodeByKey(key);
                Assert.IsNotNull(node);
                Assert.AreEqual(key.Last(), node.Key);
                Assert.IsTrue(node.IsEndOfWord);
            }
        }

        [TestMethod]
        public void UnknownKeysCannotBeFoundInTrie()
        {
            var unknownKeys = new List<string> { "b", "abd", "informatiom", "ant", "antic", "tri", "retrie" };
            foreach (var key in unknownKeys)
            {
                var node = sampleTrie.FindNodeByKey(key);
                Assert.IsNull(node);
            }
        }

        [TestMethod]
        public void StringKeyCanBeInsertedInTrie()
        {
            var newKeys = new List<string> { "zoom", "antic", "b" };
            foreach (var key in newKeys)
            {
                var node = sampleTrie.Insert(key);
                Assert.IsNotNull(node);
                Assert.AreEqual(key.Last(), node.Key);
                Assert.IsTrue(node.IsEndOfWord);
            }
        }

        [TestMethod]
        public void DuplicatedKeyCannotBeInsertedInTrie()
        {
            foreach (var key in sampleKeys)
            {
                Assert.ThrowsException<ArgumentException>(() => sampleTrie.Insert(key));
            }            
        }

        [TestMethod]
        public void ExistingNodeCanBeRemovedFromTrie()
        {
            foreach (var key in sampleKeys)
            {
                sampleTrie.Remove(key);
                var node = sampleTrie.FindNodeByKey(key);
                Assert.IsNull(node);
            }
        }

        [TestMethod]
        public void NonexistingNodeCannotBeRemovedFromTrie()
        {
            var unknownKeys = new List<string> { "b", "abd", "informatiom", "ant", "antic", "tri", "retrie" };
            foreach (var key in unknownKeys)
            {
                Assert.ThrowsException<ArgumentException>(() => sampleTrie.Remove(key));
            }
        }
    }
}
