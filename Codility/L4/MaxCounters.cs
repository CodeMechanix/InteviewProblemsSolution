using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Codility.L4
{
    [TestClass]
    public class MaxCounters
    {
        [TestMethod]
        public void TestMethod1()
        {
            var solution = new Solution().solution(5, new[] { 3, 4, 4, 6, 1, 4, 4 });
        }

        class Solution
        {
            DateTime maxTime = DateTime.MinValue;

            public int[] solution(int N, int[] A)
            {
                var countersGroup = new CountersGroup(N);

                foreach (int i in A)
                {
                    if (1 <= i && i <= N)
                    {
                        countersGroup.Set(i-1);
                    }
                    else if (i == N + 1)
                    {
                        countersGroup.SetMax();
                    }
                }

                return countersGroup.Counters.Select((o, i) => countersGroup.Get(i)).ToArray();
            }
        }

        class IntObject
        {
            private int value;

            public int Value
            {
                get { return value; }
                set
                {
                    this.value = value;
                    Time = DateTime.Now;
                }
            }

            public DateTime Time { get; set; }

            public IntObject()
            {
                Value = 0;
                Time = DateTime.MinValue;
            }
        }

        class CountersGroup
        {
            public IntObject Max { get; set; }
            private int tempMax = 0;
            public List<IntObject> Counters { get; set; }

            public CountersGroup(int N)
            {
                Counters = new List<IntObject>();
                Max = new IntObject();
                for (int i = 0; i < N; i++)
                {
                    Counters.Add(new IntObject());
                }
            }

            public void Set(int index)
            {
                var counter = Counters[index];
                counter.Value = Get(index) + 1;

                if (tempMax < counter.Value)
                {
                    tempMax = counter.Value;
                }
            }

            public int Get(int index)
            {
                var counter = Counters[index];
                if (counter.Time > Max.Time)
                {
                    return counter.Value;
                }
                else
                {
                    return Max.Value;
                }
            }

            public void SetMax( )
            {
                Max.Value = tempMax;
            }
        }
    }
}