using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingPatterns.TwoPointers.FastSlowPointers
{
    [TestClass]
    public class MiddleOfLinkedListTest
    {
        [TestMethod]
        public void Test()
        {
            ListNode head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(3);
            head.next.next.next = new ListNode(4);
            head.next.next.next.next = new ListNode(5);
            MiddleOfLinkedList.findMiddle(head).value.ShouldBe(3);

            head.next.next.next.next.next = new ListNode(6);
             MiddleOfLinkedList.findMiddle(head).value.ShouldBe(4);

            head.next.next.next.next.next.next = new ListNode(7);
            MiddleOfLinkedList.findMiddle(head).value.ShouldBe(4);
        }
    }

    internal class MiddleOfLinkedList
    {
        public static ListNode findMiddle(ListNode head)
        {
            var fast = head;
            var slow = head;

            while (fast?.next != null) {
                fast = fast.next?.next;
                slow = slow.next;
            }


            return slow;
        }
    }
}
