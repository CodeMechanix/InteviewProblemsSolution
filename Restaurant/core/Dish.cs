using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.core
{
    public class Dish
    {
        public string Name { get; set; }
        public long Price { get; set; }
        public int PrepTimeInMinutes { get; set; }

        public Dish(string name, long price, int prepTimeInMinutes)
        {
            Name = name;
            Price = price;
            PrepTimeInMinutes = prepTimeInMinutes;
        }
    }
}
