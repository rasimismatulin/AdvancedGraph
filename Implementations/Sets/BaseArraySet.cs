using System;
using System.Collections.Generic;
using System.Linq;

namespace AdvancedGraph.Implementations.Sets
{
    public class BaseArraySet<TIndex, TData> : TypedSet<TIndex, TData>
    {
        private List<TData>[,] _dataList;

        public BaseArraySet()
        {
            _dataList = new List<TData>[DefaultCapacity, DefaultCapacity];
        }

        #region Body methods
        protected override int GetCurrentLength()
        {
            return _dataList.GetLength(0);
        }
        protected override void EnsureCapacity(int size)
        {
            ArrayHelper.EnsureCapacity(ref _dataList, size, size);
        }
        protected override void InitNewNode(int newNode)
        {
            var size = GetNodeCount();
            for (var i = 0; i < size; i++)
            {
                _dataList[i, newNode] = new List<TData>();
                _dataList[newNode, i] = new List<TData>();
            }
        }
        protected override void TerminateNode(int termNode)
        {
            var size = GetNodeCount();
            for (var i = 0; i < size; i++)
            {
                _dataList[i, termNode] = default(List<TData>);
                _dataList[termNode, i] = default(List<TData>);
            }
        }
        protected override void AddData(int iIndex, int jIndex, TData data)
        {
            _dataList[iIndex, jIndex].Add(data);
        }
        protected override void RemoveData(int iIndex, int jIndex, TData data)
        {
            _dataList[iIndex, jIndex].Remove(data);
        }
        protected override void AddSimplifiedData(int iIndex, int jIndex, TData data)
        {
            if (iIndex > jIndex)
            {
                var tempInt = iIndex;
                iIndex = jIndex;
                jIndex = tempInt;
            }
            _dataList[iIndex, jIndex].Add(data);
        }
        protected override void RemoveSimplifiedData(int iIndex, int jIndex, TData data)
        {
            if (iIndex > jIndex)
            {
                var tempInt = iIndex;
                iIndex = jIndex;
                jIndex = tempInt;
            }
            _dataList[iIndex, jIndex].Remove(data);
        }
        public override void ToConsole()
        {
            var keys = GetKeys();
            Console.Write(" ");
            var iKeys = keys as TIndex[] ?? keys.ToArray();
            foreach (var key in iKeys)
            {
                Console.Write("{0,3}", key);
            }
            Console.Write("\n");
            foreach (var iKey in iKeys)
            {
                Console.Write("{0}", iKey);
                var iInd = GetIndex(iKey);
                foreach (var jKey in iKeys)
                {
                    var jInd = GetIndex(jKey);
                    Console.Write("{0,3}", _dataList[iInd, jInd].Count);
                }
                Console.Write("\n");
            }
        }
        #endregion


        #region Find methods
        protected override IEnumerable<TData> Find(int index, Func<TData, bool> pred)
        {
            var resultList = new List<TData>();
            var indexes = GetIndexes();


            foreach (var ind in indexes)
            {
                if (ind == index)
                {
                    resultList.AddRange(from item in _dataList[index, index]
                                        where pred.Invoke(item)
                                        select item);
                    continue;
                }
                resultList.AddRange(from item in _dataList[ind, index]
                                    where pred.Invoke(item)
                                    select item);
                resultList.AddRange(from item in _dataList[index, ind]
                                    where pred.Invoke(item)
                                    select item);
            }
            return resultList;
        }
        protected override IEnumerable<TData> FindSimple(int index, Func<TData, bool> pred)
        {
            var resultList = new List<TData>();
            var indexes = GetIndexes();

            foreach (var ind in indexes)
            {
                if (ind < index)
                    resultList.AddRange(from item in _dataList[ind, index]
                                        where pred.Invoke(item)
                                        select item);
                else if (ind > index)
                    resultList.AddRange(from item in _dataList[index, ind]
                                        where pred.Invoke(item)
                                        select item);
                else
                    resultList.AddRange(from item in _dataList[index, index]
                                        where pred.Invoke(item)
                                        select item);
            }
            return resultList;
        }
        #endregion Find methods


        //        #region Findings
        //        public IEnumerable<TData> FindAll(TIndex index)
        //        {
        //            GraphContracts.AssumeNotNull(index, "index");
        //            var resultList = new List<TData>();
        //            var indexes = GetIndexes();
        //            var constIndex = GetIndex(index);


        //            foreach (var ind in indexes)
        //            {
        //                if (ind == constIndex)
        //                {
        //                    resultList.AddRange(_dataList[constIndex, constIndex]);
        //                    continue;
        //                }
        //                resultList.AddRange(_dataList[ind, constIndex]);
        //                resultList.AddRange(_dataList[constIndex, ind]);
        //            }
        //            return resultList;
        //        }

