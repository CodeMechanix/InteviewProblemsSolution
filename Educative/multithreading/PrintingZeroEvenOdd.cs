using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Educative.multithreading
{
    [TestClass]
    public class PrintingZeroEvenOdd
    {
        [TestMethod]
        public void TestMethod1()
        {
            var printNumberSeries = new PrintNumberSeries(10);
            printNumberSeries.Run();
        }
    }

    class PrintNumberSeries
    {
        private int _n;
        private int _i;

        AutoResetEvent _eventZero = new AutoResetEvent(true);

        // AutoResetEvent _event = new AutoResetEvent(false);
        private object _lock = new object();

        public PrintNumberSeries(int n)
        {
            this._n = n;
        }

        public void Run()
        {
            var task = Task.Run(PrintZero);
            var run = Task.Run(PrintEven);
            var task1 = Task.Run(PrintOdd);
            Task.WaitAll(new[] { task1, task, run });
        }


        public void PrintZero()
        {
            while (Working())
            {
                _eventZero.WaitOne();

                Debug.WriteLine("0");
                _i++;
                lock (_lock)
                {
                    Monitor.PulseAll(_lock);
                }
            }
        }

        public void PrintOdd()
        {
            lock (_lock)
            {
                Monitor.Wait(_lock);
                while (Working())
                {
                    while (_i % 2 == 1)
                    {
                        Monitor.Wait(_lock);
                    }

                    Debug.WriteLine(_i);

                   
                    _eventZero.Set();
                    Monitor.Wait(_lock);
                }
            }
        }

        public void PrintEven()
        {
            lock (_lock)
            {
                Monitor.Wait(_lock);
                while (Working())
                {
                    while (_i % 2 == 0)
                    {
                        Monitor.Wait(_lock);
                    }

                    Debug.WriteLine(_i);


                    _eventZero.Set();
                    Monitor.Wait(_lock);
                }
            }
        }

        private bool Working()
        {
            lock (_lock)
            {
                return _i != _n;
            }
        }
    }
}