using System.Data;
using Shouldly;

namespace CodingPatterns.TwoPointers
{
    [TestClass]
    public class SubarrayProductLessThanKTest
    {
        [TestMethod]
        [DataRow(new[] { 2, 5, 3, 10 }, 30,
            new[] { 2 }, new[] { 5 }, new[] { 2, 5 }, new[] { 3 }, new[] { 5, 3 }, new[] { 10 })]
        [DataRow(new[] { 8, 2, 6, 5 }, 50,
            new[] { 8 }, new[] { 2 }, new[] { 8, 2 }, new[] { 6 }, new[] { 2, 6 }, new[] { 5 }, new[] { 6, 5 })]
        public void Test(int[] arr, int target, params int[][] result)
        {
            SubarrayProductLessThanK.findSubarrays(arr, target)
                .ShouldBe(result.Select(i => i.ToList()));
        }
    }
    class SubarrayProductLessThanK
    {

        public static List<List<int>> findSubarrays(int[] arr, int target)
        {
            List<List<int>> subarrays = new();

            var start = 0;
            var product = 1;

            for (int end = 1; end <= arr.Length; end++)
            {
                product = arr[end - 1] * product;

                if (arr[end - 1] < target)
                {
                    subarrays.Add([arr[end - 1]]);
                }

                while (product >= target)
                {
                    var remove = arr[start];
                    product /= arr[start];
                    start++;

                };

                var subList = new List<int>();

                for (int i = start; i < end; i++)
                {
                    subList.Add(arr[i]);
                }

                if (subList.Count > 1)
                    subarrays.Add(subList);
            }

            // TODO: Write your code here
            return subarrays;
        }
    }
}
