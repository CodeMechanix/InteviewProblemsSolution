using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Codility.L6
{
    [TestClass]
    public class Distinct
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        class Solution
        {
            public int solution(int[] A)
            {
                HashSet<int> hashSet = new HashSet<int>();

                foreach (int i in A)
                {
                    if (!hashSet.Contains(i))
                    {
                        hashSet.Add(i);
                    }
                }

                return hashSet.Count;
            }
        }
    }
}