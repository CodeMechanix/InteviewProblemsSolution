using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Codility.L10
{
    [TestClass]
    public class MinPerimeterRectangle
    {
        [TestMethod]
        public void TestMethod1()
        {

            DevisorList devisorList = new DevisorList(30);
            devisorList.GenerateDevisors();
            int v = devisorList.Min(pair => (pair.Item1 + pair.Item2) * 2);


        }
    }

    public class DevisorList : IEnumerable<Tuple<int, int>>
    {
        private readonly int _targetNumber;
        private IList<int> _devisorList;
        public DevisorList(int targetNumber)
        {
            _targetNumber = targetNumber;
            _devisorList = new List<int>();
        }

        public void GenerateDevisors()
        {
            int nextDevisor = 1;

            while (Math.Pow(nextDevisor, 2) <= _targetNumber)
            {
                if (_targetNumber %  nextDevisor  == 0)
                {
                    _devisorList.Add(nextDevisor);
                }

                nextDevisor++;
            }
        }


        public IEnumerator<Tuple<int, int>> GetEnumerator()
        {
           return new DivisorEnumerator(_devisorList, _targetNumber);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public class DivisorEnumerator : IEnumerator<Tuple<int, int>>
        {
            private readonly IEnumerable<int> _devisors;
            private readonly int _result;
            private int _position = -1;

            public DivisorEnumerator(IEnumerable<int> devisors, int result)
            {
                _devisors = devisors;
                _result = result;
            }

            private int SecondDevisor(int firstDevisor)
            {
                return _result / firstDevisor;
            }

            private Tuple<int, int> DevisorPair(int index)
            {
                int v = _devisors.ElementAt(index);

                return Tuple.Create(v, SecondDevisor(v));
            }

            public Tuple<int, int> Current => DevisorPair(_position);

            object IEnumerator.Current => Current;

            public void Dispose()
            {
                   
            }

            public bool MoveNext()
            {
                _position++;
                return _position < _devisors.Count();
            }

            public void Reset()
            {
                _position = -1;
            }
        }
    }
}
