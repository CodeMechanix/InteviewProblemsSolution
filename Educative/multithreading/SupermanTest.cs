using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Educative.multithreading
{
    [TestClass]
    public class SupermanTest
    {
        [TestMethod]
        public void TestMethod1()
        {
        }
    }

    class Superman
    {
        private static volatile Superman _instance;
        private static readonly object Lock = new object();

        public static Superman Instance()
        {
            if (_instance is null)
            {
                lock (Lock)
                {
                    if (_instance is null)
                    {
                        _instance = new Superman();
                    }
                }
            }


            return _instance;
        }

        private Superman()
        {
        }
    }
}