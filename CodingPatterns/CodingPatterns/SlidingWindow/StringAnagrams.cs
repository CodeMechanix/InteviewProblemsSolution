using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;

namespace CodingPatterns.SlidingWindow
{
    class StringAnagrams
    {
        public static List<int> findStringAnagrams(String str, String pattern)
        {
            //init HashMap
            var map = new Dictionary<char, int>();
            foreach (var item in pattern)
            {
                if (map.ContainsKey(item))
                {
                    map[item]++;
                }
                else {
                    map[item] = 1;
                }
            }

            //use window
            List<int> resultIndices = new List<int>();
            int start = 0;
            int matchCount =0;
            for (int end = 1; end <= str.Length; end++)
            {
                //grow
                var currentLetter = str[end-1];

                if (map.ContainsKey(currentLetter))
                {
                    map[currentLetter]--;
                    matchCount++;
                }
                else
                {
                    start = end-1;
                    matchCount = 0;
                    continue;
                }


                //shrink
                while (map.ContainsKey(currentLetter) && map[currentLetter]<0)
                {
                    var firstLetter = str[start];
                    map[firstLetter]++;
                    matchCount--;
                    start++;
                }

                if (matchCount == pattern.Length) { 
                    resultIndices.Add(start);
                }
            }



            // TODO: Write your code here
            return resultIndices;
        }
    }

    [TestClass]
    public class StringAnagrams_Test
    {
        [TestMethod]
        //[DataRow("ppqp", "pq", new[] {1,2})]
        [DataRow("abbcabc", "abc", new[] { 2, 3, 4 })]
        public void Test(String str, String pattern, int[] results)
        {
            StringAnagrams.findStringAnagrams(str, pattern)
                .ShouldBe(results);
        }
    }
}
