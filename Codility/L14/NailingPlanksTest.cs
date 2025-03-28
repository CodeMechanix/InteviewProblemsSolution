﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Codility.L14
{
    [TestClass]
    public class NailingPlanksTest
    {
        [TestMethod]
        public void Test()
        {
            var A = new[] { 28,18,43,15,26,18,21,49,6,23,12,18,50,17,31,21,37,23,9,22,21,40,29,10,34,15,26,11,21,40,26,38,38,30,33,20,31,39,5,47,19,7,8,18,4,20,21,33,24,47,33,17,44,35,49,37,49,11,14,49,2,47,46,7,8,46,48,44,37,38,16,1,32,45,48,26,1,9,23,12,2,10,25,7,6,9,2,40,44,11,32,44,13,17,45,39,32,40,29,16
 };
            var B = new[] { 55, 32, 44, 48, 36, 31, 41, 81, 56, 46, 62, 68, 62, 20, 39, 63, 67, 69, 58, 55, 48, 43, 30, 51, 68, 53, 54, 45, 53, 85, 31, 63, 53, 72, 77, 32, 35, 51, 21, 86, 39, 45, 23, 44, 13, 52, 47, 76, 72, 73, 36, 64, 92, 59, 73, 84, 61, 24, 49, 83, 36, 89, 72, 28, 19, 56, 66, 66, 74, 69, 42, 20, 63, 64, 88, 58, 36, 28, 49, 48, 50, 36, 41, 42, 12, 26, 3, 68, 56, 30, 72, 76, 14, 39, 45, 80, 57, 83, 42, 57 };
            var C = new[] { 55, 35, 85, 29, 52, 35, 42, 98, 11, 45, 23, 35, 100, 33, 61, 42, 74, 45, 18, 44, 41, 80, 57, 20, 68, 30, 52, 22, 42, 79, 52, 76, 76, 59, 65, 40, 62, 78, 10, 94, 37, 14, 16, 35, 7, 40, 42, 66, 47, 94, 66, 33, 88, 70, 97, 74, 97, 21, 28, 98, 3, 93, 92, 14, 16, 92, 96, 87, 73, 76, 31, 1, 63, 89, 95, 52, 1, 18, 45, 24, 3, 20, 50, 13, 12, 17, 4, 79, 87, 21, 64, 88, 25, 34, 89, 77, 63, 80, 58, 32, 69, 79, 6, 33, 30, 89, 29, 68, 44, 38, 50, 90, 66, 39, 16, 35, 48, 65, 100, 33, 95, 92, 45, 23, 24, 93, 18, 65, 66, 17, 4, 64, 6, 55, 98, 47, 32, 11, 31, 33, 12, 71, 61, 72, 11, 26, 93, 1, 37, 82, 23, 23, 64, 26, 34, 40, 30, 66, 74, 77, 99, 8, 26, 99, 80, 77, 23, 13, 28, 90, 76, 37, 66, 74, 29, 11, 82, 71, 81, 75, 37, 66, 37, 91, 13, 70, 35, 91, 81, 18, 2, 24, 97, 77, 71, 21, 22, 45, 54, 62, 6, 85, 25, 72, 32, 30, 88, 22, 51, 88, 83, 72, 25, 63, 48, 31, 78, 68, 90, 43, 15, 28, 74, 71, 65, 40, 58, 7, 10, 81, 12, 63, 30, 18, 79, 89, 32, 16, 47, 12, 97, 3, 51, 17, 1, 100, 69, 71, 77, 79, 61, 67, 32, 11, 73, 74, 74, 65, 9, 65, 9, 88, 1, 27, 54, 87, 66, 14, 73, 21, 34, 37, 80, 21, 33, 29, 25, 22, 39, 18, 26, 12, 59, 70, 24, 45, 61, 98, 97, 12, 95, 81, 23, 20, 51, 29, 32, 41, 55, 55 };

            int v = new Solution().solution(A, B, C);
        }



        class Solution
        {
            public int solution(int[] A, int[] B, int[] C)
            {
                BinarySearchInRange search = new BinarySearchInRange();
                int maxNails = -1 ;


                //create 2d array
                var nails = new int[C.Length][];
                for (int i = 0; i < C.Length; i++)
                {
                    nails[i] = new [] { C[i], i };
                }
                Array.Sort(nails, (a, b) => a[0] - b[0]);

                for (int i = 0; i < A.Length; i++)
                {
                    var plankStart = A[i];
                    var plankEnd = B[i];

                    int minNailPosition = search.FindMin(plankStart, plankEnd, nails);
                    if (minNailPosition < 0)
                    {
                        return -1;
                    }

                    int minNailIndex = nails[minNailPosition][1];

                    for (int j = minNailPosition+1; j < C.Length; j++)
                    {
                        int nailValue = nails[j][0];
                        if (nailValue > plankEnd)
                        {
                            break;
                        }

                        int nailPosition = nails[j][1];

                        minNailIndex = Math.Min(nailPosition, minNailIndex);
                    }

                    maxNails = Math.Max(maxNails, minNailIndex + 1);
                }
                return maxNails;
            }
        }

       
        class BinarySearchInRange
        {
            public int FindMin(int plankStart, int plankEnd, int[][] values)
            {
                var low = 0;
                var high = values.Length-1;

                var minResult = -1;

                while (low<= high)
                {
                    var mid = (low + high) / 2;
                    int resultValue = values[mid][0];

                    if (resultValue < plankStart)
                    {
                        low = mid + 1;
                    }
                    else if(resultValue > plankEnd)
                    {
                        high = mid - 1;
                    }
                    else
                    {
                        if (minResult <0) minResult = mid;
                        minResult = Math.Min(minResult, mid);
                        high = mid - 1;
                    }
                }

                return minResult;

            }

            private int Recursion(int start, int end, int[] values, int from, int to)
            {
                if (end < start) { return -1; }

                var mid = ((end - start) / 2) + start;

                int midValue = values[mid];

                if (from <= midValue && midValue <= to)
                {
                    return mid;
                }

                if (midValue > from)
                {
                    return Recursion(start, mid - 1, values, from, to);
                }

                return Recursion(mid + 1, end, values, from, to);
            }

        }
        class BinarySearch
        {
            private readonly int[] _values;

            public BinarySearch(int[] values)
            {
                _values = values;

            }


            public int FindIndexOf(int value)
            {
                return Recursion(0, _values.Length - 1, value);
            }

            private int Recursion(int start, int end, int value)
            {
                if (end < start) { return -1; }

                var mid = ((end - start) / 2) + start;

                int midValue = _values[mid];

                if (midValue == value)
                {
                    return mid;
                }

                if (midValue > value)
                {

                    return Recursion(start, mid - 1, value);
                }
                return Recursion(mid + 1, end, value);
            }

        }

    }
}
