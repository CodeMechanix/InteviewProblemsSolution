using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace LeetCode._695.MaxAreaOfIsland
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int[][] mat = new int[][]
            {
                new[] {0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0},
                new[] {0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0},
                new[] {0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0},
                new[] {0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 1, 0, 0},
                new[] {0, 1, 0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 0},
                new[] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0},
                new[] {0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0},
                new[] {0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0}
            };

           

            var maxAreaOfIsland = new Solution().MaxAreaOfIsland(mat);
        }
    }

    /// <summary>
    /// https://leetcode.com/problems/max-area-of-island/
    /// </summary>
    public class Solution
    {
      

        public int MaxAreaOfIsland(int[][] grid)
        {
            Dictionary<string, Point> dictionary = new Dictionary<string, Point>();

            FillIslandsList(grid, dictionary);


            Queue<Point> queue = new Queue<Point>();
            int maxIsland = 0;


            while (dictionary.Count != 0)
            {
                queue.Enqueue(dictionary.First().Value);

                int islandLength = 0;

                while (queue.Count != 0)
                {
                    Point islandPoint = queue.Dequeue();
                    dictionary.Remove(islandPoint.ToString());
                    IEnumerable<Point> enumerable = GetNeighbors(islandPoint, dictionary);
                    ProcessPoints(enumerable, queue, dictionary);
                    islandLength++;
                }

                if (islandLength > maxIsland)
                {
                    maxIsland = islandLength;
                }
            }

            return maxIsland;
        }

        private void ProcessPoints(IEnumerable<Point> enumerable, Queue<Point> queue, Dictionary<string, Point> _dictionary)
        {
            foreach (Point point in enumerable)
            {
                _dictionary.Remove(point.ToString());
                queue.Enqueue(point);
            }
        }

        private void RemoveFromDictionary(IEnumerable<Point> enumerable)
        {
        }


        private IEnumerable<Point> GetNeighbors(Point point, Dictionary<string, Point> _dictionary)
        {
            List<Point> list = new List<Point>();
            list.Add(new Point(point.X + 1, point.Y));
            list.Add(new Point(point.X - 1, point.Y));
            list.Add(new Point(point.X, point.Y + 1));
            list.Add(new Point(point.X, point.Y - 1));

            return list.Where(point1 => _dictionary.ContainsKey(point1.ToString()));
        }


        private void FillIslandsList(int[][] grid, Dictionary<string, Point> _dictionary)
        {
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        Point p = new Point(j, i);
                        _dictionary[p.ToString()] = p;
                    }
                }
            }
        }
    }
}