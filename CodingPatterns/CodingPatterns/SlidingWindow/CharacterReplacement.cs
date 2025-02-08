using Shouldly;

namespace CodingPatterns.SlidingWindow
{
    [TestClass]

    public class CharacterReplacement_Test
    {
        [TestMethod]
        [DataRow("aabccbb", 2, 5)]
        [DataRow("abbcb", 1, 4)]
        [DataRow("abccde", 1, 3)]
        public void Test(string text, int k, int expected)
        {
            CharacterReplacement.findLength(text, k)
                .ShouldBe(expected);
        }
    }

    class CharacterReplacement
    {
        public static int findLength(String str, int k)
        {
            int start = 0;
            int max = 0;
            int tmpCount = 0;

            var dic = new Dictionary<char, int>();

            for (int end = 0; end < str.Length; end++)
            {
                var currentChar = str[end];

                if (dic.ContainsKey(currentChar))
                {
                    dic[currentChar]++;
                }
                else
                {
                    dic.Add(currentChar, 1);
                }

                tmpCount++;

                while (ShouldSrink(dic, k))
                {
                    dic[str[start]]--;

                    if (dic[str[start]] == 0)
                        dic.Remove(str[start]);

                    start++;
                    tmpCount--;
                }

                max = Math.Max(max, tmpCount);
            }

            return max;
        }
        private static bool ShouldSrink(Dictionary<char, int> dic, int k)
        {
            if (dic.Keys.Count > k + 1)
                return true;

            if (dic.Count == 1)
            {
                return false;
            }

            var maxPair = dic.MaxBy(p  => p.Value);

            var enumerable = dic.Where(p =>
            {
                return p.Key != (maxPair.Key);
            }).ToArray();
            int v = enumerable.Sum(pair => pair.Value);
            return v > k;

        }
    }
}
