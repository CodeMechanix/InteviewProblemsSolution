using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Codility.L13
{
    [TestClass]
    public class FibonacciNumbersTest
    {
        [TestMethod]
        public void FibFrogTest()
        {
            int v = new FibFrog.Solution()
                .solution(new int[] {0 });
        }

        [TestMethod]
        public void LadderTest()
        {
            long v = new LadderSolution.LadderWays().NumberOfDifferentWaysOfClimbingLadder(5);
        }
    }

    class LadderSolution
    {
        class Solution { 
            public int[] solution(int[] A, int[] B)
            {

                var ladderWays = new LadderWays();

                var result = new int[A.Length];
                for (int i = 0; i < A.Length; i++)
                {
                    var v = ladderWays.NumberOfDifferentWaysOfClimbingLadder(A[i]);
                    var v1 = (int) Math.Pow(2, B[i]);
                    result[i] =  v % v1;
                }
                return result;
            } 
        }

        public class LadderWays
        {
            public int NumberOfDifferentWaysOfClimbingLadder(int stepsCount)
            {
                //create stuck and save parrent's index in child
                //when no more child, pop the top o the stack, update the parent way-count, update is-visited
                
                var isVisited = new bool[stepsCount + 1];
                var wayCount = new int[stepsCount +1];
                var parrents = new int[stepsCount +1];
                var stack = new Stack<int>();
                stack.Push(0);
                wayCount[stepsCount] = 1;

                while (stack.Count > 0) {

                    var current = stack.Peek();

                    if (isVisited[current])
                    {
                        var pop = stack.Pop();
                        if (pop == 0) break;


                        var parrent = parrents[pop];
                        wayCount[parrent] = wayCount[parrent] + wayCount[pop];
                    }
                    else {

                        isVisited[current] = true;
                        var childs = GetGilds(current, stepsCount);
                        foreach (var item in childs)
                        {
                            parrents[item] = current;
                            stack.Push(item);
                        }
                    }
                }

                return wayCount[0];
            }

            private int[] GetGilds(int parrentIndex, int total)
            {
                var childs = new List<int>();

                var childTemp = new int[] { parrentIndex + 1, parrentIndex + 2 };

                foreach (var item in childTemp)
                {
                    if (item <= total)
                    {
                        childs.Add(item);
                    }
                }

                return childs.ToArray();
            }
        }
        
    }
}
