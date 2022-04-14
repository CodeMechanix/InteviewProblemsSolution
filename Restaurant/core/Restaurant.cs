using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant.core
{
    public class Restaurant
    {
        public Menu Menu { get; set; }
        public Kitchen Kitchen { get; set; }
        public Cash Cash { get; set; }

        public Restaurant()
        {
            Menu = new Menu();
            Kitchen = new Kitchen(new List<Chef>() { new Chef(), new Chef() }, OnOrderReady);
            Kitchen.InitChefs();
            Cash = new Cash();

        }

        private void OnOrderReady(Order order)
        {
            Debug.WriteLine($"Order sent to TableId: {order.TableId}");
            long bill = Cash.CreateBill(order);
            Cash.UpdateCash(bill);
        }

        public void MakeOrder(int tableId, List<string> dishes)
        {
            List<Dish> dishesList = new List<Dish>();

            foreach (string dish in dishes)
            {
                Dish dish1 = Menu.menu[dish];
                dishesList.Add(dish1);
            }

            Order order = new Order(tableId, dishesList);

            Kitchen.AddOrder(order);
        }
    }
}