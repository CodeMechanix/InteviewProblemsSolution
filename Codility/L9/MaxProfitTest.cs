using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Codility.L9
{
    [TestClass]
    public class MaxProfitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var solution = new Solution().solution(new []
            {
                23171 ,
                21011,
                21123,
                21366,
                21013,
                21367
            });
        }

        class Solution
        {
            public int solution(int[] A)
            {
                int profit = 0;
                int low = A[0], high = A[0];
                for (int i = 0; i < A.Length; i++)
                {
                    var num = A[i];
                    if (num < low)
                    {
                        profit = Math.Max( high - low, profit);
                        low = num;
                        high = num;
                    }
                    else
                    {
                        if (num> high)
                        {
                            high = num;
                        }
                    }
                }
                profit = Math.Max(high - low, profit);

                return profit;
            }
        }
    }
}