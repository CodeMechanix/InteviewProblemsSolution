using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;

namespace CodingPatterns.SlidingWindow
{
    [TestClass]
    public class LongestSubstringKDistinct_Test
    {
        [TestMethod]
        [DataRow("araaci",2, 4)]
        [DataRow("araaci", 1, 2)]
        [DataRow("cbbebi", 3, 5)]
        public void TestMethod1(string text, int distinctCharacters, int longestSubstring)
        {
            LongestSubstringKDistinct.findLength(text, distinctCharacters)
                .ShouldBe(longestSubstring);
        }
    }
    class LongestSubstringKDistinct
    {
        public static int findLength(String str, int k)
        {
            int maxLength = 0;
            int windowStart = 0;
            var charSet = new CountingDictionary();
            for (int windowEnd = 0; windowEnd < str.Length; windowEnd++)
            {
                //Grow
                var c = str[windowEnd];
                charSet.Add(c);

                //Shrink
                while (charSet.Count() > k)
                {
                    var firstChar = str[windowStart];
                    charSet.Remove(firstChar);
                    windowStart++;
                }
                //update Max
                maxLength = Math.Max(maxLength, windowEnd - windowStart + 1);
            }



            return maxLength;
        }
    }

    class CountingDictionary
    {
        private readonly Dictionary<char, int> dictionary = new Dictionary<char, int>();
        public CountingDictionary()
        {
                
        }

        public void Add(char key)
        {

            if (dictionary.ContainsKey(key))
            {
                dictionary[key] ++;
            }
            else
            {
                dictionary.Add(key, 1);
            }
        }
        public void Remove(char key) 
        {

            if (dictionary[key] > 0)
            {
                dictionary[key]--;
            }
            if (dictionary[key] == 0)
            {
                dictionary.Remove(key);
            }
        }

        public int Count()
        {
            return dictionary.Count;
        }
    }
}
