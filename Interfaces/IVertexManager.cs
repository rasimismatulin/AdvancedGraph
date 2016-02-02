namespace AdvancedGraph.Interfaces
{
    public interface IVertexManager<TVertex>
    {
        IVertex<TVertex> CreateVertex(IVertexId vertexId, TVertex vertexData);
        IVertex<TVertex> CreateEmptyVertex(IVertexId vertexId);
    }
}