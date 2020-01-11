using DataStructures.Arrays;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructures.UnitTests.Arrays.LinkedLists
{
    [TestClass]
    public class StackTests
    {
        [TestMethod]
        public void StackCanCorrectlyReturnLastPushedItems()
        {
            var stack = new Stack<int>();

            for (int i = 0; i < 100; i++)
            {
                stack.Push(i);
            }

            for (int i = 99; i >= 0; i--)
            {
                var element = stack.Pop();
                Assert.AreEqual(i, element);
            }
        }
    }
}
