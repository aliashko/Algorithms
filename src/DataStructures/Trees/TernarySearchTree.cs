using System;

namespace DataStructures.Trees
{
    /// <summary>
    /// Purpose the same as in tries
    /// Fast retrieving, inserting - O(key.length)
    /// More space effective than tries for less distributed words
    /// </summary>
    public class TernarySearchTree
    {
        public TernarySearchTree()
        {
        }

        public TernarySearchTreeNode RootNode { get; private set; }

        public TernarySearchTreeNode FindNodeByKey(string key)
        {
            var currentNode = RootNode;

            foreach(var keyChar in key)
            {
                if (currentNode == null) return null;

                if (keyChar < currentNode.Key) currentNode = currentNode.LeftNode;
                else if (keyChar > currentNode.Key) currentNode = currentNode.RightNode;
                else
                {
                    if (currentNode.IsEndOfWord) return currentNode;
                    currentNode = currentNode.EqualNode;
                }
            }

            return null;
        }
        /*
        public TernarySearchTreeNode Insert(string key)
        {
            var currentNode = RootNode;

            for (var i = 0; i < key.Length;)
            {
                var keyChar = key[i];

                if (RootNode == null)
                {
                    currentNode = RootNode = new TernarySearchTreeNode(keyChar);
                    i++;
                    continue;
                }

                if (currentNode.EqualNode == null)
                {
                    currentNode = currentNode.SetEqualNode(keyChar);
                    i++;
                }
                else
                {
                    if (keyChar == currentNode.EqualNode.Key)
                    {
                        currentNode = currentNode.EqualNode;
                        i++;
                    }
                    else if (keyChar < currentNode.EqualNode.Key)
                    {
                        if (currentNode.EqualNode.LeftNode == null) currentNode.EqualNode.SetLeftNode(keyChar);
                        currentNode = currentNode.EqualNode.LeftNode;
                        if (currentNode.Key == keyChar) i++;
                    }
                    else if (keyChar > currentNode.EqualNode.Key)
                    {
                        if (currentNode.EqualNode.RightNode == null) currentNode.EqualNode.SetRightNode(keyChar);
                        currentNode = currentNode.EqualNode.RightNode;
                        if (currentNode.Key == keyChar) i++;
                    }
                }
            }

            if (currentNode.IsEndOfWord) throw new ArgumentException("Key is already exist");
            currentNode.SetAsEndOfWord();
            return currentNode;
        }*/

        public TernarySearchTreeNode Insert(string key)
        {
            RootNode = InsertRecursive(key, RootNode, 0);
            return RootNode;
        }

        public TernarySearchTreeNode InsertRecursive(string key, TernarySearchTreeNode nodeToInsert, int index)
        {
            var keyChar = key[index];

            if(nodeToInsert == null)
            {
                nodeToInsert = new TernarySearchTreeNode(keyChar);
            }

            if (keyChar < nodeToInsert.Key)
            {
                nodeToInsert.SetLeftNode(InsertRecursive(key, nodeToInsert.LeftNode, index));
            }
            else if (keyChar == nodeToInsert.Key)
            {
                if (index < key.Length-1)
                {
                    nodeToInsert.SetEqualNode(InsertRecursive(key, nodeToInsert.EqualNode, ++index));
                }
                else
                {
                    nodeToInsert.SetAsEndOfWord();
                }
            }
            else
            {
                nodeToInsert.SetRightNode(InsertRecursive(key, nodeToInsert.RightNode, index));
            }

            return nodeToInsert;
        }

        public void Remove(string key)
        {
            // RemoveRecursively(RootNode, key);
        }

        public class TernarySearchTreeNode
        {
            public TernarySearchTreeNode(char key)
            {
                Key = key;
            }

            public char Key { get; }

            public bool IsEndOfWord { get; private set; }

            public TernarySearchTreeNode LeftNode { get; private set; }

            public TernarySearchTreeNode EqualNode { get; private set; }

            public TernarySearchTreeNode RightNode { get; private set; }

            public TernarySearchTreeNode SetLeftNode(TernarySearchTreeNode node) => LeftNode = node;
            public TernarySearchTreeNode SetLeftNode(char key) => LeftNode = new TernarySearchTreeNode(key);

            public TernarySearchTreeNode SetEqualNode(TernarySearchTreeNode node) => RightNode = node;
            public TernarySearchTreeNode SetEqualNode(char key) => EqualNode = new TernarySearchTreeNode(key);

            public TernarySearchTreeNode SetRightNode(TernarySearchTreeNode node) => EqualNode = node;
            public TernarySearchTreeNode SetRightNode(char key) => RightNode = new TernarySearchTreeNode(key);

            public void SetAsEndOfWord() => IsEndOfWord = true;
            public void SetAsWalkThroughNode() => IsEndOfWord = false;
        }
    }
}
