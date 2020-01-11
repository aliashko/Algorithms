namespace DataStructures.Arrays.LinkedLists
{
    public class SinglyLinkedListNode<T>
    {
        public SinglyLinkedListNode(T data = default)
        {
            Data = data;
        }

        private SinglyLinkedListNode<T> NextNode = null;

        public T Data { get; }
        
        public SinglyLinkedListNode<T> GetNextNode()
        {
            return NextNode;
        }

        public void SetNextNode(SinglyLinkedListNode<T> nextNode)
        {
            NextNode = nextNode;
        }

        public void AddToTail(T element)
        {
            var node = this;
            while(node.NextNode != null)
            {
                node = node.NextNode;
            }

            node.NextNode = new SinglyLinkedListNode<T>(element);
        }
    }
}
