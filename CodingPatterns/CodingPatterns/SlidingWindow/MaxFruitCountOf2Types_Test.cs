using Shouldly;

namespace CodingPatterns.SlidingWindow
{
    [TestClass]
    public class MaxFruitCountOf2Types_Test
    {
        [TestMethod]
        [DataRow(new[] { 'A', 'B', 'C', 'A', 'C' }, 3)]
        [DataRow(new[] { 'A', 'B', 'C', 'B', 'B', 'C' }, 5)]
        public void TestMethod1(char [] str, int num)
        {
            MaxFruitCountOf2Types.findLength(str)
                .ShouldBe(num);
        }

        
    }
    class MaxFruitCountOf2Types
    {
        public static int findLength(char[] arr)
        {
            int max = 0;
            int windowsStart = 0;
            var dictionary = new Dictionary<char, int>();
            int currentCount = 0;

            //Grow
            for (int windowEnd = 0; windowEnd < arr.Length; windowEnd++)
            {
                var c = arr[windowEnd];

                if (dictionary.ContainsKey(c))
                {
                    dictionary[c]++;
                }
                else {
                    dictionary[c] = 1;
                }
                currentCount++;

                //Shrink
                while (dictionary.Count > 2)
                {
                    char v = arr[windowsStart];
                    var value = dictionary[v];
                    currentCount-= value;
                    dictionary.Remove(v);
                }

                max = Math.Max(max, currentCount);
            }


            // TODO: Write your code here
            return max;
        }
    }
}
