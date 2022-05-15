using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace Canditech.NewFolder1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // var i = T(1, new []{2,3});

            MyPublisher publisher = new MyPublisher();
            MySubscriber mySubscriber = new MySubscriber("1");

            publisher.Action += mySubscriber.Handler;


           
            publisher.Publish();

            mySubscriber = null;

            GC.Collect();

            Thread.Sleep(1000);

            publisher.Publish();
        }


        static int T(int distance, int[] valid_steps)
        {
            Queue<int> distances = new Queue<int>();

            distances.Enqueue(distance);

            int result = 0;

            while (distances.Count > 0)
            {
                int currentDistance = distances.Dequeue();

                foreach (int step in valid_steps)
                {
                    int remainedDistance = currentDistance - step;

                    if (remainedDistance == 0)
                    {
                        result++;
                    }
                    else if (remainedDistance > 0)
                    {
                        distances.Enqueue(remainedDistance);
                    }
                }
            }

            return result;
        }
    }

    class MyPublisher
    {
        public event Action Action;

        public void Publish()
        {
            Action.Invoke();
        }
    }

    class MySubscriber
    {
        private readonly string _name;

        public MySubscriber(string name)
        {
            _name = name;
        }
        public void Handler()
        {
            Trace.WriteLine($"{_name} - Handled event");
        }


    }
}
