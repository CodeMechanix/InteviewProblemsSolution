using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Text;

namespace LeetCode._557ReverseWordsInStringIII
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var reverseWords = new Solution().ReverseWords("Let's take LeetCode contest");
        }
    }

    public class Solution
    {
        public string ReverseWords(string s)
        {
            string[] strings = s.Split(' ');
            for (int i = 0; i < strings.Length; i++)
            {
                char[] word = strings[i].ToCharArray();
                ReverseString(word);
                strings[i] = new string(word);
            }

            return String.Join(" ", strings);
        }


        public void ReverseString(char[] s)
        {
            int _leftIndex = 0;
            int _rightIndex = s.Length - 1;
            char _tempCahr;

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