using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingPatterns.Cyclic_Sort
{

    [TestClass]
    public class AllMissingNumbersTests
    {
        [TestMethod]
        public void TestCase1()
        {
            int[] nums = { 2, 3, 1, 8, 2, 3, 5, 1 };
            List<int> expected = new List<int> { 4, 6, 7 };
            List<int> actual = AllMissingNumbers.findNumbers(nums);
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestCase2()
        {
            int[] nums = { 2, 2, 2, 2, 2 };
            List<int> expected = new List<int> { 1, 3, 4, 5 };
            List<int> actual = AllMissingNumbers.findNumbers(nums);
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestCase3()
        {
            int[] nums = { 1, 1, 1, 1, 1 };
            List<int> expected = new List<int> { 2, 3, 4, 5 };
            List<int> actual = AllMissingNumbers.findNumbers(nums);
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestCase4()
        {
            int[] nums = { 1, 2, 3, 4, 5 };
            List<int> expected = new List<int> { };
            List<int> actual = AllMissingNumbers.findNumbers(nums);
            CollectionAssert.AreEqual(expected, actual);
        }

        //59_Find_all_Missing_Numbers__easy_.mhtml
        internal class AllMissingNumbers
        {
            public static List<int> findNumbers(int[] nums)
            {
                return new AllMissingNumbersSol(nums)
                    .FindNumbers();
            }
        }

        private class AllMissingNumbersSol
        {
            private readonly int[] nums;

            public AllMissingNumbersSol(int[] nums)
            {
                this.nums = nums;
            }

            public List<int> FindNumbers()
            {
                for (int index = 1; index <= nums.Length; index++)
                {
                    while (Value(index) != index)
                    {
                        if (Value(index) == Value(Value(index)))
                            break;

                            //swap
                         Swap(index, Value(index));

                    }
                }


                List<int> missingNumbers = new List<int>();
                // TODO: Write your code here

                for (int i = 1; i <= nums.Length; i++)
                {
                    if(Value(i) != i)
                    {
                        missingNumbers.Add(i);
                    }
                }

                return missingNumbers;
            }
            private int Value(int i)
            {
                return nums[i - 1];
            }

            private void Swap(int i, int j)
            {
                i--;
                j--;
                int temp = nums[i];
                nums[i] = nums[j];
                nums[j] = temp;
            }
        }
    }
}
