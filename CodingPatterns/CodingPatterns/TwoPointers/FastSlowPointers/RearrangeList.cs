using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingPatterns.TwoPointers.FastSlowPointers
{
    [TestClass]
    public class RearrangeListTest
    {
        [TestMethod]
        public void Test()
        {
            ListNode head = new ListNode(2);
            head.next = new ListNode(4);
            head.next.next = new ListNode(6);
            head.next.next.next = new ListNode(8);
            head.next.next.next.next = new ListNode(10);
            head.next.next.next.next.next = new ListNode(12);
            RearrangeList.reorder(head);
            while (head != null)
            {
               Debug.WriteLine(head.value);
                head = head.next;
            }
        }

    }

    internal class RearrangeList
    {
        public static void reorder(ListNode head)
        {
            
            var nextItem = head;

            while(nextItem != null) {

                //cut from the end
                var last = CutLast(head);
                //insert
                Insert(last, nextItem);
                nextItem = last.next;
            }
        }

        private static int Length(ListNode? node)
        {
            int count = 0;
            while (node != null)
            {
                count++;
                node = node.next;
            }
            return count;
        }

        private static void Insert(ListNode item, ListNode list)
        {
            item.next = list.next;
            list.next = item;
        }

        private static ListNode CutLast(ListNode item) 
        {
            //go to last Item
            ListNode previous = item;
            while (item.next != null) {
                
                previous = item;
                item = item.next;
            }
            
            previous.next = null;
            return item;
        }
    }
}
