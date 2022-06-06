using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Hackerrank
{
    [TestClass]
    public class NoPrefixSet
    {
        [TestMethod]
        public void TestMethod1()
        {
            Result.noPrefix(new List<string>() {"ab", "abcd", "bcd", "abcde", "bcde" });
        }

        class Result
        {
            /*
             * Complete the 'noPrefix' function below.
             *
             * The function accepts STRING_ARRAY words as parameter.
             */

            public static void noPrefix(List<string> words)
            {
                Trace.WriteLine(string.Join(", ", words));

                HashSet<string> stringSet = new HashSet<string>();
                HashSet<string> prefixSet = new HashSet<string>();


                foreach (string word in words)
                {
                    string tmp = word;


                    if ( prefixSet.Contains(tmp))
                    {
                        Console.WriteLine("BAD SET");
                        Console.WriteLine(word);
                        return;
                    }



                    while (tmp.Length > 0)
                    {
                        if (stringSet.Contains(tmp))
                        {
                            Console.WriteLine("BAD SET");
                            Console.WriteLine(word);
                            return;
                        }

                        prefixSet.Add(tmp);
                        tmp = tmp.Remove(tmp.Length - 1);
                    }

                    stringSet.Add(word);
                }

                Console.WriteLine("GOOD SET");
            }
        }
    }
}