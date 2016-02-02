using System;

namespace AdvancedGraph.Exceptions
{
    internal class UnknownGraphType : ApplicationException
    {

        public UnknownGraphType(string message = "Graph type can not be realized!") : base(message)
        {
        }

        public UnknownGraphType(string message, Exception inner) : base(message, inner)
        {
        }

        public UnknownGraphType(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        { }
    }
}
