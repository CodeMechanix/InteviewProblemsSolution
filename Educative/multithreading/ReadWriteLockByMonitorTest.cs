using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Educative.multithreading
{
    [TestClass]
    public class ReadWriteLockByMonitorTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            ReadWriteLockByMonitor readWriteLockByMonitor = new ReadWriteLockByMonitor();
            int num = 0;

            Task task = null;

            for (int i = 0; i < 3; i++)
            {
                task = Task.Run(() =>
                {
                    while (true)
                    {
                        readWriteLockByMonitor.ReadEnter();
                        Trace.WriteLine($"{Thread.CurrentThread.ManagedThreadId:00} - Reading: {num}");
                       
                        readWriteLockByMonitor.ReadExit();
                        Thread.Sleep(100);
                    }
                });
            }

            for (int i = 0; i < 3; i++)
            {
                Task.Run(() =>
                {
                    while (true)
                    {
                        readWriteLockByMonitor.WriteEnter();
                        num++;
                        Trace.WriteLine($"{Thread.CurrentThread.ManagedThreadId:00} - WRITING: {num}");
                        
                        readWriteLockByMonitor.WriteExit();
                        Thread.Sleep(100);
                    }
                });
            }

            task.Wait();
        }
    }

    public class ReadWriteLockByMonitor
    {
        private int _readCount;
        private int _writeCount;
        private object _lock = new object();


        public void ReadEnter()
        {
            lock (_lock)
            {
                while (_writeCount > 0)
                {
                    Monitor.Wait(_lock);
                }

                _readCount++;
            }
        }

        public void ReadExit()
        {
            lock (_lock)
            {
                _readCount--;
                Monitor.PulseAll(_lock);
            }
        }

        public void WriteEnter()
        {
            lock (_lock)
            {
                while (_writeCount > 1)
                {
                    Monitor.Wait(_lock);
                }

                _writeCount++;

                while (_readCount > 0)
                {
                    Monitor.Wait(_lock);
                }
            }
        }

        public void WriteExit()
        {
            lock (_lock)
            {
                _writeCount--;
                Monitor.PulseAll(_lock);
            }
        }
    }

}