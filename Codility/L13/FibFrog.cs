using System;
using System.Collections.Generic;

namespace Codility.L13
{
    class FibFrog
    {
        public class Solution
        {


            public int solution(int[] A)
            {

                var fibLeafTree = new FibLeafTree(A);
                var fibLeafTree_BFS = new FibLeafTree_BFS(fibLeafTree);
                return fibLeafTree_BFS.StepsCount(A.Length);

            }

        }

        class FibLeafTree_BFS
        {
            private readonly FibLeafTree _tree;

            public FibLeafTree_BFS(FibLeafTree tree)
            {
                _tree = tree;
            }

            public int StepsCount(int target)
            {
                var queue = new Queue<(int position, int spetCount)>();
                var visited = new HashSet<int>();
                queue.Enqueue((-1, 0));


                while (queue.Count > 0)
                {
                    (int position, int spetCount) = queue.Dequeue();


                    if (position == target)
                    {
                        return spetCount;
                    }

                    if (visited.Contains(position))
                    {
                        continue;
                    }
                    else
                    {
                        visited.Add(position);
                    }


                    int[] childs = _tree.GetChildFibPositions(position);

                    foreach (var item in childs)
                    {
                        queue.Enqueue((item, spetCount + 1));
                    }
                }

                return -1;

            }

        }

        class FibLeafTree
        {
            private readonly int[] _a;
            private int[] _fibArray;

            public FibLeafTree(int[] A)
            {
                _a = A;
                _fibArray = new FibonacciDynamic().FibSequence(A.Length + 3);

            }

            public int[] GetChildFibPositions(int position)
            {
                var childPositions = new List<int>();

                for (int i = 2; i < _fibArray.Length; i++)
                {
                    int fibNumber = _fibArray[i];
                    var nextPosition = fibNumber + position;

                    if (nextPosition > _a.Length)
                        break;

                    if (nextPosition == _a.Length || _a[nextPosition] == 1)
                    {
                        childPositions.Add(nextPosition);
                    }
                }

                return childPositions.ToArray();
            }
        }

        class FibonacciDynamic
        {

            public FibonacciDynamic()
            {
            }

            public int FibOf(int fibIndex)
            {
                var storage = new int[3];
                storage[1] = 1;

                int index = 2;
                while (index < fibIndex)
                {
                    storage[2] = storage[0] + storage[1];
                    Array.Copy(storage, 1, storage, 0, storage.Length - 1);
                    index++;
                }


                return storage[2];
            }

            public int[] FibSequence(int maxLimit)
            {
                var storage = new List<int> { 0, 1 };

                int index = 2;
                while (index < maxLimit)
                {
                    int nextFibValue = storage[index - 1] + storage[index - 2];

                    if (nextFibValue > maxLimit)
                    {
                        break;
                    }

                    storage.Add(nextFibValue);
                    index++;
                }

                return storage.ToArray();
            }


        }
    }


}
