using AdvancedGraph.Interfaces;

namespace AdvancedGraph.Implementations
{
    public class BaseVertexId : IVertexId
    {
        public string Name { get; }
        public BaseVertexId(string name)
        {
            Name = name;
        }

        public override bool Equals(object obj)
        {
            var basevertex = obj as BaseVertexId;
            return basevertex != null && Name.Equals(basevertex.Name);
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
        public override string ToString()
        {
            return Name;
        }

    }
}
