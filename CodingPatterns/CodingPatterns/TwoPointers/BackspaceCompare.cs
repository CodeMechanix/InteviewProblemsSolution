using Shouldly;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingPatterns.TwoPointers
{
    [TestClass]
    public class BackspaceCompareTest
    {
        [TestMethod]
        [DataRow("xy#z", "xz")]
        [DataRow("xzz#", "xz")]
        public void Test(string input, string output)
        {
            var o = new BackspaceCompare();
            o.CleanBackSpace(input)
                .Reverse()
                .ShouldBe(output);
        }

        [TestMethod]
        [DataRow("xy#z", "xzz#", true)]
        [DataRow("xy#z", "xyz#", false)]
        [DataRow("xp#", "xyz##", true)]
        [DataRow("xywrrmp", "xywrrmu#p", true)]
        public void Test(string str1, string str2, bool expected)
        {
            var o = new BackspaceCompare();
            o.Compare(str1, str2)
                
                .ShouldBe(expected);
        }
    }
    class BackspaceCompare
    {
        public  bool Compare(String str1, String str2)
        {
            var cleanStr1 = CleanBackSpace(str1);
            var cleanStr2 = CleanBackSpace(str2);
            return cleanStr1.SequenceEqual(cleanStr2);
            // TODO: Write your code here
            
        }

        public IEnumerable<char> CleanBackSpace(string str) 
        {
            int right = str.Length -1;
            int backSpaceCount = 0;
            while (right >= 0) { 
            
                var c = str[right];

                if (c == '#')
                {
                    backSpaceCount++;
                }
                else
                {
                    if (backSpaceCount > 0)
                    {
                        backSpaceCount--;
                    }
                    else
                    {
                        yield return c;
                    }
                }

                right--;
            }
        }


    }
}
