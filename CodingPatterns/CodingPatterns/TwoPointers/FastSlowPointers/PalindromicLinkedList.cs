using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CodingPatterns.TwoPointers.FastSlowPointers
{
    [TestClass]
    public class PalindromicLinkedListTest{

        [TestMethod]
        public void Test()
        {
            ListNode head = new ListNode(2);
            head.next = new ListNode(4);
            head.next.next = new ListNode(6);
            head.next.next.next = new ListNode(4);
            head.next.next.next.next = new ListNode(2);
            PalindromicLinkedList.isPalindrome(head)
                .ShouldBe(true);

            head.next.next.next.next.next = new ListNode(2);
            PalindromicLinkedList.isPalindrome(head)
                .ShouldBe(false);
        }
    
    }

    internal class PalindromicLinkedList
    {
        public static bool isPalindrome(ListNode head)
        {
            // find middle
            var fast = head;
            var slow = head;

            while (fast != null)
            {
                slow = slow.next;
                fast = fast.next?.next;
            }
            var mid = slow;

            //reverse
            var revesed = Reverse(mid);
            var left = head;
            var right = revesed;

            while (right != null)
            {
                if (left.value != right.value)
                {
                    Reverse(revesed);
                    return false;
                }
                left = left.next;
                right = right.next;
            }

            Reverse(revesed);
            return true;
        }

        private static ListNode Reverse(ListNode? head)
        {
            ListNode previous = null;
            while (head != null)
            {
                ListNode? next = head.next;
                head.next = previous;
                previous = head;
                head = next;
            }
            return previous;
        }
    }
}
