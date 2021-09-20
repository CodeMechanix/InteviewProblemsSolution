using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeetCode._1117BuildingH2O
{
    public class H2O
    {
        private int hCount;
        private object _lock1 = new object();
        private object _lock2 = new object();


        private int oCount;
        private AutoResetEvent hWait = new AutoResetEvent(true);
        private AutoResetEvent oWait = new AutoResetEvent(true);


        public H2O()
        {
        }

        public void Hydrogen(Action releaseHydrogen) // for an oxygen thread and another hydrogen thread.
        {
            hWait.WaitOne();

            lock (_lock2)
            {
                // releaseHydrogen() outputs "H". Do not change or remove this line.
                releaseHydrogen();
            }


            lock (_lock1)
            {
                hCount++;
                if (hCount < 2)
                {
                    hWait.Set();
                }

                NewMethod();
            }
        }

        public void Oxygen(Action releaseOxygen) //for two hydrogen threads.
        {
            oWait.WaitOne();

            lock (_lock2)
            {
                // releaseOxygen() outputs "O". Do not change or remove this line.
                releaseOxygen();
            }


            lock (_lock1)
            {
                oCount++;

                NewMethod();
            }
        }

        private void NewMethod()
        {
            if (hCount == 2 && oCount == 1)
            {
                oCount = 0;
                hCount = 0;
                hWait.Set();
                oWait.Set();
            }
        }
    }


    public class H2O_Monitor
    {
        int h = 0;
        int o = 0;

        static readonly object _lock = new object();

        public H2O_Monitor()
        {

        }

        public void Hydrogen(Action releaseHydrogen)
        {
            lock (_lock)
            {
                while (h >= 2)
                {
                    Monitor.Wait(_lock);
                }

                releaseHydrogen();
                h++;
                if (h >= 2 && o >= 1)
                {
                    h -= 2;
                    o -= 1;
                }
                Monitor.Pulse(_lock);
            }
        }

        public void Oxygen(Action releaseOxygen)
        {
            lock (_lock)
            {
                while (o >= 1)
                {
                    Monitor.Wait(_lock);
                }

                releaseOxygen();
                o++;
                if (h >= 2 && o >= 1)
                {
                    h -= 2;
                    o -= 1;
                }
                Monitor.Pulse(_lock);
            }
        }
    }
}