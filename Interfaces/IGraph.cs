using System.Collections.Generic;

namespace AdvancedGraph.Interfaces
{
    public interface IGraph<in TVertex, TEdge>
    {
        void AddVertex(IVertexId vertexId, TVertex vertexData);
        void RemoveVertex(IVertexId vertexId);
        void AddEdge(IEdgeId edgeId, TEdge edgeData);
        void RemoveEdge(IEdgeId edgeId);
        IEnumerable<IEdge<TEdge>> GetEdges(IVertexId vertexId);
        IEnumerable<IEdge<TEdge>> GetInEdges(IVertexId vertexId);
        IEnumerable<IEdge<TEdge>> GetOutEdges(IVertexId vertexId);
        void EdgeSetToConsole();
        void VertexSetToConsole();
        int VertexDedree(IVertexId vertexId);
    }
}
