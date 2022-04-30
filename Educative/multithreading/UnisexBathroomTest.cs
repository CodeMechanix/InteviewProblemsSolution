using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Educative.multithreading
{
    [TestClass]
    public class UnisexBathroomTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            //todo test
            UnisexBathroom bathroom = new UnisexBathroom(3);

            List<Task> tasks = new List<Task>();

            for (int i = 0; i < 4; i++)
            {
                var task = Task.Run(() =>
                {
                    while (true)
                    {
                        bathroom.Enter(UnisexBathroom.Type.Man);
                        Thread.Sleep(3000);
                        bathroom.Exit(UnisexBathroom.Type.Man);
                        Thread.Sleep(3000);
                    }
                });
                tasks.Add(task);
            }

            for (int i = 0; i < 5; i++)
            {
                var task = Task.Run(() =>
                {
                    while (true)
                    {
                        bathroom.Enter(UnisexBathroom.Type.Women);
                        Thread.Sleep(3000);
                        bathroom.Exit(UnisexBathroom.Type.Women);
                        Thread.Sleep(3000);
                    }
                });
                tasks.Add(task);
            }

            Task.WaitAll(tasks.ToArray());
        }
    }

    public class UnisexBathroom
    {
        private int _capacity;
        private Type _currentType;
        private int _currentUsersCount;
        private object _lock;

        public UnisexBathroom(int capacity)
        {
            _capacity = capacity;
            _lock = new object();
        }

        public void Enter(Type type)
        {
            lock (_lock)
            {


                while (_currentType != type)
                {
                    if (_currentUsersCount == 0)
                    {
                        _currentType = type;
                        Trace.WriteLine($"{Thread.CurrentThread.ManagedThreadId:00} - UnisexBathroom Changed to type:{_currentType}");
                        break;
                    }
                    Trace.WriteLine($"{Thread.CurrentThread.ManagedThreadId:00} - {type} wait for type change to:{type}");
                    Monitor.Wait(_lock); //wait for type change
                }

                while (_currentUsersCount == _capacity)
                {
                    Trace.WriteLine($"{Thread.CurrentThread.ManagedThreadId:00} - {type} Wait before Enter");
                    Monitor.Wait(_lock); //Wait for capacity
                }
                _currentUsersCount++;

                Trace.WriteLine($"{Thread.CurrentThread.ManagedThreadId:00} - {type} Enter");
            }
        }

        public void Exit(Type type)
        {
            lock (_lock)
            {
                _currentUsersCount--;
                Trace.WriteLine($"{Thread.CurrentThread.ManagedThreadId:00} - {type} Exit");
                Monitor.PulseAll(_lock);
            }
        }

        public enum Type
        {
            Man,
            Women
        }
    }
}