using FluentAssertions;
using System.Diagnostics;

namespace OtherCategory
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [DataRow(3, 1, 10)]
        [DataRow(5, 1, 10)]
        public void TestMethod1(int amountOfNumbersToGenerate,int minValue, int maxValue)
        {
            IEnumerable<int> enumerable = GenerateUniqueRandom(amountOfNumbersToGenerate, minValue, maxValue);
            enumerable
                .Should()
                .OnlyHaveUniqueItems()
                .And
                .HaveCount(amountOfNumbersToGenerate);

            foreach (var item in enumerable)
            {
                Debug.Write(item);
                Debug.Write(' ');
            };
        }

        int GenrateRandom(int minValue, int maxValue)
        {
            Random random = new Random();
            return random.Next(minValue, maxValue+1);
        }

        public IEnumerable<int> GenerateUniqueRandom(
            int amountOfNumbersToGenerate, 
            int minValue, int maxValue) 
        {
            var counter = amountOfNumbersToGenerate;
            var set = new HashSet<int>();

            while (counter > 0)
            {
                int newRnd = GenrateRandom(minValue, maxValue);

                if (set.Add(newRnd))
                {
                    yield return newRnd;
                    counter--;
                }
            }
        }
    }
}