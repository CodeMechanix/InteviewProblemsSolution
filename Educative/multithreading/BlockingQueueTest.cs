using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Educative.multithreading
{
    [TestClass]
    public class BlockingQueueTest
    {
        [TestMethod]
        public void Test()
        {
            BlockingQueue<int> blockingQueue = new BlockingQueue<int>(3);

            var task = Task.Run(() =>
            {
                int i = 0;
                while (true)
                {
                    blockingQueue.Enqueue(i);
                    i++;
                }
            });

            var task1 = Task.Run(() =>
            {
               
                while (true)
                {
                    blockingQueue.Dequeue();
                }
            });

            task1.Wait();
        }
    }

    public class BlockingQueue<T>
    {
        private readonly int _capacity;
        private Queue<T> _queue;
        private AutoResetEvent _enqueueEvent;
        private AutoResetEvent _dequeueEvent;
        private object _lock;


        public BlockingQueue(int capacity)
        {
            this._capacity = capacity;
            _queue = new Queue<T>(capacity);
            _dequeueEvent = new AutoResetEvent(false);
            _enqueueEvent = new AutoResetEvent(true);
            _lock = new object();
        }

        public void Enqueue(T item)
        {
            while (IsFull())
            {
                Trace.WriteLine($"[{Thread.CurrentThread.ManagedThreadId}] Start Enqueue Sleep");
                _enqueueEvent.WaitOne();
                Trace.WriteLine($"[{Thread.CurrentThread.ManagedThreadId}] End Enqueue Sleep");

                Thread.Sleep(1000);
            }

            lock (_lock)
            {
                _queue.Enqueue(item);
                _dequeueEvent.Set();
            }
            Trace.WriteLine($"[{Thread.CurrentThread.ManagedThreadId}] Enqueue: {item}");

        }

        public T Dequeue()
        {
            while (IsEmpty())
            {
                Trace.WriteLine($"[{Thread.CurrentThread.ManagedThreadId}] Start Dequeue Sleep");
                _dequeueEvent.WaitOne();
                Trace.WriteLine($"[{Thread.CurrentThread.ManagedThreadId}] End Dequeue Sleep");
            }

            lock (_lock)
            {
                var dequeue = _queue.Dequeue();
                _enqueueEvent.Set();
                Trace.WriteLine($"[{Thread.CurrentThread.ManagedThreadId}] Dequeue: {dequeue}");
                return dequeue;
            }
        }

        public bool IsFull()
        {
            lock (_lock)
            {
                return _queue.Count >= _capacity;
            }
        }

        public bool IsEmpty()
        {
            lock (_lock)
            {
                return _queue.Count == 0;
            }
        }
    }
}