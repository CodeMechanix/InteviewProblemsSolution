using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode._617.MergeTwoBinaryTrees
{
    //https://leetcode.com/problems/merge-two-binary-trees/
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var root1 = new[] {1, 3, 2, 5};
            var root2 = new[] {2, 1, 3, -1, 4, -1, 7};
            Tree tree = new Tree();
            TreeNode t1 = tree.insertLevelOrder(root1, new TreeNode(), 0);
            TreeNode t2 = tree.insertLevelOrder(root2, new TreeNode(), 0);

            var mergeTrees = new Solution().MergeTrees(t1, t2);
        }


        public class Solution
        {
            Queue<TreeNode[]> q1 = new Queue<TreeNode[]>();
            List<TreeNode> list = new List<TreeNode>();

            public TreeNode MergeTrees(TreeNode root1, TreeNode root2)
            {
                var state = GetState(root1, root2);
                Handel(root1, root2, state);

                while (q1.Count != 0)
                {
                    var trees = q1.Dequeue();

                    var resultNode = new TreeNode();

                    if (trees.Length == 2)
                    {
                        resultNode.val = trees[0].val + trees[1].val;
                        
                         state = GetState(trees[0].left, trees[1].left);
                        Handel(trees[0].left, trees[1].left, state);

                        state = GetState(trees[0].right, trees[1].right);
                        Handel(trees[0].right, trees[1].right, state);

                    }
                    else
                    {
                        resultNode = trees[0];
                    }

                    list.Add(resultNode);
                }


                for (int i = 0; 2*(i +1) < list.Count; i++)
                {
                    if (list[i] != null)
                    {
                        list[i].left = list[2 * i + 1];
                        list[i].right = list[2 * (i + 1)];
                    }
                   
                }

                return list[0];
            }

            private State GetState(TreeNode l0, TreeNode l1)
            {
                State state = State.NullNull;

                if (l0 == null && l1 == null)
                {
                    state = State.NullNull;
                }
                else if (l0 == null && l1 != null)
                {
                    state = State.NullRight;
                }
                else if (l0 != null && l1 == null)
                {
                    state = State.LeftNull;
                }
                else if (l0 != null && l1 != null)
                {
                    state = State.LeftRight;
                }

                return state;
            }

            private void Handel(TreeNode n0, TreeNode n1, State state)
            {
                switch (state)
                {
                    case State.LeftRight:
                        q1.Enqueue(new[] {n0, n1});
                        break;
                    case State.NullRight:
                        q1.Enqueue(new[] {n1});
                        break;
                    case State.LeftNull:
                        q1.Enqueue(new[] {n0});
                        break;
                    case State.NullNull:
                        q1.Enqueue(new TreeNode[] {null});
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(state), state, null);
                }
            }

         

        }

        public enum State
        {
            LeftRight,
            NullRight,
            LeftNull,
            NullNull
        }

        public class Tree
        {
            TreeNode root;

            // Function to insert nodes in level order
            public TreeNode insertLevelOrder(int[] arr,
                TreeNode root, int i)
            {
                // Base case for recursion
                if (i < arr.Length)
                {
                    TreeNode temp;
                    if (arr[i] == -1)
                    {
                        temp = null;
                    }
                    else
                    {
                        temp = new TreeNode(arr[i]);
                    }

                    root = temp;

                    // insert left child
                    if (root != null)
                    {
                        root.left = insertLevelOrder(arr,
                            root.left, 2 * i + 1);
                        // insert right child
                        root.right = insertLevelOrder(arr,
                            root.right, 2 * i + 2);
                    }
                }

                return root;
            }

            // Function to print tree
            // nodes in InOrder fashion
            public void inOrder(TreeNode root)
            {
                if (root != null)
                {
                    inOrder(root.left);
                    Console.Write(root.val + " ");
                    inOrder(root.right);
                }
            }
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;

            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }
    }
}