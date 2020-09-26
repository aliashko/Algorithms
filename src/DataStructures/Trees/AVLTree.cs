using System;

namespace DataStructures.Trees
{
    /// <summary>
    ///  AVL tree is used for faster search in the tree (opposite of Red-black)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AVLTree<T> : BinarySearchTree<T>
        where T : IComparable
    {
        public new void Insert(T key)
        {
            RootNode = InsertInternally((AVLTreeNode<T>)RootNode, key);
        }

        private AVLTreeNode<T> InsertInternally(AVLTreeNode<T> rootNode, T key)
        {
            // Perform the normal BST insertion
            if (rootNode == null)
                return new AVLTreeNode<T>(key);

            var compareResult = rootNode.Key.CompareTo(key);

            if (compareResult > 0)
                rootNode.ReplaceLeftNodeWith(InsertInternally((AVLTreeNode<T>)rootNode.Left, key));
            else if (compareResult < 0)
                rootNode.ReplaceRightNodeWith(InsertInternally((AVLTreeNode<T>)rootNode.Right, key));
            else // The tree is already contain element
                return rootNode;

            // Update height of this ancestor node
            rootNode.Height = GetMaxValue(GetHeight(rootNode.Left), GetHeight(rootNode.Right)) + 1;

            // Get the balance factor of this ancestor node to check whether this node became unbalanced
            int balanceFactor = GetBalanceFactor(rootNode);

            // If this node becomes unbalanced, then there are 4 cases 
            // Left Left Case  
            if (balanceFactor > 1 && rootNode.Left.Key.CompareTo(key) > 0)
                return RightRotate(rootNode);

            // Right Right Case  
            if (balanceFactor < -1 && rootNode.Right.Key.CompareTo(key) < 0)
                return LeftRotate(rootNode);

            // Left Right Case  
            if (balanceFactor > 1 && rootNode.Left.Key.CompareTo(key) < 0)
            {
                rootNode.ReplaceLeftNodeWith(LeftRotate((AVLTreeNode<T>)rootNode.Left));
                return RightRotate(rootNode);
            }

            // Right Left Case  
            if (balanceFactor < -1 && rootNode.Right.Key.CompareTo(key) > 0)
            {
                rootNode.ReplaceRightNodeWith(RightRotate((AVLTreeNode<T>)rootNode.Right));
                return LeftRotate(rootNode);
            }

            /* return the (unchanged) node pointer */
            return rootNode;
        }

        public new void RemoveNode(T key)
        {
            RootNode = RemoveNodeInternally((AVLTreeNode<T>)RootNode, key);
        }

        private AVLTreeNode<T> RemoveNodeInternally(AVLTreeNode<T> rootNode, T key)
        {
            // Perform standard BST deletion
            if (rootNode == null)
                return rootNode;

            var compareResult = rootNode.Key.CompareTo(key);

            // If the key to be deleted is smaller than the root's key, then it lies in left subtree  
            if (compareResult > 0)
                rootNode.ReplaceLeftNodeWith(RemoveNodeInternally((AVLTreeNode<T>)rootNode.Left, key));

            // If the key to be deleted is greater than the root's key, then it lies in right subtree  
            else if (compareResult < 0)
                rootNode.ReplaceRightNodeWith(RemoveNodeInternally((AVLTreeNode<T>)rootNode.Right, key));

            // if key is same as root's key, then this is the node to be deleted  
            else
            {
                // node with only one child or no child  
                if ((rootNode.Left == null) || (rootNode.Right == null))
                {
                    AVLTreeNode<T> tempNode = null;
                    if (tempNode == rootNode.Left)
                        tempNode = (AVLTreeNode<T>)rootNode.Right;
                    else
                        tempNode = (AVLTreeNode<T>)rootNode.Left;

                    // No child case  
                    if (tempNode == null)
                    {
                        tempNode = rootNode;
                        rootNode = null;
                    }
                    else // One child case  
                        rootNode = tempNode; // Copy the contents of the non-empty child  
                }
                else
                {
                    // node with two children: Get the inorder successor (smallest in the right subtree)  
                    AVLTreeNode<T> tempNode = GetMinValueNode((AVLTreeNode<T>)rootNode.Right);

                    // Copy the inorder successor's data to this node  
                    rootNode.SetKey(tempNode.Key);

                    // Delete the inorder successor
                    rootNode.ReplaceRightNodeWith(RemoveNodeInternally((AVLTreeNode<T>)rootNode.Right, tempNode.Key));
                }
            }

            // If the tree had only one node then return  
            if (rootNode == null)
                return rootNode;

            // STEP 2: UPDATE HEIGHT OF THE CURRENT NODE  
            rootNode.Height = GetMaxValue(GetHeight(rootNode.Left), GetHeight(rootNode.Right)) + 1;

            // STEP 3: GET THE BALANCE FACTOR OF THIS NODE (to check whether this node became unbalanced)  
            int balanceFactor = GetBalanceFactor(rootNode);

            // If this node becomes unbalanced, then there are 4 cases
            // Left Left Case  
            if (balanceFactor > 1 && GetBalanceFactor((AVLTreeNode<T>)rootNode.Left) >= 0)
                return RightRotate(rootNode);

            // Left Right Case  
            if (balanceFactor > 1 && GetBalanceFactor((AVLTreeNode<T>)rootNode.Left) < 0)
            {
                rootNode.ReplaceLeftNodeWith(LeftRotate((AVLTreeNode<T>)rootNode.Left));
                return RightRotate(rootNode);
            }

            // Right Right Case  
            if (balanceFactor < -1 && GetBalanceFactor((AVLTreeNode<T>)rootNode.Right) <= 0)
                return LeftRotate(rootNode);

            // Right Left Case  
            if (balanceFactor < -1 && GetBalanceFactor((AVLTreeNode<T>)rootNode.Right) > 0)
            {
                rootNode.ReplaceRightNodeWith(RightRotate((AVLTreeNode<T>)rootNode.Right));
                return LeftRotate(rootNode);
            }

            return rootNode;
        }

        /// <summary>
        /// Given a non-empty binary search tree, return the node with minimum key value found in that tree.  
        /// Note that the entire tree does not need to be searched.
        /// </summary>
        private AVLTreeNode<T> GetMinValueNode(AVLTreeNode<T> node)
        {
            AVLTreeNode<T> current = node;

            // loop down to find the leftmost leaf
            while (current.Left != null)
                current = (AVLTreeNode<T>)current.Left;

            return current;
        }

        /// <summary>
        /// A utility function to right rotate subtree rooted with subtreeRootNode
        /// </summary>
        private AVLTreeNode<T> RightRotate(AVLTreeNode<T> subtreeRootNode)
        {
            var leftNode = (AVLTreeNode <T>)subtreeRootNode.Left;
            var T2 = leftNode.Right;

            // Perform rotation  
            leftNode.ReplaceRightNodeWith(subtreeRootNode);
            subtreeRootNode.ReplaceLeftNodeWith(T2);

            // Update heights  
            subtreeRootNode.Height = GetMaxValue(GetHeight(subtreeRootNode.Left), GetHeight(subtreeRootNode.Right)) + 1;
            leftNode.Height = GetMaxValue(GetHeight(leftNode.Left), GetHeight(leftNode.Right)) + 1;

            // Return new root  
            return leftNode;
        }

        /// <summary>
        /// A utility function to left rotate subtree rooted with subtreeRootNode
        /// </summary>
        private AVLTreeNode<T> LeftRotate(AVLTreeNode<T> subtreeRootNode)
        {
            var rightNode = (AVLTreeNode<T>)subtreeRootNode.Right;
            var T2 = rightNode.Left;

            // Perform rotation  
            rightNode.ReplaceLeftNodeWith(subtreeRootNode);
            subtreeRootNode.ReplaceRightNodeWith(T2);

            // Update heights  
            subtreeRootNode.Height = GetMaxValue(GetHeight(subtreeRootNode.Left), GetHeight(subtreeRootNode.Right)) + 1;
            rightNode.Height = GetMaxValue(GetHeight(rightNode.Left), GetHeight(rightNode.Right)) + 1;

            // Return new root  
            return rightNode;
        }


        private int GetHeight(BinaryTreeNode<T> node)
        {
            return ((AVLTreeNode<T>)node)?.Height ?? 0;
        }

        private int GetBalanceFactor(AVLTreeNode<T> node)
        {
            if (node == null) return 0;
            return GetHeight(node.Left) - GetHeight(node.Right);
        }

        private int GetMaxValue(int a, int b)
        {
            return a > b ? a : b;
        }
    }

    public class AVLTreeNode<T> : BinaryTreeNode<T>
    {
        public AVLTreeNode(T key) : base(key)
        {
            Height = 1;
        }

        public int Height { get; set; }
    }
}
