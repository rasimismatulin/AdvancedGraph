using AdvancedGraph.Interfaces;

namespace AdvancedGraph.Implementations
{
    public class BaseEdge<TEdge> : IEdge<TEdge>
    {
        public IEdgeId EdgeId { get; }
        public TEdge EdgeData { get; set; }
        public BaseEdge(IEdgeId edgeId)
        {
            GraphContracts.AssumeNotNull(edgeId, "edgeId");
            EdgeId = edgeId;
        }
        public BaseEdge(IVertexId vertexId1, IVertexId vertexId2, string name)
        {
            GraphContracts.AssumeNotNull(vertexId1, "vertexId1");
            GraphContracts.AssumeNotNull(vertexId2, "vertexId2");
            GraphContracts.AssumeNotNull(name, "name");
            EdgeId = new BaseEdgeId(vertexId1, vertexId2, name);
        }

        public override bool Equals(object obj)
        {
            var edge = obj as BaseEdge<TEdge>;
            return edge != null && EdgeId.Equals(edge.EdgeId);
        }
        public override int GetHashCode()
        {
            return EdgeId.GetHashCode();
        }
        public override string ToString()
        {
            return EdgeId.ToString();
        }
    }
}
