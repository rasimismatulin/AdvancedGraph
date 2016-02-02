using AdvancedGraph.Enums;
using AdvancedGraph.Exceptions;
using AdvancedGraph.Interfaces;
using AdvancedGraph.Managers;

namespace AdvancedGraph.Factories
{
    internal static class VertexManagerFactory<TVertex>
    {
        public static IVertexManager<TVertex> CreateVertexManager(GraphTypes type)
        {
            if (type == GraphTypes.Directed || type == GraphTypes.Undirected)
            {
                return new BaseVertexManager<TVertex>();
            }
            throw new UnknownGraphType();
        }
    }
}
