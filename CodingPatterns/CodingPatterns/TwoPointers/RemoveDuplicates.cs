﻿using Shouldly;

namespace CodingPatterns.TwoPointers
{
    [TestClass]
    public class RemoveDuplicates_Test
    {


        [TestMethod]
        [DataRow(new int[] { 2, 3, 3, 3, 6, 9, 9 }, 4)]
        [DataRow(new int[] { 2, 2, 2, 11 }, 2)]

        public void Test(int[] arr, int result)
        {
            RemoveDuplicates.remove(arr)
                .ShouldBe(result);
        }

        [TestMethod]
        [DataRow(new int[] { 3, 2, 3, 6, 3, 10, 9, 3 }, 3, 4)]
        [DataRow(new int[] { 2, 11, 2, 2, 1 }, 2, 2)]

        public void Test2(int[] arr, int key, int result)
        {
            RemoveDuplicates.remove(arr, key)
                .ShouldBe(result);
        }
    }

    class RemoveDuplicates
    {
        public static int remove(int[] arr, int key)
        {
            int left = 0;

            for (int right = 0; right < arr.Length; right++)
            {
                var rValue = arr[right];

                if (rValue != key)
                {
                    arr[left] = arr[right];
                    left++;
                }
            }


            return left ;
        }

        public static int remove(int[] arr)
        {
            int left = 0;
            for (int right = 0; right < arr.Length; right++)
            {
                int lValue = arr[left];
                int rValue = arr[right];
                if (lValue != rValue)
                {
                    left++;
                    arr[left] = arr[right];
                }       
            }

            return left +1;
        }
        public static int CountInuqueElemnts(int[] arr)
        {
            int lenghtCount = 0;
            int left = 0;
            for (int right = 0; right < arr.Length; right++)
            {
                int rValue = arr[right];
                int lValure = arr[left];
                if (lValure != rValue)
                {
                    left = right;
                }
                if (left == right)
                {
                    lenghtCount++;
                }
            }

            return lenghtCount;
        }
    }
}
