using System.Collections.Generic;
using System.Linq;

namespace Codility.L11
{
    internal class DevisorsData
    {
        public Dictionary<int, List<int>> Devisors(int max)
        {
            var data = new Dictionary<int, List<int>>();

            int runner = 1;
            while (runner < max)
            {
                data[runner] = new List<int>() { 1};
                runner++;
            }


            int i = 2;
            while (i < max)
            {
                int k = i;

                while (k < max)
                {
                    data[k].Add(i);
                    k += i;
                }

                i++;
            }

            return data;
        }

        public Dictionary<int, List<int>> Result(int[] values)
        {
            var data = new Dictionary<int, List<int>>();
            for (int i = 0; i < values.Length; i++)
            {
                data[values[i]] = new List<int>() {};
            }
            var max = values.Max();

            for (int i = 0; i < values.Length; i++)
            {
                int k = values[i];

                while (k <= max)
                {
                    if (data.ContainsKey(k))
                    {
                        data[k].Add(values[i]);
                    }
                    k += values[i];
                }
            }
            return data;
        }

        public Dictionary<int, bool> Primes(int max)
        {
            var data = new Dictionary<int, bool>();

            int runner = 1;
            while (runner < max)
            {
                data[runner] = true;
                runner++;
            }

            int i = 2;
            while (i < max )
            {
                int k = i * i;

                while (k < max)
                { 
                    data[k] = false;
                    k += i;
                }
                i++;
            }

            return data;    
        }

        public int[] SemiPrimesRangCount(int max)
        {
            Dictionary<int, bool> primesDic = Primes(max);
            Dictionary<int, List<int>> devisorsDic = Devisors(max);
            var result = new int[max+1];

            int totalSemiPrimes = 0;
            for (int i = 1;i < max; i++)
            {
                result[i] = totalSemiPrimes;

                 if(devisorsDic[i].Count == 3)
                {
                    int v = devisorsDic[i][1];
                    if (v * v == i)
                    {
                        result[i] = ++totalSemiPrimes;
                    }
                }
                else if(devisorsDic[i].Count == 4)
                {
                    int v = devisorsDic[i][1];
                    int vv = devisorsDic[i][2];
                    if (primesDic[v] & primesDic[vv])
                    {
                        result[i] = ++totalSemiPrimes;
                    }

                }
            }

            return result;
        }


        public int[] SemiPrimesInRanges(int N, int[] P, int[] Q) 
        {
            int[] ints = SemiPrimesRangCount(N+1);

            var result = new int[P.Length];

            for (int i = 0; i < P.Length; i++)
            {
                var from = ints[P[i]-1];
                var to = ints[Q[i]];

                result[i] = to - from;
            }

            return result ;
        }
    }

}
