using AdvancedGraph.Enums;
using AdvancedGraph.Exceptions;
using AdvancedGraph.Interfaces;
using AdvancedGraph.Managers;

namespace AdvancedGraph.Factories
{
    internal static class EdgeManagerFactory<TEdge>
    {
        public static IEdgeManager<TEdge> CreateEdgeManager(GraphTypes type)
        {
            switch (type)
            {
                case GraphTypes.Directed:
                    return new DirectedEdgeManager<TEdge>();
                case GraphTypes.Undirected:
                    return new BaseEdgeManager<TEdge>();
                default:
                    throw new UnknownGraphType();
            }
        }
    }
}
