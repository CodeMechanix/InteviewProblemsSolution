using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Hackerrank
{
    [TestClass]
    public class MergeSortedLists
    {
        [TestMethod]
        public void TestMethod1()
        {
            var a1 = new int[] { 1,3,7};
            var l1 = new SinglyLinkedList();
            foreach (int i in a1)
            {
                l1.InsertNode(i);
            }

            var a2 = new int[] { 1,2 };
            var l2 = new SinglyLinkedList();
            foreach (int i in a2)
            {
                l2.InsertNode(i);
            }


            var singlyLinkedListNode = mergeLists(l1.head, l2.head);
        }

        static SinglyLinkedListNode mergeLists(SinglyLinkedListNode head1, SinglyLinkedListNode head2)
        {
            SinglyLinkedListNode left = head1;
            SinglyLinkedListNode right = head2;
            SinglyLinkedList mergedList = new SinglyLinkedList();


            while (left != null && right != null)
            {
                if (left.data < right.data)
                {
                    mergedList.InsertNode(left.data);
                    left = left.next;
                }
                else
                {
                    mergedList.InsertNode(right.data);
                    right = right.next;
                }
            }

            while (left != null)
            {
                mergedList.InsertNode(left.data);
                left = left.next;
            }
            while (right != null)
            {
                mergedList.InsertNode(right.data);
                right = right.next;
            }

            return mergedList.head;
        }

        class SinglyLinkedListNode
        {
            public int data;
            public SinglyLinkedListNode next;

            public SinglyLinkedListNode(int nodeData)
            {
                this.data = nodeData;
                this.next = null;
            }
        }

        class SinglyLinkedList
        {
            public SinglyLinkedListNode head;
            public SinglyLinkedListNode tail;

            public SinglyLinkedList()
            {
                this.head = null;
                this.tail = null;
            }

            public void InsertNode(int nodeData)
            {
                SinglyLinkedListNode node = new SinglyLinkedListNode(nodeData);

                if (this.head == null)
                {
                    this.head = node;
                }
                else
                {
                    this.tail.next = node;
                }

                this.tail = node;
            }
        }
    }
}
