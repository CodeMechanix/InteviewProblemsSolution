using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CrackingCode.StockData
{
    public class StockRequestHandler
    {
        private readonly ConcurrentQueue<StockRequestInfo> queue;
        private readonly AutoResetEvent autoResetEvent;

        private bool b = true;

        public StockRequestHandler(ConcurrentQueue<StockRequestInfo> queue, AutoResetEvent autoResetEvent)
        {
            this.queue = queue;
            this.autoResetEvent = autoResetEvent;
        }

        public void Init()
        {
            Task.Factory.StartNew(() =>
            {
                while (b)
                {
                    autoResetEvent.WaitOne();

                    bool tryDequeue = queue.TryDequeue(out var result);

                    if (tryDequeue)
                    {
                        //process result

                        result.OnComplete();
                    }
                }
            });
        }
    }
}