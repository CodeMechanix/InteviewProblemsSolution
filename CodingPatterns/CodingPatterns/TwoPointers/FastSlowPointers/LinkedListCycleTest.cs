using System.Diagnostics;


namespace CodingPatterns.TwoPointers.FastSlowPointers
{
    [TestClass]
    public class LinkedListCycleTest
    {
        [TestMethod]
        public void MainTest()
        {
            ListNode head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(3);
            head.next.next.next = new ListNode(4);
            head.next.next.next.next = new ListNode(5);
            head.next.next.next.next.next = new ListNode(6);
            Debug.WriteLine("LinkedList has cycle: " + LinkedListExtension.ContainCycle(head));

            head.next.next.next.next.next.next = head.next.next;
            Debug.WriteLine("LinkedList has cycle: " + LinkedListExtension.ContainCycle(head));

            head.next.next.next.next.next.next = head.next.next.next;
            Debug.WriteLine("LinkedList has cycle: " + LinkedListExtension.ContainCycle(head));
        }

        [TestMethod]
        public void FindCycleLength()
        {

            ListNode head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(3);
            head.next.next.next = new ListNode(4);
            head.next.next.next.next = new ListNode(5);
            head.next.next.next.next.next = new ListNode(6);
            head.next.next.next.next.next.next = head.next.next;
            Debug.WriteLine("LinkedList cycle length: " + LinkedListExtension.CycleLength(head));

            head.next.next.next.next.next.next = head.next.next.next;
            Debug.WriteLine("LinkedList cycle length: " + LinkedListExtension.CycleLength(head));


        }

        [TestMethod]
        public void FindCycleStart() {

            ListNode head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(3);
            head.next.next.next = new ListNode(4);
            head.next.next.next.next = new ListNode(5);
            head.next.next.next.next.next = new ListNode(6);

            head.next.next.next.next.next.next = head.next.next;
            Debug.WriteLine("LinkedList cycle start: " + LinkedListExtension.findCycleStart(head).value);

            head.next.next.next.next.next.next = head.next.next.next;
            Debug.WriteLine("LinkedList cycle start: " + LinkedListExtension.findCycleStart(head).value);

            head.next.next.next.next.next.next = head;
            Debug.WriteLine("LinkedList cycle start: " + LinkedListExtension.findCycleStart(head).value);

        }
    }
}
