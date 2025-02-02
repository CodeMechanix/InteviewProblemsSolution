using System.Collections;
using System.Collections.Generic;
using Shouldly;

namespace CodingPatterns.SlidingWindow
{
    [TestClass]
    public sealed class MaximumSumSubarraySizeK_Test
    {
        [TestMethod]
        public void TestMethod1()
        {
            new MaximumSumSubarraySizeK()
                .MuxSubArraySum([2, 1, 5, 1, 3, 2], 3)
                .ShouldBe(9);
        }
    }

    /// <summary>
    /// Problem Statement # Given an array of positive numbers and a positive number ‘k’, 
    /// find the maximum sum of any contiguous subarray of size ‘k’.
    /// </summary>
    class MaximumSumSubarraySizeK
    {
        public int MuxSubArraySum(int[] numbers, int subArraySize)
        {
            //create window
            var window = new SlidingWindow<int>(numbers, subArraySize);
            //calculate all window sum
            int maxSum = 0;
            int current = 0;
            foreach (var number in window.WindowsVlues()) 
            {
                maxSum += number;
                current = maxSum;
            }

            //slide the window one step
            while (window.CanMove())
            {
                int leftValue = window.GetWindowValue(0);
                window.MoveWindow();
                var surrentWindow = window.WindowsVlues().ToArray();
                current = current - leftValue + window.GetWindowValue(subArraySize - 1);
                maxSum = Math.Max(maxSum, current);
            }

            //calculate sum of window
            //update max sum


            return maxSum;
        }

    }

    class SlidingWindow<T>
    {
        private readonly IList<T> _dataList;
        private readonly int _windowLength;
        private int _windowStart;

        public SlidingWindow(IList<T> dataList, int windowLength)
        {
            this._dataList = dataList;
            this._windowLength = windowLength;
            _windowStart = 0;
        }

        public IEnumerable<T> WindowsVlues()
        {
            for (int i = _windowStart; i < _windowStart + _windowLength; i++)
            {
                yield return _dataList[i];
            }
        }

        public bool CanMove(int steps = 1)
        {
            return _windowStart + _windowLength + steps < _dataList.Count;
        }

        public void MoveWindow(int steps = 1)
        {
            _windowStart += steps;
        }

        public T GetWindowValue(int index) 
        {
            return _dataList[_windowStart + index];
        }
    }
}
