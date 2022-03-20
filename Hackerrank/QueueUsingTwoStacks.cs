using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Hackerrank
{
    [TestClass]
    public class QueueUsingTwoStacks
    {
        [TestMethod]
        public void TestMethod1()
        {
            List<string> input = new List<string>();

            // string line;
            // while ((line = Console.ReadLine()) != null && line != "")
            // {
            //     input.Add(line);
            // }

            input = new List<string>()
            {
                "10", //q = 10 (number of queries)
                "1 42", //    1st query, enqueue 42
                "2", //dequeue front element
                "1 14", //    enqueue 42
                "3", //   print the front element
                "1 28", //    enqueue 28
                "3", // print the front element
                "1 60", // enqueue 60
                "1 78", // enqueue 78
                "2", // dequeue front element
                "2", // dequeue front element
            };

            MyQ q = new MyQ();

            for (int i = 1; i < int.Parse(input[0]) +1; i++)
            {
                string[] strings = input[i].Split(' ');

                switch (int.Parse(strings[0]))
                {
                    case 1:
                    {
                        q.Enqueue(int.Parse(strings[1]));
                        break;
                    }
                    case 2:
                    {
                        q.Dequeue();
                        break;
                    }
                    case 3:
                    {
                        q.PrintFront();
                        break;
                    }

                    default:
                        break;
                }
            }
        }

        public class MyQ
        {
            private Stack<int> stack1;
            private Stack<int> stack2;

            public MyQ()
            {
                stack1 = new Stack<int>();
                stack2 = new Stack<int>();
            }

            public void Enqueue(int val)
            {
                stack1.Push(val);
            }

            public void Dequeue()
            {

                if (stack2.Count == 0)
                {
                    while (stack1.Count > 0)
                    {
                        int pop = stack1.Pop();
                        stack2.Push(pop);
                    }
                }

                stack2.Pop();
            }

            public void PrintFront()
            {

                if (stack2.Count == 0)
                {
                    while (stack1.Count > 0)
                    {
                        int pop = stack1.Pop();
                        stack2.Push(pop);
                    }
                }

                int peek = stack2.Peek();
                Console.WriteLine(peek);
                Debug.WriteLine(peek);

            }
        }
    }
}