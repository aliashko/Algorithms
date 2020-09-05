using DataStructures.Arrays.LinkedLists;

namespace DataStructures.Trees
{
    public class TreeNode<T>
    {
        public TreeNode(T key)
        {
            Key = key;
            Children = new SinglyLinkedList<TreeNode<T>>();
        }

        public TreeNode<T> AddChild(T key)
        {
            var childNode = new TreeNode<T>(key);
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

        public T Key { get; }

        public SinglyLinkedList<TreeNode<T>> Children { get; }
    }
}
