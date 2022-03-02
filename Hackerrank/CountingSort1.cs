using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hackerrank
{
    [TestClass]
    public class CountingSort1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var sort = countingSort(new List<int>(){1,1,3,2,1});
        }
        public static List<int> countingSort(List<int> arr)
        {
            int[] ints = new int[100];

            foreach (int i in arr)
            {
                ints[i]++;
            }

            return ints.ToList();
        }
    }
}
