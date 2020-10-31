using System;

namespace DataStructures.Trees
{
    /// <summary>
    /// Tries are used for storing strings and autocomplete features (prefix search)
    /// Main adventage: Fast retrieving, inserting, deleting - O(key.length)
    ///                 Other self-balanced BST require O(L Log n) for all operations where n is total number words and L is length of word
    /// Main Disadventage: Trie requires a lot of memory
    /// </summary>
    public class Trie
    {
        // Alphabet size (# of symbols) 
        static readonly int ALPHABET_SIZE = 26;

        public Trie()
        {
            RootNode = new TrieNode(default);
        }

        public TrieNode RootNode { get; private set; }

        public TrieNode FindNodeByKey(string key)
        {
            var currentNode = RootNode;

            foreach(var keyChar in key)
            {
                var nextNode = currentNode.Children[CharToIndex(keyChar)];
                if (nextNode == null) return null;
                currentNode = nextNode;
            }

            if (!currentNode.IsEndOfWord) return null;
            return currentNode;
        }

        public TrieNode Insert(string key)
        {
            var currentNode = RootNode;

            foreach (var keyChar in key)
            {
                var charIndex = CharToIndex(keyChar);
                var nextNode = currentNode.Children[charIndex];
                if(nextNode == null)
                {
                    nextNode = currentNode.Children[charIndex] = new TrieNode(keyChar);
                }
                currentNode = nextNode;
            }
            if (currentNode.IsEndOfWord) throw new ArgumentException("Key is already exist");
            currentNode.SetAsEndOfWord();
            return currentNode;
        }

        public void Remove(string key)
        {
            RemoveRecursively(RootNode, key);
        }

        private void RemoveRecursively(TrieNode subTreeRootNode, string key, int depth = 0)
        {
            var charIndex = CharToIndex(key[depth]);
            var subTreeNode = subTreeRootNode.Children[charIndex];
            if (subTreeNode == null) throw new ArgumentException("Key doesn't exists");

            if (depth + 1 == key.Length)
            {
                if (!subTreeNode.IsEndOfWord) throw new ArgumentException("Key doesn't exists");
                subTreeNode.SetAsWalkThroughNode();
            }
            else {
                RemoveRecursively(subTreeNode, key, depth + 1);
            }

            //Remove empty node
            if (IsEmptyNode(subTreeNode))
            {
                subTreeRootNode.Children[charIndex] = null;
            }
        }

        private bool IsEmptyNode(TrieNode node)
        {
            if (node == null) return true;

            for(int i = 0; i < ALPHABET_SIZE; i++)
            {
                if (node.Children[i] != null) return false;
            }

            return true;
        }

        private int CharToIndex(char keyChar)
        {
            var charIndex = keyChar - 'a';
            if (charIndex < 0 || charIndex > ALPHABET_SIZE) throw new ArgumentException("Symbol in key is out of range of acceptable symbols");
            return charIndex;
        }

        public class TrieNode
        {
            public TrieNode(char key)
            {
                Key = key;
                Children = new TrieNode[ALPHABET_SIZE];
            }

            public char Key { get; }

            public bool IsEndOfWord { get; private set; }

            public TrieNode[] Children { get; }

            public void SetAsEndOfWord() => IsEndOfWord = true;

            public void SetAsWalkThroughNode() => IsEndOfWord = false;
        }
    }
}
