using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode._567.PermutationInString
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var checkInclusion = new Solution().CheckInclusion("adc", "dcda");
        }
    }

    public class Solution
    {
        public bool CheckInclusion(string s1, string s2)
        {
            Dictionary<char, int> dictionary = new Dictionary<char, int>();

            foreach (char c in s1)
            {
                if (dictionary.ContainsKey(c))
                {
                    dictionary[c]++;
                }
                else
                {
                    dictionary[c] = 1;
                }
            }


            int leftWindow;

            for (int i = 0; i < s2.Length; i++)
            {
                char c = s2[i];
                leftWindow = i - s1.Length;
                if (dictionary.ContainsKey(c))
                {
                    dictionary[c]--;
                }


                if (leftWindow >= 0)
                {
                    char key = s2[leftWindow];
                    if (dictionary.ContainsKey(key))
                    {
                        dictionary[key]++;
                    }
                }

                if (dictionary.Values.Count(i1 => i1 != 0) == 0)
                {
                    return true;
                }
            }

            return false;
        }
    }
}