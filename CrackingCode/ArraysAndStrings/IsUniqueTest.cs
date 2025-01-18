using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CrackingCode.ArraysAndStrings
{
    [TestClass]
    public class IsUniqueTest
    {
        [TestMethod]
        public void TestMethod1()
        {
           var v = new IsUniqueSolution().IsUnique("dsnlsdnvclas");
        }
    }

    /*
     Implement an algorithm to determine if a string has all unique characters. What if you
cannot use additional data structures? 
     */


    class IsUniqueSolution
    {
        public bool IsUnique (string word)
        {
            var hash = new HashSet<char> ();

            foreach (char c in word) { 
            
                if (hash.Contains (c)) return false;
                
                hash.Add (c);   
            
            }

            return true;
        }

        public bool IsUniqueNoDataStructure(string word)
        {
            for (int i = 0; i < word.Length; i++) {

                var currentChar = word [i]; 
                for (int j = i+1; j < word.Length; j++)
                {
                    if (word[j] == currentChar)
                    {
                        return false;
                    }
                }
            
            }

            return true;
        }
    }
}
