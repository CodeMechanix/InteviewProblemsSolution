using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Hackerrank
{
    [TestClass]
    public class MiniMaxSum
    {
        [TestMethod]
        public void TestMethod1()
        {
            miniMaxSum(new List<int>(){ 942381765 ,627450398 ,954173620 ,583762094 ,236817490 });
        }

        public static void miniMaxSum(List<int> arr)
        {
            Int64 sum = 0;
            arr.ForEach(i => sum+=i);

            Int64 min = Int64.MaxValue;
            Int64 max = Int64.MinValue;


            arr.ForEach(i =>
            {
                Int64 sum1 = sum - i;
                if (sum1 < min)
                {
                    min = sum1;
                }

                if (sum1 > max)
                {
                    max = sum1;
                }
            });

            Console.WriteLine($"{min} {max}");
        }
    }
}
