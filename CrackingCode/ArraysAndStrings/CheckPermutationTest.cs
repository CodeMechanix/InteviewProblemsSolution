using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CrackingCode.ArraysAndStrings
{
    [TestClass]
    public class CheckPermutationTest
    {
        [TestMethod]
        [DataRow("abc", "cba", true)]
        [DataRow("abc", "cbb", false)]
        public void IsPermutationTest(string a, string b, bool expexcted)
        {
            var result = new CheckPermutation()
                .IsPermutation(a, b);

            Assert.AreEqual(expexcted,result);
        }
    }

    /*
     Check Permutation: Given two strings, write a method to decide if one is a permutation of the
other
     */
    class CheckPermutation {
        
        public bool IsPermutation(string s1, string s2)
        {
            var hashTable = new Dictionary<char, int>();

            foreach (var item in s1)
            {
                if(!hashTable.ContainsKey(item))
                {
                    hashTable.Add(item, 1);
                }
                else
                {
                    hashTable[item] += 1;
                }
            }

            foreach (var item in s2)
            {
                if (hashTable.ContainsKey(item))
                {
                    hashTable[item] -= 1;
                }
                else 
                { 
                    return false;
                }
            }
            return hashTable.Values.Any(i => i != 0) ? false : true;
        }
    
    
    
    }
}
