using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Codility.L7
{
    [TestClass]
    public class StoneWallTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var solution = new Solution().solution(new[] { 8, 8, 5, 7, 9, 8, 7, 4, 8 });
        }


        class Solution
        {
            public int solution(int[] H)
            {
                int currentHeight = H[0];
                int blockCounter = 0;

                List<int> _list = H.ToList();
                Stack<IList<int>> stack = new Stack<IList<int>>();
                stack.Push(_list);

                while (stack.Count > 0)
                {
                    blockCounter++;
                    IList<int> ints = stack.Pop();

                    int height = ints[0];

                    IList<int> tempInts = new List<int>();

                    foreach (int i in ints)
                    {
                        if (i == height)
                        {
                            
                            if (tempInts.Count > 0)
                            {
                                stack.Push(tempInts);
                                tempInts = new List<int>();
                            }
                        }
                        else if(i < height)
                        {
                            blockCounter++;
                            height = i;
                            if (tempInts.Count > 0)
                            {
                                stack.Push(tempInts);
                                tempInts = new List<int>();
                            }
                        }
                        else
                        {
                            tempInts.Add(i-height);
                        }
                    }

                    if (tempInts.Count > 0)
                    {
                        stack.Push(tempInts);
                    }
                }

                return blockCounter;
            }
        }
    }
}