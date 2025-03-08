using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingProblems.adventofcode2024.d11
{
    [TestClass]
    public class PlutonianPebbles
    {
        [TestMethod]
        public void Test()
        {
            var length = CalcLengthAfterBlinks([572556, 22, 0, 528, 4679021, 1, 10725, 2790], 75);
        }

        public long CalcLengthAfterBlinks(int[] arr, int blickCount)
        {
            var dic = new Dictionary<long, long>();
            foreach (var item in arr) {
                    
                dic[item] = dic.ContainsKey(item) ? dic[item] + 1 : 1;
            }

            for (int i = 0; i < blickCount; i++)
            {
                var tmpDic = new Dictionary<long, long>();
                foreach (var pair in dic)
                {
                    var newNums = CalcBlink(pair.Key);
                    foreach (var item in newNums)
                    {
                        tmpDic[item] = tmpDic.ContainsKey(item) 
                            ? tmpDic[item] + pair.Value : pair.Value;
                    }
                }
                dic = tmpDic;
            }

            return dic.Sum(p => p.Value);
        }

        private IEnumerable<long> CalcBlink(long num)
        {
            if (num == 0) yield return 1;
            else
            if (num.ToString().Length % 2 == 0)
            {
                var strNum = num.ToString();
                var n1 = strNum.Substring(0, strNum.Length / 2);
                var n2 = strNum.Substring(strNum.Length / 2, strNum.Length / 2);
                yield return long.Parse(n1);
                yield return long.Parse(n2);
            }
            else { 
                yield return num * 2024;
            }

        }

    }
}
