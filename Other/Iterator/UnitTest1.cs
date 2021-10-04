using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Other.Iterator
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }
    }

    class MonthWithDays
    {
        public int Days { get; set; }
        public string Date { get; set; }
    }

    class DaysEnumerator : IEnumerator<MonthWithDays>
    {

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public MonthWithDays Current { get; }

        object IEnumerator.Current => Current;
    }
}
