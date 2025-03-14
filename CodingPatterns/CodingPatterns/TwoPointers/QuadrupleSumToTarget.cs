using Shouldly;
using System.Text;

namespace CodingPatterns.TwoPointers
{
    [TestClass]
    public class QuadrupleSumToTargetTest
    {
        [TestMethod]
        [DataRow(new[] { 4, 1, 2, -1, 1, -3 }, 1, new[] { -3, -1, 1, 4 }, new[] { -3, 1, 1, 2 })]
        [DataRow(new[] { 2, 0, -1, 1, -2, 2 }, 2, new[] { -2, 0, 2, 2 }, new[] { -1, 0, 1, 2 })]
        public void Test(int[] arr, int target, params int[][] ints)
        {
            var v = new QuadrupleSumToTarget();
            Array.Sort(arr);
            v.searchQuadruplets(arr, target)
                .ShouldBe(ints);
        }


        [TestMethod]
        [DataRow(new[] { 4, 1, 2, -1, 1, -3 }, 1, new[] { -3, 4 }, new[] { -1, 2 })]
        public void Test2(int[] arr, int target, params int[][] ints)
        {
            var v = new QuadrupleSumToTarget();
            Array.Sort(arr);
            v.FindAllPairWithSum(arr, target)
                .ShouldBe(ints);
        }

        [TestMethod]
        [DataRow(new[] { 4, 1, 2, -1, 1, -3 }, 0, new[] { -3, -1, 4 }, new[] { -3, 1, 2 })]
        public void Test3(int[] arr, int target, params int[][] ints)
        {
            var v = new QuadrupleSumToTarget();
            Array.Sort(arr);
            v.FindAllTripletWithSum(arr, target)
                .ShouldBe(ints);
        }
    }

    class QuadrupleSumToTarget
    {
        public IEnumerable<IEnumerable<int>> searchQuadruplets(int[] arr, int target)
        {
            for (int i = 0; i < arr.Length - 3; i++)
            {
                var first = arr[i];
                var triplets = FindAllTripletWithSum(new ArraySegment<int>(arr, i + 1, arr.Length - 1 - i).ToArray(), 
                    target - first);

                foreach (var triplet in triplets)
                {
                    yield return triplet.Prepend(first);
                }
            }
            
        }

        public IEnumerable<IEnumerable<int>> FindAllTripletWithSum(int[] arr, int target)
        {
            for (var i = 0; i < arr.Length - 2; i++)
            {
                var first = arr[i];
                if (i > 0 && first == arr[i - 1])
                {
                    continue;
                }
                var pairs = FindAllPairWithSum(
                    new ArraySegment<int>(arr, i + 1, arr.Length - i - 1).ToArray(),
                    target - first);

                foreach (var item in pairs)
                {
                    yield return item.Prepend(first);
                }

            }

        }

        public IEnumerable<IEnumerable<int>> FindAllPairWithSum(int[] arr, int target)
        {
            var left = 0; var right = arr.Length - 1;
            var list = arr;

            while (left < right)
            {
                var sum = list[left] + list[right];

                if (sum == target)
                {
                    yield return [list[left], list[right]];
                }
                else if (sum > target)
                {
                    do { right--; }
                    while (left < right && arr[right] == arr[right + 1]);
                    continue;
                }

                do
                {
                    left++;
                } while (left < right && arr[left] == arr[left - 1]);
            }

        }
    }
}
