using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Hackerrank
{
    [TestClass]
    public class AmazonCustomerReviews
    {
        [TestMethod]
        public void TestMethod1()
        {
            List<string> repo = new List<string>() { "mobile", "Mouse", "moneypot", "monitor", "mousepad" };
            string q = "mouse";

            var suggestions = searchSuggestions(repo, q);
        }

        public static List<List<string>> searchSuggestions(List<string> repository, string customerQuery)
        {
            Console.WriteLine($"customerQuery: {customerQuery}");
            Console.WriteLine($"repository: {string.Join(",", repository)}");


            List<string> tempList = new List<string>(repository);
            List<List<string>> resultList = new List<List<string>>();
            string subQuery;


            for (int i = 2; i <= customerQuery.Length; i++)
            {
                subQuery = customerQuery.Substring(0, i);

                tempList = repository.Where(s => s.StartsWith(subQuery, StringComparison.OrdinalIgnoreCase)).ToList();
                tempList.Sort(Comparison);

                for (int j = 0; j < tempList.Count; j++)
                {
                    tempList[j] = tempList[j].ToLower();
                }


                if (tempList.Count > 3)
                {
                    resultList.Add(tempList.GetRange(0, 3));
                }
                else
                {
                    resultList.Add(tempList);
                }
            }

            return resultList;
        }

        private static int Comparison(string x, string y)
        {
            int length = Math.Min(x.Length, y.Length);

            for (int i = 0; i < length; i++)
            {
                int xVal = x[i];
                int yVal = y[i];


                if (xVal == yVal)
                {
                    continue;
                }
                else
                {
                    return xVal - yVal;
                }
            }

            return 0;
        }
    }
}
