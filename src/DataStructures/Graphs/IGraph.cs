using DataStructures.Arrays;

namespace DataStructures.Graphs
{
    public interface IGraph<T>
    {
        void SetVertex(int index, T value);
        void AddEdge(int index1, int index2, bool directed = false);
        void RemoveVertex(int index);
        ArrayList<int> GetAllConnectedVertexes(int parentIndex);

        ArrayList<int> BreadthFirstTraversal(int startIndex = 0);
        ArrayList<int> DepthFirstTraversal(int startIndex = 0);
        bool IsContainCycle(int startIndex = 0);

        int VertexesCount { get; }
        T this[int index] { get; }
    }
}
