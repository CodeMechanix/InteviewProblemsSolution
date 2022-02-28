using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Hackerrank
{
    [TestClass]
    public class PlusMinus
    {
        [TestMethod]
        public void TestMethod1()
        {
            plusMinus(new List<int>() { 1, 1, 0, -1, -1 });
        }

        public static void plusMinus(List<int> arr)
        {
            int[] counters = new int[3];

            foreach (int i in arr)
            {
                if (i == 0)
                {
                    counters[2]++;
                }
                else if(i > 0)
                {
                    counters[0]++;
                }
                else
                {
                    counters[1]++;
                }
            }

            //print

            foreach (double counter in counters)
            {
                double d = counter / arr.Count;

                var s = d.ToString("0.000000");
                Console.WriteLine(s);
            }

        }
    }
}
