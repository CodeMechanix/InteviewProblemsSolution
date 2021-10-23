using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.CodeDom;

namespace Other.CheckPoint._1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
//            var S = "id,name,age,act.,room,dep.\n1,Jack,68,T,13,8\n17,Betty,28,F,15,7";
            var S = "area,land\n3722,CN\n6612,RU\n3855,CA\n3797,USA";
            var C = "area";
            var solution = new Solution().solution(S,C);
        }
        class Solution
        {
            public int solution(string S, string C)
            {
                string[] lines = S.Split(new []{ '\n' });


                string[] conNames = lines[0].Split(new []{','});

                int conNum = 0;
                for (int i = 0; i < conNames.Length; i++)
                {
                    if (conNames[i].Equals(C))
                    {
                        conNum = i;
                        break;
                    }
                }

                int max = int.MinValue;

                for (int i = 1; i < lines.Length; i++)
                {
                    var line = lines[i];
                    var cellString = line.Split(new []{','})[conNum];
                    var cellNum = Int32.Parse(cellString);

                    if (cellNum > max)
                    {
                        max = cellNum;
                    }
                }





                return max;
            }
        }
    }
}
