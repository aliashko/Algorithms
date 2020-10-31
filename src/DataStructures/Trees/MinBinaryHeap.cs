using DataStructures.Arrays;
using System;

namespace DataStructures.Trees
{
    /// <summary>
    /// Binary heap is a complete binary tree (but left elements can be added to the last level) where root is bigger (smaller) then children
    /// Used for heap sort, priority queues, Graph Algorithms
    /// Complexity: get min (max) element - O(1), insert, delete, pop - O(logn)
    /// Can be represented as array
    /// </summary>
    public class MinBinaryHeap<T>
        where T : IComparable
    {
        public MinBinaryHeap() {
            _heapArray = new ArrayList<T>();
        }

        private ArrayList<T> _heapArray;

        public int GetLength() => _heapArray.GetLength();

        public void Insert(T key)
        {
            // Firstly insert the new key at the end  
            int i = _heapArray.GetLength();
            _heapArray.Add(key);

            // Fix the min heap property if it is violated  
            while (i != 0 && _heapArray[i].CompareTo(_heapArray[GetParentIndex(i)]) < 0)
            {
                SwapHeapElements(i, GetParentIndex(i));
                i = GetParentIndex(i);
            }
        }

        public T GetMinKeyOrDefault()
        {
            if(_heapArray.GetLength() == 0) return default;
            return _heapArray[0];
        }

        public T PopMinKey()
        {
            if (_heapArray.GetLength() == 0)
            {
                throw new Exception("There is no elements in the heap");
            }

            // Store the minimum value, and remove it from heap  
            var root = _heapArray[0];

            _heapArray[0] = _heapArray[_heapArray.GetLength() - 1];
            _heapArray.Remove(_heapArray.GetLength() - 1);
            MinHeapify(0);

            return root;
        }

        /*
        public void DeleteByKeyIndex(int keyIndex)
        {
            _heapArray[keyIndex] = int.MinValue;

            while (keyIndex != 0 && _heapArray[keyIndex].CompareTo(_heapArray[GetParentIndex(keyIndex)]) < 0)
            {
                SwapHeapElements(keyIndex, GetParentIndex(keyIndex));
                keyIndex = GetParentIndex(keyIndex);
            }

            PopMinKey();
        }*/

        private int GetParentIndex(int keyIndex)
        {
            return (keyIndex - 1) / 2;
        }

        private int GetLeftChildIndex(int keyIndex)
        {
            return 2 * keyIndex + 1;
        }

        private int GetRightChildIndex(int keyIndex)
        {
            return 2 * keyIndex + 2;
        }

        private void SwapHeapElements(int firstElementIndex, int secondElementIndex)
        {
            var tempElement = _heapArray[firstElementIndex];
            _heapArray[firstElementIndex] = _heapArray[secondElementIndex];
            _heapArray[secondElementIndex] = tempElement;
        }

        // A recursive method to heapify a subtree with the root at given index  
        // This method assumes that the subtrees are already heapified 
        private void MinHeapify(int rootIndex)
        {
            int leftChildIndex = GetLeftChildIndex(rootIndex);
            int rightChildIndex = GetRightChildIndex(rootIndex);

            int smallestKeyIndex = rootIndex;
            if (leftChildIndex < _heapArray.GetLength() &&
                _heapArray[leftChildIndex].CompareTo(_heapArray[smallestKeyIndex]) < 0)
            {
                smallestKeyIndex = leftChildIndex;
            }
            if (rightChildIndex < _heapArray.GetLength() &&
                _heapArray[rightChildIndex].CompareTo(_heapArray[smallestKeyIndex]) < 0)
            {
                smallestKeyIndex = rightChildIndex;
            }

            if (smallestKeyIndex != rootIndex)
            {
                SwapHeapElements(rootIndex, smallestKeyIndex);
                MinHeapify(smallestKeyIndex);
            }
        }
    }
}
