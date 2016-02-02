using System;
using System.Collections.Generic;
using System.Linq;

namespace AdvancedGraph.Implementations.Sets
{
    public class BaseListSet<TIndex, TData> : TypedSet<TIndex, TData>
    {
        private List<KeyValuePair<int, TData>>[] _dataList;

        public BaseListSet()
        {
            _dataList = new List<KeyValuePair<int, TData>>[DefaultCapacity];
        }


        #region Body methods
        protected override int GetCurrentLength()
        {
            return _dataList.Length;
        }
        protected override void EnsureCapacity(int size)
        {
            ArrayHelper.EnsureCapacity(ref _dataList, size);
        }
        protected override void InitNewNode(int newNode)
        {
            _dataList[newNode] = new List<KeyValuePair<int, TData>>();
        }
        protected override void TerminateNode(int termNode)
        {
            _dataList[termNode] = default(List<KeyValuePair<int, TData>>);
        }
        protected override void AddData(int iIndex, int jIndex, TData data)
        {
            _dataList[iIndex].Add(new KeyValuePair<int, TData>(jIndex, data));
        }
        protected override void RemoveData(int iIndex, int jIndex, TData data)
        {
            var removed = _dataList[iIndex].First(x => x.Value.Equals(data) && x.Key.Equals(jIndex));
            _dataList[iIndex].Remove(removed);
        }
        protected override void AddSimplifiedData(int iIndex, int jIndex, TData data)
        {
            AddData(iIndex, jIndex, data);
            if (iIndex != jIndex)
                AddData(jIndex, iIndex, data);
        }
        protected override void RemoveSimplifiedData(int iIndex, int jIndex, TData data)
        {
            RemoveData(iIndex, jIndex, data);
            if (iIndex != jIndex)
                RemoveData(jIndex, iIndex, data);
        }
        public override void ToConsole()
        {
            var indexes = GetKeys();
            foreach (var index in indexes)
            {
                Console.Write("{0} -> ", index);
                var reformedIndex = GetIndex(index);
                foreach (var data in _dataList[reformedIndex])
                {
                    Console.Write("{0,3}  ", data);
                }
                Console.Write("\n");
            }
        }
        #endregion


        #region Find methods
       /// <summary>
       /// 
       /// </summary>
        protected override IEnumerable<TData> Find(int index, Func<TData, bool> pred)
        {
            var resultList = new List<TData>();
            resultList.AddRange(_dataList[index].Select(x => x.Value));

            var indexes = GetIndexes();
            foreach (var ind in indexes.Where(ind => ind != index))
            {
                resultList.AddRange(from item in _dataList[ind]
                                    where item.Key.Equals(index) && pred.Invoke(item.Value)
                                    select item.Value);
            }
            return resultList;
        }
        protected override IEnumerable<TData> FindSimple(int index, Func<TData, bool> pred)
        {
            return from item in _dataList[index]
                   where pred.Invoke(item.Value)
                   select item.Value;
        }
        #endregion


        //#region Find methos

        //public IEnumerable<TData> FindAll(TIndex index)
        //{
        //    var constIndex = GetIndex(index);
        //    var resultList = new List<TData>();
        //    resultList.AddRange(_dataList[constIndex].Select(x => x.Value));
        //    var indexes = GetIndexes();

        //    foreach (var ind in indexes.Where(ind => ind != constIndex))
        //    {
        //        resultList.AddRange(_dataList[ind].Where(x => x.Key.Equals(index)).Select(x => x.Value));
        //    }
        //    return resultList;
        //}

        //public IEnumerable<TData> FindAll(TIndex index, TData data)
        //{
        //    var constIndex = GetIndex(index);
        //    var resultList = new List<TData>();
        //    resultList.AddRange(_dataList[constIndex].Where(x => x.Value.Equals(data)).Select(x => x.Value));
        //    var indexes = GetIndexes();

        //    foreach (var ind in indexes.Where(ind => ind != constIndex))
        //    {
        //        resultList.AddRange(_dataList[ind].Where(x => x.Key.Equals(index) && x.Value.Equals(data)).
        //            Select(x => x.Value));
        //    }
        //    return resultList;
        //}

        //public IEnumerable<TData> FindAll(TIndex iIndex, TIndex jIndex)
        //{
        //    var iConstIndex = GetIndex(iIndex);
        //    var jConstIndex = GetIndex(jIndex);
        //    var resultList = new List<TData>();
        //    resultList.AddRange(_dataList[iConstIndex].Where(x => x.Key.Equals(jIndex)).
        //        Select(x => x.Value));
        //    if (!iIndex.Equals(jIndex))
        //        resultList.AddRange(_dataList[jConstIndex].Where(x => x.Key.Equals(iIndex)).
        //            Select(x => x.Value));
        //    return resultList;
        //}

        //public IEnumerable<TData> FindAll(TIndex iIndex, TIndex jIndex, TData data)
        //{
        //    var iConstIndex = GetIndex(iIndex);
        //    var jConstIndex = GetIndex(jIndex);
        //    var resultList = new List<TData>();

        //    resultList.AddRange(_dataList[iConstIndex].Where(x => x.Key.Equals(jIndex) && x.Value.Equals(data)).
        //        Select(x => x.Value));
        //    if (!iIndex.Equals(jIndex))
        //        resultList.AddRange(_dataList[jConstIndex].Where(x => x.Key.Equals(iIndex) && x.Value.Equals(data)).
        //            Select(x => x.Value));
        //    return resultList;
        //}

        //public IEnumerable<TData> FindAll(TData data)
        //{
        //    var resultList = new List<TData>();
        //    var indexes = GetKeys();
        //    foreach (var reformedIndex in indexes.Select(GetIndex))
        //    {
        //        var tempList = _dataList[reformedIndex].Where(x => x.Value.Equals(data)).
        //            Select(x => x.Value).ToList();
        //        resultList.AddRange(tempList);
        //    }
        //    return resultList;
        //}

        //public IEnumerable<TData> FindSimple(TIndex index)
        //{
        //    var constIndex = GetIndex(index);
        //    return _dataList[constIndex].Select(x => x.Value);
        //}

        //public IEnumerable<TData> FindSimple(TIndex index, TData data)
        //{
        //    var constIndex = GetIndex(index);
        //    return _dataList[constIndex].Where(x => x.Value.Equals(data)).Select(x => x.Value);
        //}

        //public IEnumerable<TData> FindSimple(TIndex iIndex, TIndex jIndex)
        //{
        //    var iConstIndex = GetIndex(iIndex);
        //    return _dataList[iConstIndex].Where(x => x.Key.Equals(jIndex)).
        //        Select(x => x.Value);
        //}

        //public IEnumerable<TData> FindSimple(TIndex iIndex, TIndex jIndex, TData data)
        //{
        //    var iConstIndex = GetIndex(iIndex);
        //    var jConstIndex = GetIndex(jIndex);
        //    return _dataList[iConstIndex].Where(x => x.Key.Equals(jIndex) && x.Value.Equals(data)).
        //        Select(x => x.Value);
        //}

        //#endregion
    }
}
