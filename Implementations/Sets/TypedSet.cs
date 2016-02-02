using System;
using System.Collections.Generic;
using AdvancedGraph.Interfaces;

namespace AdvancedGraph.Implementations.Sets
{
    public abstract class TypedSet<TIndex, TData> : KeyPersonalizator<TIndex, int>, ITypedSet<TIndex, TData>
    {
        protected const int DefaultCapacity = 4;

        #region Body methods
        public void AddNode(TIndex index)
        {
            GraphContracts.AssumeNotNull(index, nameof(index), "Node index can not be null!");
            var size = GetCurrentLength();
            int? newIndex = HasDeletedIndex() ? RestoreDeletedIndex(index) : Capacity;
            if (Capacity == size)
            {
                EnsureCapacity(size + 1);
            }
            AddIndex(index, newIndex.Value);
            if (!newIndex.HasValue)
                throw new ArgumentException("Новое значение индекса не определено!");
            InitNewNode(newIndex.Value);
        }
        public void RemoveNode(TIndex index)
        {
            GraphContracts.AssumeNotNull(index, nameof(index), "Node index can not be null!");
            var reformedIndex = RemoveIndex(index);
            TerminateNode(reformedIndex);
        }
        public bool HasNode(TIndex index)
        {
            GraphContracts.AssumeNotNull(index, nameof(index), "Node index can not be null!");
            return HasKey(index);
        }
        public int GetNodeCount()
        {
            return Capacity;
        }
        public void AddData(TIndex iIndex, TIndex jIndex, TData data)
        {
            GraphContracts.AssumeNotNull(iIndex, nameof(iIndex), "Node index can not be null!");
            GraphContracts.AssumeNotNull(jIndex, nameof(jIndex), "Node index can not be null!");
            GraphContracts.AssumeNotNull(data, nameof(data), "Data can not be null!");
            var iReformedIndex = GetIndex(iIndex);
            var jReformedIndex = GetIndex(jIndex);
            AddData(iReformedIndex, jReformedIndex, data);
        }
        public void AddSimplifiedData(TIndex iIndex, TIndex jIndex, TData data)
        {
            GraphContracts.AssumeNotNull(iIndex, nameof(iIndex), "Node index can not be null!");
            GraphContracts.AssumeNotNull(jIndex, nameof(jIndex), "Node index can not be null!");
            GraphContracts.AssumeNotNull(data, nameof(data), "Data can not be null!");
            var iReformedIndex = GetIndex(iIndex);
            var jReformedIndex = GetIndex(jIndex);
            AddSimplifiedData(iReformedIndex, jReformedIndex, data);
        }
        public void RemoveData(TIndex iIndex, TIndex jIndex, TData data)
        {
            GraphContracts.AssumeNotNull(iIndex, nameof(iIndex), "Node index can not be null!");
            GraphContracts.AssumeNotNull(jIndex, nameof(jIndex), "Node index can not be null!");
            GraphContracts.AssumeNotNull(data, nameof(data), "Data can not be null!");
            var iReformedIndex = GetIndex(iIndex);
            var jReformedIndex = GetIndex(jIndex);
            RemoveData(iReformedIndex, jReformedIndex, data);
        }
        public void RemoveSimplifiedData(TIndex iIndex, TIndex jIndex, TData data)
        {
            GraphContracts.AssumeNotNull(iIndex, nameof(iIndex), "Node index can not be null!");
            GraphContracts.AssumeNotNull(jIndex, nameof(jIndex), "Node index can not be null!");
            GraphContracts.AssumeNotNull(data, nameof(data), "Data can not be null!");
            var iReformedIndex = GetIndex(iIndex);
            var jReformedIndex = GetIndex(jIndex);
            RemoveSimplifiedData(iReformedIndex, jReformedIndex, data);
        }

        #endregion

        #region Finding methods
        public IEnumerable<TData> Find(TIndex index)
        {
            var constIndex = GetIndex(index);
            return Find(constIndex, item => true);
        }

        public IEnumerable<TData> FindData(TIndex index, TData data)
        {
            var constIndex = GetIndex(index);
            return Find(constIndex, item => item.Equals(data));
        }

        public IEnumerable<TData> FindSimplified(TIndex index)
        {
            var constIndex = GetIndex(index);
            return FindSimple(constIndex, item => true);
        }

        public IEnumerable<TData> FindSimplifiedData(TIndex index, TData data)
        {
            var constIndex = GetIndex(index);
            return FindSimple(constIndex, item => item.Equals(data));
        }
        #endregion Finding methods

        #region Abstract methods
        public abstract void ToConsole();
        protected abstract int GetCurrentLength();
        protected abstract void EnsureCapacity(int size);
        protected abstract void InitNewNode(int newNode);
        protected abstract void TerminateNode(int termNode);
        protected abstract void AddData(int iIndex, int jIndex, TData data);
        protected abstract void AddSimplifiedData(int iIndex, int jIndex, TData data);
        protected abstract void RemoveSimplifiedData(int iIndex, int jIndex, TData data);
        protected abstract void RemoveData(int iIndex, int jIndex, TData data);
        protected abstract IEnumerable<TData> Find(int index, Func<TData, bool> pred);
        protected abstract IEnumerable<TData> FindSimple(int index, Func<TData, bool> pred);

        #endregion
    }
}
