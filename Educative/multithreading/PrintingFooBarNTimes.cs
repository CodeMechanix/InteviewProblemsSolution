using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Educative.multithreading
{
    [TestClass]
    public class PrintingFooBarNTimes
    {
        [TestMethod]
        public void TestMethod1()
        {
            var printFooBar = new PrintFooBar(10);
            var task = Task.Run(() => printFooBar.PrintBar());
            Task run = Task.Run(() => { printFooBar.PrintFoo(); });

            Task.WaitAll(new Task[]{task, run});

        }
    }

    class PrintFooBar
    {
        private readonly int _n;
        private AutoResetEvent _eventFoo = new AutoResetEvent(true);
        private AutoResetEvent _eventBar = new AutoResetEvent(false);

        public PrintFooBar(int n)
        {
            _n = n;
        }
        public void PrintFoo()
        {
          
            for (int i = 1; i <= _n; i++)
            {
                _eventFoo.WaitOne();
                Debug.WriteLine("Foo");
                _eventBar.Set();
            }
        }
        public void PrintBar()
        {
          
            for (int i = 1; i <= _n; i++)
            {
                _eventBar.WaitOne();
               Debug.WriteLine("Bar");
               _eventFoo.Set();
            }
        }
    }

}
