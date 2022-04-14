using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant.core
{
    public class Cash
    {
        private long _total;
        private object _chashLock;

        public Cash()
        {
            _chashLock = new object();
        }

        public long CreateBill(Order order)
        {
            long cash = 0;

            foreach (Dish dish in order.Dishes)
            {
                cash += dish.Price;
            }

            Debug.WriteLine($"{Thread.CurrentThread.ManagedThreadId} - Table: {order.TableId} - Bill: {cash}");

            return cash;
        }

        public void UpdateCash(long cash)
        {
            lock (_chashLock)
            {
                _total += cash;
                Debug.WriteLine($"{Thread.CurrentThread.ManagedThreadId} - Total cash: {_total}");
            }
        }

    }
}
