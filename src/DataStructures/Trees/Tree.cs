using DataStructures.Arrays;
using DataStructures.Arrays.LinkedLists;

namespace DataStructures.Trees
{
    public class Tree<T>
    {
        public Tree(T rootNodeKey)
        {
            RootNode = new TreeNode<T>(rootNodeKey);
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
                elementsList.Add(node.Key);
            }

            return elementsList.ToArray();
        }

        public static T[] TraverseTreePreorder(TreeNode<T> node)
        {
            var elementsList = new ArrayList<T>();

            if (node != null)
            {
                elementsList.Add(node.Key);
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

                elementsList.Add(currentNode.Key);

                foreach (var child in currentNode.Children)
                {
                    queue.Enqueue(child);
                }
            }
                                 
            return elementsList.ToArray();
        }
    }
}
