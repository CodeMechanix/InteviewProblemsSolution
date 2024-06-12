using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Codility.L4
{
    [TestClass]
    public class FrogRiverOne
    {
        [TestMethod]
        public void TestMethod1()
        {
            int[] A = new[] { 1, 3, 1, 4, 2, 3, 5, 4 };

            int solution = new Solution().solution(5, A);
        }

        class Solution
        {
            public int solution(int X, int[] A)
            {
                Dictionary<int, int> dictionary = new Dictionary<int, int>();
            
            
                int counter = 0;
                int val;
                for (int i = 0; i < A.Length; i++)
                {
                    val = A[i];
            
                    if (val > X)
                    {
                        continue;
                    }
            
                    if (!dictionary.ContainsKey(val))
                    {
                        dictionary.Add(val,val);
                        counter++;
                        if (counter == X)
                        {
                            return i;
                        }
                    }
                }
            
                return -1;
            }
        }
    }
}