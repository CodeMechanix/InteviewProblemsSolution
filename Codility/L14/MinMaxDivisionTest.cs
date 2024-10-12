using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Codility.L14
{
    [TestClass]
    public class MinMaxDivisionTest
    {
        [TestMethod]
        public void TestMethod()
        {
            //int v = new BynarySearch()
            //    .FindCloseTo(new int[] { 2, 1, 5, 1, 2, 2, 2 }, 5);
            int v = new MinMaxDivision.Solution().solution(3, 5, new int[] { 2, 1, 5, 1, 2, 2, 2 });


        }
        class MinMaxDivision
        {
            public class Solution
            {
                public int solution(int K, int M, int[] A)
                {
                    int mid = M;
                    int low = M;
                    int high = 0;
                    foreach (int i in A)
                    {
                        high += i;
                    }

                    while (high >= low)
                    {
                        mid = (high + low) / 2;

                        if (CanSplit(A, K, mid))
                        {
                              high = mid -1;
                        }
                        else
                        {
                          
                            low = mid + 1;
                        }
                    }

                    return mid;
                }


                private bool CanSplit(int[] A, int K, int maxBlockSum)
                {
                    int usedBlocks = 1;
                    int blockSum = 0;

                    for (int i = 0; i < A.Length; i++)
                    {
                        if(blockSum +  A[i] > maxBlockSum)
                        {
                            usedBlocks++;

                            if (usedBlocks > K) return false;

                            blockSum = A[i];
                        }
                        else
                        {
                            blockSum += A[i];
                        }
                    }

                    return true;
                }
            }


        }

    }



}
