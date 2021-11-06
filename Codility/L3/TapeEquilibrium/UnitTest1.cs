using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Codility.L3.TapeEquilibrium
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var solution = new Solution().solution(new []{3,1,2,4,3});
        }
    }

    class Solution
    {
        public int solution(int[] A)
        {
            int left = 0;
            int right = 0;
            int minDiff = Int32.MaxValue;
            //sume of All
            foreach (var i in A)
            {
                right += i;
            }

            for (int i = 1; i < A.Length; i++)
            {
                left += A[i-1];
                right -= A[i-1];

                int newDiff = Math.Abs( right - left );
                if (newDiff< minDiff)
                {
                    minDiff = newDiff;
                }
            }

            return minDiff;
        }
    }
}