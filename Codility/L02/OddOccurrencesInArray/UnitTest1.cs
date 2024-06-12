using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Codility.L2.OddOccurrencesInArray
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var solution = new Solution().solution(new []{9,3,9,3,9,7,9});
        }
    }

    class Solution
    {
        public int solution(int[] A)
        {
            Dictionary<int, int> dictionary = new Dictionary<int, int>();

            foreach (int i in A)
            {
                if (dictionary.ContainsKey(i))
                {
                    dictionary.Remove(i);
                }
                else
                {
                    dictionary.Add(i, 0);
                }
            }

            return dictionary.Keys.First();
        }
    }
}