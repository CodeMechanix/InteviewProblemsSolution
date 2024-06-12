using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Codility.L6
{
    [TestClass]
    public class NumberOfDiscIntersectionsTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var solution = new Solution().solution(new[] { 1, 5, 2, 1, 4, 0 });
        }

        class Solution
        {
            public int solution(int[] A)
            {
                //Create Shapes List
                var shapes = new List<Shape>();
                for (int i = 0; i < A.Length; i++)
                {
                    shapes.Add(new Shape(i, A[i]));
                }

                //Sort shapes by left side
                shapes.Sort((shape1, shape2) => (int)(shape1.LeftSide() - shape2.LeftSide()));

                int countIntersections = 0;


                for (int i = 0; i < shapes.Count; i++)
                {
                    var currentShape = shapes[i];

                    for (int j = i + 1; j < shapes.Count; j++)
                    {
                        var nextShape = shapes[j];

                        if (currentShape.Touch(nextShape))
                        {
                            countIntersections++;
                            if (countIntersections > 10000000)
                            {
                                return -1;
                            }
                        }
                        else
                        {
                            break;
                            // continue to next currentShape
                        }
                    }
                }


                return countIntersections;
            }


            class Shape
            {
                public Shape(int center, int radius)
                {
                    Center = center;
                    Radius = radius;
                }

                public double Center { get; set; }
                public double Radius { get; set; }

                public double LeftSide()
                {
                    return Center - Radius;
                }

                public double RightSide()
                {
                    return Center + Radius;
                }

                public bool Touch(Shape otherShape)
                {
                   // Debug.WriteLine($"this.RightSide():{this.RightSide()} | otherShape.LeftSide():{otherShape.LeftSide()}");
                    return (this.RightSide() >= otherShape.LeftSide());
                }
            }
        }
    }
}