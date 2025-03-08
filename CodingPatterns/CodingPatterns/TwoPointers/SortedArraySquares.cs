using Shouldly;

namespace CodingPatterns.TwoPointers
{
    [TestClass]
    public class SortedArraySquares_Test
    {
        [TestMethod]
        [DataRow(new[] { -2, -1, 0, 2, 3 }, new[] { 0, 1, 4, 4, 9 })]
        [DataRow(new[] { -3, -1, 0, 1, 2 }, new[] { 0, 1, 1, 4, 9 })]
        public void Test(int[] arr, int[] expected)
        {
            SortedArraySquares.makeSquares(arr)
                .ShouldBe(expected);
        }
    }
    class SortedArraySquares
    {

        public static int[] makeSquares(int[] arr)
        {
            int[] squares = new int[arr.Length];
            int nextIndex = arr.Length - 1;
            int l_index = 0;
            int r_index = arr.Length - 1;

            while (l_index < r_index)
            {
                var l_Value = arr[l_index];
                var r_Value = arr[r_index];
                var nextValue = 0;
                if (Math.Abs(l_Value) < Math.Abs(r_Value))
                {
                    //right side select
                    nextValue = (int)Math.Pow(r_Value, 2);
                    r_index--;
                }
                else {
                    nextValue = (int)Math.Pow(l_Value, 2);
                    l_index++;
                }

                squares[nextIndex] = nextValue;
                nextIndex--;
            }

            // TODO: Write your code here
            return squares;
        }
    }
}
