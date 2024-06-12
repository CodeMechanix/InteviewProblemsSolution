using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Codility.L8
{
    [TestClass]
    public class EquiLeaderTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            int solution = new Solution().solution(new[] { 4, 3, 4, 4, 4, 2 });
        }

        class Solution
        {
            public int solution(int[] A)
            {
                int leaderCount = 0;

                for (int i = 0; i < A.Length; i++)
                {
                    int[] array = new int[i + 1];
                    Array.ConstrainedCopy(A, 0, array, 0, i + 1);
                    int leftIndex = FindLeaderIndex(array);
                    if (leftIndex < 0)
                        continue;
                    int leftLeader = array[leftIndex];

                    array = new int[A.Length - i - 1];
                    Array.ConstrainedCopy(A, i + 1, array, 0, A.Length - 1 - i);
                    int rightIndex = FindLeaderIndex(array);
                    if (rightIndex < 0)
                        continue;

                    if (leftLeader == array[rightIndex])
                    {
                        leaderCount++; 
                    }
                   
                }

                return leaderCount;
            }

            public int FindLeaderIndex(int[] A)
            {
                //Find candidate
                Stack<int> stack = new Stack<int>();

                for (int i = 0; i < A.Length; i++)
                {
                    var num = A[i];

                    if (stack.Count > 0)
                    {
                        if (stack.Peek() != num)
                        {
                            stack.Pop();
                        }
                        else
                        {
                            stack.Push(num);
                        }
                    }
                    else
                    {
                        stack.Push(num);
                    }
                }

                //count candidate
                if (stack.Count == 0)
                {
                    return -1;
                }

                int count = 0;
                int position = 0;

                for (var index = 0; index < A.Length; index++)
                {
                    var num = A[index];
                    if (num == stack.Peek())
                    {
                        count++;
                        position = index;
                    }
                }

                if (count >= A.Length / 2)
                {
                    return position;
                }
                else
                {
                    return -1;
                }
            }
        }
    }
}