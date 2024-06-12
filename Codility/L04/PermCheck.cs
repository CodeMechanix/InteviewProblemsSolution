using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Codility.L4
{
    [TestClass]
    public class PermCheck
    {
        [TestMethod]
        public void TestMethod1()
        {
            var solution = new Solution().solution(new []{4,1,3});
        }


        class Solution
        {
            public int solution(int[] A)
            {

                Dictionary<int, bool> dictionary = new Dictionary<int, bool>();


                foreach (int i in A)
                {
                    if (!dictionary.ContainsKey(i) && i <= A.Length && i> 0)
                    {
                         dictionary.Add(i, false);
                    }
                }

                return dictionary.Count == A.Length ? 1 : 0;
            }
        }
    }
}