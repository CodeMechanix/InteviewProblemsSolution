using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Educative.multithreading
{
    [TestClass]
    public class MultithreadedFizzBuzzTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var t = new MultithreadedFizzBuzz(15);
            var tasks = new List<Task>();

            tasks.Add( Task.Factory.StartNew(() =>t.buzz()));
            tasks.Add(Task.Factory.StartNew(() => t.fizz()));
            tasks.Add(Task.Factory.StartNew(() => t.fizzbuzz()));
            tasks.Add(Task.Factory.StartNew(() => t.number()));

            Task.WaitAll(tasks.ToArray());

        }
    }

    class MultithreadedFizzBuzz
    {
        private int _n;
        private int _index;
        private object _lock = new object();

        public MultithreadedFizzBuzz(int n)
        {
            this._n = n;
            _index = 1;
        }

        public void fizz()
        {
            lock (_lock)
            {
                while (_index <= _n)
                {
                    if (_index % 3 == 0 && _index % 5 != 0)
                    {
                        Debug.WriteLine("fizz");
                        _index++;
                        Monitor.PulseAll(_lock);
                    }
                    else
                    {
                        Monitor.Wait(_lock);
                    }
                }
            }
        }

        public void buzz()
        {
            lock (_lock)
            {
                while (_index <= _n)
                {
                    if (_index % 5 == 0 && _index % 3 !=0)
                    {
                        Debug.WriteLine("buzz");
                        _index++;
                        Monitor.PulseAll(_lock);
                    }
                    else
                    {
                        Monitor.Wait(_lock);
                    }
                }
            }
           
        }

        public void fizzbuzz()
        {
            lock (_lock)
            {
                while (_index <= _n)
                {
                    if (_index % 5 == 0 && _index % 3 == 0)
                    {
                        Debug.WriteLine("fizzbuzz");
                        _index++;
                        Monitor.PulseAll(_lock);
                    }
                    else
                    {
                        Monitor.Wait(_lock);
                    }
                }
            }
           
        }

        public void number()
        {
            lock (_lock)
            {
                while (_index <= _n)
                {
                    if (_index % 5 != 0 && _index % 3 != 0)
                    {
                        Debug.WriteLine(_index);
                        _index++;
                        Monitor.PulseAll(_lock);
                    }
                    else
                    {
                        Monitor.Wait(_lock);
                    }
                }
            }
           
        }
    }
}