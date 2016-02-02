using AdvancedGraph.Interfaces;

namespace AdvancedGraph.Implementations
{
    public class BaseEdgeId : IEdgeId
    {
        public BaseEdgeId(string name)
        {
            Name = name;
        }
        public BaseEdgeId(IVertexId vertex1, IVertexId vertex2, string name)
            : this(name)
        {

            Vertex1Id = vertex1;
            Vertex2Id = vertex2;
        }
        public IVertexId Vertex1Id { get; }
        public IVertexId Vertex2Id { get; }
        public string Name { get; }

        public override bool Equals(object obj)
        {
            var baseEdge = obj as BaseEdgeId;
            return baseEdge != null && 
                   baseEdge.Name.Equals(Name) && 
                   baseEdge.Vertex1Id.Equals(Vertex1Id) &&
                   baseEdge.Vertex2Id.Equals(Vertex2Id);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Name?.GetHashCode() ?? 0;
                hashCode = (hashCode*397) ^ (Vertex1Id?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (Vertex2Id?.GetHashCode() ?? 0);
                return hashCode;
            }
        }
        public override string ToString()
        {
            return $"Edge: {Name} <{Vertex1Id}-{Vertex2Id}>";
        }
    }
}
