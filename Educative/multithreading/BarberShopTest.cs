using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Educative.multithreading
{
    [TestClass]
    public class BarberShopTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            BarberShop barberShop = new BarberShop(3);

            for (int i = 0; i < 5; i++)
            {
                Task.Run(() => { barberShop.Enter(new BarberClient(new HairCut(10))); });
            }


            Thread.Sleep(int.MaxValue);
        }
    }

    class BarberShop
    {
        ConcurrentQueue<BarberQitem> _hairCutsQueue = new ConcurrentQueue<BarberQitem>();
        private int _maxChairs;
        private int _usedChairs;
        object _lock = new object();
        private AutoResetEvent _barbeResetEvent = new AutoResetEvent(false);

        public BarberShop(int maxChairs)
        {
            _maxChairs = maxChairs;
            Init();
        }

        private void Init()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    BarberQitem barberQitem;
                    _hairCutsQueue.TryDequeue(out barberQitem);


                    if (barberQitem is null)
                    {
                        _barbeResetEvent.WaitOne();
                    }
                    else
                    {
                        lock (_lock)
                        {
                            _usedChairs--;
                        }
                        Thread.Sleep(barberQitem.Client.HairCut.WorkTime * 1000);
                        barberQitem.Release();
                    }


                 
                }
            });
        }


        public void Enter(BarberClient client)
        {
            BarberQitem barberQitem = null;

            lock (_lock)
            {
                Trace.WriteLine($"{Thread.CurrentThread.ManagedThreadId:00} - Enter");

                if (_maxChairs > _usedChairs)
                {
                    _usedChairs++;

                    barberQitem = new BarberQitem(client);
                    _hairCutsQueue.Enqueue(barberQitem);
                    _barbeResetEvent.Set();
                }
                else
                {
                    Trace.WriteLine($"{Thread.CurrentThread.ManagedThreadId:00} - No free Chairs");
                }
            }

            barberQitem?.Wait();

            Trace.WriteLine($"{Thread.CurrentThread.ManagedThreadId:00} - Exit");
        }
    }

    class BarberQitem
    {
        public BarberClient Client { get; set; }
        private ManualResetEventSlim ManualResetEventSlim { get; set; }

        public BarberQitem(BarberClient client)
        {
            Client = client;
            ManualResetEventSlim = new ManualResetEventSlim(false);
        }


        public void Wait()
        {
            Trace.WriteLine($"{Thread.CurrentThread.ManagedThreadId:00} - Waiting");
            ManualResetEventSlim.Wait();
            Trace.WriteLine($"{Thread.CurrentThread.ManagedThreadId:00} - Completed Wait");
        }

        public void Release()
        {
            Trace.WriteLine($"{Thread.CurrentThread.ManagedThreadId:00} - Release");
            ManualResetEventSlim.Set();
        }
    }

    class HairCut
    {
        public HairCut(int workTime)
        {
            WorkTime = workTime;
        }

        public int WorkTime { get; set; }
    }

    class BarberClient
    {
        public BarberClient(HairCut hairCut)
        {
            HairCut = hairCut;
        }

        public HairCut HairCut { get; set; }
    }
}