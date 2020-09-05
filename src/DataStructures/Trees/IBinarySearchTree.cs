namespace DataStructures.Trees
{
    public interface IBinarySearchTree<T>
    {
        BinaryTreeNode<T> GetRootNode();
        BinaryTreeNode<T> SearchNode(T key);
        BinaryTreeNode<T> SearchNodeIterative(T key);

        BinaryTreeNode<T> Insert(T key);

        void RemoveNode(T key);
    }
}
