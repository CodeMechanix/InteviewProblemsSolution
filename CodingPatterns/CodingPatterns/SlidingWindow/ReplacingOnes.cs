using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;

namespace CodingPatterns.SlidingWindow
{
    [TestClass]
    public class ReplacingOnes_Test
    {
        [TestMethod]
        [DataRow(new []{ 0, 1, 1, 0, 0, 0, 1, 1, 0, 1, 1 }, 2, 6)]
        [DataRow(new []{ 0, 1, 0, 0, 1, 1, 0, 1, 1, 0, 0, 1, 1 }, 3, 9)]
        public void Test(int[] ints, int k, int maxLength)
        {
            ReplacingOnes.findLength(ints, k)
                .ShouldBe(maxLength);
        }
    }
    class ReplacingOnes
    {
        public static int findLength(int[] arr, int k)
        {
            int maxLength = 0;
            int start = 0;
            int kCount = 0;
            for (int end = 0; end < arr.Length; end++)
            {
                int current = arr[end];

                if (current == 0)
                {
                    kCount++;
                }

                while (kCount > k)
                {
                    var firstValue = arr[start];
                    if (firstValue == 0)
                    {
                        kCount--;
                    }
                    start++;
                }

                maxLength = Math.Max(maxLength, end - start +1);

            }

            return maxLength;
        }
    }
}
