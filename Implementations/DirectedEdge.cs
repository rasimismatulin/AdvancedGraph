using AdvancedGraph.Interfaces;

namespace AdvancedGraph.Implementations
{
    public class DirectedEdge<TEdge> : BaseEdge<TEdge>, IDirectedEdge<TEdge>
    {
        public IVertexId OutboundVertex { get; }
        public DirectedEdge(IEdgeId edgeId, IVertexId outboundVertex)
            : base(edgeId)
        {
            OutboundVertex = outboundVertex;
        }
        public DirectedEdge(IVertexId vertex1, IVertexId vertex2, string name, IVertexId outboundVertex)
            : base(vertex1, vertex2, name)
        {
            OutboundVertex = outboundVertex;
        }

        public override bool Equals(object obj)
        {
            var dEdge = obj as DirectedEdge<TEdge>;
            return dEdge != null &&
                   dEdge.EdgeId.Equals(EdgeId) &&
                   dEdge.OutboundVertex.Equals(OutboundVertex);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode() * 397) ^ (OutboundVertex?.GetHashCode() ?? 0);
            }
        }
        public override string ToString()
        {
            return $"{EdgeId} [{OutboundVertex}->x]}}";
        }
    }
}
