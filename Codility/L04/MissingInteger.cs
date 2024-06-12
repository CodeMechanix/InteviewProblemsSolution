using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Codility.L4
{
    [TestClass]
    public class MissingInteger
    {
        [TestMethod]
        public void TestMethod1()
        {
            var solution = new Solution().solution(new [] {-1, -3 });
        }
    }

    class Solution
    {
        public int solution(int[] A)
        {
            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            foreach (var i in A)
            {
                if (i > 0)
                {
                    dictionary[i] = i;
                }
            }

            for (int i = 1; i < dictionary.Count+2; i++)
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