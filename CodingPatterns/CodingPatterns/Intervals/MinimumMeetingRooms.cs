using static CodingPatterns.Intervals.MinimumMeetingRooms;

namespace CodingPatterns.Intervals
{
    [TestClass]
    public class MinimumMeetingRoomsTest
    {
        [TestMethod]
        public void findMinimumMeetingRoomsTest()
        {
            //generate test case
            List<Meeting> meetings = new List<Meeting>
            {
                new Meeting(0, 30),
                new Meeting(5, 10),
                new Meeting(15, 20)
            };
            int result = MinimumMeetingRooms.findMinimumMeetingRooms(meetings);
            Assert.AreEqual(2, result);
        }
    }

    internal class MinimumMeetingRooms
    {
        public static int findMinimumMeetingRooms(List<Meeting> meetings)
        {
            int maxCount=0;
            int tmpCount=0;

            IOrderedEnumerable<Meeting> sortedMeetings = meetings.OrderBy(i => i.Start);
            using IEnumerator<Meeting> enumerator = sortedMeetings.GetEnumerator();
            var hasNext = enumerator.MoveNext();
            var itemA = enumerator.Current;
            hasNext = enumerator.MoveNext();
            var itemB = enumerator.Current;
            while (hasNext)
            {
                if (itemA.End <= itemB.Start)//no overlap
                {
                    tmpCount = 0;
                    hasNext = enumerator.MoveNext();
                    itemA = enumerator.Current;
                    continue;
                }
                if (itemB.End <= itemA.Start)//no overlap
                {
                    tmpCount = 0;
                    hasNext = enumerator.MoveNext();
                    itemB = enumerator.Current;
                    continue;
                }
                //overlap
                tmpCount++;
                maxCount = Math.Max(maxCount, tmpCount);
                if (itemA.End <= itemB.End)
                {
                    hasNext = enumerator.MoveNext();
                    itemA = enumerator.Current;
                }
                else
                {
                    hasNext = enumerator.MoveNext();
                    itemB = enumerator.Current;
                }

            }











            return maxCount;
        }
        internal class Meeting
        {
            public Meeting(int start, int end)
            {
                this.Start = start;
                this.End = end;
            }

            public int Start { get; set; }
            public int End { get; set; }
        };
    }
}
