using System.Diagnostics.CodeAnalysis;
using Shouldly;

namespace CodingPatterns.TwoPointers
{
    [TestClass]
    public class TripletSumToZeroTest
    {
        [TestMethod]
        [DynamicData(nameof(data))]
        public void Test(int[] arr, List<List<int>> result)
        {
            TripletSumToZero.searchTriplets(arr)
                .ShouldBe(result);
        }
        private static IEnumerable<object[]> data =>
        [
                [
                    new[] { -3, 0, 1, 2, -1, 1, -2 },
                    new List<List<int>>([[-3, 1, 2], [-2, 0, 2], [-2, 1, 1], [-1, 0, 1]])
                ],
                [
                    new[] {-5, 2, -1, -2, 3},
                    new List<List<int>>([[-5, 2, 3], [-2, -1, 3]])
                ],
        ];
    }
    class TripletSumToZero
    {
        public static List<List<int>> searchTriplets(int[] arr)
        {
            List<List<int>> triplets = new List<List<int>>();
            var v = new HashSet<List<int>>(new Comparer());
            Array.Sort(arr);
            int leftP= 0;
            int rightP= arr.Length-1;

            for (int i = 0; i < arr.Length; i++)
            {
                int value = arr[i];
                leftP = i + 1;
                rightP = arr.Length - 1;
                if (value < 0)//search for two numbers with sum equal Abs(i)
                {
                    while (leftP < rightP)
                    {
                        var sum = arr[leftP] + arr[rightP] + value;
                        if (sum < 0)
                        {
                            leftP++;
                        }else if (sum > 0)
                        {
                            rightP--;
                        }
                        else
                        {
                            v.Add([value, arr[leftP], arr[rightP]]);
                            rightP--;
                        }
                    }
                }
                else
                {
                    break;
                }
            }

            return v.ToList();
        }

        class Comparer : IEqualityComparer<List<int>>
        {
            public bool Equals(List<int>? x, List<int>? y)
            {
                return string.Join('-',x).Equals(string.Join('-', y));
            }

            public int GetHashCode([DisallowNull] List<int> obj)
            {
                return string.Join('-', obj).GetHashCode();
            }
        }
    }
}
