using DataStructures.Graphs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructures.UnitTests.Graphs
{
    [TestClass]
    public class DirectedGraphTests
    {
        [TestMethod]
        public void DirectedGraphCanBeTopologicallySorted()
        {
            var graph = CreateSampleDirectedGraph();
            var sortedGraph = graph.TopologicalSort();
            CollectionAssert.AreEqual(new[] { 5, 4, 2, 3, 1, 0 }, sortedGraph.ToArray());
        }

        private static DirectedGraph<int> CreateSampleDirectedGraph()
        {
            var graph = new DirectedGraph<int>();
            graph.AddVertex(1);
            graph.AddVertex(2);
            graph.AddVertex(3);
            graph.AddVertex(4);
            graph.AddVertex(5);
            graph.AddVertex(6);

            graph.AddEdge(5, 2);
            graph.AddEdge(5, 0);
            graph.AddEdge(4, 0);
            graph.AddEdge(4, 1);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 1);

            return graph;
        }
    }
}
