using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Codility.L6
{
    [TestClass]
    public class MaxProductOfThree
    {
        [TestMethod]
        public void TestMethod1()
        {
            var solution = new Solution().solution(new []{ -5, 5, -5, 4 });
        }


        class Solution
        {
            public int solution(int[] A)
            {
                Array.Sort(A);

                int res1 = A[A.Length - 3] * A[A.Length - 2] * A[A.Length - 1];


                int res2 = 0;
                if (A[1] < 0)
                {
                    res2 = A[0] * A[1] * A[A.Length - 1];
                }

                return Math.Max(res1, res2);
            }
        }
    }
}