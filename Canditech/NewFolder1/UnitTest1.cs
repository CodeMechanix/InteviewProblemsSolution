using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Codility.NewFolder1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var isPalindrome = Solution.IsPalindrome("madam");
        }
    }
    class Solution
    {
        public static bool IsPalindrome(string text)
        {
            return Check(text, 0, text.Length-1);
        }

        private static bool Check(string text, int left, int right)
        {
            if (left > right)
            {
                return true;
            }

            char leftChar = text[left];
            char rightChar = text[right];

            if (leftChar == rightChar)
            {
                return Check(text, left + 1, right - 1);
            }
            else
            {
                return false;
            }
        }
    }
}
