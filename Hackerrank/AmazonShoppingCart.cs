using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Hackerrank
{
    [TestClass]
    public class AmazonShoppingCart
    {
        [TestMethod]
        public void TestMethod1()
        {
            //     shoppingCart: banana; orange; guava; apple; apricot; papaya; kiwi
            //     codeList: apple apricot; banana anything guava; papaya anything


            List<string> codeList = new List<string>() { "apple apple", "banana anything banana" };
            List<string> shoppingCart = new List<string>() { "orange", "apple", "apple", "banana", "orange", "banana" };

            var i = foo(codeList, shoppingCart);
        }

        public static int foo(List<string> codeList, List<string> shoppingCart)
        {
            Console.WriteLine($"codeList: {string.Join("; ", codeList)}");
            Console.WriteLine($"shoppingCart: {string.Join("; ", shoppingCart)}");

            //List<List<string>> codeListSplited = new List<List<string>>();

            Queue<List<string>> queue = new Queue<List<string>>();

            codeList.ForEach(s => queue.Enqueue( s.Split(new []{' '}).ToList()));

            List<string> currentGroup = queue.Dequeue();
            int groupItemCounter = 0;

            foreach (var item in shoppingCart)
            {
                string prizeItem = currentGroup[groupItemCounter];

                if (item.Equals(prizeItem) || prizeItem.Equals("anything"))
                {
                    groupItemCounter++;
                    if (groupItemCounter >= currentGroup.Count)
                    {
                        //next group
                        if (queue.Count > 0)
                        {
                            currentGroup = queue.Dequeue();
                            groupItemCounter = 0;
                        }
                        else
                        {
                            return 1;
                        }
                    }
                }
            }



            

           


            return 0;
        }
    }
}
