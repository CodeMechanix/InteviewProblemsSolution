using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LeetCode._278FirstBadVersion
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            LeetCode._278FirstBadVersion.Solution solution = new _278FirstBadVersion.Solution();

            var firstBadVersion = solution.FirstBadVersion(5);
        }
    }
}
