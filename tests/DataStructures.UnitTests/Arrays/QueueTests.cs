using DataStructures.Arrays;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructures.UnitTests.Arrays.Queues
{
    [TestClass]
    public class QueueTests
    {
        [TestMethod]
        [DynamicData(nameof(GetTestCases), DynamicDataSourceType.Method)]
        public void QueueCanCorrectlyReturnFirstPushedItems(QueueFacade<int> queue)
        {
            for (int i = 0; i < 100; i++)
            {
                queue.Enqueue(i);
            }

            for (int i = 0; i < 100; i++)
            {
                var element = queue.Dequeue();
                Assert.AreEqual(i, element);
            }
        }

        [TestMethod]
        [DynamicData(nameof(GetTestCases), DynamicDataSourceType.Method)]
        public void QueueCanCorrectlyEnquedAlongWithDequeing(QueueFacade<int> queue)
        {
            for (int i = 0; i < 100; i++)
            {
                queue.Enqueue(i);
            }

            for (int i = 0; i < 30; i++)
            {
                var element = queue.Dequeue();
                Assert.AreEqual(i, element);
            }

            for (int i = 100; i < 200; i++)
            {
                queue.Enqueue(i);
            }

            for (int i = 30; i < 200; i++)
            {
                var element = queue.Dequeue();
                Assert.AreEqual(i, element);
            }
        }

        // This is not optimal testing approach for this specific case
        // Because we will not know what exact implementation failed
        // But I'll leave it here as example of using Dynamic Data Rows in MSTest
        public static System.Collections.Generic.IEnumerable<object[]> GetTestCases()
        {
            yield return new object[] { new QueueFacade<int>(new Queue<int>()) };
            yield return new object[] { new QueueFacade<int>(new FastQueue<int>()) };
        }
    }

    public class QueueFacade<TType>
    {
        private object _queue;

        public QueueFacade(object queue)
        {
            _queue = queue;
        }

        public void Enqueue(TType element)
        {
            switch (_queue)
            {
                case Queue<TType> queueImplementation:
                    queueImplementation.Enqueue(element);
                    break;
                case FastQueue<TType> queueImplementation:
                    queueImplementation.Enqueue(element);
                    break;
            }
        }

        public TType Dequeue()
        {
            switch (_queue)
            {
                case Queue<TType> queueImplementation:
                    return queueImplementation.Dequeue();
                case FastQueue<TType> queueImplementation:
                    return queueImplementation.Dequeue();
                default:
                    return default;
            }
        }
    }
}
