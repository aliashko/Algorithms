using DataStructures.Arrays.HashTables;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DataStructures.UnitTests.Arrays.HashTables
{
    [TestClass]
    public class SimpleHashTableTests
    {
        private SimpleHashTable<string, int> HashTable;

        [TestInitialize]
        public void Setup()
        {
            HashTable = new SimpleHashTable<string, int>();

            for (int i = 100; i < 1000; i++)
            {
                HashTable.AddItem($"item{i}", i);
            }
        }

        [TestMethod]
        public void ItemsCanBeAddedToHashTable()
        {
            for (int i = 100; i < 1000; i++)
            {
                var item = HashTable.GetItemOrDefault($"item{i}");
                Assert.AreEqual(i, item);
            }
        }

        [TestMethod]
        public void ItemsCanBeRemovedFromHashTable()
        {
            for (int i = 100; i < 1000; i++)
            {
                HashTable.RemoveItem($"item{i}");
                for (int j = 100; j < 1000; j++)
                {
                    var item = HashTable.GetItemOrDefault($"item{j}");

                    if (j <= i)
                    {
                        Assert.AreEqual(default, item);
                    }
                    else
                    {
                        Assert.AreEqual(j, item);
                    }
                }
            }
        }

        [TestMethod]
        public void DuplicatedKeysCannotBeAddedToHashTable()
        {
            Assert.ThrowsException<ArgumentException>(()=> HashTable.AddItem("item100", 100));
            Assert.ThrowsException<ArgumentException>(()=> HashTable.AddItem("item999", 1000));
        }
    }
}
