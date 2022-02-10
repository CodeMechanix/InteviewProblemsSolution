using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Codility.L5
{
    [TestClass]
    public class PassingCars
    {
        [TestMethod]
        public void TestMethod1()
        {
            var solution = new Solution().solution(new[] { 0, 1, 0, 1, 1 });
        }

        class Solution
        {
            public int solution(int[] A)
            {
                bool waitForZero = true;
                int pairsCounter = 0;
                List<int> pairs = new List<int>();
                foreach (int i in A)
                {
                    if (waitForZero)
                    {
                        if (i == 1)
                        {
                            continue;
                        }
                        else
                        {
                            waitForZero = false;
                        }
                    }


                    if (i == 0)
                    {
                        pairs.Add(pairsCounter);
                    }
                    else
                    {
                        pairsCounter++;
                    }
                }

                int total = 0;

                foreach (var pair in pairs)
                {
                    if (total > 1000000000)
                    {
                        return -1;
                    }
                    total += pairsCounter - pair;
                }

                return total;
            }
        }
    }


}