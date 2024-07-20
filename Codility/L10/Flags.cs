using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Codility.L10
{
    [TestClass]
    public class Flags
    {
        [TestMethod]
        public void TestMethod()
        {
            int[] arr = { 1, 5, 3, 4, 3, 4, 1, 2, 3, 4, 6, 2 };
            //int[] peaks = new Peaks(arr).Result();
            //int[] peakDistances = new Distances(peaks).Result();
            //int[] ints = new Multiplicators(2, 9).Result();

            int maxFlags = new MaxFlags(arr).Result();
        }

        private class MaxFlags
        {
            private readonly int[] _arr;

            public MaxFlags(int[] arr)
            {
                _arr = arr;
            }

            public int Result()
            {
                int[] peakList = new Peaks(_arr).Result();
                if (peakList.Length == 0)
                {
                    return 0;
                }
                if (peakList.Length == 1)
                {
                    return 1;
                }

                var maxFalgs = 1;
                var nextEnd = 0;

                for (int k = 2; k < peakList.Length + 1; k++)
                {
                    var flags = 1;
                    var start = 0;
                    var shouldSetNextEnd = true;
                   
                    var end = nextEnd;
                    while (
                        flags < k &&
                        start < peakList.Length &&
                        end < peakList.Length)
                    {
                        var distanceToNextPeak = peakList[end] - peakList[start];

                        if (distanceToNextPeak >= k)
                        {
                            if (shouldSetNextEnd)
                            {
                                nextEnd = end;
                                shouldSetNextEnd = false;
                            }
                            flags++;
                            start = end;
                        }
                        else
                        {
                            end++;
                        }
                        
                    }

                    if (maxFalgs < flags)
                    {
                        maxFalgs = flags;
                    }
                    else if(maxFalgs == flags) 
                    {
                        break;
                    }
                }

                return maxFalgs;
            }
        }

        private class Peaks
        {
            private readonly int[] _values;

            public Peaks(int[] values)
            {
                _values = values;
            }

            public int[] Result()
            {
                List<int> result = new List<int>();

                for (int i = 1; i < _values.Length - 1; i++)
                {
                    int left = _values[i - 1];
                    int right = _values[i + 1];
                    int center = _values[i];

                    if (left < center && center > right)
                    {
                        result.Add(i);
                        i++;
                    };
                }

                return result.ToArray();
            }

        }
    }
}
