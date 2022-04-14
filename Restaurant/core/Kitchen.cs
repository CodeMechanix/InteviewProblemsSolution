using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.core
{
    public class Kitchen
    {


        private Queue<Order> _orders;
        private List<Chef> _chefs;

        private Object _queueLock;

        public Action<Order> OnOrderReady;

        public Kitchen(List<Chef> chefs, Action<Order> onOrderReady)
        {
            _orders = new Queue<Order>();
            _chefs = chefs;
            OnOrderReady = onOrderReady;
            _queueLock = new object();
        }

        public void InitChefs()
        {
            foreach (var chef in _chefs)
            {
                chef.Work(this);
            }
        }

        public void AddOrder(Order order)
        {
            lock (_queueLock)
            {
                _orders.Enqueue(order);
            }
        }


        public Order RemoveOrder()
        {
            lock (_queueLock)
            {
                if (_orders.Count != 0)
                {
                    return _orders.Dequeue();
                }

                return null;

            }
        }

        public int OrderCount()
        {
            lock (_queueLock)
            {
                return _orders.Count;
            }
        }
    }
}