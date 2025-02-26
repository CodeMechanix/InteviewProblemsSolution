using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;

namespace CodingPatterns.SlidingWindow
{
    class WordConcatenation
    {
        public static List<int> findWordConcatenation(String str, String[] words)
        {
            var resultIndices = new List<int>();
            var map = new Dictionary<String, int>();
            // build hashMap
            foreach (var word in words) 
            {
                map[word] = map.ContainsKey(word) ? map[word] + 1 : 1;
            }
            var stepLength = words.First().Length;
            var matchCount = 0;
            var start = 0;
            for (int end = 3; end <= str.Length; end+= stepLength)
            {
                var currentWord = str.Substring(end - stepLength, stepLength);

                if (map.ContainsKey(currentWord))
                {
                    if (map[currentWord] > 0)
                    {
                        matchCount++;
                    }
                    map[currentWord]--;
                }

                while (matchCount == words.Length)
                {
                    if ((end - start) == words.Length * stepLength)
                    {
                        resultIndices.Add(start);
                    }

                    var leftWord = str.Substring(start , stepLength);
                    if (map.ContainsKey(leftWord))
                    {
                        map[leftWord]++;
                        if (map[leftWord] > 0)
                        {
                            matchCount--;
                        }
                    }

                    start += stepLength;
                }

            }

            return resultIndices;
        }
    }

    [TestClass]
    public class WordConcatenation_Test
    {

        [TestMethod]
        [DataRow("catfoxcat", new[] { "cat", "fox" }, new[] { 0, 3 })]
        [DataRow("catcatfoxfox", new[] { "cat", "fox" }, new[] { 3 })]
        public void Test(String str, String[] words, int[] expectedSubstringBegining)
        {
            WordConcatenation.findWordConcatenation(str, words)
                .ShouldBe(expectedSubstringBegining);
        }
    }
}
