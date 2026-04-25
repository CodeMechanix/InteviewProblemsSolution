using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingPatterns.Cyclic_Sort
{
    [TestClass]
    public class MissingNumberTest
        {
            [TestMethod]
            public void Test()
            {
                MissingNumber.findMissingNumber(new int[] { 4, 0, 3, 1 }).ShouldBe(2);
                MissingNumber.findMissingNumber(new int[] { 8, 3, 5, 2, 4, 6, 0, 1 }).ShouldBe(7);
            }
    }

    internal class MissingNumber
    {
        private static int _missingIndex = -1;
        public static int findMissingNumber(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                var currentValue = nums[i];
                if (currentValue == i) {
                    //move next
                    continue;
                }
                //swap
                while (currentValue != i && currentValue != -1)
                {
                    Swap(i, currentValue, nums);
                    currentValue = nums[i];
                    if(currentValue == -1)
                    {
                        _missingIndex = i;
                    }
                }
            }

            // TODO: Write your code here
            return _missingIndex;
        }
        private static void Swap(int sourceIndex, int targetIndex, int[] nums) {
            
            if (targetIndex >= nums.Length) {
                nums[sourceIndex] = -1;
                return;
            }

            int from = nums[sourceIndex];
            nums[sourceIndex] = nums[targetIndex]; 
            nums[targetIndex] = from;
        }
    }
}
