using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Codility.L7
{
    [TestClass]
    public class BracketsTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var solution = new Solution().solution("{[()()]}");
        }

        private class Solution
        {
            private Stack<char> _stack = new Stack<char>();
            private HashSet<char> _visited = new HashSet<char>() { '}', ']', ')' };

            private Dictionary<char, char> _dictionary = new Dictionary<char, char>()
            {
                { '{', '}' },
                { '[', ']' },
                { '(', ')' }
            };

            public int solution(string S)
            {
                if (S.Length % 2 != 0)
                {
                    return 0;
                }
                foreach (char c in S)
                {
                    if (_stack.Count > 0)
                    {
                        var peek = _stack.Peek();
                        Debug.WriteLine($"Peek: {peek} - char: {c}");
                        if (GetOpposite(peek).Equals(c))
                        {
                            Debug.WriteLine($"Pop {peek}");
                            _stack.Pop();
                        }
                        else
                        {
                            if (_visited.Contains(c))
                                return 0;
                            Debug.WriteLine($"Push: {c}");
                            _stack.Push(c);
                        }
                    }
                    else
                    {
                        if (_visited.Contains(c))
                            return 0;
                        _stack.Push(c);
                    }
                }


                return _stack.Count == 0 ? 1 : 0;
            }

            private char GetOpposite(char c)
            {
                return _dictionary[c];
            }
        }
    }
}