namespace AdvancedGraph.Interfaces
{
    public interface IDirectedEdge<TEdge> : IEdge<TEdge>
    {
        IVertexId OutboundVertex { get; }
    }
}
