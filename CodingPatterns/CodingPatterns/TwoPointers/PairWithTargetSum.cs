using Shouldly;

namespace CodingPatterns.TwoPointers
{
    [TestClass]
    public class PairWithTargetSum_Test
    {
        [TestMethod]
        [DataRow(new[] { 1, 2, 3, 4, 6 }, 6, new[] { 1, 3 })]
        [DataRow(new[] { 2, 5, 9, 11 }, 11, new[] { 0, 2 })]
        public void Test(int[] arr, int targetSum, int[] result)
        {
            PairWithTargetSum.search(arr, targetSum)
                .ShouldBe(result);
        }
    }
    class PairWithTargetSum
    {
        public static int[] search(int[] arr, int targetSum)
        {
            int left = 0;
            int right = arr.Length - 1;
            while (left < right)
            {

                var sum = arr[left] + arr[right];


                if (sum > targetSum)
                {
                    right--;
                    continue;
                }
                else if (sum < targetSum)
                {
                    left++;
                    continue;
                }


                return new int[] {left, right};
            }
            // TODO: Write your code here
            return new int[] { -1, -1 };
        }
    }
}
