using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Educative.multithreading
{
    [TestClass]
    public class CustomSemaphoreTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            CustomSemaphore semaphore = new CustomSemaphore(3);
            Task task = null;
            long count = 0;
            for (int i = 0; i < 6; i++)
            {
                task = Task.Run(() =>
                {
                    while (true)
                    {
                        semaphore.Wait();

                        Thread.Sleep(1000);

                        Trace.WriteLine($"In same time:{Interlocked.Read(ref count)}");

                        //TODO how to count all treads in here
                    
                        semaphore.Release();
                    }
                });
            }

            task.Wait();
        }
    }

    public class CustomSemaphore
    {
        private int _max;
        private int current;
        private object _lock;

        private int Current
        {
            get { return current; }
            set { current = value; }
        }

        public CustomSemaphore(int max)
        {
            _lock = new object();
            _max = max;
            Current = 0;
        }


        public void Wait()
        {
            var currentThreadManagedThreadId = Thread.CurrentThread.ManagedThreadId;
            lock (_lock)
            {
                if (Current < _max)
                {
                    Current++;
                }

                while (Current > _max)
                {
                    Monitor.Wait(_lock);
                }
            }
        }

        public void Release()
        {
            var currentThreadManagedThreadId = Thread.CurrentThread.ManagedThreadId;


            lock (_lock)
            {
                if (Current > 0)
                {
                    Current--;
                }


                Monitor.PulseAll(_lock);
            }
        }
    }
}