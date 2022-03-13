using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Hackerrank
{
    [TestClass]
    public class NewYearChaos
    {
        [TestMethod]
        public void TestMethod1()
        {
            minimumBribes(new List<int>() { 1, 2, 5, 3, 7, 8, 6, 4 });
        }


        public static void minimumBribes(List<int> q) // count times of insertion sort need to move items back to order
        {
            int stepsCounter = 0; //TODO add count for swap same value
            int stepsMax = 2;
            int stepsCurrent = 0;

            int leftIndex = 0;
            int rightIndex = 1;

            while (rightIndex < q.Count)
            {
                if (q[leftIndex] <= q[rightIndex])
                {
                    leftIndex++;
                    rightIndex++;
                }
                else
                {
                    Swap(leftIndex, rightIndex, q);
                    if (leftIndex == 0)
                    {
                        break;
                    }

                    leftIndex--;
                    rightIndex--;
                }
            }
        }

        private static void Swap(int index1, int index2, List<int> q)
        {
            int temp = q[index1];
            q[index1] = q[index2];
            q[index2] = temp;
        }

        // public static void minimumBribes(List<int> q) // count times of insertion sort need to move items back to order
        // {
        //     int bribeCount = 0;
        //
        //     for (int i = 0; i < q.Count; i++)
        //     {
        //         if (q[i] > i + 1)
        //         {
        //             int bribe = q[i] - (i + 1);
        //             if (bribe > 2)
        //             {
        //                 Console.WriteLine("Too chaotic");
        //                 break;
        //             }
        //             else
        //             {
        //                 bribeCount += bribe;
        //             }
        //         }
        //     }
        //
        //     Console.WriteLine(bribeCount);
        // }
    }
}