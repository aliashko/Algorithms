using DataStructures.Arrays;
using System;
using System.Net.Http.Headers;

namespace DataStructures.Graphs
{
    /// <summary>
    /// Graph with is represented with array of lists
    /// Queries like whether there is an edge from vertex ‘u’ to vertex ‘v’ can be done O(V).
    /// Adding a vertex is O(1) time
    /// Pros: Space efficiency (O(|V|+|E|)), Fast adding vertex
    /// Cons: Slow querying (O(V))
    /// </summary>
    public class ListGraph<T> : IGraph<T>
    {
        public ListGraph(int initialVertexCount = 0)
        {
            AdjacencyList = new ArrayList<ArrayList<int>>();
            Vertexes = new ArrayList<T>();
            for (int i = 0; i < initialVertexCount; i++)
            {
                AddVertex(default);
            }
        }

        public int VertexesCount { get; private set; }

        public T this[int index] => Vertexes[index];

        public ArrayList<T> Vertexes { get; private set; }

        private ArrayList<ArrayList<int>> AdjacencyList;

        public int AddVertex(T value)
        {
            Vertexes.Add(value);
            AdjacencyList.Add(new ArrayList<int>());
            VertexesCount++;
            return VertexesCount - 1;
        }

        public void SetVertex(int index, T value)
        {
            GuardIndex(index, nameof(index));
            Vertexes[index] = value;
        }

        public void AddEdge(int index1, int index2)
        {
            GuardIndex(index1, nameof(index1));
            GuardIndex(index2, nameof(index2));
            if (index1 == index2) throw new ArgumentException("indexes shouldn't be the same");

            foreach (var connection in AdjacencyList[index1])
            {
                if(connection == index2) throw new ArgumentException("edge has already added");
            }

            AdjacencyList[index1].Add(index2);
            AdjacencyList[index2].Add(index1);        
        }

        public void RemoveVertex(int index)
        {
            GuardIndex(index, nameof(index));

            Vertexes.Remove(index);
            AdjacencyList.Remove(index);
            VertexesCount--;

            // TODO: very bad (O = n^2) removing algorythm
            foreach (var vertexConnections in AdjacencyList)
            {
                for (var i = 0; i < vertexConnections.GetLength(); i++)
                {
                    if (vertexConnections[i] > index) vertexConnections[i]--;
                    else if (vertexConnections[i] == index)
                    {
                        vertexConnections.Remove(i);
                        i--;
                    }
                }
            }
        }

        public ArrayList<int> GetAllConnectedVertexes(int parentIndex)
        {
            var connectionsIndexes = new ArrayList<int>();
            connectionsIndexes.AddRange(AdjacencyList[parentIndex].ToArray());
            return connectionsIndexes;
        }

        /// <summary>
        /// Traverse graph layer by layer, all neighbours first, then their neighbors and so on
        /// Usages: searching closest neighbours - closest friends in social networks, 
        /// search engines crawler, GPS (search all neighboring areas)
        /// </summary>
        public ArrayList<int> BreadthFirstTraversal(int startIndex = 0)
        {
            var isVisited = new bool[VertexesCount];
            var traversedNodes = new ArrayList<int>();
            var traversalQueue = new Queue<int>();

            traversalQueue.Enqueue(startIndex);
            isVisited[startIndex] = true;

            while(traversalQueue.Count() != 0)
            {
                var indexToProcess = traversalQueue.Dequeue();
                traversedNodes.Add(indexToProcess);

                foreach(var connectedNodeIndex in GetAllConnectedVertexes(indexToProcess))
                {
                    if (!isVisited[connectedNodeIndex])
                    {
                        traversalQueue.Enqueue(connectedNodeIndex);
                        isVisited[connectedNodeIndex] = true;
                    }
                }
            }

            return traversedNodes;
        }

        /// <summary>
        /// Traverse graph recursively in the deep till there is no more connected node.
        /// Usages: Detecting cycle in a graph, Path Finding,  Topological Sorting (sort with dependencies)
        /// </summary>
        public ArrayList<int> DepthFirstTraversal(int startIndex = 0)
        {
            var _isVisited = new bool[VertexesCount];
            return DepthFirstTraversalRecursive(startIndex, _isVisited);

            ArrayList<int> DepthFirstTraversalRecursive(int currentParentIndex, bool[] isVisited)
            {
                var traversedNodes = new ArrayList<int>();
                traversedNodes.Add(currentParentIndex);
                isVisited[currentParentIndex] = true;

                foreach (var connectedNodeIndex in GetAllConnectedVertexes(currentParentIndex))
                {
                    if (!isVisited[connectedNodeIndex])
                    {
                        traversedNodes.AddRange(
                            DepthFirstTraversalRecursive(connectedNodeIndex, isVisited).ToArray());
                    }
                }

                return traversedNodes;
            }
        }

        public bool IsContainCycle(int startIndex = 0)
        {
            var _isVisited = new bool[VertexesCount];
            return IsContainCycleRecursive(startIndex, _isVisited, -1);

            bool IsContainCycleRecursive(int currentIndex, bool[] isVisited, int previousParentIndex)
            {
                isVisited[currentIndex] = true;

                foreach (var connectedNodeIndex in GetAllConnectedVertexes(currentIndex))
                {
                    if (!isVisited[connectedNodeIndex])
                    {
                        if (IsContainCycleRecursive(connectedNodeIndex, isVisited, currentIndex))
                            return true;
                    }
                    else if(connectedNodeIndex != previousParentIndex)
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        private void GuardIndex(int index, string nameOfParam)
        {
            if (index < 0 || index >= VertexesCount) throw new ArgumentException($"{nameOfParam} is out of range");
        }
    }
}
