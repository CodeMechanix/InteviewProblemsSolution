using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hackerrank
{
    [TestClass]
    public class LonelyInteger
    {
        [TestMethod]
        public void TestMethod1()
        {
            var i = lonelyinteger(new List<int>(){1,2,3,4,3,2,1});
        }
        public static int lonelyinteger(List<int> a)
        {
            Dictionary<int, int> int_count = new Dictionary<int, int>();
            HashSet<int> intSet = new HashSet<int>();

            foreach (int i in a)
            {
                if (int_count.ContainsKey(i))
                {
                    int_count[i]++;
                }
                else
                {
                    int_count.Add(i, 1);
                }

                intSet.Add(i);

                if (int_count[i] > 1)
                {
                    intSet.Remove(i);
                }
            }

            return intSet.First();
        }

    }
}
