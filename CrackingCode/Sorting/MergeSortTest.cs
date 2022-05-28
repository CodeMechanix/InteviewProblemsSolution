using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CrackingCode.Sorting
{
    [TestClass]
    public class MergeSortTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            // var mergeSort = new MergeSort();
            // var sort = mergeSort.Sort(new[] { 3, 7, 5, 9, 1, 6 });
            var mergeSortII = new MergeSortII();
            mergeSortII.Sort(new List<int>() { 3, 7, 5, 9, 1, 6 });
        }
    }

    class MergeSort
    {
        public List<int> Sort(int[] list)
        {
            Queue<List<int>> queue = new Queue<List<int>>();
            foreach (int i in list)
            {
                queue.Enqueue(new List<int>() { i });
            }

            while (queue.Count > 1)
            {
                List<int> left = queue.Dequeue();
                List<int> right = queue.Dequeue();

                queue.Enqueue(Merge(left, right));
            }

            return queue.Dequeue();
        }

        private List<int> Merge(List<int> left, List<int> right)
        {
            List<int> mergedList = new List<int>();

            while (left.Count != 0 && right.Count != 0)
            {
                if (left[0] < right[0])
                {
                    mergedList.Add(left[0]);
                    left.RemoveAt(0);
                }
                else
                {
                    mergedList.Add(right[0]);
                    right.RemoveAt(0);
                }
            }

            mergedList.AddRange(left);
            mergedList.AddRange(right);

            return mergedList;
        }

        // private void Merge(int l_first, int l_last, int r_first, int r_last)
        // {
        //
        // }
    }

    class MergeSortII
    {
        public void Sort(List<int> ints)
        {
            Split(ints, 0, ints.Count - 1);
        }

        private void Split(List<int> list, int left, int right)
        {
            int length = right - left;

            if (length <= 0)
            {
                return;
            }

            int mid = length / 2 + left;

            Split(list, left, mid);

            Split(list, mid + 1, right);


            Merge(list, left, mid, mid + 1, right);
        }

        private void Merge(List<int> list, int leftStart, int leftEnd, int rightStart, int rightEnd)
        {
            List<int> left = new List<int>();

            for (int i = leftStart; i <= leftEnd; i++)
            {
                left.Add(list[i]);
            }

            List<int> right = new List<int>();

            for (int i = rightStart; i <= rightEnd; i++)
            {
                right.Add(list[i]);
            }

            int indexMain = leftStart;

            while (left.Count > 0 && right.Count > 0)
            {
                int next;
                if (left[0] < right[0])
                {
                    next = left[0];
                    left.RemoveAt(0);
                }
                else
                {
                    next = right[0];
                    right.RemoveAt(0);
                }
                list[indexMain] = next;
                indexMain++;
            }

            List<int> leftOvers = left.Count > 0 ? left : right;

            while (leftOvers.Count > 0)
            {
                list[indexMain] = leftOvers[0];
                leftOvers.RemoveAt(0);
                indexMain++;
            }

        }
    }
}