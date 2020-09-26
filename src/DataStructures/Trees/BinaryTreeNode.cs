namespace DataStructures.Trees
{
    public class BinaryTreeNode<T>
    {
        public BinaryTreeNode(T key, BinaryTreeNode<T> parent = null)
        {
            Key = key;
            //Parent = parent;
        }

        public T Key { get; private set; }

        public BinaryTreeNode<T> Left { get; private set; }

        public BinaryTreeNode<T> Right { get; private set; }

        public BinaryTreeNode<T> Parent { get; private set; }

        public BinaryTreeNode<T> AddLeftNode(T nodeKey)
        {
            Left = new BinaryTreeNode<T>(nodeKey, this);
            return Left;
        }

        public BinaryTreeNode<T> AddRightNode(T nodeKey)
        {
            Right = new BinaryTreeNode<T>(nodeKey, this);
            return Right;
        }

        public void ReplaceLeftNodeWith(BinaryTreeNode<T> node)
        {
            //if(node != null) node.ReplaceParentNodeWith(this);
            Left = node;            
        }

        public void ReplaceRightNodeWith(BinaryTreeNode<T> node)
        {
            //if (node != null) node.ReplaceParentNodeWith(this);
            Right = node;
        }

        public void ReplaceParentNodeWith(BinaryTreeNode<T> node)
        {
            Parent = node;
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
