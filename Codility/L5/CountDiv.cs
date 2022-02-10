using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Codility.L5
{
    [TestClass]
    public class CountDiv
    {
        [TestMethod]
        public void TestMethod1()
        {
            int solution = new Solution().solution(0, 2000000000, 1);
        }
        class Solution
        {
            public int solution(int A, int B, int K)
            {
                int total = 0;

                for (int i = A; i <= B; i++)
                {
                    if (i % K == 0)
                    {
                        total++;
                    }
                }

                return total;
            }
        }

    }

   
}