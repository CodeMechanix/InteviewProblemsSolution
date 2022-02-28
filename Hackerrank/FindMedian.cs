using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Hackerrank
{
    [TestClass]
    public class FindMedian
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        public static int findMedian(List<int> arr)
        {
            Console.WriteLine(string.Join(", ", arr));
            arr.Sort();
            Console.WriteLine(string.Join(", ", arr));
            return arr[(arr.Count / 2 )];
        }
    }
}
