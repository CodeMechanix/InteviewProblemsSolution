using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Concurency
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Task doWork = DoWork();

            while (true)
            {
                Debug.WriteLine("main");
                doWork.Wait(1000);
            }
        }


        public async Task DoWork()
        {
            int val = 13;

            Thread.Sleep(5000);

            await Task.Delay(TimeSpan.FromSeconds(5));

            val *= 2;

           Thread.Sleep(5000);

            Trace.WriteLine(val);
        }
    }

   
}
