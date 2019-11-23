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
        }

        private void CheckIfIndexAvailable(int index)
        {
            if (index > currentIndex || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
        }

        private void ExpandDataArray()
        {
            var expandedData = new T[data.Length * 2];

            // This place can be optimized by using standard method. It uses memcpy analog and much faster
            // data.CopyTo(expandedData, 0);
            for (var i = 0; i < data.Length; i ++)
            {
                expandedData[i] = data[i];
            }
            
            data = expandedData;
        }

        public T this[int key]
        {
            get => ElementAt(key);
            set => SetValue(key, value);
        }
    }
}
