using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Codility.L15
{
    [TestClass]
    public class CountDistinctSlices
    {
        [TestMethod]
        public void TestMethod1()
        {
           
           var v = new Solution().solution(0,new int[] { 3, 4, 5, 5, 2 });
        }

        class Solution
        {
            public int solution(int M, int[] A)
            {
                int counter = 0;

                for (int i = 0; i < A.Length; i++) {

                    HashSet<int> visited = new HashSet<int>();
                    int runner = i;

                    while (runner < A.Length && !visited.Contains(A[runner]))
                    {
                        visited.Add(A[runner]);
                        runner++;
                    }

                    counter += RecursiveSum(runner - i );
                    i = runner - 1;
                }
                
                return counter;
            }

            int RecursiveSum(int val)
            {
                if (val == 0) return 0;
                return RecursiveSum(val - 1) + val;
            }
        }


    }
}
