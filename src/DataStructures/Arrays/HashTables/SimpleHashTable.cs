using DataStructures.Arrays.LinkedLists;
using System;

namespace DataStructures.Arrays.HashTables
{
    public class SimpleHashTable<TKey, TValue>
    {
        private const int minCapacity = 10;
        private const int maxCapacity = int.MaxValue;

        public SimpleHashTable()
        {
            ResizeHashTable(minCapacity, true);
        }
        
        private SinglyLinkedList<HashTableBucketItem<TKey, TValue>>[] Buckets;

        public int Count { get; private set; }

        public void AddItem(TKey key, TValue value)
        {
            if (ContainsKey(key))
            {
                throw new ArgumentException($"Duplicated key: {key}");
            }

            if(Count == Buckets.Length)
            {
                ResizeHashTable(Buckets.Length * 2);
            }

            var bucketIndex = GetBucketIndex(key);
            if(Buckets[bucketIndex] == null)
            {
                Buckets[bucketIndex] = new SinglyLinkedList<HashTableBucketItem<TKey, TValue>>();
            }

            Buckets[bucketIndex].AddToTail(new HashTableBucketItem<TKey, TValue>(key, value));
            Count++;
        }

        public bool ContainsKey(TKey key)
        {
            var bucketItem = GetBucketItemByKey(key);
            return bucketItem.HasValue;
        }

        public TValue GetItemOrDefault(TKey key)
        {
            var bucketItem = GetBucketItemByKey(key);
            return bucketItem != null ? bucketItem.Value.Value : default;
        }

        public void RemoveItem(TKey key)
        {
            var bucketIndex = GetBucketIndex(key);
            var bucketItem = GetBucketItemByKey(key);

            if (!bucketItem.HasValue)
            {
                throw new ArgumentException($"Item with key '{key}' is not found");
            }

            Buckets[bucketIndex].RemoveItem(bucketItem.Value);
            Count--;

            if (Count <= Buckets.Length / 2)
            {
                ResizeHashTable(Buckets.Length / 2);
            }
        }

        private void ResizeHashTable(int newCapacity, bool initialize = false)
        {
            if(newCapacity > maxCapacity)
            {
                newCapacity = maxCapacity;
            }
            else if (newCapacity < minCapacity)
            {
                newCapacity = minCapacity;
            }
            if(!initialize && newCapacity == Buckets.Length)
            {
                return;
            }

            var newBuckets = new SinglyLinkedList<HashTableBucketItem<TKey, TValue>>[newCapacity];

            if (!initialize)
            {
                for(int bucketIndex = 0; bucketIndex< Buckets.Length; bucketIndex++)
                {
                    if(Buckets[bucketIndex] == null) 
                    {
                        continue;
                    }

                    var currentBucketNode = Buckets[bucketIndex].GetHeadNode();
                    while (currentBucketNode != null)
                    {
                        var newBucketIndex = GetBucketIndex(currentBucketNode.Data.Key, newCapacity);
                        if (newBuckets[newBucketIndex] == null)
                        {
                            newBuckets[newBucketIndex] = new SinglyLinkedList<HashTableBucketItem<TKey, TValue>>();
                        }

                        newBuckets[newBucketIndex].AddToTail(currentBucketNode.Data);

                        currentBucketNode = currentBucketNode.GetNextNode();
                    }
                }
            }

            Buckets = newBuckets;
        }

        private int GetBucketIndex(TKey key, int? calculateForCapacity = null)
        {
            var hashIndex = Math.Abs(key.GetHashCode());
            var bucketIndex = hashIndex % (calculateForCapacity ?? Buckets.Length);

            return bucketIndex;
        }

        private HashTableBucketItem<TKey, TValue>? GetBucketItemByKey(TKey key)
        {
            var bucketIndex = GetBucketIndex(key);
            if (Buckets[bucketIndex] == null)
            {
                return null;
            }

            var currentBucketNode = Buckets[bucketIndex].GetHeadNode();
            while (currentBucketNode != null)
            {
                if (key.Equals(currentBucketNode.Data.Key))
                {
                    return currentBucketNode.Data;
                }

                currentBucketNode = currentBucketNode.GetNextNode();
            }

            return null;
        }

        // built in KeyValuePair can be used instead
        private struct HashTableBucketItem<TKey, TValue>
        {
            public HashTableBucketItem(TKey key, TValue value)
            {
                Key = key;
                Value = value;
            }

            public TKey Key { get; }

            public TValue Value { get; }
        }
    }
}
