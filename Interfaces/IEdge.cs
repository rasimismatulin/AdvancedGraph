namespace AdvancedGraph.Interfaces
{
    public interface IEdge<TEdge>
    {
        IEdgeId EdgeId { get; }
        TEdge EdgeData { get; set; }
    }
}
