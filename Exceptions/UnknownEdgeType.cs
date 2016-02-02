using System;

namespace AdvancedGraph.Exceptions
{
    internal class UnknownEdgeType : ApplicationException
    {

        public UnknownEdgeType(string message = "Edge type can not be realized!") : base(message)
        {
        }

        public UnknownEdgeType(string message, Exception inner) : base(message, inner)
        {
        }

        public UnknownEdgeType(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        { }
    }
}
