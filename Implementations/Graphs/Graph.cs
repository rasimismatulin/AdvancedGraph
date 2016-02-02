using System;
using System.Collections.Generic;
using AdvancedGraph.Enums;
using AdvancedGraph.Factories;
using AdvancedGraph.Interfaces;

namespace AdvancedGraph.Implementations.Graphs
{
    public class Graph<TVertex, TEdge> : IGraph<TVertex, TEdge>
    {
        protected IList<IVertex<TVertex>> VertexSet;
        protected ITypedSet<IVertexId, IEdge<TEdge>> EdgeSet;

        protected IEdgeManager<TEdge> EdgeManager;
        protected IVertexManager<TVertex> VertexManager;

        public Graph(GraphTypes graphType, SetTypes setType)
        {
            EdgeManager = EdgeManagerFactory<TEdge>.CreateEdgeManager(graphType);
            VertexManager = VertexManagerFactory<TVertex>.CreateVertexManager(graphType);
            EdgeSet = EdgeSetFactory<TEdge>.CreateEdge(setType);
            VertexSet = new List<IVertex<TVertex>>();
        }
        public void AddVertex(IVertexId vertexId, TVertex vertexData)
        {
            var newVertex = VertexManager.CreateVertex(vertexId, vertexData);
            VertexSet.Add(newVertex);
            EdgeSet.AddNode(newVertex.VertexId);
        }
        public void RemoveVertex(IVertexId vertexId)
        {
            var deletingVertex = VertexManager.CreateEmptyVertex(vertexId);
            VertexSet.Remove(deletingVertex);
            EdgeSet.RemoveNode(vertexId);
        }
        public void AddEdge(IEdgeId edgeId, TEdge edgeData)
        {
            var newEdge = EdgeManager.CreateEdge(edgeId, edgeData);
            EdgeManager.AddEdge(EdgeSet, newEdge);
        }
        public void RemoveEdge(IEdgeId edgeId)
        {
            var deletingEdge = EdgeManager.CreateEmptyEdge(edgeId);
            EdgeManager.AddEdge(EdgeSet, deletingEdge);
        }
        public IEnumerable<IEdge<TEdge>> GetEdges(IVertexId vertexId)
        {
            return EdgeManager.GetEdges(EdgeSet, vertexId);
        }
        public IEnumerable<IEdge<TEdge>> GetInEdges(IVertexId vertexId)
        {
           return EdgeManager.GetInEdges(EdgeSet, vertexId);
        }
        public IEnumerable<IEdge<TEdge>> GetOutEdges(IVertexId vertexId)
        {
            return EdgeManager.GetOutEdges(EdgeSet, vertexId);
        }

        public void EdgeSetToConsole()
        {
            EdgeSet.ToConsole();
        }

        public void VertexSetToConsole()
        {
            Console.WriteLine("=== Printing vertex set ===");
            foreach (var vertex in VertexSet)
            {
                Console.WriteLine("Vertex: {0}  Data: {1}",vertex.VertexId, vertex.VertexData);
            }
            Console.WriteLine("=== Vertex set count: {0} ===", VertexSet.Count);
        }

        public int VertexDedree(IVertexId vertexId)
        {
            return -1;
        }
        public int VertexInDedree(IVertexId vertexId)
        {
            return -1;
        }

        public int VertexOutDedree(IVertexId vertexId)
        {
            return -1;
        }
    }
}
