using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;

namespace CodingPatterns.SlidingWindow
{
    [TestClass]
    public class MinSizeSubArraySum_Test
    {
        [TestMethod]
        public void TestMethod1()
        {
            var w = new FluidSlidingWindow([2, 1, 5, 2, 3, 2]);

            while (w.CanGrow()) {

                w.Grow();
                Debug.WriteLine(w.Sum);
            }
            while (w.CanShrink())
            {

                w.Shrink();
                Debug.WriteLine(w.Sum);
            }
        }

        [TestMethod]
        [DataRow(7, new int[] { 2, 1, 5, 2, 3, 2 }, 2)]
        [DataRow(7, new int[] { 2, 1, 5, 2, 8 }, 1)]
        [DataRow(8, new int[] { 3, 4, 1, 1, 6 }, 3)]
        public void TestMethod2(int max, int [] array, int expected)
        {
            var r = MinSizeSubArraySum.FindMinSubArray(max, array);
            r.ShouldBe(expected);
          
        }
      
    }

    class MinSizeSubArraySum
    {
        public static int FindMinSubArray(int S, int[] arr)
        {
            int minLength = arr.Length;
            var window = new FluidSlidingWindow(arr);

            while (window.CanGrow())
            {
                //grow while < S
                while (window.Sum < S && window.CanGrow())
                {
                    window.Grow();
                }
              
                //shrink while >= S
                while (window.Sum >= S && window.CanShrink())
                {
                    //update minLength
                    minLength = Math.Min(minLength, window.Length);
                    window.Shrink();
                }
                //repiat
            }
            return minLength;
        }
    }

    class FluidSlidingWindow
    {
        private readonly int[] _dataList;
        private int _windowStart;

        public int Sum { get; private set; }
        public int Length { get ; private set; }

        public FluidSlidingWindow(int[] dataList)
        {
            _dataList = dataList;
            _windowStart = 0;
            Length = 0;
            Sum = 0;
        }

        public IEnumerable<int> WindowsVlues()
        {
            for (int i = _windowStart; i <  Length ; i++)
            {
                yield return _dataList[i];
            }
        }

        public void Shrink()
        {
            Sum -= _dataList[_windowStart];
            _windowStart ++;
            Length --;
        }
        public void Grow()
        {
            Sum += _dataList[_windowStart + Length];  
            Length += 1;
        }

        public bool CanShrink()
        {
            return Length > 0;
        }
        public bool CanGrow()
        {
           return _windowStart + Length < _dataList.Length;
        }

      
    }
}
