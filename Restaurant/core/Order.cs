using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.core
{
    public class Order
    {
        public int TableId { get; set; }
        public List<Dish> Dishes { get; set; }
        public string Comment { get; set; }

        public Order(int tableId, List<Dish> dishes, string comment = null)
        {
            TableId = tableId;
            Dishes = dishes;
            Comment = comment;
        }
    }
}