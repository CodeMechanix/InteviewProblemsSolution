using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListNode = CodingPatterns.LinkedList.ReverseLinkedList.ListNode;

namespace CodingPatterns.LinkedList
{
    [TestClass]
    public class ReverseLinkedListTests
    {
        [TestMethod]
        public void TestCase1()
        {
            ListNode head = new ListNode(2)
            {
                next = new ListNode(4)
                {
                    next = new ListNode(6)
                    {
                        next = new ListNode(8)
                    }
                }
            };
            ListNode expected = new ListNode(8)
            {
                next = new ListNode(6)
                {
                    next = new ListNode(4)
                    {
                        next = new ListNode(2)
                    }
                }
            };
            ReverseLinkedList sol = new ReverseLinkedList();
            ListNode actual = sol.ReverseInplace(head);
            Assert.IsTrue(AreEqual(expected, actual));

            actual = sol.ReverseStack(head);
            Assert.IsTrue(AreEqual(expected, actual));

        }

        [TestMethod]
        public void TestCase2()
        {
            ListNode head = new ListNode(2)
            {
                next = new ListNode(4)
                {
                    next = new ListNode(6)
                    {
                        next = new ListNode(8)
                    }
                }
            };
            ListNode expected = new ListNode(8)
            {
                next = new ListNode(6)
                {
                    next = new ListNode(4)
                    {
                        next = new ListNode(2)
                    }
                }
            };
            ReverseLinkedList sol = new ReverseLinkedList();
            ListNode actual = sol.ReverseStack(head);
            Assert.IsTrue(AreEqual(expected, actual));
        }
        private bool AreEqual(ListNode expected, ListNode actual)
        {
            while (expected != null && actual != null)
            {
                if (expected.value != actual.value) return false;
                expected = expected.next;
                actual = actual.next;
            }
            return expected == null && actual == null;
        }
    }


    class ReverseLinkedList
    {
        public class ListNode
        {
            public int value = 0;
            public ListNode? next;

            public ListNode(int value)
            {
                this.value = value;
            }

            public override string ToString()
            {
                return $"{value} -> {next?.value}";
            }
        }

        public ListNode ReverseStack(ListNode head)
        {
            var stack = new Stack<ListNode>();
            var current = head;
            while (current != null) 
            {
                stack.Push(current);
                current = current.next;
            }

            current = stack.Pop();
            head = current;

            while (stack.Count > 0) 
            {
                var next = stack.Pop();
                next.next = null;
                current.next = next;

                current = next;
            }

            return head;
        }



        public ListNode ReverseInplace(ListNode head)
        {
            ListNode prev = null;
            ListNode current = head;
            ListNode next;

            while (current != null) 
            {
                next = current.next;

                current.next = prev;

                prev = current;
                current = next;
            }

            return prev;
        }
    }
}
