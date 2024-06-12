using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Codility.L7
{
    [TestClass]
    public class FishTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var solution = new Solution().solution(new[] { 4, 3, 2, 1, 5 }, new[] { 0, 1, 0, 0, 0 });
        }

        class Solution
        {
            private Stack<Fish> _stack = new Stack<Fish>();

            public int solution(int[] A, int[] B)
            {
                for (int i = 0; i < A.Length; i++)
                {
                    var fish = new Fish(A[i], (Direction)B[i]);

                    if (_stack.Count == 0)
                    {
                        _stack.Push(fish);
                    }
                    else
                    {
                        while (_stack.Count != 0 &&
                               _stack.Peek().Direction == Direction.Down &&
                               fish.Direction == Direction.Up)
                        {
                            if (_stack.Peek().Size < fish.Size)
                            {
                                _stack.Pop();
                            }
                            else
                            {
                                fish = null;
                                break;
                            }
                        }

                        if (fish != null)
                        {
                            _stack.Push(fish);
                        }
                    }
                }


                return _stack.Count;
            }


            enum Direction
            {
                Up,
                Down,
            }

            class Fish
            {
                public int Size { get; set; }
                public Direction Direction { get; set; }

                public Fish(int size, Direction direction)
                {
                    Size = size;
                    Direction = direction;
                }
            }
        }
    }
}