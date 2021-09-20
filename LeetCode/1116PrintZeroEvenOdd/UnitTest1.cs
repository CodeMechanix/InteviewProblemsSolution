using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using LeetCode._1195FizzBuzzMultithreaded;

namespace LeetCode._1116PrintZeroEvenOdd
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            List<Task> tasks = new List<Task>();
            ZeroEvenOdd f = new ZeroEvenOdd(5);


            tasks.Add(Task.Run(() => f.Even((n) => Debug.Write(n))));
            tasks.Add(Task.Run(() => f.Zero((n) => Debug.Write(n))));
            tasks.Add(Task.Run(() => f.Odd((n) => Debug.Write(n))));

            Task.WaitAll(tasks.ToArray());
        }
    }
}