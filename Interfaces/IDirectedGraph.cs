using System.Collections.Generic;

namespace AdvancedGraph.Interfaces
{
    public interface IDirectedGraph<out TEdge>
    {
        IEnumerable<TEdge> GetInEdges(IVertexId vertexId);
        int VertexInDedree(IVertexId vertexId);

        IEnumerable<TEdge> GetOutEdges(IVertexId vertexId);
        int VertexOutDedree(IVertexId vertexId);
    }
}
