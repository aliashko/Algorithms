using DataStructures.Arrays;

namespace DataStructures.Trees
{
    public class BinaryTree<T>
    {
        public BinaryTree(T rootNodeValue)
        {
            RootNode = new BinaryTreeNode<T>(rootNodeValue);
        }

        public BinaryTreeNode<T> RootNode { get; }

        /// <summary>
        /// Given a binary tree, return its nodes according to the "bottom-up" postorder traversal.
        /// Usings: delete tree
        /// </summary>
        public T[] TraverseTreePostorder(BinaryTreeNode<T> node)
        {
            var elementsList = new ArrayList<T>();

            if (node != null)
            {
                elementsList.AddRange(TraverseTreePostorder(node.Left));
                elementsList.AddRange(TraverseTreePostorder(node.Right));
                elementsList.Add(node.Value);
            }

            return elementsList.ToArray();
        }

        /// <summary>
        /// Given a binary tree, return its nodes in inorder
        /// Usings: get sorted sequence in BST
        /// </summary>
        public T[] TraverseTreeInorder(BinaryTreeNode<T> node)
        {
            var elementsList = new ArrayList<T>();

            if (node != null)
            {
                elementsList.AddRange(TraverseTreeInorder(node.Left));
                elementsList.Add(node.Value);
                elementsList.AddRange(TraverseTreeInorder(node.Right));                
            }

            return elementsList.ToArray();
        }

        /// <summary>
        /// Given a binary tree, return its nodes in preorder
        /// </summary>
        public T[] TraverseTreePreorder(BinaryTreeNode<T> node)
        {
            var elementsList = new ArrayList<T>();

            if (node != null)
            {
                elementsList.Add(node.Value);
                elementsList.AddRange(TraverseTreePreorder(node.Left));                
                elementsList.AddRange(TraverseTreePreorder(node.Right));
            }

            return elementsList.ToArray();
        }
    }

    public class BinaryTreeNode<T>
    {
        public BinaryTreeNode(T nodeValue)
        {
            Value = nodeValue;
        }

        public T Value { get; }

        public BinaryTreeNode<T> Left { get; private set; }

        public BinaryTreeNode<T> Right { get; private set; }

        public void SetLeftNode(T nodeValue)
        {
            Left = new BinaryTreeNode<T>(nodeValue);
        }

        public void SetRightNode(T nodeValue)
        {
            Right = new BinaryTreeNode<T>(nodeValue);
        }
    }
}
