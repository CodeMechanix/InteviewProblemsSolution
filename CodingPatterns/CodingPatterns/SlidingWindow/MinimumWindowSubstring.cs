using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;

namespace CodingPatterns.SlidingWindow
{
    class MinimumWindowSubstring
    {
        public static String findSubstring(String str, String pattern)
        {
            var map = new Dictionary<char, int>();
            foreach (char c in pattern) {
            
                map[c] = map.ContainsKey(c) ? map[c] + 1 : 1;
            }

            string minSubstring = string.Empty;
            int start = 0;
            int charMatchCount = 0;

            for (int end = 1; end <= str.Length; end++)
            {
                var currentChar = str[end-1];

                if (map.ContainsKey(currentChar))
                {
                    map[currentChar]--;
                    if (map[currentChar] == 0)
                    {
                        charMatchCount++;
                    }
                }

                while (charMatchCount == map.Count)
                {
                    if (minSubstring.Length > end - start - 1 || minSubstring.Equals(string.Empty))
                    {
                        minSubstring = str.Substring(start, end - start );

                        if(minSubstring.Length == pattern.Length) return minSubstring;
                    }

                    var firstInWindow = str[start];
                    if (map.ContainsKey(firstInWindow))
                    {
                        if (map[firstInWindow] == 0)
                        {
                            charMatchCount--;
                        }
                        map[firstInWindow]++;
                    }
                    start++;
                }

                
            }
            return minSubstring;
        }
    }
    [TestClass]
    public class MinimumWindowSubstring_Test
    {
        [TestMethod]
        [DataRow("aabdec", "abc", "abdec")]
        [DataRow("abdabca", "abc", "abc")]
        [DataRow("adcad", "abc", "")]
        public void Test(String str, String pattern, String expected)
        {
            MinimumWindowSubstring.findSubstring(str, pattern)
                .ShouldBe(expected);
        }
    }
}
