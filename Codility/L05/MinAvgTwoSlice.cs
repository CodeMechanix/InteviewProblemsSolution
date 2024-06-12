using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Security.Principal;

namespace Codility.L5
{
    [TestClass]
    public class MinAvgTwoSlice
    {
        [TestMethod]
        public void TestMethod1()
        {
            var solution = new Solution().solution(new[] { 5, 6, 3, 4, 9 });
        }

        class Solution
        {
            public int solution(int[] A)
            {
                Slice slice = new Slice(A);

                int left = 0;
                int right = A.Length - 1;


                while (right - left > 1)
                {
                    int leftSum = slice.Sum(left, left + 1);
                    int rightSum = slice.Sum(right - 1, right);

                    if (leftSum > rightSum)
                    {
                        left++;
                    }
                    else if (leftSum == rightSum)
                    {
                        leftSum = A[left];
                        rightSum = A[right];

                        if (leftSum > rightSum)
                        {
                            left++;
                        }
                        else
                        {
                            right--;
                        }
                    }
                    else
                    {
                        right--;
                    }
                }

                return left;
            }
        }

        class Slice
        {
            private readonly int[] a;
            private int[] ints;

            public Slice(int[] A)
            {
                a = A;


                init();
            }

            private void init()
            {
                ints = new int[a.Length + 1];

                for (int i = 0; i < a.Length; i++)
                {
                    ints[i + 1] = ints[i] + a[i];
                }
            }

            public int Sum(int from, int to)
            {
                return ints[to + 1] - ints[from];
            }

            public int Avg(int from, int to)
            {
                return Sum(@from, to) / (to - @from + 1);
            }
        }
    }
}