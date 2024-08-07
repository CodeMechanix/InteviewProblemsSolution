using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility.L11
{
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
                    if ( deviser % devisible != 0)
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
