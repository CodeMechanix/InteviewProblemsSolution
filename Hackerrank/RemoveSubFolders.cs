using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hackerrank
{
    [TestClass]
    public class RemoveSubFolders
    {
        [TestMethod]
        public void TestMethod1()
        {
            var solution = Solution(new List<string>(){"/a", "/a/b", "/c/d", "/c/d/e", "/c/f"}); 
            solution = Solution(new List<string>() { "/a", "/a/b/c", "/a/b/d" });
        }

        public static List<string>Solution(List<string> list)
        {
            List<string> nextList = new List<string>();
            List<string> workingList= new List<string>(list);
            List<string> rootFolderList = new List<string>();
            string current = null;

            while (workingList.Count > 0) 
            {
                current = workingList.First();

                foreach (string next in workingList)
                {
                    if (current.Length > next.Length)
                    {
                        if (current.Contains(next))
                        {
                            current = next;
                        }
                        else
                        {
                            nextList.Add(next);
                        }
                    }
                    else
                    {
                        if (next.Contains(current))
                        {
                            continue;
                        }
                        else
                        {
                            nextList.Add(next);
                        }
                    }
                }

                workingList = nextList;
                nextList = new List<string>();
                rootFolderList.Add(current);
            }
            
            return rootFolderList;
        }
    }
}
