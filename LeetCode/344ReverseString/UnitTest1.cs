using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LeetCode._344ReverseString
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            new Solution().ReverseString( "hello".ToCharArray() );
        }

        public class Solution
        {
            private int _leftIndex, _rightIndex;
            private char _tempCahr;

            public void ReverseString(char[] s)
            {
                _rightIndex = s.Length-1;

                while (_rightIndex - _leftIndex > 0)
                {
                    _tempCahr = s[_leftIndex];
                    s[_leftIndex] = s[_rightIndex];
                    s[_rightIndex] = _tempCahr;

                    _leftIndex++;
                    _rightIndex--;
                }
            }
        }
    }
}
