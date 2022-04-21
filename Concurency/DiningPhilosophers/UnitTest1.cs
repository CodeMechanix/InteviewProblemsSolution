using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Concurency.DiningPhilosophers
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void DiningPhilosophers()
        {
            var chops = new List<Chop>()
            {
                new Chop(new Mutex(), 1),
                new Chop(new Mutex(), 2),
                new Chop(new Mutex(), 3)
            };

            var phils = new List<Phil>()
            {
                new Phil(chops[0], chops[1]),
                new Phil(chops[1], chops[2]),
                new Phil(chops[2], chops[0])
            };

            Table table = new Table(phils);
            table.StartDinning();
        }


        public class Table
        {
            public Table(List<Phil> phils)
            {
                Phils = phils;
            }


            public List<Phil> Phils { get; set; }

            public void StartDinning()
            {
                List<Task> tasks = new List<Task>();
                foreach (Phil phil in Phils)
                {
                    tasks.Add(phil.UseChops());
                }

                Task.WaitAll(tasks.ToArray());
            }
        }

        public class Phil
        {
            private Chop _leftChop;
            private Chop _rightChop;
            private AutoResetEvent AutoResetEvent;

            public Phil(Chop leftChop, Chop rightChop)
            {
                _leftChop = leftChop;
                _rightChop = rightChop;
            }

            public Task UseChops()
            {
                return Task.Run(_UseChops);
            }

            private void _UseChops()
            {
                Thread.Sleep(500);
                while (true)
                {
                    var leftUse = _leftChop.Use();
                    var rightUse = _rightChop.Use();

                    while (!leftUse || !rightUse)
                    {
                       
                        if (leftUse)
                        {
                            _leftChop.Release();
                            Thread.Sleep(1000);
                        }

                        if (rightUse)
                        {
                            _rightChop.Release();
                            Thread.Sleep(1000);
                        }

                        leftUse = _leftChop.Use();
                        rightUse = _rightChop.Use();
                    }

                    Trace.WriteLine(
                        $"{Thread.CurrentThread.ManagedThreadId} using chops: {_leftChop.Id}, {_rightChop.Id}");
                    Thread.Sleep(3000);
                    _leftChop.Release();
                    _rightChop.Release();
                }
            }
        }

        public class Chop
        {
            private Mutex _mutex;
            private object _lock;
            public int Id { get; }

            public Chop(Mutex mutex, int id)
            {
                _mutex = mutex;
                Id = id;
                ;
                _lock = new object();
            }

            public bool Use()
            {
                bool waitOne;
                lock (_lock)
                {
                    waitOne = _mutex.WaitOne(1000);
                }

                if (waitOne)
                {
                    Trace.WriteLine($"{Thread.CurrentThread.ManagedThreadId} locked chop: {Id}");
                }
                else
                {
                    Trace.WriteLine($"{Thread.CurrentThread.ManagedThreadId} failed to lock chop: {Id}");
                }

                return waitOne;
            }

            public void Release()
            {
                Trace.WriteLine($"{Thread.CurrentThread.ManagedThreadId} released chop: {Id}");

                lock (_lock)
                {
                    _mutex.ReleaseMutex();
                }
            }
        }
        
      


    }
}