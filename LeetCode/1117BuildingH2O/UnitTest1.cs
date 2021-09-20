using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace LeetCode._1117BuildingH2O
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            List<Task> tasks = new List<Task>();
            H2O f = new H2O();


       

            tasks.Add(Task.Run(() => f.Oxygen(() => Debug.Write("O"))));
            tasks.Add(Task.Run(() => f.Oxygen(() => Debug.Write("O"))));
            tasks.Add(Task.Run(() => f.Oxygen(() => Debug.Write("O"))));

            tasks.Add(Task.Run(() => f.Hydrogen(() => Debug.Write("H"))));
            tasks.Add(Task.Run(() => f.Hydrogen(() => Debug.Write("H"))));

            tasks.Add(Task.Run(() => f.Hydrogen(() => Debug.Write("H"))));
            tasks.Add(Task.Run(() => f.Hydrogen(() => Debug.Write("H"))));

            tasks.Add(Task.Run(() => f.Hydrogen(() => Debug.Write("H"))));
            tasks.Add(Task.Run(() => f.Hydrogen(() => Debug.Write("H"))));


            Task.WaitAll(tasks.ToArray());
        }
    }
}