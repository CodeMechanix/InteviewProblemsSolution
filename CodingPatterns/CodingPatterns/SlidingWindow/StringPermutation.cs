using Shouldly;

namespace CodingPatterns.SlidingWindow
{
    [TestClass]
    public class StringPermutation_Test
    {
        [TestMethod]
        [DataRow("oidbcaf", "abc", true)]
        [DataRow("odicf", "dc", false)]
        [DataRow("bcdxabcdy", "bcdyabcdx", true)]
        [DataRow("abbbaacb", "abc", true)]
        public void Test(string str, string pattern, bool result)
        {
            StringPermutation.findPermutationV2(str, pattern)
                .ShouldBe(result);
        }
    }

    class StringPermutation
    {

        public static bool findPermutationV2(string str, string pattern)
        {
            var frequency = new Dictionary<char, int>();
            foreach (char ch in pattern) {

                if (frequency.ContainsKey(ch))
                {
                    frequency[ch]++;
                }
                else
                {
                    frequency[ch] = 1;
                }
            }

            var matchCount = 0;
            var start = -1;

            for (int end = 0; end < str.Length; end++)
            {
                var currentValueInWindow = str[end];

                if (frequency.ContainsKey(currentValueInWindow))
                {
                    frequency[currentValueInWindow]--;
                    matchCount++;
                }

                while ((end - start) > pattern.Length ||
                   frequency.ContainsKey(currentValueInWindow) && frequency[currentValueInWindow] < 0
                    )//shrink
                {
                    var firstValueInVindow = str[start+1];
                    if (frequency.ContainsKey(firstValueInVindow))
                    {
                        frequency[firstValueInVindow]++;
                        matchCount--;
                    }
                    start++;
                }


                if (matchCount == pattern.Length)
                {
                    return true;
                }
            }

            return false;
        }


        public static bool findPermutation(string str, string pattern)
        {
            int start = 0;
            var patternDic = PrepareDic(pattern);
            var tmpDic = new Dictionary<char, int>();
            for (int end = 0; end < str.Length; end++)
            {
                char c = str[end];
                if (patternDic.ContainsKey(c))
                {
                    Incement( tmpDic, c );
                }
                else
                {
                    start = end +1;
                    tmpDic = new Dictionary<char, int>();
                    continue;
                }

                while (tmpDic.ContainsKey(c) && tmpDic[c] > patternDic[c])
                {
                    Decement( tmpDic, str[start]);
                    start++;
                }

                if ((end - start + 1) == pattern.Length)
                {
                    return true;
                }
            }
            return false;
        }

        private static void Incement(Dictionary<char, int> dic, char key)
        {
            if (dic.ContainsKey(key))
            {
                dic[key]++;
            }
            else
            {
                dic[key] = 1;
            }
        }

        private static void Decement(Dictionary<char, int> dic, char key)
        {
            if (dic.ContainsKey(key))
            {
                dic[key]--;
            }           
        }
        private static Dictionary<char, int> PrepareDic(string pattern)
        {
            var dic = new Dictionary<char, int>();

            for (int i = 0; i < pattern.Length; i++)
            {
                if (dic.ContainsKey(pattern[i]))
                {
                    dic[pattern[i]]++;
                }
                else
                {
                    dic[pattern[i]] = 1;
                }
            }
            return dic;
        }

        

    }
}

