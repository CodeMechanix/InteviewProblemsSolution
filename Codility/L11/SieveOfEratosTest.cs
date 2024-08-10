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

            DevisorsData devisorsData = new DevisorsData();
            int[] ints = devisorsData.SemiPrimesInRanges(27, new[] {1,4,16}, new[] {26, 10 , 20} );




        }
    }
}
