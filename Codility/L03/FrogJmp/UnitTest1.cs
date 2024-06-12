using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Codility.L3.FrogJmp
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var solution = new Solution().solution(10, 85, 30);
        }
    }
     
    class Solution
    {
        public int solution(int X, int Y, int D)
        {
            int distance = Y - X;

            int numberOfD = distance / D;
            int remains = distance % D;

            return numberOfD + (remains != 0 ? 1:0);
        }
    }
}