using System;

namespace AdvancedGraph.Exceptions
{
    internal class UnknownSetType : ApplicationException
    {

        public UnknownSetType(string message = "Set type can not be realized!") : base(message)
        {
        }

        public UnknownSetType(string message, Exception inner) : base(message, inner)
        {
        }

        public UnknownSetType(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        { }
    }
}
