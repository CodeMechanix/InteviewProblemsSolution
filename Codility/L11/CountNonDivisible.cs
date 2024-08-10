using System.Collections.Generic;
using System.Linq;

namespace Codility.L11
{
    class CountNonDivisibleQuick
    {
        private readonly int[] _ints;

        public CountNonDivisibleQuick(int[] ints)
        {
            _ints = ints;
        }

        //public int[] Result()
        //{
        //    int max = _ints.Max();
        //    var devisorsData = new DevisorsData().Result(max + 1);
        //    var counterDic = Counters();


        //    var arr = new int[_ints.Length];
        //    for (int i = 0; i < _ints.Length; i++)
        //    {
        //        int value = _ints[i];
        //        var countOfnotDevisors = _ints.Length - devisorsData[value].Count;


        //    }


        //}

        private Dictionary<int, int> Counters()
        {
            var dic = new Dictionary<int, int>();
            foreach (var i in _ints)
            {
                if (dic.ContainsKey(i))
                {
                    dic[i]++;
                }
                else
                {
                    dic[i] = 1;
                }

            }

            return dic;
        }

    }

    internal class CountNonDivisible
    {
        private readonly int[] _values;

        public CountNonDivisible(int[] values)
        {
            _values = values;
        }

        public int[] Result()
        {
            var results = new List<int>[_values.Length];


            for (int i = 0; i < _values.Length; i++)
            {
                int devisible = _values[i];
                if (results[i] == null)
                {
                    results[i] = new List<int>();
                }

                int k = i;
                while (k < _values.Length)
                {
                    int deviser = _values[k];
                    if (results[k] == null)
                    {
                        results[k] = new List<int>();
                    }

                    if (devisible % deviser != 0)
                    {
                        results[i].Add(deviser);
                    }
                    if (deviser % devisible != 0)
                    {
                        results[k].Add(devisible);
                    }

                    k++;
                }
            }

            return results.Select(x => x.Count).ToArray();
        }
    }
}
