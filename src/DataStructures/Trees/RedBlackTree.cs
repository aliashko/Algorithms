// TODO: Fix implementation
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
        public new void Insert(T key)
        {
            var newNode = new RedBlackTreeNode<T>(key);
            if (RootNode == null)
            {
                newNode.SetColor(true);
                RootNode = newNode;
                return;
            }

            RedBlackTreeNode<T> Y = null;
            RedBlackTreeNode<T> X = (RedBlackTreeNode<T>)RootNode;

            while (X != null)
            {
                Y = X;

                if (newNode.Key.CompareTo(X.Key) < 0)
                {
                    X = (RedBlackTreeNode<T>)X.Left;
                }
                else
                {
                    X = (RedBlackTreeNode<T>)X.Right;
                }
            }

            newNode.ReplaceParentNodeWith(Y);
            if (Y == null)
            {
                RootNode = newNode;
            }
            else if (newNode.Key.CompareTo(Y.Key) < 0)
            {
                Y.ReplaceLeftNodeWith(newNode);
            }
            else
            {
                Y.ReplaceRightNodeWith(newNode);
            }

            FixTreeAfterInsertion(newNode);     
        }

        private void FixTreeAfterInsertion(RedBlackTreeNode<T> insertedNode)
        {
            var insertedNodeParent = (RedBlackTreeNode<T>)insertedNode.Parent;

            // Checks Red-Black Tree properties
            while (insertedNode != RootNode && !insertedNodeParent.IsBlack)
            {                
                // We have a violation because parent is Red and new node is red
                if (insertedNodeParent == insertedNodeParent.Parent.Left)
                {
                    var Y = (RedBlackTreeNode<T>)insertedNodeParent.Parent.Right;

                    if (Y != null && !Y.IsBlack) //Case 1: uncle is red
                    {
                        insertedNodeParent.SetColor(true);
                        Y.SetColor(true);
                        ((RedBlackTreeNode<T>)insertedNodeParent.Parent).SetColor(false);
                        insertedNode = (RedBlackTreeNode<T>)insertedNodeParent.Parent;
                    }
                    else //Case 2: uncle is black
                    {
                        if (insertedNode == insertedNodeParent.Right)
                        {
                            insertedNode = insertedNodeParent;
                            LeftRotate(insertedNode);
                        }
                        //Case 3: recolour & rotate
                        insertedNodeParent.SetColor(true);
                        ((RedBlackTreeNode<T>)insertedNodeParent.Parent).SetColor(false);

                        RightRotate((RedBlackTreeNode<T>)insertedNodeParent.Parent);                        
                    }
                }
                else
                {
                    //Mirror image of code above
                    RedBlackTreeNode<T> X = null;

                    X = (RedBlackTreeNode<T>)insertedNodeParent.Parent.Left;
                    if (X != null && X.IsBlack) // Case 1
                    {
                        insertedNodeParent.SetColor(false);
                        X.SetColor(false);
                        ((RedBlackTreeNode<T>)insertedNodeParent.Parent).SetColor(true);
                        insertedNode = (RedBlackTreeNode<T>)insertedNodeParent.Parent;
                    }
                    else //Case 2
                    {
                        if (insertedNode == insertedNodeParent.Left)
                        {
                            insertedNode = insertedNodeParent;
                            RightRotate(insertedNode);
                        }
                        //Case 3: recolour & rotate
                        insertedNodeParent.SetColor(true);
                        ((RedBlackTreeNode<T>)insertedNodeParent.Parent).SetColor(false);

                        LeftRotate((RedBlackTreeNode<T>)insertedNodeParent.Parent);
                    }
                }

                ((RedBlackTreeNode<T>)RootNode).SetColor(true); //re-colour the root black as necessary
            }
        }        

        /// <summary>
        /// A utility function to right rotate subtree rooted with subtreeRootNode
        /// </summary>
        private void RightRotate(RedBlackTreeNode<T> subtreeRootNode)
        {
            /*
            var leftNode = (RedBlackTreeNode<T>)subtreeRootNode.Left;
            var subtreeRootNodeParent = subtreeRootNode.Parent;
            var T2 = leftNode.Right;

            // Perform rotation  
            leftNode.ReplaceRightNodeWith(subtreeRootNode);
            subtreeRootNode.ReplaceLeftNodeWith(T2);

            leftNode.ReplaceParentNodeWith(subtreeRootNodeParent);

            // Return new root  
            return leftNode;
            */

            // right rotate is simply mirror code from left rotate
            var X = subtreeRootNode.Left;
            subtreeRootNode.ReplaceLeftNodeWith(X.Right);
            if (X.Right != null)
            {
                X.Right.ReplaceParentNodeWith(subtreeRootNode);
            }
            if (X != null)
            {
                X.ReplaceParentNodeWith(subtreeRootNode.Parent);
            }
            if (subtreeRootNode.Parent == null)
            {
                RootNode = X;
            }
            else
            {
                if (subtreeRootNode == subtreeRootNode.Parent.Right)
                {
                    subtreeRootNode.Parent.ReplaceRightNodeWith(X);
                }
                if (subtreeRootNode == subtreeRootNode.Parent.Left)
                {
                    subtreeRootNode.Parent.ReplaceLeftNodeWith(X);
                }
            }

            X.ReplaceRightNodeWith(subtreeRootNode);//put subtreeRootNode on X's right
            if (subtreeRootNode != null)
            {
                subtreeRootNode.ReplaceParentNodeWith(X);
            }
        }

        /// <summary>
        /// A utility function to left rotate subtree rooted with subtreeRootNode
        /// </summary>
        private void LeftRotate(RedBlackTreeNode<T> subtreeRootNode)
        {
            /*var rightNode = (RedBlackTreeNode<T>)subtreeRootNode.Right;
            var subtreeRootNodeParent = subtreeRootNode.Parent;
            var T2 = rightNode.Left;

            // Perform rotation  
            rightNode.ReplaceLeftNodeWith(subtreeRootNode);
            subtreeRootNode.ReplaceRightNodeWith(T2);

            rightNode.ReplaceParentNodeWith(subtreeRootNodeParent);

            return rightNode;*/

            var Y = subtreeRootNode.Right; // set Y
            subtreeRootNode.ReplaceRightNodeWith(Y.Left); //turn Y's left subtree into subtreeRootNode's right subtree
            if (Y.Left != null)
            {
                Y.Left.ReplaceParentNodeWith(subtreeRootNode);
            }
            if (Y != null)
            {
                Y.ReplaceParentNodeWith(subtreeRootNode.Parent); //link subtreeRootNode's parent to Y
            }
            if (subtreeRootNode.Parent == null)
            {
                RootNode = Y;
            }
            else
            {
                if (subtreeRootNode == subtreeRootNode.Parent.Left)
                {
                    subtreeRootNode.Parent.ReplaceLeftNodeWith(Y);
                }
                else
                {
                    subtreeRootNode.Parent.ReplaceRightNodeWith(Y);
                }
            }

            Y.ReplaceLeftNodeWith(subtreeRootNode); //put subtreeRootNode on Y's left

            if (subtreeRootNode != null)
            {
                subtreeRootNode.ReplaceParentNodeWith(Y);
            }
        }
    }


    public class RedBlackTreeNode<T> : BinaryTreeNode<T>
    {
        public RedBlackTreeNode(T key) : base(key)
        {
            IsBlack = false;
        }

        public bool IsBlack { get; private set; }

        public void SetColor(bool isBlack)
        {
            IsBlack = isBlack;
        }
    }
}
