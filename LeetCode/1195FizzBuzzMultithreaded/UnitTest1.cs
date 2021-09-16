using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace LeetCode._1195FizzBuzzMultithreaded
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            List<Task> tasks = new List<Task>();
            FizzBuzz buzz = new FizzBuzz(15);

            
            tasks.Add(Task.Run(() => buzz.Buzz(() => Debug.Write("Buzz"))));
            tasks.Add(Task.Run(() => buzz.Fizz(() => Debug.Write("Fuzz"))));
            tasks.Add(Task.Run(() => buzz.Fizzbuzz(() => Debug.Write("Fizzbuzz"))));
            tasks.Add(Task.Run(() => buzz.Number((num) => Debug.Write(num))));

            Task.WaitAll(tasks.ToArray());

        }
    }
}
