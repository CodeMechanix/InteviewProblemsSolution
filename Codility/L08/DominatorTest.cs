using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Codility.L8
{
    [TestClass]
    public class DominatorTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var solution = new Solution().solution(new []{3,4,3,2,3,-1,3,3});
        }

        public class Solution
        {


            public int solution(int[] A)
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
                int position=0;

                for (var index = 0; index < A.Length; index++)
                {
                    var num = A[index];
                    if (num == stack.Peek())
                    {
                        count++;
                        position = index;
                    }
                }

                if (count >= A.Length/2)
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