using DataStructures.Arrays;

namespace DataStructures.Graphs
{
    public class DirectedGraph<T> : ListGraph<T>, IGraph<T>
    {
        public DirectedGraph(int initialVertexCount = 0) : base(initialVertexCount)
        {
        }

        public void AddEdge(int indexFrom, int indexTo) => base.AddEdge(indexFrom, indexTo, true);

        /// <summary>
        /// Returns elements indexes starting from most independent, finishing to most dependant ones
        /// Usage: "build systems" which should include dependent packages in correct order
        /// </summary>
        public ArrayList<int> TopologicalSort()
        {
            Stack<int> stack = new Stack<int>();

            // Mark all the vertices as not visited 
            var visited = new bool[VertexesCount];

            // Call the recursive helper function to store Topological Sort starting from all vertices one by one 
            for (int i = 0; i < VertexesCount; i++)
            {
                if (visited[i] == false)
                    TopologicalSortRecursive(i, visited, stack);
            }

            var sortedArray = new ArrayList<int>();
            sortedArray.AddRange(stack.ToArray());
            return sortedArray;

            // A recursive function used by topologicalSort 
            void TopologicalSortRecursive(int currentIndex, bool[] _visited, Stack<int> _stack)
            {
                // Mark the current node as visited. 
                _visited[currentIndex] = true;

                // Recur for all the vertices adjacent to this vertex 
                foreach (var connectedNodeIndex in GetAllConnectedVertexes(currentIndex))
                {
                    if (!_visited[connectedNodeIndex])
                        TopologicalSortRecursive(connectedNodeIndex, _visited, _stack);
                }

                // Push current vertex to stack which stores result 
                _stack.Push(currentIndex);
            }
        }
    }
}
