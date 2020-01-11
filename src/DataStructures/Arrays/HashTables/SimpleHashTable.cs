using DataStructures.Arrays.LinkedLists;
using System;

namespace DataStructures.Arrays.HashTables
{
    public class SimpleHashTable<TKey, TValue>
    {
        public SimpleHashTable(int capacity = 10)
        {
            Capacity = capacity;
            InitializeBuckets(capacity);
        }

        private int Capacity { get; }

        private SinglyLinkedList<HashTableBucketItem<TKey, TValue>>[] Buckets;

        public void AddItem(TKey key, TValue value)
        {
            if (ContainsKey(key))
            {
                throw new ArgumentException($"Duplicated key: {key}");
            }

            var bucketIndex = GetBucketIndex(key);
            if(Buckets[bucketIndex] == null)
            {
                Buckets[bucketIndex] = new SinglyLinkedList<HashTableBucketItem<TKey, TValue>>();
            }

            Buckets[bucketIndex].AddToTail(new HashTableBucketItem<TKey, TValue>(key, value));
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
        }

        private void InitializeBuckets(int newCapacity)
        {
            Buckets = new SinglyLinkedList<HashTableBucketItem<TKey, TValue>>[newCapacity];
        }

        private int GetBucketIndex(TKey key)
        {
            var hashIndex = Math.Abs(key.GetHashCode());
            var bucketIndex = hashIndex / (int.MaxValue / Capacity);

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
    }

    // built in KeyValuePair can be used instead
    struct HashTableBucketItem<TKey, TValue>
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
