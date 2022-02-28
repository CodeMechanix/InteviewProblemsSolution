using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Hackerrank
{
    [TestClass]
    public class TimeConversion
    {
        [TestMethod]
        public void TestMethod1()
        {
            var conversion = timeConversion("07:05:45PM");
        }

        public static string timeConversion(string s)
        {
            string[] strings = s.Split(':');
            int hh = int.Parse( strings[0]);
            string am_pm = strings.Last().Substring(2);

            if (am_pm.Equals("PM"))
            {
                if (hh< 12)
                {
                    hh += 12;
                }
            }
            else
            {
                if (hh == 12)
                {
                    hh = 0;
                }
            }

            return $"{hh.ToString("00")}:{strings[1]}:{strings[2].Substring(0, 2)}";
        }
    }
}
