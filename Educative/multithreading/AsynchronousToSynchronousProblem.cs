using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Threading;

namespace Educative.multithreading
{
    [TestClass]
    public class AsynchronousToSynchronousProblem
    {
        [TestMethod]
        public void TestMethod1()
        {

            ManualResetEventSlim eventSlim = new ManualResetEventSlim();

            Executor executor = new Executor();
            executor.asynchronousExecution(() =>
            {
                Debug.WriteLine("I am done");
                eventSlim.Set();
            });

            eventSlim.Wait();

            Debug.WriteLine("main thread exiting...");



        }
    }

    

    class Executor
    {
        public void asynchronousExecution(Action callback)
        {
            Thread t = new Thread(() =>
            {
                // Do some useful work
                try
                {
                    Thread.Sleep(5000);
                }
                catch (Exception ie)
                {
                }

                callback();
            });
            t.Start();
        }
    }
}