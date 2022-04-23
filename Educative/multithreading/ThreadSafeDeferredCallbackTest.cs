using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Educative.multithreading
{
    [TestClass]
    public class ThreadSafeDeferredCallbackTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            // ThreadSafeDeferredCallback deferredCallback = new ThreadSafeDeferredCallback();
            // for (int i = 5; i < 50; i = i + 5)
            // {
            //     deferredCallback.RegisterDeferredCallback(() => Trace.WriteLine($"Message from future: {DateTime.Now}"),
            //         i);
            // }

            ThreadSafeDeferredCallbackII deferredCallback = new ThreadSafeDeferredCallbackII();
            for (int i = 5; i < 50; i = i + 5)
            {
                deferredCallback.SetCallback(new ThreadSafeDeferredCallbackII.Callback(i));
            }

            Task.Delay(100000).Wait();
        }
    }

    public class ThreadSafeDeferredCallbackII
    {
        private SortedList<int, Callback> _list;
        private object _lock;
        private AutoResetEvent _resetEvent;

        public ThreadSafeDeferredCallbackII()
        {
            _list = new SortedList<int, Callback>();
            _lock = new object();
            _resetEvent = new AutoResetEvent(false);

            Task.Run(Action);
        }

        private void Action()
        {
            while (true)
            {
                Monitor.Enter(_lock);

                if (_list.Count == 0)
                {
                    Monitor.Exit(_lock);
                    _resetEvent.WaitOne();
                }

                if (Monitor.IsEntered(_lock))
                {
                    Monitor.Exit(_lock);
                }

                

                Callback callabck;
                lock (_lock)
                {
                    callabck = _list.First().Value;
                }

                int sleep = (int)(callabck.StartTime - DateTime.Now).TotalMilliseconds;

                if (sleep > 0)
                {
                    _resetEvent.WaitOne(sleep);
                }
                else
                {
                    lock (_lock)
                    {
                        _list.First().Value.Action();
                        _list.RemoveAt(0);
                    }
                    
                }
            }
        }

        public void SetCallback(Callback callback)
        {
            lock (_lock)
            {
                _list.Add(callback.SleepSec, callback);
                _resetEvent.Set();
            }
        }


        public class Callback
        {
            public int SleepSec { get; set; }
            public DateTime StartTime { get; set; }
            public string Msg { get; set; }

            public Callback(int sleepSec)
            {
                Msg = $"Delayed to:{DateTime.Now.AddSeconds(sleepSec):hh:mm:ss}";
                SleepSec = sleepSec;
                StartTime = DateTime.Now.AddSeconds(sleepSec);
            }

            public void Action()
            {
                Trace.WriteLine($"{DateTime.Now:hh:mm:ss} - {Msg}");
            }
        }
    }


    public class ThreadSafeDeferredCallback
    {
        private object _lock;

        public ThreadSafeDeferredCallback()
        {
            _lock = new object();
        }

        public void RegisterDeferredCallback(Action action, int timeout)
        {
            lock (_lock)
            {
                Task.Run(() =>
                {
                    Trace.WriteLine($"Sending message to future: {DateTime.Now.AddSeconds(timeout)}");
                    Thread.Sleep(TimeSpan.FromSeconds(timeout));
                    action.Invoke();
                });
            }
        }
    }
}