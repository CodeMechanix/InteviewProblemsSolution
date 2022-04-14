using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.core
{
    public class Menu
    {
        public readonly Dictionary<string, Dish> menu;

        public Menu()
        {
            menu = new Dictionary<string, Dish>();
            Init();
        }

        public void Init()
        {
            menu.Add("Dish1", new Dish("Dish1", 1, 1));
            menu.Add("Dish2", new Dish("Dish2", 1, 1));
            menu.Add("Dish3", new Dish("Dish3", 1, 1));
        }

        public void Add(Dish dish)
        {
            menu.Add(dish.Name, dish);
        }
    }
}
