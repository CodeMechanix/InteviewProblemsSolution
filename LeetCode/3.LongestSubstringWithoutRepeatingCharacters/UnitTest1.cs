using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace LeetCode._3.LongestSubstringWithoutRepeatingCharacters
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var lengthOfLongestSubstring = new Solution().LengthOfLongestSubstring("dvdf");
        }
    }
    public class Solution
    {
        public int LengthOfLongestSubstring(string s)
        {
            Dictionary<char, int> list = new Dictionary<char, int>();
            int counter = 0;
            int max = 0;

            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];

                if (list.ContainsKey(c))
                {
                    if (counter > max)
                    {
                        max = counter;
                    }
                  
                    i = list[c];
                    list.Clear();
                    counter = 0;
                }
                else
                {
                    list.Add(c, i);
                    counter++;
                }
             
            }
            if (counter > max)
            {
                max = counter;
            }
            return max;
        }
    }
}
