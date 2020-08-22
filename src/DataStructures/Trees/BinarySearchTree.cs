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
        /// worst case - O(n). average - O(log(n))
        /// </summary>
        public BinaryTreeNode<T> SearchNode(T value)
        {
            return SearchNodeFrom(RootNode, value);
        }

        /// <summary>
        /// worst case - O(n). average - O(log(n))
        /// </summary>
        public BinaryTreeNode<T> SearchNodeIterative(T value)
        {
            var rootNode = RootNode;
            while(rootNode != null)
            {
                var compareResult = rootNode.Value.CompareTo(value);

                if (compareResult > 0)
                {
                    rootNode = rootNode.Left;
                }
                else if (compareResult < 0)
                {
                    rootNode = rootNode.Right;
                }
                else
                {
                    return rootNode;
                }
            }

            return null;
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

        /// <summary>
        /// O(n)
        /// </summary>
        public void RemoveNode(T value)
        {
            RootNode = RemoveNodeFrom(RootNode, value);
        }

        private BinaryTreeNode<T> RemoveNodeFrom(BinaryTreeNode<T> rootNode, T value)
        {
            if (rootNode == null) return rootNode; // Base case

            var compareResult = rootNode.Value.CompareTo(value);

            if (compareResult > 0)
            {
                rootNode.ReplaceLeftNodeWith(RemoveNodeFrom(rootNode.Left, value));
            }
            else if (compareResult < 0)
            {
                rootNode.ReplaceRightNodeWith(RemoveNodeFrom(rootNode.Right, value));
            }
            else
            {
                // This is the removing element
                if(rootNode.Left == null)
                {
                    return rootNode.Right;
                }
                else if(rootNode.Right == null)
                {
                    return rootNode.Left;
                }

                var minNodeInSubtree = SearchMinNode(rootNode.Right);
                rootNode.SetValue(minNodeInSubtree.Value);

                rootNode.ReplaceRightNodeWith(RemoveNodeFrom(rootNode.Right, minNodeInSubtree.Value));
            }

            return rootNode;
        }

        private BinaryTreeNode<T> SearchMinNode(BinaryTreeNode<T> rootNode)
        {
            var minNode = rootNode;
            while(minNode.Left != null)
            {
                minNode = minNode.Left;
            }

            return minNode;
        }
    }
}
