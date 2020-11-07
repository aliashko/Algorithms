using DataStructures.Arrays;
using System;

namespace DataStructures.Graphs
{
    /// <summary>
    /// Graph with is represented with array of lists
    /// Queries like whether there is an edge from vertex ‘u’ to vertex ‘v’ can be done O(V).
    /// Adding a vertex is O(1) time
    /// Pros: Space efficiency (O(|V|+|E|)), Fast adding vertex
    /// Cons: Slow querying (O(V))
    /// </summary>
    public class ListGraph<T>
    {
        public ListGraph()
        {
            VertexesCount = 0;
            AdjacencyList = new ArrayList<ArrayList<int>>();
        }

        public int VertexesCount { get; private set; }

        public ArrayList<T> Vertexes;

        private ArrayList<ArrayList<int>> AdjacencyList;

        public int AddVertex(T value)
        {
            Vertexes.Add(value);
            AdjacencyList.Add(new ArrayList<int>());
            VertexesCount++;
            return VertexesCount - 1;
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

        private void GuardIndex(int index, string nameOfParam)
        {
            if (index < 0 || index >= VertexesCount) throw new ArgumentException($"{nameOfParam} is out of range");
        }
    }
}
