using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Codility.L3.PermMissingElem
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var solution = new Solution().solution(new []{2,3,1,4});
        }
    }

    class Solution
    {
        public int solution(int[] A)
        {
            Dictionary<int, bool> dictionary = new Dictionary<int, bool>();

            foreach (int i in A)
            {
                dictionary.Add(i, false);
            }

            for (int i = 1; i < A.Length+2; i++)
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