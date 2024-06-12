using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Codility.L6
{
    [TestClass]
    public class Triangle
    {
        [TestMethod]
        public void TestMethod1()
        {
            var solution = new Solution().solution(new []{int.MaxValue, int.MaxValue, int.MaxValue});
        }

        class Solution
        {
            public int solution(int[] A)
            {
                Array.Sort(A, (i, i1) => i-i1 );

                for (int i = 0; i < A.Length-2; i++)
                {
                    int first = A[i];
                    int second = A[i + 1];
                    int third = A[i + 2];

                    if (first < 0 || second  < 0 || third < 0)
                    {
                        continue;
                    }

                     
                    if (first+second > third &&
                        first+third > second &&
                        second + third> first)
                    {
                        return 1;
                    }
                }

                return 0;
            }
        }
    }
}
