using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LeetCode._35SearchInsertPosition
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var searchInsert = new Solution().SearchInsert(new[] {1, 3, 5, 6}, 2);
        }
    }

    public class Solution
    {
        public int SearchInsert(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length;
            int mid;

            while (left <= right)
            {
                mid = (right - left) / 2 + left;

                int num = nums[mid];
                if (num == target)
                {
                    return mid;
                }

                if (num < target)
                {
                    if (nums.Length == mid + 1 || nums[mid + 1] > target)
                    {
                        return mid + 1;
                    }

                    left = mid + 1;
                }
                else //(num > target)
                {
                    if ((mid - 1) < 0)
                    {
                        return 0;
                    }
                    else if (nums[mid - 1] < target)
                    {
                        return mid;
                    }

                    right = mid - 1;
                }
            }

            return -1;
        }
    }
}