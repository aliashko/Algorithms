using DataStructures.Graphs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace DataStructures.UnitTests.Graphs
{
    [TestClass]
    public class GraphTests
    {
        [TestMethod]
        [DynamicData(nameof(GetGraphsWithCycles), DynamicDataSourceType.Method)]
        public void VertexesCanBeCorrectlyConnected(IGraph<int> sampleGraph)
        {
            CollectionAssert.AreEquivalent(new[] { 1, 2, 3 }, sampleGraph.GetAllConnectedVertexes(0).ToArray());
            CollectionAssert.AreEquivalent(new[] { 0, 4 }, sampleGraph.GetAllConnectedVertexes(1).ToArray());
            CollectionAssert.AreEquivalent(new[] { 0, 5, 6, 3 }, sampleGraph.GetAllConnectedVertexes(2).ToArray());
            CollectionAssert.AreEquivalent(new[] { 0, 7, 2 }, sampleGraph.GetAllConnectedVertexes(3).ToArray());
            CollectionAssert.AreEquivalent(new[] { 1, 8 }, sampleGraph.GetAllConnectedVertexes(4).ToArray());
            CollectionAssert.AreEquivalent(new[] { 2, 8 }, sampleGraph.GetAllConnectedVertexes(5).ToArray());
            CollectionAssert.AreEquivalent(new[] { 2 }, sampleGraph.GetAllConnectedVertexes(6).ToArray());
            CollectionAssert.AreEquivalent(new[] { 3 }, sampleGraph.GetAllConnectedVertexes(7).ToArray());
            CollectionAssert.AreEquivalent(new[] { 4, 9, 5 }, sampleGraph.GetAllConnectedVertexes(8).ToArray());
            CollectionAssert.AreEquivalent(new[] { 8 }, sampleGraph.GetAllConnectedVertexes(9).ToArray());
        }

        [TestMethod]
        public void VertexesCanBeRemovedFromMatrixGraph()
        {
            var sampleGraph = CreateSampleGraph(new MatrixGraph<int>(10));
            sampleGraph.RemoveVertex(2);
            sampleGraph.RemoveVertex(8);

            CollectionAssert.AreEquivalent(new[] { 2, 4 }, sampleGraph.GetAllConnectedVertexes(0).Select(x => sampleGraph[x]).ToArray());
            CollectionAssert.AreEquivalent(new[] { 1, 8 }, sampleGraph.GetAllConnectedVertexes(3).Select(x => sampleGraph[x]).ToArray());
            Assert.AreEqual(0, sampleGraph.GetAllConnectedVertexes(5).ToArray().Length);
            Assert.AreEqual(0, sampleGraph.GetAllConnectedVertexes(9).ToArray().Length);
            CollectionAssert.AreEquivalent(new[] { 2 }, sampleGraph.GetAllConnectedVertexes(4).Select(x => sampleGraph[x]).ToArray());
        }

        [TestMethod]
        public void VertexesCanBeRemovedFromListGraph()
        {
            var sampleGraph = CreateSampleGraph(new ListGraph<int>(10));
            sampleGraph.RemoveVertex(2);
            sampleGraph.RemoveVertex(7);

            CollectionAssert.AreEquivalent(new[] { 2, 4 }, sampleGraph.GetAllConnectedVertexes(0).Select(x => sampleGraph[x]).ToArray());
            CollectionAssert.AreEquivalent(new[] { 1, 8 }, sampleGraph.GetAllConnectedVertexes(2).Select(x => sampleGraph[x]).ToArray());
            Assert.AreEqual(0, sampleGraph.GetAllConnectedVertexes(4).ToArray().Length);
            Assert.AreEqual(0, sampleGraph.GetAllConnectedVertexes(7).ToArray().Length);
            CollectionAssert.AreEquivalent(new[] { 2 }, sampleGraph.GetAllConnectedVertexes(3).Select(x => sampleGraph[x]).ToArray());
        }

        [TestMethod]
        [DynamicData(nameof(GetGraphsWithCycles), DynamicDataSourceType.Method)]
        public void GraphCanBeCorrectlyTraversedInBreadth(IGraph<int> sampleGraph)
        {
            var traversedNodex = sampleGraph.BreadthFirstTraversal();
            CollectionAssert.AreEquivalent(new[] { 0,1,2,3,4,5,6,7,8,9 }, traversedNodex.ToArray());
        }

        [TestMethod]
        [DynamicData(nameof(GetGraphsWithCycles), DynamicDataSourceType.Method)]
        public void GraphCanBeCorrectlyTraversedInDepth(IGraph<int> sampleGraph)
        {
            var traversedNodex = sampleGraph.DepthFirstTraversal();
            CollectionAssert.AreEquivalent(new[] { 0,1,4,8,9,5,2,6,3,7 }, traversedNodex.ToArray());
        }

        [TestMethod]
        [DynamicData(nameof(GetGraphsWithCycles), DynamicDataSourceType.Method)]
        public void CycleCanBeFoundInTheGraphWhichContainCycle(IGraph<int> sampleGraph)
        {
            var isContainCycle = sampleGraph.IsContainCycle();
            Assert.IsTrue(isContainCycle);
        }

        [TestMethod]
        [DynamicData(nameof(GetGraphsWithoutCycles), DynamicDataSourceType.Method)]
        public void CycleCannotBeFoundInTheGraphWithoutCycle(IGraph<int> sampleGraph)
        {
            var isContainCycle = sampleGraph.IsContainCycle();
            Assert.IsFalse(isContainCycle);
        }

        public static System.Collections.Generic.IEnumerable<object[]> GetGraphs(bool addCycles)
        {
            yield return new object[] { CreateSampleGraph(new MatrixGraph<int>(10), addCycles) };
            yield return new object[] { CreateSampleGraph(new ListGraph<int>(10), addCycles) };
        }

        public static System.Collections.Generic.IEnumerable<object[]> GetGraphsWithCycles() => GetGraphs(true);

        public static System.Collections.Generic.IEnumerable<object[]> GetGraphsWithoutCycles() => GetGraphs(false);

        private static IGraph<int> CreateSampleGraph(IGraph<int> initializedGraph, bool addCycles = true)
        {
            initializedGraph.SetVertex(9, 10);
            initializedGraph.SetVertex(4, 5);
            initializedGraph.SetVertex(5, 6);
            initializedGraph.SetVertex(6, 7);
            initializedGraph.SetVertex(7, 8);
            initializedGraph.SetVertex(0, 1);
            initializedGraph.SetVertex(1, 2);
            initializedGraph.SetVertex(2, 3);
            initializedGraph.SetVertex(3, 4);
            initializedGraph.SetVertex(8, 9);

            initializedGraph.AddEdge(2, 5);
            initializedGraph.AddEdge(2, 6);
            initializedGraph.AddEdge(3, 7);
            initializedGraph.AddEdge(4, 8);
            initializedGraph.AddEdge(0, 1);
            initializedGraph.AddEdge(0, 2);
            initializedGraph.AddEdge(0, 3);
            initializedGraph.AddEdge(1, 4);
            initializedGraph.AddEdge(8, 9);

            if (addCycles)
            {
                initializedGraph.AddEdge(2, 3);
                initializedGraph.AddEdge(5, 8);
            }

            return initializedGraph;
        }
    }
}
