using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ElementsProgrammingInterviews.Arrays
{
    [TestClass]
    public class EvenUnclassifiedOdd_Test
    {
        [TestMethod]
        public void Main()
        {
            var o = new EvenUnclassifiedOdd([8, 2, 3, 4, 5, 9, 2, 8, 7, 3, 4, 9]);
            o.SortII();
        }

        
    }

    class EvenUnclassifiedOdd
    {
        private readonly int[] _array;
        private int _leftIndex;
        private int _rightIndex;
        private int _midRightIndex;
        private int _midLeftIndex;



        public EvenUnclassifiedOdd(int[] array)
        {
            _array = array;
            _leftIndex = 0;
            _rightIndex = array.Length-1;
        }



        /// <summary>
        /// input is an array of integers, and you have to reorder its entries so that the even entries appear first.
        /// </summary>
        public void Sort()
        {
            while (_leftIndex <= _rightIndex) 
            {
                if (IsEven(_array[_leftIndex])) 
                {
                    _leftIndex++;
                }
                else
                {
                    Swap(_leftIndex, _rightIndex);
                    _rightIndex--;
                }
            }
        }

        public void SortII()
        {
            while (_leftIndex <= _rightIndex)
            {
                if (IsEven(_array[_leftIndex]))
                {
                    _leftIndex++;
                }
                else
                {
                    if (!IsEven(_array[_rightIndex]))
                    {
                        _rightIndex--;

                    }
                    else
                    {
                        Swap(_leftIndex, _rightIndex);
                        _rightIndex--;
                    }
                }
            }
        }

        private bool IsEven(int num) 
        {
            return (num % 2 == 0);
        }

        private void Swap(int sourceIndex, int destIndex) 
        {
            var temp = _array[destIndex];
            _array[destIndex] = _array[sourceIndex];
            _array[sourceIndex] = temp;
        
        }
    }
}
