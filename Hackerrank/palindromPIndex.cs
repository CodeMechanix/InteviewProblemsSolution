using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

namespace Hackerrank
{
    [TestClass]
    public class palindromPIndex
    {
        [TestMethod]
        public void TestMethod1()
        {
            var index = palindromeIndex("hgygsvlfcwnswtuhmyaljkqlqjjqlqkjlaymhutwsnwcwflvsgygh");
        }

        public static int palindromeIndex(string s)
        {
            Console.WriteLine(s);

            int badIndex = -1;
            int left = 0;
            int right = s.Length - 1;

            while (left <= right)
            {
                if (s[left] == s[right])
                {
                    left++;
                    right--;
                }
                else if(badIndex == -1)
                {
                    if (s[left + 1] == s[right] && s[left + 2] == s[right - 1])
                    {
                        badIndex = left;
                        left++;
                    }
                    else if(s[left] == s[right - 1] && s[left + 1] == s[right - 2])
                    {
                        badIndex = right;
                        right--;
                    }
                }
                else
                {
                    badIndex = -1;
                    break;
                }
            }


            return badIndex;
        }


        // public static int palindromeIndex(string s)
        // {
        //     Debug.WriteLine(s);
        //
        //     bool res = IsPal(s);
        //
        //     if (res)//todo
        //     {
        //         return -1;
        //     }
        //
        //     for (int i = 0; i < s.Length; i++)
        //     {
        //         string subS = s.Remove(i,1);
        //         if (IsPal(subS))//todo
        //         {
        //             return i;
        //         }
        //
        //     }
        //
        //
        //     return -1;
        // }
        //
        // private static bool IsPal(string s)
        // {
        //     int mid = s.Length / 2;
        //     int res = s.Length % 2;
        //
        //     int indexLeft = mid + res -1;
        //     int indexRight = mid;
        //
        //     for (int i = 0; i < mid + res; i++)
        //     {
        //         Debug.WriteLine($"{s[indexLeft]} {s[indexRight]}");
        //
        //         if (s[indexLeft] != s[indexRight])
        //         {
        //             return false;
        //         }
        //         indexLeft--;
        //         indexRight++;
        //     }
        //
        //     return true;
        // }
    }
}