        //        public IEnumerable<TData> FindSimple(TIndex index)
        //        {
        //            GraphContracts.AssumeNotNull(index, "index");
        //            var resultList = new List<TData>();
        //            var indexes = GetIndexes();
        //            var constIndex = GetIndex(index);

        //            foreach (var ind in indexes)
        //            {
        //                if (ind < constIndex)
        //                    resultList.AddRange(_dataList[ind, constIndex]);
        //                else if (ind > constIndex)
        //                    resultList.AddRange(_dataList[constIndex, ind]);
        //                else
        //                    resultList.AddRange(_dataList[constIndex, ind]);
        //            }

        //            return resultList;
        //        }


        //        public IEnumerable<TData> FindAll(TIndex index, TData data)
        //        {
        //            GraphContracts.AssumeNotNull(index, "index");
        //            var resultList = new List<TData>();
        //            var indexes = GetIndexes();
        //            var constIndex = GetIndex(index);

        //            foreach (var ind in indexes)
        //            {
        //                if (ind == constIndex)
        //                {
        //                    resultList.AddRange(_dataList[constIndex, constIndex].Where(x => x.Equals(data)));
        //                    continue;
        //                }
        //                resultList.AddRange(_dataList[ind, constIndex].Where(x => x.Equals(data)));
        //                resultList.AddRange(_dataList[constIndex, ind].Where(x => x.Equals(data)));
        //            }
        //            return resultList;
        //        }
        //        public IEnumerable<TData> FindAll(TIndex iIndex, TIndex jIndex)
        //        {
        //            var resultList = new List<TData>();
        //            var iConstIndex = GetIndex(iIndex);
        //            var jConstIndex = GetIndex(jIndex);

        //            resultList.AddRange(_dataList[iConstIndex, jConstIndex]);
        //            if (!iConstIndex.Equals(jConstIndex))
        //                resultList.AddRange(_dataList[jConstIndex, iConstIndex]);
        //            return resultList;
        //        }

        //        public IEnumerable<TData> FindAll(TIndex iIndex, TIndex jIndex, TData data)
        //        {
        //            var resultList = new List<TData>();
        //            var iConstIndex = GetIndex(iIndex);
        //            var jConstIndex = GetIndex(jIndex);

        //            resultList.AddRange(_dataList[iConstIndex, jConstIndex].Where(x => x.Equals(data)));
        //            if (!iConstIndex.Equals(jConstIndex))
        //                resultList.AddRange(_dataList[jConstIndex, iConstIndex].Where(x => x.Equals(data)));
        //            return resultList;
        //        }

        //        public IEnumerable<TData> FindAll(TData data)
        //        {
        //            var resultList = new List<TData>();
        //            var keys = GetKeys();
        //            var iKeys = keys as TIndex[] ?? keys.ToArray();
        //            foreach (var iKey in iKeys)
        //            {
        //                var iInd = GetIndex(iKey);
        //                foreach (var jKey in iKeys)
        //                {
        //                    var jInd = GetIndex(jKey);
        //                    resultList.AddRange(_dataList[iInd, jInd].Where(x => x.Equals(data)));
        //                }
        //            }
        //            return resultList;
        //        }



        //        public IEnumerable<TData> FindSimple(TIndex index, TData data)
        //        {
        //            var resultList = new List<TData>();
        //            var indexes = GetIndexes();
        //            var constIndex = GetIndex(index);

        //            foreach (var ind in indexes)
        //            {
        //                if (ind < constIndex)
        //                    resultList.AddRange(_dataList[ind, constIndex].Where(x => x.Equals(data)));
        //                else if (ind > constIndex)
        //                    resultList.AddRange(_dataList[constIndex, ind].Where(x => x.Equals(data)));
        //                else
        //                    resultList.AddRange(_dataList[constIndex, ind].Where(x => x.Equals(data)));
        //            }

        //            return resultList;
        //        }

        //        public IEnumerable<TData> FindSimple(TIndex iIndex, TIndex jIndex)
        //        {
        //            var iConstIndex = GetIndex(iIndex);
        //            var jConstIndex = GetIndex(jIndex);
        //            if (iConstIndex > jConstIndex)
        //            {
        //                var temp = iConstIndex;
        //                iConstIndex = jConstIndex;
        //                jConstIndex = temp;
        //            }
        //            return _dataList[iConstIndex, jConstIndex];
        //        }

        //        public IEnumerable<TData> FindSimple(TIndex iIndex, TIndex jIndex, TData data)
        //        {
        //            var iConstIndex = GetIndex(iIndex);
        //            var jConstIndex = GetIndex(jIndex);
        //            if (iConstIndex > jConstIndex)
        //            {
        //                var temp = iConstIndex;
        //                iConstIndex = jConstIndex;
        //                jConstIndex = temp;
        //            }
        //            return _dataList[iConstIndex, jConstIndex].Where(x => x.Equals(data));
        //        }
        //#endregion
    }
}
