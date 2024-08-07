using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility.L11
{
    internal class SieveOfEratos
    {
        private readonly int _length;

        public SieveOfEratos(int length)
        {
            _length = length;
        }


        public bool[] Result()
        {
            var filtered = new bool[_length];
            for (int i = 0; i < filtered.Length; i++)
            {
                filtered[i] = true;
            }


            int index = 2;

            while (index * index < _length) {
                
                int k = index * index;

                while (k < filtered.Length) {

                    if (filtered[k])
                    {
                        filtered[k] = false;
                    }

                    k = k+index;
                }

                index++;    
            }



            return filtered;
        }





    }
}
