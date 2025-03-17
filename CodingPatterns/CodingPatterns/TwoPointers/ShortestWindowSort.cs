using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingPatterns.TwoPointers
{
    [TestClass]
    public class ShortestWindowSortTest
    {
        [TestMethod]
        [DataRow(new int[] { 1, 2, 5, 3, 7, 10, 9, 12 }, 5)]
        [DataRow(new int[] { 1, 3, 2, 0, -1, 7, 10 }, 5)]
        [DataRow(new int[] { 1, 2, 3 }, 0)]
        [DataRow(new int[] { 3, 2, 1 }, 3)]
      
        public void Test(int[] arr, int result)
        {
            ShortestWindowSort.sort(arr)
                .ShouldBe(result);
        }
    }

    class ShortestWindowSort
    {
        public static int sort(int[] arr)
        {
            var sortedArr = new int[arr.Length];
            Array.Copy(arr, sortedArr, arr.Length);
            Array.Sort(sortedArr);    

            var left = 0;
            var right = arr.Length - 1;


                while (left <= right && arr[left] == sortedArr[left])
                {
                    left++;
                }
                
                while(left <= right && arr[right] == sortedArr[right])
                {
                    right--;
                }
            
            

            // TODO: Write your code here
            return right - (left - 1);
        }
    }
}
