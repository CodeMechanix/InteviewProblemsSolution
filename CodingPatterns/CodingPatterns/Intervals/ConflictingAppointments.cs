using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CodingPatterns.Intervals
{
    [TestClass]
    public class ConflictingAppointmentsTest
    {
        [TestMethod]
        public void Test()
        {
            //test CanAttendAllAppointments
            Interval[] intervals = new Interval[]
            {
                new Interval(1, 3),
                new Interval(2, 4),
                new Interval(3, 5)
            };  
            bool result = ConflictingAppointments.CanAttendAllAppointments(intervals);
            Assert.IsFalse(result, "Should return false as there are conflicting appointments.");
            
        }

        [TestMethod]
        public void Test2()
        {

            Interval[] intervals = new Interval[]
            {
                new Interval(1, 2),
                new Interval(2, 3),
                new Interval(3, 4)
            };
            var result = ConflictingAppointments.CanAttendAllAppointments(intervals);
            Assert.IsTrue(result, "Should return true as there are no conflicting appointments.");
        }
        
    }
    class ConflictingAppointments
    {

        public static bool CanAttendAllAppointments(Interval[] intervals)
        {
            // TODO: Write your code here

            var ordered = intervals.OrderBy(i => i.start);
            var enumerator = ordered.GetEnumerator();
            var hasNextA = enumerator.MoveNext();
            var intervalA = enumerator.Current;
            var hasNextB = enumerator.MoveNext();
            var intervalB = enumerator.Current;

            while (hasNextA && hasNextB)
            {

                if (intervalA.end <= intervalB.start)
                {
                    hasNextA = enumerator.MoveNext();
                    intervalA = enumerator.Current;
                    continue;
                }
                if (intervalB.end <= intervalA.start)
                {
                    hasNextB = enumerator.MoveNext();
                    intervalB = enumerator.Current;
                    continue;
                }
                return false;

            }


            return true;
        }
    }
}
