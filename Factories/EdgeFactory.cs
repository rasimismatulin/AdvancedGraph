using AdvancedGraph.Enums;
using AdvancedGraph.Exceptions;
using AdvancedGraph.Implementations;
using AdvancedGraph.Interfaces;

namespace AdvancedGraph.Factories
{
    internal static class EdgeFactory<TEdge>
    {
        public static IEdge<TEdge> CreateEdge(EdgeTypes edgeType, IEdgeId edgeId)
        {
            switch (edgeType)
            {
                case EdgeTypes.UndirectedEdge:
                    return new BaseEdge<TEdge>(edgeId);
                case EdgeTypes.DirectedEdge:
                    return new DirectedEdge<TEdge>(edgeId, edgeId.Vertex1Id);
                default:
                    throw new UnknownEdgeType();
            }
        }
    }
}
