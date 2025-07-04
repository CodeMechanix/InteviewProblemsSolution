using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingPatterns.Intervals
{
    [TestClass]
    public class InsertIntervalTest
    {


        [TestMethod]
        public void Test() {
            var intervals = new List<Interval>() 
            {
                new Interval(1,3),
                new Interval(5,7),
                new Interval(8,12),
            };
            var inserted = InsertInterval.insert(intervals, new Interval(4, 6));

            inserted.ShouldBeEquivalentTo(new List<Interval>()
            {
                new Interval(1,3),
                new Interval(4,7),
                new Interval(8,12),
            });
        }
    }

    class Interval
    {
        public int start;
        public int end;

        public Interval(int start, int end)
        {
            this.start = start;
            this.end = end;
        }
    };
    internal class InsertInterval
    {
        public static List<Interval> insert(List<Interval> intervals, Interval newInterval)
        {
            //TODO: Write your code here
            List<Interval> mergedIntervals = new List<Interval>();

             var enumerator = intervals.GetEnumerator();

            while (enumerator.MoveNext()) {
                var current = enumerator.Current;

                if (current.end < newInterval.start || newInterval.end < current.start)
                {
                    mergedIntervals.Add(current);
                    continue;
                }

                while (newInterval.end >= enumerator.Current.start)
                {
                    if (newInterval.start <= current.start && current.start <= newInterval.end
                        ||
                        newInterval.start <= current.end && current.end <= newInterval.end)
                    {
                        newInterval.start = Math.Min(current.start, newInterval.start);
                        newInterval.end = Math.Max(current.end, newInterval.end);
                    }
                    enumerator.MoveNext();
                    current = enumerator.Current;
                }
                mergedIntervals.Add(newInterval);
                mergedIntervals.Add(current);
            }
            return mergedIntervals;
        }
    }
}
