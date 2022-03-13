using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Numerics;
using System.Text;

namespace Hackerrank
{
    [TestClass]
    public class RecursiveDigitSum
    {
        [TestMethod]
        public void TestMethod1()
        {
            var digit = superDigit("9875", 4);
        }

        public static int superDigit(string n, int k)
        {
            long i1 = F(n) * k;
            
            return F(i1.ToString());
        }

        private static int F(string num)
        {
            if (num.Length == 1)
            {
                return int.Parse(num);
            }

            BigInteger integer = BigInteger.Zero;
            foreach (char c in num)
            {
                integer += (int)char.GetNumericValue(c);
            }

            return F(integer.ToString());
        }

       
    }
}