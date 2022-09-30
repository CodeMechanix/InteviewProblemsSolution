using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Educative.multithreading
{
    [TestClass]
    public class H2OMachineTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            H2OMachine h2OMachine = new H2OMachine();

            List<Task> tasks = new List<Task>();
            tasks.Add(Task.Run(() => h2OMachine.HydrogenAtom()));
            tasks.Add(Task.Run(() => h2OMachine.HydrogenAtom()));
            tasks.Add(Task.Run(() => h2OMachine.HydrogenAtom()));
            tasks.Add(Task.Run(() => h2OMachine.OxygenAtom()));
            tasks.Add(Task.Run(() => h2OMachine.OxygenAtom()));
            tasks.Add(Task.Run(() => h2OMachine.OxygenAtom()));
            tasks.Add(Task.Run(() => h2OMachine.HydrogenAtom()));
            tasks.Add(Task.Run(() => h2OMachine.HydrogenAtom()));
            tasks.Add(Task.Run(() => h2OMachine.HydrogenAtom()));
            tasks.Add(Task.Run(() => h2OMachine.OxygenAtom()));
            tasks.Add(Task.Run(() => h2OMachine.OxygenAtom()));
            tasks.Add(Task.Run(() => h2OMachine.OxygenAtom()));
            tasks.Add(Task.Run(() => h2OMachine.HydrogenAtom()));
            tasks.Add(Task.Run(() => h2OMachine.HydrogenAtom()));
            tasks.Add(Task.Run(() => h2OMachine.HydrogenAtom()));
            tasks.Add(Task.Run(() => h2OMachine.OxygenAtom()));
            tasks.Add(Task.Run(() => h2OMachine.OxygenAtom()));
            tasks.Add(Task.Run(() => h2OMachine.OxygenAtom()));

            Task.WaitAll(tasks.ToArray());
        }
    }


    class H2OMachine
    {
        private Semaphore _semaphoreO = new Semaphore(1, 1);
        private Semaphore _semaphoreH = new Semaphore(2, 2);
        private int _atomCount = 0;
        private object _lock = new object();
        private ManualResetEventSlim _manualResetEventSlim1 = new ManualResetEventSlim(false);
        private ManualResetEventSlim _manualResetEventSlim2 = new ManualResetEventSlim(false);


        public H2OMachine()
        {
        }

        public void HydrogenAtom()
        {
            _semaphoreH.WaitOne();
            EnterQueue(AtomType.H);
            _semaphoreH.Release();
        }

        public void OxygenAtom()
        {
            _semaphoreO.WaitOne();
            EnterQueue(AtomType.O);
            _semaphoreO.Release();
        }

        private void EnterQueue(AtomType atomType)
        {
            Debug.WriteLine($"{Thread.CurrentThread.ManagedThreadId} - {atomType} - In");

            lock (_lock)
            {
                _atomCount++;
            }

            if (_atomCount == 3)
            {
                _manualResetEventSlim1.Set();
            }
            else
            {
                _manualResetEventSlim2.Reset();
                _manualResetEventSlim1.Wait();

            }
            Debug.WriteLine($"{Thread.CurrentThread.ManagedThreadId} - {atomType} - Out");

            lock (_lock)
            {
                _atomCount--;
            }

            if (_atomCount == 0)
            {

                Debug.WriteLine($"========================");
                _manualResetEventSlim1.Reset();
                _manualResetEventSlim2.Set();
            }


            _manualResetEventSlim2.Wait();
           

        }


        enum AtomType
        {
            H,
            O
        }
    }
}