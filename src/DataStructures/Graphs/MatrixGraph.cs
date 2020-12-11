using DataStructures.Arrays;
using System;

namespace DataStructures.Graphs
{
    /// <summary>
    /// Graph with is represented with 2D Adjacency matrix
    /// Removing an edge takes O(1), 
    /// Queries like whether there is an edge from vertex ‘u’ to vertex ‘v’ are efficient and can be done O(1).
    /// Adding a vertex is O(V^2) time
    /// Pros: Quick querying and removing elements
    /// Cons: Consumes more space (O(V^2)) Even if the graph is sparse(contains less number of edges), it consumes the same space. Slow adding of vertex
    /// </summary>
    public class MatrixGraph<T> : IGraph<T>
    {
        public MatrixGraph(int vertexesCount)
        {
            VertexesCount = vertexesCount;
            Matrix = new int[vertexesCount][];
            for(int i = 0; i< vertexesCount; i++)
            {
                Matrix[i] = new int[vertexesCount];
            }

            Vertexes = new T[vertexesCount];
        }

        public int VertexesCount { get; }

        public T this[int index] => Vertexes[index];

        public T[] Vertexes;

        private int[][] Matrix;

        public void SetVertex(int index, T value)
        {
            GuardIndex(index, nameof(index));
            Vertexes[index] = value;
        }

        public void AddEdge(int index1, int index2, bool directed = false)
        {
            GuardIndex(index1, nameof(index1));
            GuardIndex(index2, nameof(index2));
            if(index1 == index2) throw new ArgumentException("indexes shouldn't be the same");

            Matrix[index1][index2] = 1;
            if (!directed)
            {
                Matrix[index2][index1] = 1;
            }
        }

        public void RemoveVertex(int index)
        {
            GuardIndex(index, nameof(index));
            
            Vertexes[index] = default;
            for (int i = 0; i < VertexesCount; i++) {
                Matrix[index][i] = 0;
                Matrix[i][index] = 0;
            }
        }

        public ArrayList<int> GetAllConnectedVertexes(int parentIndex)
        {
            var connections = new ArrayList<int>();
            for(int i = 0; i < VertexesCount; i++)
            {
                if (Matrix[parentIndex][i] != 0) connections.Add(i);
            }

            return connections;
        }

        public ArrayList<int> BreadthFirstTraversal(int startIndex = 0)
        {
            throw new NotImplementedException();
        }

        public ArrayList<int> DepthFirstTraversal(int startIndex = 0)
        {
            throw new NotImplementedException();
        }

        public bool IsContainCycle(int startIndex = 0)
        {
            throw new NotImplementedException();
        }

        private void GuardIndex(int index, string nameOfParam)
        {
            if (index < 0 || index >= VertexesCount) throw new ArgumentException($"{nameOfParam} is out of range");
        }
    }
}
