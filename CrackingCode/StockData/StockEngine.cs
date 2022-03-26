using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CrackingCode.StockData
{
    public class StockEngine
    {
        private ConcurrentQueue<StockRequestInfo> Queue;
        private AutoResetEvent AutoResetEvent;
        private StockRequestHandler RequestHandler;

        public StockEngine()
        {
            Queue = new ConcurrentQueue<StockRequestInfo>();
            AutoResetEvent = new AutoResetEvent(false);
            RequestHandler = new StockRequestHandler(Queue, AutoResetEvent);
            RequestHandler.Init();
        }

        public void AddRequest(StockRequestInfo requestInfo)
        {
            Queue.Enqueue(requestInfo);
            AutoResetEvent.Set();
        }


    }
}
