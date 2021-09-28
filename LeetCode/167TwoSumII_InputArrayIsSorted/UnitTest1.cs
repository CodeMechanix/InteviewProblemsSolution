using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LeetCode._167TwoSumII_InputArrayIsSorted
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var twoSum = new Solution().TwoSum(new [] { 5, 25, 75}, 100);
        }

        public class Solution
        {
            private int _leftIndex;
            private int _rigthIndex;

            public int[] TwoSum(int[] numbers, int target)
            {
                // Get right border
                if (target != 0)
                {
                    for (int i = numbers.Length - 1; i >= 0; i--)
                    {
                        if (numbers[i] <= target || numbers[i] == 0)
                        {
                            _rigthIndex = i;
                            break;
                        }
                    }
                }
                else
                {
                    _rigthIndex = numbers.Length-1;

                }
                //Find Sum

                while (_rigthIndex - _leftIndex > 0)
                {
                    if (numbers[_leftIndex] + numbers[_rigthIndex] == target)
                    {
                        return new[] {_leftIndex+1, _rigthIndex+1};
                    }

                    if (numbers[_leftIndex] + numbers[_rigthIndex] > target)
                    {
                        _rigthIndex--;
                    }
                    else
                    {
                        _leftIndex++;
                    }
                }

                return null;
            }
        }
    }
}