using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Other.CheckPoint
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var solution = new Solution().solution(new [] { -1, -3 });
        }
    }
    // write your code in C# 6.0 with .NET 4.5 (Mono)
    class Solution
    {
        public int solution(int[] A)
        {
            int N = A.Length;
            int positiveCount = 0;
            Dictionary<int, int> dictionary = new Dictionary<int, int>();

            foreach (int num in A)
            {
                if (num > 0)
                {
                    positiveCount++;
                    dictionary[num] = num;
                }
              
            }


            for (int i = 1; i <= positiveCount+1; i++)
            {
                if (!dictionary.ContainsKey(i))
                {
                    return i;
                }
            }


            return -1;

        }
    }
}
