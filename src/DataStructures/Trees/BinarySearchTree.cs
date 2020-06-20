using System;

namespace DataStructures.Trees
{
    public class BinarySearchTree<T> : BinaryTree<T> 
        where T: IComparable
    {
        public BinarySearchTree(T rootNodeValue) : base(rootNodeValue)
        {
        }

        /// <summary>
        /// O(log(n))
        /// </summary>
        public BinaryTreeNode<T> SearchNode(T value)
        {
            return SearchNodeFrom(RootNode, value);
        }

        private BinaryTreeNode<T> SearchNodeFrom(BinaryTreeNode<T> rootNode, T value, bool returnLastMatchingNode = false)
        {
            if(rootNode == null)
            {
                return null;
            }

            var compareResult = rootNode.Value.CompareTo(value);

            if (compareResult > 0)
            {
                if (rootNode.Left == null && returnLastMatchingNode) return rootNode;
                return SearchNodeFrom(rootNode.Left, value, returnLastMatchingNode);
            }
            else if (compareResult < 0)
            {
                if (rootNode.Right == null && returnLastMatchingNode) return rootNode;
                return SearchNodeFrom(rootNode.Right, value, returnLastMatchingNode);
            }

            return rootNode;
        }

        /// <summary>
        /// O(log(n))
        /// </summary>
        public BinaryTreeNode<T> Insert(T value)
        {
            var nodeParent = SearchNodeFrom(RootNode, value, true);

            var compareResult = nodeParent.Value.CompareTo(value);

            if (compareResult > 0)
            {
                nodeParent.SetLeftNode(value);
                return nodeParent.Left;
            }
            else if (compareResult < 0)
            {
                nodeParent.SetRightNode(value);
                return nodeParent.Right;
            }

            // The tree is already contain element
            return nodeParent;
        }
    }
}
