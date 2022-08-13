using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Educative.multithreading
{
    [TestClass]
    public class MultithreadedMergeSortTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var ints = new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
            MultithreadedMergeSort.MergeSort(0, ints.Length - 1, ints);
        }
    }

    class MultithreadedMergeSort
    {
        public static void MergeSort(int start, int end, int[] input)
        {
            Debug.WriteLine($"start: {start}, end: {end}");

            if (start == end)
            {
                return;
            }
            var length = (end - start) / 2;
            Task task1 = Task.Run(() => MergeSort(start, start + length, input)); 
            Task task2 = Task.Run(() => MergeSort(start + length + 1, end, input));

            Task.WaitAll(new Task[] { task1, task2 });

            Merge(start, start + length, start + length + 1, end, input);
        }

        private static void Merge(int start1, int end1, int start2, int end2, int[] input)
        {
            List<int> result = new List<int>();
            Queue<int> left = new Queue<int>();
            Queue<int> right = new Queue<int>();

            for (int i = start1; i <= end1; i++)
            {
                left.Enqueue(input[i]);
            }

            for (int i = start2; i <= end2; i++)
            {
                right.Enqueue(input[i]);
            }

            Queue<int> current = left;

            while (current.Count > 0)
            {
                if (left.Peek() < right.Peek())
                {
                    current = left;
                }
                else
                {
                    current = right;
                }

                result.Add(current.Dequeue());
            }

            current = left;
            while (current.Count > 0)
            {
                result.Add(current.Dequeue());
            }

            current = right;
            while (current.Count > 0)
            {
                result.Add(current.Dequeue());
            }

            int indexStart = start1;
            foreach (var i in result)
            {
                input[indexStart] = i;
                indexStart++;
            }
            Debug.WriteLine(String.Join(" ", input));
        }
    }
}