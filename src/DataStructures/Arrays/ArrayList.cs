using System;

namespace DataStructures.Arrays
{
    public class ArrayList<T>
    {
        private const int defaultCapacity = 8;

        private T[] data;

        private int currentIndex = 0;

        public ArrayList()
        {
            data = new T[defaultCapacity];
        }

        /// <summary>
        /// O(1)
        /// </summary>
        public void Add(T element)
        {
            if(currentIndex == data.Length)
            {
                ExpandDataArray();
            }

            data[currentIndex] = element;
            currentIndex++;
        }

        public void AddRange(T[] elements)
        {
            if(currentIndex + elements.Length >= data.Length)
            {
                ExpandDataArray(elements.Length);
            }

            for (var i = 0; i < elements.Length; i++)
            {
                data[currentIndex+i] = elements[i];
            }

            currentIndex += elements.Length;
        }

        /// <summary>
        /// O(1)
        /// </summary>
        public void SetValue(int index, T element)
        {
            CheckIfIndexAvailable(index);

            data[index] = element;
        }

        /// <summary>
        /// O(1)
        /// </summary>
        public T ElementAt(int index)
        {
            CheckIfIndexAvailable(index);

            return data[index];
        }

        /// <summary>
        /// O(n)
        /// </summary>
        public void Remove(int index)
        {
            CheckIfIndexAvailable(index);

            for(var i = index; i < data.Length - 1; i++)
            {
                data[i] = data[i + 1];
            }

            data[data.Length - 1] = default;
            currentIndex--;
        }

        public int GetLength()
        {
            return currentIndex;
        }

        private void CheckIfIndexAvailable(int index)
        {
            if (index >= currentIndex || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
        }

        private void ExpandDataArray(int? minimumCapacityToAdd = null)
        {
            var newCapacity = data.Length * 2;
            if(newCapacity < data.Length + minimumCapacityToAdd)
            {
                newCapacity += minimumCapacityToAdd.Value;
            }

            var expandedData = new T[newCapacity];

            // This place can be optimized by using standard method. It uses memcpy analog and much faster
            // data.CopyTo(expandedData, 0);
            for (var i = 0; i < data.Length; i ++)
            {
                expandedData[i] = data[i];
            }
            
            data = expandedData;
        }

        public T[] ToArray()
        {
            var array = new T[currentIndex];
            for (var i = 0; i < currentIndex; i++)
            {
                array[i] = data[i];
            }

            return array;
        }

        public T this[int key]
        {
            get => ElementAt(key);
            set => SetValue(key, value);
        }
    }
}
