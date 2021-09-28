using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LeetCode._283MoveZeroes
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            new Solution().MoveZeroes(new[] {0, 1, 0, 3, 12});
        }
    }

    public class Solution
    {
        private int _nextIndex;
        private int _currentIndex;

        public void MoveZeroes(int[] nums)
        {
            while (nums[_currentIndex] != 0 && _currentIndex< nums.Length)
            {
                _currentIndex++;
                _nextIndex = _currentIndex;
            }

            _currentIndex++;
            while (_currentIndex < nums.Length)
            {
                if (nums[_currentIndex] != 0)
                {
                    nums[_nextIndex] = nums[_currentIndex];
                    _nextIndex++;
                }

                _currentIndex++;
            }

            for (int i = _nextIndex; i < nums.Length; i++)
            {
                nums[i] = 0;
            }
        }
    }
}