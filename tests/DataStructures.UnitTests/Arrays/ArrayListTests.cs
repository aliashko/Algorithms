using DataStructures.Arrays;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace DataStructures.UnitTests.Arrays.LinkedLists
{
    [TestClass]
    public class ArrayListTests
    {
        private ArrayList<int> arrayList;

        [TestInitialize]
        public void Setup()
        {
            arrayList = new ArrayList<int>();

            for (int i = 0; i < 100; i++)
            {
                arrayList.Add(i);
            }
        }

        [TestMethod]
        public void ElementsCanBeAddedToArrayList()
        {
            for (int i = 0; i < 100; i++)
            {
                Assert.AreEqual(i, arrayList[i]);
                Assert.AreEqual(i, arrayList.ElementAt(i));
            }            
        }

        [TestMethod]
        public void ElementValueCanBeSet()
        {
            arrayList.SetValue(0, 1000);
            arrayList.SetValue(50, 1001);
            arrayList.SetValue(99, 1002);

            Assert.AreEqual(arrayList[0], 1000);
            Assert.AreEqual(arrayList[50], 1001);
            Assert.AreEqual(arrayList[99], 1002);
            Assert.AreEqual(arrayList[70], 70);
        }

        [TestMethod]
        public void ElementCanBeRemovedFromList()
        {
            arrayList.Remove(50);

            Assert.AreEqual(arrayList[0], 0);
            Assert.AreEqual(arrayList[49], 49);
            Assert.AreEqual(arrayList[50], 51);
            Assert.AreEqual(arrayList[99], default);
        }
    }
}
