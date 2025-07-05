using CodingPatterns.Intervals;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingPatterns.Intervals
{
    [TestClass]
    public class IntervalsIntersectionTest
    {
        [TestMethod]
        public void T()
        {
            var intersection = IntervalsIntersection.merge(
                new[] { new Interval(1,3), new Interval(5, 6), new Interval(7, 9)},
                new[] { new Interval(2,3), new Interval(5, 7)});
            intersection.ShouldBeEquivalentTo(
                new[] { new Interval(2, 3), new Interval(5, 6), new Interval(7, 7) });
        }
    }
    internal class IntervalsIntersection
    {
        public static Interval[] merge(Interval[] arr1, Interval[] arr2)
        {
            List<Interval> intervalsIntersection = new List<Interval>();
            // TODO: Write your code here

            var e1 = arr1.GetEnumerator();
            var e2 = arr2.GetEnumerator();
            var hasNext1 = e1.MoveNext();
            var hasNext2 = e2.MoveNext();

            while (hasNext1 && hasNext2)
            {
                var int1 = e1.Current as Interval;
                var int2 = e2.Current as Interval;

                //no overlap
                if (int1.end < int2.start)
                {
                    hasNext1 = e1.MoveNext();
                    continue;
                }
                if(int2.end < int1.start)
                {
                    hasNext2 = e2.MoveNext();
                    continue;
                }
                //overlap

                var start = Math.Max(int1.start, int2.start);
                var end = Math.Min(int1.end, int2.end);
                intervalsIntersection.Add( new Interval(start, end));

                if(int1.end < int2.end)
                {
                    hasNext1 = e1.MoveNext();
                }
                else
                {
                    hasNext2 = e2.MoveNext();
                }
            }


            return intervalsIntersection.ToArray();
        }

    }
}
