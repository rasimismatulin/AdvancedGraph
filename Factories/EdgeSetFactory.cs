using AdvancedGraph.Enums;
using AdvancedGraph.Exceptions;
using AdvancedGraph.Implementations.Sets;
using AdvancedGraph.Interfaces;

namespace AdvancedGraph.Factories
{
    internal static class EdgeSetFactory<TEdge>
    {
        public static ITypedSet<IVertexId, IEdge<TEdge>> CreateEdge(SetTypes setType)
        {
            switch (setType)
            {
                case SetTypes.List:
                    return new BaseListSet<IVertexId, IEdge<TEdge>>();
                case SetTypes.Matrix:
                    return new BaseArraySet<IVertexId, IEdge<TEdge>>();
                default:
                    throw new UnknownSetType();
            }
        }
    }
}
