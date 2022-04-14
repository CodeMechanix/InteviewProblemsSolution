using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant.core
{
    public class Chef
    {
        public void Work(Kitchen kitchen)
        {
            var thread = new Thread(() =>
            {
                while (true)
                {
                    Order newOrder = kitchen.RemoveOrder();

                    if (newOrder == null)
                    {
                        Thread.Sleep(10000);
                    }
                    else
                    {
                        ProcessOrder(newOrder);
                        OnCompletedOrder(newOrder, kitchen);
                    }
                }
            });

            thread.Start();
        }

        private void ProcessOrder(Order order)
        {
            Debug.WriteLine(
                $"Chef: {Thread.CurrentThread.ManagedThreadId} - Start Working on Order - TableId:{order.TableId}");
            foreach (var dish in order.Dishes)
            {
                Debug.WriteLine(
                    $"Chef: {Thread.CurrentThread.ManagedThreadId} - Working on Order - TableId:{order.TableId}, Dish: {dish.Name}");
                Thread.Sleep(dish.PrepTimeInMinutes * 1000);
            }

            Debug.WriteLine(
                $"Chef: {Thread.CurrentThread.ManagedThreadId} - Completed Working on Order - TableId:{order.TableId}");
        }

        private void OnCompletedOrder(Order order, Kitchen kitchen)
        {
            kitchen.OnOrderReady(order);
        }
    }
}