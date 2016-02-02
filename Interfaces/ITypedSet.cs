using System.Collections.Generic;

namespace AdvancedGraph.Interfaces
{
    public interface ITypedSet<in TIndex, TData>
    {
        void AddNode(TIndex index);
        void RemoveNode(TIndex index);
        bool HasNode(TIndex index);
        int GetNodeCount();

        void AddData(TIndex iIndex, TIndex jIndex, TData data);
        void AddSimplifiedData(TIndex iIndex, TIndex jIndex, TData data);
        void RemoveData(TIndex iIndex, TIndex jIndex, TData data);
        void RemoveSimplifiedData(TIndex iIndex, TIndex jIndex, TData data);

        IEnumerable<TData> Find(TIndex index);
        IEnumerable<TData> FindData(TIndex index, TData data);

        IEnumerable<TData> FindSimplified(TIndex index);
        IEnumerable<TData> FindSimplifiedData(TIndex index, TData data);


        void ToConsole();
    }
}
