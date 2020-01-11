namespace DataStructures.Arrays.LinkedLists
{
    public class SinglyLinkedList<T>
    {
        private SinglyLinkedListNode<T> HeadNode;

        public SinglyLinkedListNode<T> GetHeadNode()
        {
            return HeadNode;
        }

        public void AddToTail(T element)
        {
            if (HeadNode == null)
            {
                HeadNode = new SinglyLinkedListNode<T>(element);
            }
            else
            {
                HeadNode.AddToTail(element);
            }
        }

        public void RemoveItem(T element)
        {
            var previousNode = HeadNode;

            for (var node = HeadNode; node != null; node = node.GetNextNode()) 
            {
                if (node.Data.Equals(element))
                {
                    if (node.Equals(HeadNode))
                    {
                        HeadNode = node.GetNextNode();
                        break;
                    }

                    previousNode.SetNextNode(node.GetNextNode());
                }                

                previousNode = node;
            }

            // Variant #2 without temporary variable but with additional checks
            //if (HeadNode != null && HeadNode.Data.Equals(element))
            //{
            //    HeadNode = HeadNode.GetNextNode();
            //    return;
            //}

            //for (var node = HeadNode; node != null; node = node.GetNextNode())
            //{
            //    var nextNode = node.GetNextNode();

            //    if (nextNode != null && nextNode.Data.Equals(element))
            //    {
            //        node.SetNextNode(nextNode.GetNextNode());
            //    }
            //}            
        }
    }
}
