using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LeetCode._704BinarySearch
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution solution = new Solution();
            solution.Search(new[] {-1, 0, 3, 5, 9, 12}, 2);
        }
    }
}
