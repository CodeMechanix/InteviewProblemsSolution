using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeetCode._1116PrintZeroEvenOdd
{
    public class ZeroEvenOdd
    {
        private int n;
        AutoResetEvent _waitFromZeroToEven = new AutoResetEvent(true);
        AutoResetEvent _waitFromZeroToOdd = new AutoResetEvent(true);
        AutoResetEvent _waitFromEven = new AutoResetEvent(false);
        AutoResetEvent _waitFromOdd = new AutoResetEvent(false);
        public ZeroEvenOdd(int n)
        {
            this.n = n+1;
        }

        // printNumber(x) outputs "x", where x is an integer.
        public void Zero(Action<int> printNumber)
        {
            for (int i = 1; i < n; i++)
            {
                _waitFromZeroToEven.WaitOne();
                _waitFromZeroToOdd.WaitOne();
                printNumber(0);
                _waitFromEven.Set();
                _waitFromOdd.Set();
            }
        }

        public void Even(Action<int> printNumber)
        {
            for (int i = 1; i < n; i++)
            {
                _waitFromEven.WaitOne();
                if (IsEven(i))
                {
                    printNumber(i);
                }

                _waitFromZeroToEven.Set();
            }

        }

        public void Odd(Action<int> printNumber)
        {
            for (int i = 1; i < n; i++)
            {
                _waitFromOdd.WaitOne();
                if (IsOdd(i))
                {
                    printNumber(i);
                }

                _waitFromZeroToOdd.Set();
            }
        }

        private bool IsEven(int num)
        {
            return (num % 2) == 0;
        }

        private bool IsOdd(int num)
        {
            return !IsEven(num);
        }
    }

    public class ZeroEvenOdd_Semaphore
    {
        private int n;

        System.Threading.Semaphore z;
        System.Threading.Semaphore e;
        System.Threading.Semaphore o;

        public ZeroEvenOdd_Semaphore(int n)
        {
            this.n = n;

            z = new System.Threading.Semaphore(1, 1); //initialize to unblocked
            e = new System.Threading.Semaphore(0, 1);
            o = new System.Threading.Semaphore(0, 1);

            //z.Release();
        }

        // printNumber(x) outputs "x", where x is an integer.
        public void Zero(Action<int> printNumber)
        {

            for (int i = 1; i <= this.n; i++)
            {
                z.WaitOne();
                printNumber(0);

                if (i % 2 == 0)
                    e.Release();
                else
                    o.Release();

            }
        }

        public void Even(Action<int> printNumber)
        {
            for (int i = 2; i <= this.n; i += 2)
            {

                e.WaitOne();
                printNumber(i);
                z.Release();
            }
        }

        public void Odd(Action<int> printNumber)
        {
            for (int i = 1; i <= this.n; i += 2)
            {

                o.WaitOne();
                printNumber(i);
                z.Release();

            }
        }
    }
}
