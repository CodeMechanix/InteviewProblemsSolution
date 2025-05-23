using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CodingPatterns.TwoPointers.FastSlowPointers
{
    public static class LinkedListExtension
    {
        public static bool ContainCycle(this ListNode head)
        {
            ListNode? slow = head;
            ListNode? fast = head.next;

            while (fast != null && slow != null)
            {
                if (slow.value == fast!.value)
                {
                    return true;
                }
                slow = slow.next;
                fast = fast.next?.next;
            }
            // TODO: Write your code here
            return false;
        }
        public static ListNode GetInCycleNode(this ListNode head)
        {
            ListNode? slow = head;
            ListNode? fast = head.next;

            while (fast != null && slow != null)
            {
                if (slow.value == fast!.value)
                {
                    return slow!;
                }
                slow = slow.next;
                fast = fast.next?.next;
            }
            // TODO: Write your code here
            throw new ArgumentException("No cycle");
        }

        public static int CycleLength(this ListNode listNode)
        {
            var node = listNode.GetInCycleNode();
            var start = node;
            int length = 1;
            while (node.next != start)
            {
                node = node.next;
                length++;
            }
            return length;
        }

        public static ListNode findCycleStart(this ListNode head)
        {
            var lenght = head.CycleLength();
            var first = head;
            var last = head;
            while (lenght > 0) {
                first = first.next;
                lenght--;
            }

            while (first != last) { 
            
                first = first.next;
                last = last.next;
            
            }

            return first;
        }
    }
}
