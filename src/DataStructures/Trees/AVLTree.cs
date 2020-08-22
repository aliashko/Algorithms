using System;

namespace DataStructures.Trees
{
    /// <summary>
    ///  AVL tree is used for faster search in the tree (opposite of Red-black)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AVLTree<T>  where T : IComparable
    {
        public AVLTreeNode<T> RootNode { get; }

        public AVLTreeNode<T> SearchNode(T key)
        {

        }

        public AVLTreeNode<T> Insert(T key)
        {

        }

    }

    public class AVLTreeNode<T>
    {
        public AVLTreeNode(T key)
        {
            Key = key;
            _height = 1;
        }

        public T Key { get; private set; }
        
        public AVLTreeNode<T> Left { get; private set; }

        public AVLTreeNode<T> Right { get; private set; }

        private int _height;
    }
}
