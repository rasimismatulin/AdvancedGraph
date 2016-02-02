using System;
using System.Collections.Generic;
using System.Linq;

namespace AdvancedGraph.Implementations.Sets
{
    public class KeyPersonalizator<TKey, TIndex>
    {
        public int Capacity => _dictionary.Count;
        private readonly List<TIndex> _deletedIndexes;
        private readonly Dictionary<TKey, TIndex> _dictionary;
        protected KeyPersonalizator()
        {
            _dictionary = new Dictionary<TKey, TIndex>();
            _deletedIndexes = new List<TIndex>();
        }

        protected void AddIndex(TKey key, TIndex index)
        {
            GraphContracts.AssumeNotNull(key, $"{typeof (TKey)} key");
            GraphContracts.AssumeNotNull(key, $"{typeof(TIndex)} keyTIndex");
            if (_dictionary.ContainsKey(key))
                throw new ArgumentOutOfRangeException(nameof(key), "An element with the same key already exists.");
            _dictionary.Add(key, index);
        }
        protected TIndex RemoveIndex(TKey key)
        {
            GraphContracts.AssumeNotNull(key, $"{typeof (TKey)} key");
            if (!_dictionary.ContainsKey(key))
                throw new ArgumentOutOfRangeException(nameof(key), "An element with the same key already exists.");
            var removedIndex = GetIndex(key);
            _dictionary.Remove(key);
            _deletedIndexes.Add(removedIndex);
            return removedIndex;
        }
        protected TIndex RestoreDeletedIndex(TKey key)
        {
            GraphContracts.AssumeNotNull(key, $"{typeof (TKey)} key");
            if (!HasDeletedIndex())
                throw new KeyNotFoundException("This key is not in the dictionary!");
            
            var deletedIndex = _deletedIndexes[0];
            _deletedIndexes.RemoveAt(0);
            AddIndex(key, deletedIndex);
            return deletedIndex;
        }
        public TIndex GetIndex(TKey key)
        {
            GraphContracts.AssumeNotNull(key, $"{typeof (TKey)} key");
            if (!_dictionary.ContainsKey(key))
                throw new ArgumentOutOfRangeException(nameof(key), "An element with the same key not exists.");
            return _dictionary[key];
        }
        public bool HasDeletedIndex()
        {
            return _deletedIndexes.Count > 0;
        }
        public bool HasKey(TKey key)
        {
            GraphContracts.AssumeNotNull(key, $"{typeof(TKey)} key");
            return _dictionary.ContainsKey(key);
        }
        public IEnumerable<TKey> GetKeys()
        {
            return _dictionary.Select(dictItem => dictItem.Key);
        }
        public IEnumerable<TIndex> GetIndexes()
        {
            return _dictionary.Select(dictItem => dictItem.Value);
        }
    }
}
