using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility.L11
{
    [TestClass]
    public class SieveOfEratosTest
    {
        [TestMethod]
        public void Run()
        {
            //bool[] bools = new SieveOfEratos(18).Result();
            //int[] ints = new FactorList(18).Result();

            int[] ints = new CountNonDivisible(new int[] { 3,1,2,3,6 }).Result();
        }
    }
}
