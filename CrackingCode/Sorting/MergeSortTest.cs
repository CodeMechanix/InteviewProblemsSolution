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
            MergeSort mergeSort = new MergeSort();
            List<int> sort = mergeSort.Sort(new[] { 3, 7, 5, 9, 1, 3, 6 });
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
}