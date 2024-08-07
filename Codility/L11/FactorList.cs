using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility.L11
{
    internal class FactorList
    {
        private readonly int _n;

        public FactorList(int n)
        {
            _n = n;
        }


        public int[] Result()
        {
            var factors = new int[_n];

            int index = 2;


            while (index * index < _n) 
            {
                int k = index * index;
                while (k < _n)
                {
                    if (factors[k] == 0)
                    {
                        factors[k] = index;
                    }
                    k += index;
                }
            
                index++;
            }


            return factors;
        }
    }
}
