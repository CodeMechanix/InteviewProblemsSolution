using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;

namespace LeetCode._733.FloodFill
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //            var floodFill = new Solution().FloodFill(new int[][]
            //            {
            //                new int[] {1, 1, 1},
            //                new int[] {1, 1, 0},
            //                new int[] {1, 0, 1}
            //            }, 1, 1, 2);

            int[][] image = new int[][]
            {
                new int[] {0,0,0},
                new int[] {0,1,1 },
               
            };

            var imageLength = image.Length;
            var length = image[0].Length;
            var floodFill = new Solution().FloodFill(image, 1,1,1);
        }
    }

    public class Solution
    {
        public int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
        {

            if (image[sr][sc] ==newColor)
            {
                return image;
            }


            Queue<Point> queue = new Queue<Point>();
            queue.Enqueue(new Point(sr, sc));
            int originalColor = image[sr][sc];
           Print(image);

            while (queue.Count != 0)
            {
                Point dequeue = queue.Dequeue();
                Paint(image, dequeue, newColor);
               Print(image);
                IEnumerable<Point> connectedPoints = GetConnectedPoints(image, dequeue);
                IEnumerable<Point> sameColorPoints = GetSameColorPoints(image, connectedPoints, originalColor);
                foreach (Point point in sameColorPoints)
                {
                    if (!queue.Contains(point))
                    {
                        queue.Enqueue(point);
                    }
                }
            }

            return image;
        }

        private IEnumerable<Point> GetConnectedPoints(int[][] image, Point p)
        {
            List<Point> list = new List<Point>()
            {
                new Point(p.X - 1, p.Y),
                new Point(p.X + 1, p.Y),
                new Point(p.X, p.Y - 1),
                new Point(p.X, p.Y + 1),
            };

            //fix dimetions validation
            return list.Where(point => point.X > -1 && point.X < image.Length &&
                                       point.Y > -1 && point.Y < image[point.X].Length);
        }

        private IEnumerable<Point> GetSameColorPoints(int[][] image, IEnumerable<Point> points, int newColor)
        {
            return points.Where(point => image[point.X][point.Y] == newColor);
        }

        private void Paint(int[][] image, Point point, int newColor)
        {
            image[point.X][point.Y] = newColor;
        }

        private void Print(int[][] image)
        {
            Debug.WriteLine("");
            for (int i = 0; i < image.Length; i++)
            {
                Debug.WriteLine(string.Join(" ", image[i]));
            }
        }
    }
}