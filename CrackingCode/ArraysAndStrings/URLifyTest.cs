using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CrackingCode.ArraysAndStrings
{
    /*
     URLify: Write a method to replace all spaces in a string with '%20'.
    You may assume that the string has sufficient space at the end to hold the additional characters,
    and that you are given the "true" length of the string. (Note: If implementing in Java,
    please use a character array so that you can perform this operation in place.) 
    EXAMPLE Input: "Mr John Smith ", 13 Output: "Mr%20John%20Smith" 
     */
    [TestClass]
    public class URLifyTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            new URLifySolution("Mr John Smith    ")
                .URLify()
                .Trim()
                .Should().BeEquivalentTo("Mr%20John%20Smith");
        }
    }
    class URLifySolution
    {
        private char[] _text;

        public URLifySolution(string text)
        {
            this._text = text.ToCharArray();
        }

        public string URLify()
        {
            var targetIndex = _text.Length-1;

            //Find firxt char from the end
            int i = _text.Length - 1;
            for (; i >= 0; i--)
            {
                var nextChar = _text[i];
                if (nextChar != ' ')break;
            }

           
            for (; i >= 0; i--)
            {
                var nextChar = _text[i];
                if (nextChar != ' ') //move chars to the end
                {
                    _text[targetIndex] = nextChar;
                    targetIndex--;
                }
                else
                {
                    _text[targetIndex] = '0';
                    _text[targetIndex-1] = '2';
                    _text[targetIndex-2] = '%';
                    targetIndex-=3;
                }
            }


            return new string( _text);
        }

    }
}
