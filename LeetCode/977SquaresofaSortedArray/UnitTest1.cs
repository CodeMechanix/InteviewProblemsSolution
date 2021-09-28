using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LeetCode._977SquaresofaSortedArray
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var sortedSquares = new Solution().SortedSquares(new[]
            {
                -5, -3, -2, -1
            });
        }
    }

    public class Solution
    {
        public int[] SortedSquares(int[] nums)
        {
            var merge = Merge(nums);
            var sqrArr = Sqrt(merge);
            return sqrArr;
        }

        private int[] Sqrt(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                int tmp = nums[i];
                nums[i] = (int) Math.Pow(nums[i], 2);
            }

            return nums;
        }

        private int[] Merge(int[] nums)
        {
            int[] mrgArr = new int[nums.Length];

            var firstPositive = FirstPositive(nums);

            if (firstPositive > 0)
            {
                int ringhtIndex = firstPositive;
                int leftIndex = firstPositive - 1;
                int i = 0;

                while (leftIndex >= 0 && ringhtIndex < nums.Length)
                {
                    if (Math.Abs(nums[leftIndex]) < nums[ringhtIndex])
                    {
                        mrgArr[i] = Math.Abs(nums[leftIndex]);
                        leftIndex--;
                    }
                    else
                    {
                        mrgArr[i] = nums[ringhtIndex];
                        ringhtIndex++;
                    }

                    i++;
                }

                if (leftIndex < 0)
                {
                    while (ringhtIndex < nums.Length)
                    {
                        mrgArr[i] = nums[ringhtIndex];
                        ringhtIndex++;
                        i++;
                    }
                }
                else
                {
                    while (leftIndex >= 0)
                    {
                        mrgArr[i] = Math.Abs(nums[leftIndex]);
                        leftIndex--;
                        i++;
                    }
                }

                return mrgArr;
            }

            if (firstPositive == 0)
            {
                return nums;
            }
            else //rotate
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    mrgArr[i] = Math.Abs(nums[nums.Length - 1 - i]);
                }

                return mrgArr;
            }
        }

        private int FirstPositive(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] >= 0)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}