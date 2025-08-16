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
        public void Test()
        {
            var intervals1 = new List<Interval>()
            {
                new Interval(1, 3),
                new Interval(5, 7),
                new Interval(9, 12)
            };
            var intervals2 = new List<Interval>()
            {
                new Interval(2, 4),
                new Interval(6, 8),
                new Interval(10, 11)
            };
            var result = IntervalsIntersection.Intersect(intervals1.ToArray(), intervals2.ToArray());
            result.ShouldBeEquivalentTo(new List<Interval>()
            {
                new Interval(2, 3),
                new Interval(6, 7),
                new Interval(10, 11)
            }.ToArray());
        }
    
    
    }

    public class IntervalsIntersection
    {
        public static Interval[] Intersect(Interval[] arr1, Interval[] arr2)
        {
            List<Interval> intervalsIntersection = new List<Interval>();
            // TODO: Write your code here
            var e_1 = arr1.GetEnumerator();
            var e_2 = arr2.GetEnumerator();

            var hasNext_1 = e_1.MoveNext();
            var hasNext_2 = e_2.MoveNext();

            while (hasNext_1 && hasNext_2)
            {
                var interval_1 = e_1.Current as Interval?? default!;
                var interval_2 = e_2.Current as Interval?? default!;

                if (interval_1.end < interval_2.start)
                {
                    hasNext_1 = e_1.MoveNext();
                    continue;
                }
                if (interval_2.end < interval_1.start)
                {
                    hasNext_2 = e_2.MoveNext();
                    continue;
                }
                //Intersection
                var start = Math.Max(interval_1.start, interval_2.start);
                var end = Math.Min(interval_1.end, interval_2.end);
                intervalsIntersection.Add(new Interval(start, end));
                hasNext_1 = e_1.MoveNext();
                hasNext_2 = e_2.MoveNext();
            }


            return intervalsIntersection.ToArray();
        }

       
    }
}
