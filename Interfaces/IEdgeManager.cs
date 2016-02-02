using System.Collections.Generic;

namespace AdvancedGraph.Interfaces
{
    public interface IEdgeManager<TEdge>
    {
        IEdge<TEdge> CreateEdge(IEdgeId edgeId, TEdge edgeData);
        IEdge<TEdge> CreateEmptyEdge(IEdgeId edgeId);
        void AddEdge(ITypedSet<IVertexId, IEdge<TEdge>> typedSet, IEdge<TEdge> edge);
        void RemoveEdge(ITypedSet<IVertexId, IEdge<TEdge>> typedSet, IEdge<TEdge> edge);
        IEnumerable<IEdge<TEdge>> GetEdges(ITypedSet<IVertexId, IEdge<TEdge>> typedSet, IVertexId vertexId);
        IEnumerable<IEdge<TEdge>> GetInEdges(ITypedSet<IVertexId, IEdge<TEdge>> typedSet, IVertexId vertexId);
        IEnumerable<IEdge<TEdge>> GetOutEdges(ITypedSet<IVertexId, IEdge<TEdge>> typedSet, IVertexId vertexId);
    }
}
