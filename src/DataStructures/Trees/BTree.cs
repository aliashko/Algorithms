using System;

namespace DataStructures.Trees
{
    /// <summary>
    /// BTree is a balanced tree with fixed height. It's the equivalent of RB tree by operational complexity
    /// but offers wider levels (number of keys in one node), so you can work with entire disk block using less IO reads.
    /// BTree is little less efficient than RedBlack tree in memory because we need to store arrays of keys (mostly empty) 
    /// and do sorting of arrays (it's only related to modifying tree). But for searching BTree sometimes even more efficient
    /// becuase of better locality of data and caching (incl. processor cache)
    /// 
    /// Lots of lookups, little modifications: B-Tree (with high order)
    /// Little lookups, lots of modifications: RB-Tree
    /// </summary>
    public class BTree<T>
        where T : IComparable
    {
        public BTree(int keysCapacity)
        {
            KeysCapacity = keysCapacity;
            RootNode = new BTreeNode<T>(keysCapacity);
        }

        public BTreeNode<T> RootNode { get; private set; }

        public int KeysCapacity { get; }

        public BTreeNode<T> Search(T key)
        {
            return SearchRecursively(key, RootNode);
        }

        private BTreeNode<T> SearchRecursively(T key, BTreeNode<T> subtreeRoot)
        {
            var currentKeyIndex = subtreeRoot.GetNearestKeyPosition(key);

            if (subtreeRoot.Keys[currentKeyIndex].CompareTo(key) == 0) return subtreeRoot.ChildNodes[currentKeyIndex]; // node is found
            if (subtreeRoot.IsLeaf) return null; // not found

            return SearchRecursively(key, subtreeRoot.ChildNodes[currentKeyIndex]);
        }

        public void Insert(T key)
        {
            InsertInternally(key, RootNode);
        }

        private void InsertInternally(T key, BTreeNode<T> subtreeRoot)
        {
            if (subtreeRoot.IsLeaf)
            {
                if (!subtreeRoot.IsFull)
                {
                    InsertNonFull(key, subtreeRoot);
                    return;
                }

                SplitChild(key, subtreeRoot);
            }

            var nextChildPosition = subtreeRoot.GetNearestKeyPosition(key);
            InsertInternally(key, subtreeRoot.ChildNodes[nextChildPosition]);
        }

        private void InsertNonFull(T key, BTreeNode<T> subtreeRoot)
        {
            subtreeRoot.AddNewKey(key);
        }

        private void SplitChild(T key, BTreeNode<T> subtreeRoot)
        {
            
        }
    }

    public class BTreeNode<T>
        where T : IComparable
    {
        public BTreeNode(int keysCapacity, bool isLeaf = true)
        {
            KeysCapacity = keysCapacity;
            IsLeaf = isLeaf;
            Keys = new T[keysCapacity];
            ChildNodes = new BTreeNode<T>[keysCapacity + 1];
            KeysCount = 0;
        }

        public T[] Keys { get; private set; }

        public BTreeNode<T>[] ChildNodes { get; private set; }

        public int KeysCapacity { get; } 

        public int KeysCount { get; private set; } 

        public bool IsLeaf { get; private set; }

        public bool IsFull => KeysCount == KeysCapacity;

        public int GetNearestKeyPosition(T key)
        {
            int currentKeyIndex = 0;
            while (currentKeyIndex < KeysCount)
            {
                if (Keys[currentKeyIndex].CompareTo(key) > 0) break;
                currentKeyIndex++;
            }
            return currentKeyIndex;
        }

        public void AddNewKey(T key)
        {
            if (IsFull) throw new Exception("BTree Node keys capacity is overflowed");

            var currentKeyIndex = GetNearestKeyPosition(key);
            for(var i = KeysCount; i>=currentKeyIndex; i--)
            {
                Keys[i + 1] = Keys[i];
                ChildNodes[i + 1] = ChildNodes[i];
            }

            Keys[currentKeyIndex] = key;
            ChildNodes[currentKeyIndex] = new BTreeNode<T>(KeysCapacity);
            KeysCount++;
        }
    }
}
