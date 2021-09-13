using System.Diagnostics;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.PrintFooBarAlternately
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var fooBar = new FooBar(3);
            Thread t1 = new Thread(() => fooBar.Bar(() => Debug.WriteLine("Bar")));
            Thread t2 = new Thread(() => fooBar.Foo(() => Debug.WriteLine("Foo")));
            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

        }
    }
}
