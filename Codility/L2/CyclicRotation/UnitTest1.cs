using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Codility.L2.CyclicRotation
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var solution = new Solution().solution(new[] {3, 8, 9, 7, 6}, 5);
        }
    }

    class Solution
    {
        public int[] solution(int[] A, int K)
        {
            if (K > A.Length)
            {
                K = K % A.Length;
            }
            return RotateOnce(A, K);
        }

        private int[] RotateOnce(int[] A, int K)
        {
            int midArrayStartIndex = A.Length - K;

            int[] rotatedArr = new int[A.Length];

            int i = 0;

            for (; i < K; i++)
            {
                rotatedArr[i] = A[midArrayStartIndex + i];
            }

            for (; i < A.Length; i++)
            {
                rotatedArr[i] = A[i - K];
            }

            return rotatedArr;
        }
    }
}