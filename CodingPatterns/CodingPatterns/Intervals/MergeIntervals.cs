using Shouldly;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingPatterns.Intervals
{
    [TestClass]
    public class MergeIntervalsTest
    {
        [TestMethod]
        
        public void T()
        {
            var input = new List<Interval>();
            input.Add(new Interval(1, 4));
            input.Add(new Interval(2, 5));
            input.Add(new Interval(7, 9));

            MergeIntervals.merge(input).ShouldBeEquivalentTo(new List<Interval>() { new Interval(1,5), new Interval(7,9) });

            //input = new List<Interval>();
            //input.Add(new Interval(6, 7));
            //input.Add(new Interval(2, 4));
            //input.Add(new Interval(5, 9));
            //System.out.print("Merged intervals: ");
            //for (Interval interval : MergeIntervals.merge(input))
            //    System.out.print("[" + interval.start + "," + interval.end + "] ");
            //System.out.println();

            //input = new ArrayList<Interval>();
            //input.Add(new Interval(1, 4));
            //input.Add(new Interval(2, 6));
            //input.Add(new Interval(3, 5));
            //System.out.print("Merged intervals: ");
            //for (Interval interval : MergeIntervals.merge(input))
            //    System.out.print("[" + interval.start + "," + interval.end + "] ");
            //System.out.println();
        }



        class MergeIntervals
        {
            public static List<Interval> merge(List<Interval> intervals)
            {
                var mergedIntervals = new List<Interval>();
                // TODO: Write your code here
                intervals.Sort((x, y) => x.start.CompareTo(y.start));

                var left = intervals[0];
                intervals.RemoveAt(0);

                while (intervals.Count > 0)
                {
                   var right = intervals[0];
                   if (left.end >= right.start)// merge
                   {
                        left.end = Math.Max(left.end, right.end);
                        intervals.RemoveAt(0);
                    }
                    else
                    {
                        mergedIntervals.Add(left);
                        left = right;
                        intervals.RemoveAt(0);
                    }
                }

                mergedIntervals.Add(left);

                return mergedIntervals;
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
    }
   
}
