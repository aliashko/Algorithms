using System;

namespace DataStructures.Trees
{
    /// <summary>
    /// Red-black tree is used for faster modification of the tree (opposite of AVL)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RedBlackTree<T> : BinarySearchTree<T>
        where T : IComparable
    {
        public RedBlackTree(T rootNodeValue) : base(rootNodeValue)
        {
        }
    }
}
