using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Codility.L9
{
    [TestClass]
    public class MaxSliceSumTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            int solution = new Solution().solution(new[] { -5, -7, 3, -5, -2, 4, -1 /*3, 2, -6, 4, 0*/ });
        }


        class Solution
        {
            public int solution(int[] A)
            {
                Console.WriteLine(String.Join(",", A));
                int max = A[0], current = A[0];

                for (var index = 1; index < A.Length; index++)
                {
                    var number = A[index];

                    if (current < 0)
                    {
                        current = Math.Max(current + number, current);
                    }
                    else
                    {
                        current = Math.Max(current + number, 0);
                    }

                    max = Math.Max(max, current);
                }

                return max;
            }
        }
    }
}