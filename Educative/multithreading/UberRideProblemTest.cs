using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Educative.multithreading
{
    [TestClass]
    public class UberRideProblemTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            UberRide uberRide = new UberRide();

            for (int i = 0; i < 10; i++)
            {
                Task.Run(() =>
                {
                    Thread.Sleep(1000);
                    uberRide.GetRide(new UberRide.Passenger(UberRide.Passenger.Type.A));
                   
                });
                Task.Run(() =>
                {
                    Thread.Sleep(2000);
                    uberRide.GetRide(new UberRide.Passenger(UberRide.Passenger.Type.B));
                });
            }

            Thread.Sleep(int.MaxValue);
        }
    }

    class UberRide
    {
        private SemaphoreSlim _semaphoreA = new SemaphoreSlim(2, 2);
        private Barrier _barrierA = new Barrier(2);

        Object _carLock = new Object();
        int _passengerInCar = 0;

        private SemaphoreSlim _semaphoreB = new SemaphoreSlim(2, 2);
        private Barrier _barrierB = new Barrier(2);

        public void GetRide(Passenger passenger)
        {
            switch (passenger.PassengerType)
            {
                case Passenger.Type.A:
                    HandlePassengerA(passenger);
                    break;
                case Passenger.Type.B:
                    HandlePassengerB(passenger);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void HandlePassengerA(Passenger passenger)
        {
            _semaphoreA.Wait(); //enter max 2 T
            _barrierA.SignalAndWait(); //wait for 2 T

            Seated(passenger);

            _semaphoreA.Release();
        }

        private void Seated(Passenger passenger)
        {
            lock (_carLock)
            {
                _passengerInCar++;

                Trace.WriteLine($"{Thread.CurrentThread.ManagedThreadId:00} - {passenger.PassengerType} Seated In Car - Total Passenger:{_passengerInCar}");
                if (_passengerInCar==4)
                {
                    Drive();
                }
            }
        }

        private void Drive()
        {
            Trace.WriteLine($"{Thread.CurrentThread.ManagedThreadId:00} - Called Drive");
            _passengerInCar = 0;
        }

        private void HandlePassengerB(Passenger passenger)
        {
            _semaphoreB.Wait(); //enter max 2 T
            _barrierB.SignalAndWait(); //wait for 2 T

            Seated(passenger);

            _semaphoreB.Release();
        }

        internal class Passenger
        {
            public Passenger(Type passengerType)
            {
                PassengerType = passengerType;
            }

            public Type PassengerType { get; set; }

            public enum Type
            {
                A,
                B
            }
        }
    }
}