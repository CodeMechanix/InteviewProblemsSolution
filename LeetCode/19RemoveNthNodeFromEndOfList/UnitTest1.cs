using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace LeetCode._19RemoveNthNodeFromEndOfList
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var items = new int[] {1};
            ListNode list = new ListNode();
            ListNode runner = list;

            foreach (int item in items)
            {
                runner.next = new ListNode(item);
                runner = runner.next;
            }

            var middleNode = new Solution().RemoveNthFromEnd(list.next, 1);
        }
    }


    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class Solution
    {
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            ListNode cureent = head;
            List<ListNode> listNodes = new List<ListNode>();

            while (cureent != null)
            {
                listNodes.Add(cureent);
                cureent = cureent.next;
            }


            int removeIndex = listNodes.Count - n;
            if (1 < n && n < listNodes.Count)
            {
                listNodes[removeIndex - 1].next = listNodes[removeIndex + 1];
                listNodes[removeIndex].next = null;
            }
            else if (n == 1)
            {
                if (listNodes.Count == 1)
                {
                    return null;
                }
                listNodes[removeIndex - 1].next = null;
            }
            else //n == listNodes.Count
            {
                head = listNodes[removeIndex].next;
                listNodes[removeIndex].next = null;
            }

            return head;
        }
    }
}