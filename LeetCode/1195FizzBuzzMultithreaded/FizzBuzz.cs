using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeetCode._1195FizzBuzzMultithreaded
{
    public class FizzBuzz
    {
        private int n;
        private int count;
        private object lockObj = new object();

        ManualResetEvent _resetEvent1 = new ManualResetEvent(false);
        ManualResetEvent _resetEvent2 = new ManualResetEvent(false);

        public FizzBuzz(int n)
        {
            this.n = n+1;
            _resetEvent1.Set();
        }
        private void Up()
        {
            lock (lockObj)
            {
                count++;
            }
        }
        private void Down()
        {
            lock (lockObj)
            {
                count--;
            }
        }
        private int Read()
        {
            lock (lockObj)
            {
                return count;
            }
        }
        // printFizz() outputs "fizz".
        public void Fizz(Action printFizz)//"Fizz" if i is divisible by 3 and not 5,
        {
            for (int i = 1; i < n; i++)
            {
//                Debug.Write(i);

                if (DivisibleBy(i,3) && !DivisibleBy(i,5))
                {
                    printFizz();
                }

                while (Read() != 3)
                {
                    Thread.Sleep(1);
                }

                _resetEvent1.Reset();
                _resetEvent2.Set();

                while (Read() != 0)
                {
                    Thread.SpinWait(1);
                }

                _resetEvent2.Reset();
                _resetEvent1.Set();
            }
        }

        // printBuzzz() outputs "buzz".
        public void Buzz(Action printBuzz)
        {
            for (int i = 1; i < n; i++)
            {
                _resetEvent1.WaitOne();
                Up();

                //                Debug.Write(i);

                if (DivisibleBy(i, 5) && !DivisibleBy(i, 3))
                {
                    printBuzz();
                }
                _resetEvent2.WaitOne();
                Down();
            }

        }

        // printFizzBuzz() outputs "fizzbuzz".
        public void Fizzbuzz(Action printFizzBuzz)
        {
            for (int i = 1; i < n; i++)
            {
                _resetEvent1.WaitOne();
                Up();

                //                Debug.Write(i);
                if (DivisibleBy(i, 3) && DivisibleBy(i, 5))
                {
                    printFizzBuzz();
                }

                _resetEvent2.WaitOne();
                Down();


            }
        }

        // printNumber(x) outputs "x", where x is an integer.
        public void Number(Action<int> printNumber)
        {
            for (int i = 1; i < n; i++)
            {
                _resetEvent1.WaitOne();
                Up();

                //                Debug.Write(i);

                if (!DivisibleBy(i, 3) || !DivisibleBy(i, 5))
                {
                    printNumber(i);
                }
                _resetEvent2.WaitOne();
                Down();

            }
        }

        private bool DivisibleBy(int num, int byNum)
        {
            if (num < byNum)
            {
                return false;
            }
            return num % byNum == 0;
        }

       
    }



    public class FizzBuzz_Semaphore
    {
        private int n;
        private int x;
        private Semaphore semNum;
        private Semaphore semFizz;
        private Semaphore semBuzz;
        private Semaphore semFizzBuzz;

        public FizzBuzz_Semaphore(int n)
        {
            this.n = n;
            this.x = 1;
            semNum = new Semaphore(1, 1);
            semFizz = new Semaphore(0, 1);
            semBuzz = new Semaphore(0, 1);
            semFizzBuzz = new Semaphore(0, 1);
        }

        // printFizz() outputs "fizz".
        public void Fizz(Action printFizz)
        {
            while (x <= n)
            {
                semFizz.WaitOne();

                if (x > n)
                    return;

                if (x % 3 == 0)
                {
                    printFizz();
                    x++;
                }
                ReleaseSemaphore(x);
            }
        }

        // printBuzzz() outputs "buzz".
        public void Buzz(Action printBuzz)
        {
            while (x <= n)
            {
                semBuzz.WaitOne();

                if (x > n)
                    return;

                if (x % 5 == 0)
                {
                    printBuzz();
                    x++;
                }
                ReleaseSemaphore(x);
            }
        }

        // printFizzBuzz() outputs "fizzbuzz".
        public void Fizzbuzz(Action printFizzBuzz)
        {
            while (x <= n)
            {
                semFizzBuzz.WaitOne();

                if (x > n)
                    return;

                if (x % 15 == 0)
                {
                    printFizzBuzz();
                    x++;
                }

                ReleaseSemaphore(x);
            }
        }

        // printNumber(x) outputs "x", where x is an integer.
        public void Number(Action<int> printNumber)
        {
            while (x <= n)
            {
                semNum.WaitOne();

                if (x > n)
                    return;

                if (x % 3 != 0 && x % 5 != 0)
                {
                    printNumber(x);
                    x++;
                }

                ReleaseSemaphore(x);
            }
        }

        private void ReleaseSemaphore(int i)
        {
            if (i > n)
            {
                semNum.Release();
                semFizz.Release();
                semBuzz.Release();
                semFizzBuzz.Release();
                return;
            }

            if (i % 15 == 0)
            {
                semFizzBuzz.Release();
            }
            else if (i % 3 == 0)
            {
                semFizz.Release();
            }
            else if (i % 5 == 0)
            {
                semBuzz.Release();
            }
            else
            {
                semNum.Release();
            }
        }
    }


    public class FizzBuzz_AutoResetEvent
    {
        private readonly int _n;
        private int _threadCount = 0;
        private readonly Dictionary<int, AutoResetEvent> _dic = new Dictionary<int, AutoResetEvent>();

        private void Next()
        {
            var id = Thread.CurrentThread.ManagedThreadId;
            lock (_dic)
            {
                if (!_dic.ContainsKey(id))
                    _dic.Add(id, new AutoResetEvent(false));
                _threadCount++;
                if (_threadCount == 4)
                {
                    _threadCount = 0;
                    _dic.Values.ToList().ForEach(x => x.Set());
                }
            }

            _dic[id].WaitOne();
        }

        public FizzBuzz_AutoResetEvent(int n)
        {
            this._n = n;
        }

        public void Fizz(Action printFizz)
        {
            for (int i = 1; i <= _n; i++)
            {
                if (i % 3 == 0 && i % 5 != 0)
                    printFizz();
                Next();
            }
        }

        public void Buzz(Action printBuzz)
        {
            for (int i = 1; i <= _n; i++)
            {
                if (i % 3 != 0 && i % 5 == 0)
                    printBuzz();
                Next();
            }
        }

        public void Fizzbuzz(Action printFizzBuzz)
        {
            for (int i = 1; i <= _n; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                    printFizzBuzz();
                Next();
            }
        }

        public void Number(Action<int> printNumber)
        {
            for (int i = 1; i <= _n; i++)
            {
                if (i % 3 != 0 && i % 5 != 0)
                    printNumber(i);
                Next();
            }
        }
    }


    public class FizzBuzz_Barrier
    {

        private int n;
        private Barrier b = new Barrier(4);

        public FizzBuzz_Barrier(int n)
        {
            this.n = n;
        }

        // printFizz() outputs "fizz".
        public void Fizz(Action printFizz)
        {
            for (int i = 1; i <= n; ++i)
            {
                if (i % 3 == 0 && i % 5 != 0) printFizz();
                b.SignalAndWait();
            }
        }

        // printBuzzz() outputs "buzz".
        public void Buzz(Action printBuzz)
        {
            for (int i = 1; i <= n; ++i)
            {
                if (i % 3 != 0 && i % 5 == 0) printBuzz();
                b.SignalAndWait();
            }
        }

        // printFizzBuzz() outputs "fizzbuzz".
        public void Fizzbuzz(Action printFizzBuzz)
        {
            for (int i = 1; i <= n; ++i)
            {
                if (i % 3 == 0 && i % 5 == 0) printFizzBuzz();
                b.SignalAndWait();
            }
        }

        // printNumber(x) outputs "x", where x is an integer.
        public void Number(Action<int> printNumber)
        {
            for (int i = 1; i <= n; ++i)
            {
                if (i % 3 != 0 && i % 5 != 0) printNumber(i);
                b.SignalAndWait();
            }
        }
    }
}
