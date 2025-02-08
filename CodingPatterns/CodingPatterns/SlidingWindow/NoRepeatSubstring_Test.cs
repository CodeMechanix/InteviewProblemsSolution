using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;

namespace CodingPatterns.SlidingWindow
{

    [TestClass]
    public class NoRepeatSubstring_Test
    {
        [TestMethod]
        [DataRow("aabccbb", 3)]
        [DataRow("abbbb", 2)]
        [DataRow("abccde", 3)]
        public void Test(string str, int result)
        {
            NoRepeatSubstring.findLength(str)
                .ShouldBe(result);
        }
    }
    class NoRepeatSubstring
    {
        public static int findLength(String str)
        {
            int max = 0;
            int tempCount = 0;
            var set = new HashSet<char>();

            for (int end = 0; end < str.Length; end++)
            {
                var c = str[end];
                var isAdded = set.Add(c);

                if (isAdded)
                {
                    tempCount++;
                }
                else
                {
                    set.Clear();
                    set.Add(c);
                    tempCount = 1;
                }


                max = Math.Max(max, tempCount);
            }

          
            return max;
        }
    }
}
