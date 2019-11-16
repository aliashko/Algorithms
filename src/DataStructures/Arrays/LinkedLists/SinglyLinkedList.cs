namespace DataStructures.Arrays.LinkedLists
{
    public class SinglyLinkedList<T>
    {
        public SinglyLinkedList()
        {
            HeadNode = new SinglyLinkedListNode<T>();
        }

        private SinglyLinkedListNode<T> HeadNode;

        public SinglyLinkedListNode<T> GetHeadNode()
        {
            return HeadNode;
        }

        public void AddToTail(T element)
        {
            HeadNode.AddToTail(element);
        }

        public void RemoveItem(T element)
        {
            for (var node = HeadNode; node != null; node = node.GetNextNode()) 
            {
                if(node.GetNextNode() != null)
                {
                    if (node.GetNextNode().Data.Equals(element))
                    {
                        node.SetNextNode(node.GetNextNode().GetNextNode());
                    }
                }
                else if (node.Data.Equals(element))
                {
                    node = null;
                }
            }
        }
    }
}
