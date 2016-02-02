using System;

namespace AdvancedGraph.Exceptions
{
    public class UnknownVertexType : ApplicationException
    {
        public UnknownVertexType(string message = "Vertex type can not be realized!") : base(message)
        {
        }

        public UnknownVertexType(string message, Exception inner) : base(message, inner)
        {
        }

        public UnknownVertexType(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        { }
    }
}