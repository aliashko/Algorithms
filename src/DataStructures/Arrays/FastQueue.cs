using System;

namespace DataStructures.Arrays
{
    /// <summary>
    /// Used microsoft implementation with circular array
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class FastQueue<T>
    {
        private T[] dataArray;
        private int _head = 0;
        private int _tail = 0;
        private int _count = 0;
        private int _capacity;

        public FastQueue()
        {
            _capacity = 32;
            dataArray = new T[_capacity];
        }

        /// <summary>
        /// O(n)
        /// </summary>
        public void Enqueue(T element)
        {
            if(_count == _capacity - 1)
            {
                ExtendDataArray();
            }

            dataArray[_tail] = element;
            _tail = (_tail + 1) % _capacity;
            _count++;
        }

        /// <summary>
        /// O(1)
        /// </summary>
        public T Dequeue()
        {
            if(_count == 0)
            {
                throw new IndexOutOfRangeException();
            }

            var firstItem = dataArray[_head];
            dataArray[_head] = default;
            _head = (_head + 1) % _capacity;
            _count--;
            return firstItem;
        }

        public int Count => _count;

        private void ExtendDataArray()
        {
            var newCapacity = _capacity * 2;
            var expandedDataArray = new T[newCapacity];

            Array.Copy(dataArray, _head, expandedDataArray, newCapacity - _capacity + _head, _capacity - _head);
            if (_tail < _head)
            {
                Array.Copy(dataArray, 0, expandedDataArray,  0, _tail);
            }
            else
            {
                _tail += newCapacity - _capacity;
            }
            _head += newCapacity - _capacity;

            dataArray = expandedDataArray;
            _capacity = newCapacity;
        }
    }
}
