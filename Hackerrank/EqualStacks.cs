using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Hackerrank
{
    [TestClass]
    public class EqualStacks
    {
        [TestMethod]
        public void TestMethod1()
        {
            var equalStacks = Result.equalStacks(
                new List<int>(){3,2,1,1,1},
                new List<int>(){ 4, 3, 2 },
                new List<int>(){ 1, 1, 4, 1 });
        }


        class Result
        {
            /*
             * Complete the 'equalStacks' function below.
             *
             * The function is expected to return an INTEGER.
             * The function accepts following parameters:
             *  1. INTEGER_ARRAY h1
             *  2. INTEGER_ARRAY h2
             *  3. INTEGER_ARRAY h3
             */

            public static int equalStacks(List<int> h1, List<int> h2, List<int> h3)
            {
                bool run = true;

                List<int>[] stacks = new List<int>[]
                {
                    h1, h2, h3
                };

                int[] stacksHeight = new int[]
                {
                    Height(h1), Height(h2), Height(h3)
                };

                int min = stacksHeight[0];

                while (run)
                {
                    run = false;

                    for (var index = 0; index < stacks.Length; index++)
                    {
                        List<int> stack = stacks[index];
                        
                        if (stacksHeight[index] > min)
                        {
                            stacksHeight[index] -= stack[0];
                            stack.RemoveAt(0);
                            run = true;
                        }
                        else if (stacksHeight[index] < min)
                        {
                            min = stacksHeight[index];
                            run = true;
                        }
                    }
                }

                return min;
            }

            private static int Height(List<int> h1)
            {
                int height = 0;
                foreach (int i in h1)
                {
                    height += i;
                }

                return height;
            }
        }
    }
}