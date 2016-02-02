using System.Collections.Generic;
using System.Linq;
using AdvancedGraph.Enums;
using AdvancedGraph.Factories;
using AdvancedGraph.Interfaces;

namespace AdvancedGraph.Managers
{
    internal class DirectedEdgeManager<TEdge> : IEdgeManager<TEdge>
    {
        public IEdge<TEdge> CreateEdge(IEdgeId edgeId, TEdge edgeData)
        {
            var newEdge = (IDirectedEdge<TEdge>)EdgeFactory<TEdge>.CreateEdge(EdgeTypes.DirectedEdge, edgeId);
            newEdge.EdgeData = edgeData;

            return newEdge;
        }
        public IEdge<TEdge> CreateEmptyEdge(IEdgeId edgeId)
        {
            var newEmptyEdge = (IDirectedEdge<TEdge>)EdgeFactory<TEdge>.CreateEdge(EdgeTypes.DirectedEdge, edgeId);
            return newEmptyEdge;
        }
        public void AddEdge(ITypedSet<IVertexId, IEdge<TEdge>> typedSet, IEdge<TEdge> edge)
        {
            typedSet.AddData(edge.EdgeId.Vertex1Id, edge.EdgeId.Vertex2Id, edge);
        }
        public void RemoveEdge(ITypedSet<IVertexId, IEdge<TEdge>> typedSet, IEdge<TEdge> edge)
        {
            typedSet.RemoveData(edge.EdgeId.Vertex1Id, edge.EdgeId.Vertex2Id, edge);
        }
        public IEnumerable<IEdge<TEdge>> GetEdges(ITypedSet<IVertexId, IEdge<TEdge>> typedSet, IVertexId vertexId)
        {
            return typedSet.Find(vertexId);
        }
        public IEnumerable<IEdge<TEdge>> GetInEdges(ITypedSet<IVertexId, IEdge<TEdge>> typedSet, IVertexId vertexId)
        {
            return typedSet.Find(vertexId).Where(x=> !Equals(((IDirectedEdge<TEdge>)x).OutboundVertex, vertexId) 
            || x.EdgeId.Vertex1Id.Equals(x.EdgeId.Vertex2Id));
        }
        public IEnumerable<IEdge<TEdge>> GetOutEdges(ITypedSet<IVertexId, IEdge<TEdge>> typedSet, IVertexId vertexId)
        {
            return typedSet.Find(vertexId).Where(x => Equals(((IDirectedEdge<TEdge>)x).OutboundVertex, vertexId));
        }
    }
}
