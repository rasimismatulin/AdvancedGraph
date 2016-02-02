using AdvancedGraph.Enums;
using AdvancedGraph.Factories;
using AdvancedGraph.Interfaces;

namespace AdvancedGraph.Managers
{
    internal class BaseVertexManager<TVertex> : IVertexManager<TVertex>
    {
        public IVertex<TVertex> CreateVertex(IVertexId vertexId, TVertex vertexData)
        {
            var newVertex = VertexFactory<TVertex>.CreateVertex(VertexTypes.Base, vertexId);
            newVertex.VertexData = vertexData;
            return newVertex;
        }
        public IVertex<TVertex> CreateEmptyVertex(IVertexId vertexId)
        {
            var newVertex = VertexFactory<TVertex>.CreateVertex(VertexTypes.Base, vertexId);
            return newVertex;
        }
    }
}
