using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;

namespace CodingPatterns.TwoPointers
{
    [TestClass]
    public class TripletSumCloseToTargetTest
    {
        [TestMethod]
        [DataRow(new[] { -2, 0, 1, 2 }, 2, 1)]
        [DataRow(new[] { -3, -1, 1, 2 }, 1, 0)]
        [DataRow(new[] { 1, 0, 1, 1 }, 100, 3)]

        public void Test(int[] arr, int targetSum, int result)
        {
            TripletSumCloseToTarget.searchTriplet(arr, targetSum)
                .ShouldBe(result);
        }
    }
    class TripletSumCloseToTarget
    {
        public static int searchTriplet(int[] arr, int targetSum)
        {
            Array.Sort(arr);
            var result = -1;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                var first = arr[i];
                var left = i + 1;
                var right = arr.Length - 1;
                while (left < right)
                {
                    var sum = first + arr[left] + arr[right];
                    if (sum <= targetSum)
                    {
                        result = Math.Max(result, sum);
                        left++;
                    }
                    else
                    {
                        right--;
                    }

                    
                }

            }


            // TODO: Write your code here
            return result;
        }
    }
}
