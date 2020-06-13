using DataStructures.Arrays;
using DataStructures.Arrays.LinkedLists;

namespace DataStructures.Trees
{
    public class Tree<T>
    {
        public Tree(T rootNodeValue)
        {
            RootNode = new TreeNode<T>(rootNodeValue);
        }

        public TreeNode<T> RootNode { get; }

        public static T[] TraverseTreePostorder(TreeNode<T> node)
        {
            var elementsList = new ArrayList<T>();

            if (node != null)
            {
                foreach (var child in node.Children)
                {
                    elementsList.AddRange(TraverseTreePostorder(child));
                }
                elementsList.Add(node.Value);
            }

            return elementsList.ToArray();
        }

        public static T[] TraverseTreePreorder(TreeNode<T> node)
        {
            var elementsList = new ArrayList<T>();

            if (node != null)
            {
                elementsList.Add(node.Value);
                foreach (var child in node.Children)
                {
                    elementsList.AddRange(TraverseTreePreorder(child));
                }
            }

            return elementsList.ToArray();
        }

        public static T[] TraverseTreeLevelOrder(TreeNode<T> node)
        {
            var elementsList = new ArrayList<T>();
            var queue = new Queue<TreeNode<T>>();
            queue.Enqueue(node);

            while(queue.Count() != 0)
            {
                var currentNode = queue.Dequeue();

                elementsList.Add(currentNode.Value);

                foreach (var child in currentNode.Children)
                {
                    queue.Enqueue(child);
                }
            }
                                 
            return elementsList.ToArray();
        }
    }

    public class TreeNode<T>
    {
        public TreeNode(T value)
        {
            Value = value;
            Children = new SinglyLinkedList<TreeNode<T>>();
        }

        public TreeNode<T> AddChild(T value)
        {
            var childNode = new TreeNode<T>(value);
            Children.AddToTail(childNode);

            return childNode;
        }

        public TreeNode<T> GetChild(int i)
        {
            foreach (TreeNode<T> n in Children)
                if (--i == 0)
                    return n;
            return null;
        }

        public T Value { get; }

        public SinglyLinkedList<TreeNode<T>> Children { get; }
    }
}
