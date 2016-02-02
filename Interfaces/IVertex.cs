namespace AdvancedGraph.Interfaces
{
    public interface IVertex<TVertex>
    {
        IVertexId VertexId { get; }
        TVertex VertexData { get; set; }
    }
}
