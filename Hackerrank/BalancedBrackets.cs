using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Hackerrank
{
    [TestClass]
    public class BalancedBrackets
    {
        [TestMethod]
        public void TestMethod1()
        {
            var balanced = isBalanced("{[()]}");
        }

        public static string isBalanced(string s)
        {
            Dictionary<char, char> chars = new Dictionary<char, char>()
            {
                { '{', '}' },
                { '[', ']' },
                { '(', ')' }
            };

            Stack<char> stack = new Stack<char>();


            foreach (char c in s)
            {
                if (chars.ContainsKey(c))
                {
                    //open bracket
                    stack.Push(chars[c]);
                }
                else
                {
                    //closing bracket
                    if (stack.Count == 0)
                    {
                        return "NO";
                    }

                    var pop = stack.Pop();

                    if (pop != c)
                    {
                        return "NO";
                    }
                }
            }


            if (stack.Count != 0)
            {
                return "NO";
            }


            return "YES";
        }
    }
}