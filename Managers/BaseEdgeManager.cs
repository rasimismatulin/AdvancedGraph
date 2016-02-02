using System.Collections.Generic;
using AdvancedGraph.Enums;
using AdvancedGraph.Exceptions;
using AdvancedGraph.Factories;
using AdvancedGraph.Interfaces;

namespace AdvancedGraph.Managers
{
    internal class BaseEdgeManager<TEdge> : IEdgeManager<TEdge>
    {
        public IEdge<TEdge> CreateEdge(IEdgeId edgeId, TEdge edgeData)
        {
            var newEdge = EdgeFactory<TEdge>.CreateEdge(EdgeTypes.UndirectedEdge, edgeId);
            newEdge.EdgeData = edgeData;
            return newEdge;
        }
        public IEdge<TEdge> CreateEmptyEdge(IEdgeId edgeId)
        {
            var newEmptyEdge = EdgeFactory<TEdge>.CreateEdge(EdgeTypes.UndirectedEdge, edgeId);
            return newEmptyEdge;
        }
        public void AddEdge(ITypedSet<IVertexId, IEdge<TEdge>> typedSet, IEdge<TEdge> edge)
        {
            typedSet.AddSimplifiedData(edge.EdgeId.Vertex1Id, edge.EdgeId.Vertex2Id, edge);
        }
        public void RemoveEdge(ITypedSet<IVertexId, IEdge<TEdge>> typedSet, IEdge<TEdge> edge)
        {
            typedSet.RemoveSimplifiedData(edge.EdgeId.Vertex1Id, edge.EdgeId.Vertex2Id, edge);
        }
        public IEnumerable<IEdge<TEdge>> GetEdges(ITypedSet<IVertexId, IEdge<TEdge>> typedSet, IVertexId vertexId)
        {
            return typedSet.FindSimplified(vertexId);
        }
        public IEnumerable<IEdge<TEdge>> GetInEdges(ITypedSet<IVertexId, IEdge<TEdge>> typedSet, IVertexId vertexId)
        {
            throw new UnknownEdgeType("Can't call GetInEdges method for Base Edge");
        }
        public IEnumerable<IEdge<TEdge>> GetOutEdges(ITypedSet<IVertexId, IEdge<TEdge>> typedSet, IVertexId vertexId)
        {
            throw new UnknownEdgeType("Can't call GetOutEdges method for Base Edge");
        }
    }
}
