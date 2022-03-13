using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Hackerrank
{
    [TestClass]
    public class GridChallenge
    {
        [TestMethod]
        public void TestMethod1()
        {
            var challenge = gridChallenge(new List<string>() { "mpxz", "abcd", "wlmf" });
        }

        public static string gridChallenge(List<string> grid)
        {
            for (int i = 0; i < grid.Count; i++)
            {
                if (!IsSorted(grid[i]))
                {
                    char[] charArray = grid[i].ToCharArray();
                    Array.Sort(charArray);
                    grid[i] = new string(charArray);
                }
            }

            for (int i = 0; i < grid[0].Length; i++)
            {
                for (int j = 0; j < grid.Count -1; j++)
                {
                    int left = grid[j][i];
                    int right = grid[j+1][i];
                    if (left > right)
                    {
                        return "NO";
                    }
                }
            }

            return "YES";
        }

        private static bool IsSorted(string s)
        {
            for (int i = 0; i < s.Length - 1; i++)
            {
                if (s[i] > s[i + 1])
                {
                    return false;
                }
            }

            return true;
        }
    }
}