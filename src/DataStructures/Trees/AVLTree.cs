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
