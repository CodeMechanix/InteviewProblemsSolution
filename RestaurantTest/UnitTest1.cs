using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading;


namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Restaurant.core.Restaurant restaurant = new Restaurant.core.Restaurant();

            restaurant.MakeOrder(1, new List<string>() { "Dish1", "Dish2" });
            restaurant.MakeOrder(2, new List<string>() { "Dish1", "Dish2" });


            while (true)
            {
                Thread.Sleep(1000);
            }
        }
    }
}