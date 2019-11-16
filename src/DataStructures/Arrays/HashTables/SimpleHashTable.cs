namespace DataStructures.Arrays.HashTables
{
    public class SimpleHashTable<T>
    {
        public SimpleHashTable(int capacity)
        {
            Capacity = capacity;
            HashArray = new int[capacity];
        }

        private int Capacity { get; }

        private int[] HashArray;

        public void AddItem(string key, T value)
        {

        }

        public T GetItem(string key)
        {
            return default;
        }

        public void RemoveItem(string key)
        {

        }
    }
}
