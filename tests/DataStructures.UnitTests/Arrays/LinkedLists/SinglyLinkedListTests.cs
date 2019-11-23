using DataStructures.Arrays.LinkedLists;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace DataStructures.UnitTests.Arrays.LinkedLists
{
    [TestClass]
    public class SinglyLinkedListTests
    {
        [TestMethod]
        public void LinkedListCanStoreChainOfElements()
        {
            var linkedList = new SinglyLinkedList<string>();
            var expectedString = new StringBuilder();

            for (int i = 1; i<10; i++)
            {
                linkedList.AddToTail(i.ToString());
                expectedString.Append(i.ToString());
            }

            var actualString = new StringBuilder();
            for (var node = linkedList.GetHeadNode(); node != null; node = node.GetNextNode())
            {
                actualString.Append(node.Data);
            }

            Assert.AreEqual(expectedString.ToString(), actualString.ToString());
        }
    }
}
