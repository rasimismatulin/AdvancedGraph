namespace AdvancedGraph.Interfaces
{
    public interface IEdgeId
    {
        IVertexId Vertex1Id { get; }
        IVertexId Vertex2Id { get; }
        string Name { get; }
    }
}
