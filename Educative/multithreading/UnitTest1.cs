using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Educative.multithreading
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            CustomSemaphore semaphore = new CustomSemaphore(3);

            for (int i = 0; i < 6; i++)
            {
                Task.Run(() =>
                {
                    while (true)
                    {
                        semaphore.Wait();

                        for (int j = 0; j < 3; j++)
                        {
                            Trace.WriteLine($"{Thread.CurrentThread.ManagedThreadId} - in semaphore");
                            Thread.Sleep(1000);
                        }

                        semaphore.Release();
                    }
                });
            }
        }
    }

    public class CustomSemaphore
    {
        private int _max;
        private int current;
        private object _lock;

        private int Current
        {
            get
            {
                lock (_lock)
                {
                    return current;
                }
            }
            set
            {
                lock (_lock)
                {
                    current = value;
                }
            }
        }

        public CustomSemaphore(int max)
        {
            _lock = new object();
            _max = max;
            Current = 0;
        }


        public void Wait()
        {
            lock (_lock)
            {
                Current++;

                while (Current >= _max)
                {
                    Monitor.Wait(_lock);
                }
            }
        }

        public void Release()
        {
            lock (_lock)
            {
                Current--;

                Monitor.PulseAll(_lock);
            }
        }
    }
}