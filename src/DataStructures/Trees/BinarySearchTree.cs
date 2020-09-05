using System;

namespace DataStructures.Trees
{
    public class BinarySearchTree<T> : BinaryTree<T>
        where T: IComparable
    {
        public BinarySearchTree()
        {
        }

        public BinarySearchTree(T rootNodeKey) : base(rootNodeKey)
        {
        }

        public BinaryTreeNode<T> GetRootNode()
        {
            return RootNode;
        }

        /// <summary>
        /// worst case - O(n). average - O(log(n))
        /// </summary>
        public BinaryTreeNode<T> SearchNode(T key)
        {
            return SearchNodeFrom(RootNode, key);
        }

        /// <summary>
        /// worst case - O(n). average - O(log(n))
        /// </summary>
        public BinaryTreeNode<T> SearchNodeIterative(T key)
        {
            var rootNode = RootNode;
            while(rootNode != null)
            {
                var compareResult = rootNode.Key.CompareTo(key);

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

        private BinaryTreeNode<T> SearchNodeFrom(BinaryTreeNode<T> rootNode, T key, bool returnLastMatchingNode = false)
        {
            if(rootNode == null)
            {
                return null;
            }

            var compareResult = rootNode.Key.CompareTo(key);

            if (compareResult > 0)
            {
                if (rootNode.Left == null && returnLastMatchingNode) return rootNode;
                return SearchNodeFrom(rootNode.Left, key, returnLastMatchingNode);
            }
            else if (compareResult < 0)
            {
                if (rootNode.Right == null && returnLastMatchingNode) return rootNode;
                return SearchNodeFrom(rootNode.Right, key, returnLastMatchingNode);
            }

            return rootNode;
        }

        /// <summary>
        /// O(log(n))
        /// </summary>
        public BinaryTreeNode<T> Insert(T key)
        {
            var nodeParent = SearchNodeFrom(RootNode, key, true);

            var compareResult = nodeParent.Key.CompareTo(key);

            if (compareResult > 0)
            {
                nodeParent.SetLeftNode(key);
                return nodeParent.Left;
            }
            else if (compareResult < 0)
            {
                nodeParent.SetRightNode(key);
                return nodeParent.Right;
            }

            // The tree is already contain element
            return nodeParent;
        }

        /// <summary>
        /// O(n)
        /// </summary>
        public void RemoveNode(T key)
        {
            RootNode = RemoveNodeFrom(RootNode, key);
        }

        private BinaryTreeNode<T> RemoveNodeFrom(BinaryTreeNode<T> rootNode, T key)
        {
            if (rootNode == null) return rootNode; // Base case

            var compareResult = rootNode.Key.CompareTo(key);

            if (compareResult > 0)
            {
                rootNode.ReplaceLeftNodeWith(RemoveNodeFrom(rootNode.Left, key));
            }
            else if (compareResult < 0)
            {
                rootNode.ReplaceRightNodeWith(RemoveNodeFrom(rootNode.Right, key));
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
                rootNode.SetKey(minNodeInSubtree.Key);

                rootNode.ReplaceRightNodeWith(RemoveNodeFrom(rootNode.Right, minNodeInSubtree.Key));
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
