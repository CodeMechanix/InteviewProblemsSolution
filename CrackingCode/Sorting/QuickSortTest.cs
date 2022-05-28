using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CrackingCode.Sorting
{
    [TestClass]
    public class QuickSortTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            new QuickSort().Sort(new [] { 3, 7, 5, 9, 1, 6 });
        }
    }

    class QuickSort
    {
        public void Sort(int[] array)
        {
            Partition(array, 0, array.Length-1);
        }

        private void Partition(int[] array, int left, int right)
        {

            if (right - left < 2)
            {
                return;
            }
            int targetNum = array[right];
            int prev = array[left];
            int lastLowIndex = left - 1;

            for (int i = left; i <= right; i++)
            {
                int runner = array[i];

                if (runner < targetNum)
                {
                    if (prev > runner)
                    {
                        //swap
                        var i1 = array[lastLowIndex+1];
                        array[i] = i1;
                        array[lastLowIndex+1] = runner;
                    }


                    lastLowIndex++;
                }

                prev = runner;
            }

            var tmp = array[lastLowIndex + 1];
            array[right] = tmp;
            array[lastLowIndex + 1] = targetNum;

            Partition(array, left, lastLowIndex);
            Partition(array, lastLowIndex+2, right);
        }
    }
}
