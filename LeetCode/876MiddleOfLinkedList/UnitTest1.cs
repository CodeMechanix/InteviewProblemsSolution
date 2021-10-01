using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace LeetCode._876MiddleOfLinkedList
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var items = new int[] {1, 2, 3, 4, 5};
            ListNode list = new ListNode();
            ListNode runner = list;

            foreach (int item in items)
            {
                runner.next = new ListNode(item);
                runner = runner.next;
            }

            var middleNode = new Solution().MiddleNode(list.next);
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
        private List<ListNode> _nodes = new List<ListNode>();

        public ListNode MiddleNode(ListNode head)
        {
            ListNode current = head;

            while (current != null)
            {
                _nodes.Add(current);
                current = current.next;
            }


            return _nodes[_nodes.Count / 2];
        }
    }
}