using AdvancedGraph.Interfaces;

namespace AdvancedGraph.Implementations
{
    public class BaseVertex<TVertex> : IVertex<TVertex>
    {
        public IVertexId VertexId { get; }
        public TVertex VertexData { get; set; }
        public BaseVertex(IVertexId vertexId)
        {
            VertexId = vertexId;
        }
        public BaseVertex(string name)
        {
            VertexId = new BaseVertexId(name);
        }

        public override bool Equals(object obj)
        {
            var vertex = obj as BaseVertex<TVertex>;
            return vertex != null && VertexId.Equals(vertex.VertexId);
        }
        public override int GetHashCode()
        {
            return VertexId.GetHashCode();
        }
    }
}
