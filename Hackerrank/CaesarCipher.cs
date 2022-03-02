using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hackerrank
{
    [TestClass]
    public class CaesarCipher
    {
        [TestMethod]
        public void TestMethod1()
        {
            var cipher = caesarCipher("middle-Outz", 2);
        }

        public static string caesarCipher(string s, int k)
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            string alphabetUpper = alphabet.ToUpper();
            Dictionary<char, int> dictionary = new Dictionary<char, int>(alphabet.Length);
            Dictionary<char, int> dictionaryUpper = new Dictionary<char, int>(alphabet.Length);
            StringBuilder builder = new StringBuilder(alphabet.Length);

            //init dictionary
            for (int i = 0; i < alphabet.Length; i++)
            {
                dictionary.Add(alphabet[i], i);
            }
            for (int i = 0; i < alphabetUpper.Length; i++)
            {
                dictionaryUpper.Add(alphabetUpper[i], i);
            }

            //shift chars
            foreach (char c in s)
            {
                char shiftedChar;

                if (dictionary.ContainsKey(c))
                {
                    int charIndex = dictionary[c];
                    int shiftIndex = charIndex + k;
                    if (shiftIndex > alphabet.Length - 1)
                    {
                        shiftIndex %= alphabet.Length;
                    }

                    shiftedChar = alphabet[shiftIndex];
                }
                else
                if (dictionaryUpper.ContainsKey(c))
                {
                    int charIndex = dictionaryUpper[c];
                    int shiftIndex = charIndex + k;
                    if (shiftIndex > alphabetUpper.Length - 1)
                    {
                        shiftIndex %= alphabetUpper.Length;
                    }

                    shiftedChar = alphabetUpper[shiftIndex];
                }
                else
                {
                    shiftedChar = c;
                }

                builder.Append(shiftedChar);
            }

            return builder.ToString();
        }
    }
}