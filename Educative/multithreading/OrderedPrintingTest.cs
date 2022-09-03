using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Educative.multithreading
{
    [TestClass]
    public class OrderedPrintingTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var orderedPrinting = new OrderedPrinting();
            while (true)
            {

                Task.Factory.StartNew(() =>
                {                
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                    orderedPrinting.printFirst();
                });
                Task.Factory.StartNew(orderedPrinting.printSecond);
                Task.Factory.StartNew(orderedPrinting.printThird);

                Thread.Sleep(1000);
            }


            Thread.Sleep(TimeSpan.FromMinutes(1));
        }
    }

    public class OrderedPrinting
    {
        Semaphore _semaphore1 = new Semaphore(1, 1);
        Semaphore _semaphore2 = new Semaphore(0, 1);
        Semaphore _semaphore3 = new Semaphore(0, 1);

        public void printFirst()
        {
            _semaphore1.WaitOne();
            Debug.WriteLine("First");
            _semaphore2.Release();
        }

        public void printSecond()
        {
            _semaphore2.WaitOne();
            Debug.WriteLine("Second");
            _semaphore3.Release();
        }

        public void printThird()
        {
            _semaphore3.WaitOne();
            Debug.WriteLine("Third");
            _semaphore1.Release();
        }
    }
}