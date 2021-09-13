using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeetCode.PrintFooBarAlternately
{
    public class FooBar
    {
        private int n;


        private SemaphoreSlim _semaphore1;
        private SemaphoreSlim _semaphore2;


        public FooBar(int n)
        {
            this.n = n;
            _semaphore1 = new SemaphoreSlim(0);
            _semaphore2 = new SemaphoreSlim(0);
            _semaphore2.Release();
        }

        public void Foo(Action printFoo)
        {

            for (int i = 0; i < n; i++)
            {

                _semaphore2.Wait();
                // printFoo() outputs "foo". Do not change or remove this line.
                printFoo();

                _semaphore1.Release();

            }
        }

        public void Bar(Action printBar)
        {

            for (int i = 0; i < n; i++)
            {
                _semaphore1.Wait();
                // printBar() outputs "bar". Do not change or remove this line.
                printBar();

                _semaphore2.Release();
            }
        }
    }
}
