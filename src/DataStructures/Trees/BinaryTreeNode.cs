namespace DataStructures.Trees
{
    public class BinaryTreeNode<T>
    {
        public BinaryTreeNode(T key)
        {
            Key = key;
        }

        public T Key { get; private set; }

        public BinaryTreeNode<T> Left { get; private set; }

        public BinaryTreeNode<T> Right { get; private set; }

        public void SetLeftNode(T nodeKey)
        {
            Left = new BinaryTreeNode<T>(nodeKey);
        }

        public void SetRightNode(T nodeKey)
        {
            Right = new BinaryTreeNode<T>(nodeKey);
        }

        public void ReplaceLeftNodeWith(BinaryTreeNode<T> node)
        {
            Left = node;
        }

        public void ReplaceRightNodeWith(BinaryTreeNode<T> node)
        {
            Right = node;
        }

        public void SetKey(T key)
        {
            Key = key;
        }

        public bool IsLeaf()
        {
            return Left == null && Right == null;
        }
    }
}
