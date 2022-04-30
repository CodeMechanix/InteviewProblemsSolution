using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Educative.multithreading
{
    [TestClass]
    public class BarrierTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            CustomBarrier barrier = new CustomBarrier(3);

            for (int i = 0; i < 3; i++)
            {
                Task.Run(() =>
                {
                    barrier.Wait();
                    Trace.WriteLine(
                        $"{Thread.CurrentThread.ManagedThreadId:00} - Released");
                });
            }


            Thread.Sleep(Int32.MaxValue);
        }

        public class CustomBarrier
        {
            private int _barrierValue;
            private int _currentCounter;
            private object _lock = new object();

            public CustomBarrier(int barrierValue)
            {
                _barrierValue = barrierValue;
            }

            public void Wait()
            {
                lock (_lock)
                {
                    _currentCounter++;
                    if (_currentCounter == _barrierValue)
                    {
                        Trace.WriteLine(
                            $"{Thread.CurrentThread.ManagedThreadId:00} - Releasing, current:{_currentCounter}/{_barrierValue}");
                        Monitor.PulseAll(_lock);
                    }
                    else
                    {
                        Trace.WriteLine(
                            $"{Thread.CurrentThread.ManagedThreadId:00} - Waiting, current:{_currentCounter}/{_barrierValue}");
                        Monitor.Wait(_lock);
                    }
                }
            }
        }
    }
}