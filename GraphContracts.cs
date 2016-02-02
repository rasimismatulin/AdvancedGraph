using System;

namespace AdvancedGraph
{
    internal static class GraphContracts
    {
        public static string AssumeNotNullString<T>(T v)
        {
            return v == null ? "" : v.ToString();
        }
        public static void AssumeNotNull<T>(T v, string parameterName, string message = "Value can not be null!")
        {
            if (v.Equals(null))
                throw new ArgumentNullException(parameterName, message);
        }
    }
}
