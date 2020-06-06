using System;

namespace DataStructures.Arrays
{
    public class Queue<T>
    {
        private ArrayList<T> dataArray;

        public Queue()
        {
            dataArray = new ArrayList<T>();
        }

        /// <summary>
        /// O(1)
        /// </summary>
        public void Enqueue(T element)
        {
            dataArray.Add(element);
        }

        /// <summary>
        /// O(1)?
        /// </summary>
        public T Dequeue()
        {
            if(dataArray.GetLength() == 0)
            {
                throw new IndexOutOfRangeException();
            }

            var firstItem = dataArray[0];
            dataArray.Remove(0);

            return firstItem;
        }

        public int Count()
        {
            return dataArray.GetLength();
        }
    }
}
