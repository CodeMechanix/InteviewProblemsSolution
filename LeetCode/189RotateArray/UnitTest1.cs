using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LeetCode._189RotateArray
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            new Solution().Rotate(new[] {1, 2, 3, 4, 5, 6, 7}, 3);
        }
    }

    public class Solution
    {
        public void Rotate(int[] nums, int k)
        {
            int shift = k % nums.Length;

            if (shift == 0)
            {
                return;
            }

            int[] numsResult = new int[nums.Length];

            int fromIndex1 = nums.Length  - shift;
        
            Array.Copy(nums, fromIndex1, numsResult, 0, shift);

             Array.Copy(nums, 0, numsResult, shift, nums.Length - shift);

           Array.Copy(numsResult, nums, nums.Length);

            
        }
    }
}