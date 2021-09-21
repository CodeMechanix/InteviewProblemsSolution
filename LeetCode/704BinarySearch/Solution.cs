using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode._704BinarySearch
{
    public class Solution
    {
        private int midNumber;
        private int midIndex;
        public int Search(int[] nums, int target)
        {
            return _Search(nums, 0, nums.Length - 1, target);
        }


        private int _Search(int[] numbers, int left, int right, int target)
        {
            //Debug.WriteLine($"left:{ left}, right:{right}");

            if (left > right)
            {
                return -1;
            }

            midIndex = ( right - left) /2 ;
            midIndex += left;
           // Debug.WriteLine($"midIndex:{midIndex}");

            midNumber = numbers[midIndex];
           // Debug.WriteLine($"midNumber:{ midNumber}");

            if (midNumber == target)
            {
                return midIndex;
            }

            if (midNumber > target)
            {
                return _Search(numbers, left, midIndex-1, target);
            }
            else
            {
                return _Search(numbers, midIndex + 1, right, target);
            }
        }
    }
}
