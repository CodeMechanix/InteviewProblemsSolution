using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

namespace Codility.L10
{
    [TestClass]
    public class CountFactorsTest
    {
        [TestMethod]
        public void TestMethod()
        {

            int v = new DevisorCount(24).Value();
        }

        class Solution 
        {
            public int solution(int N)
            {
                int result = 0;
                int nextDevisor = 1;

                while (Math.Pow(nextDevisor, 2) <= N)
                {
                    if (N % nextDevisor == 0)
                    {
                        Debug.WriteLine(nextDevisor);
                        result++;
                    }
                    nextDevisor++;
                }

                return result;
            }


        }

        class DevisorCount 
        {
            private readonly int _num;

            public DevisorCount(int num)
            {
                _num = num;
            }

            public int Value()
            {
                int result = 0;
                int nextDevisor = 1;

                while (Math.Pow( nextDevisor , 2) < _num )
                {
                    if (_num % nextDevisor == 0)
                    {
                        Debug.WriteLine(nextDevisor);
                        result+=2;
                    }
                    nextDevisor++;
                }

                if (Math.Pow( nextDevisor ,2) == _num)
                {
                    result++;
                }

                return result;
            }

        }
    }
}
