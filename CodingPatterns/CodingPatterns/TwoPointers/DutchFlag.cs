using Shouldly;

namespace CodingPatterns.TwoPointers
{
    [TestClass]
    public class DutchFlagTest
    {
        [TestMethod]
        [DataRow(new[] { 1, 0, 2, 1, 0 }, new[] { 0, 0, 1, 1, 2 })]
        [DataRow(new[] { 2, 2, 0, 1, 2, 0 }, new[] { 0, 0, 1, 2, 2, 2 })]
        public void Test(int[] arr, int[] result)
        {
            DutchFlag.sort(arr);
            arr.ShouldBe(result);
        }
    }

    class DutchFlag
    {

        public static void sort(int[] arr)
        {
            // TODO: Write your code here   
            int nextIndex = 0;

            for (int i = 0; i < arr.Length; i++)
            {

                var value = arr[i];

                if (value == 0)
                {
                    var a = arr[nextIndex];
                    arr[nextIndex] = value;
                    arr[i] = a;
                    nextIndex++;
                }
            }

            for (int i = nextIndex; i < arr.Length; i++)
            {
                var value = arr[i];

                if (value == 1)
                {
                    var a = arr[nextIndex];
                    arr[nextIndex] = value;
                    arr[i] = a;
                    nextIndex++;
                }
            }
        }
    }
}
