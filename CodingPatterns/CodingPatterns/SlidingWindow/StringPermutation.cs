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
            StringPermutation.findPermutation(str, pattern)
                .ShouldBe(result);
        }
    }

    class StringPermutation
    {
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

