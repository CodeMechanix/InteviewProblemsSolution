using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Hackerrank
{
    [TestClass]
    public class DiagonalDifference
    {
        [TestMethod]
        public void TestMethod()
        {
            var difference = diagonalDifference(new List<List<int>>()
            {
                new List<int>() { 1, 2, 3 },
                new List<int>() { 4, 5, 6 },
                new List<int>() { 9, 8, 9 }
            });
        }

        public static int diagonalDifference(List<List<int>> arr)
        {
            int listLeft = 0;
            int listRight = 0;

            int indexLeft = 0;

            foreach (List<int> ints in arr)
            {
                listLeft += (ints[indexLeft]);
                listRight += (ints[ints.Count - 1 - indexLeft]);
                indexLeft++;
            }

            return Math.Abs(listLeft - listRight);
        }
    }
}