using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Threading;

namespace CrackingCode.StockData
{
    [TestClass]
    public class StockDataTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            StockEngine stockEngine = new StockEngine();
            stockEngine.AddRequest(new StockRequestInfo(){OnComplete = () => Debug.WriteLine("### Done 1")});


            while (true)
            {
                Thread.Sleep(1000);
            }
        }
    }
}
