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

        public T Value { get; }

        public SinglyLinkedList<TreeNode<T>> Children { get; }
    }
}
