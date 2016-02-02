using AdvancedGraph.Enums;
using AdvancedGraph.Exceptions;
using AdvancedGraph.Implementations;
using AdvancedGraph.Interfaces;

namespace AdvancedGraph.Factories
{
    internal static class VertexFactory<TVertex>
    {
        public static IVertex<TVertex> CreateVertex(VertexTypes vertexType, IVertexId vertexId)
        {
            switch (vertexType)
            {
                case VertexTypes.Base:
                    return new BaseVertex<TVertex>(vertexId);
                default:
                    throw new UnknownVertexType();
            }
        }
    }
}
