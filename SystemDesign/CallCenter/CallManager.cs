using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using SystemDesign.Common;

namespace SystemDesign.CallCenter
{
    public class CallManager
    {
        private PriorityQueue<IEmployee> employeQueue;
        private ConcurrentQueue<Call> callsQueue;
        private AutoResetEvent HandleCallEvent;
        private CallDispatcher CallDispatcher;

        public CallManager()
        {
            callsQueue = new ConcurrentQueue<Call>();
            employeQueue = new PriorityQueue<IEmployee>();
            HandleCallEvent = new AutoResetEvent(false);
            CallDispatcher = new CallDispatcher(employeQueue, callsQueue, HandleCallEvent);

            CallDispatcher.Start();
        }


        public void AddCall(Call call)
        {
            Debug.WriteLine($"{this.GetType().Name} - Adding new call id: {call.Id}");
            callsQueue.Enqueue(call);
            HandleCallEvent.Set();
        }

        public void AddEmployee(IEmployee employee)
        {
            employeQueue.Enqueue(employee, employee.Priority());
        }
    }
}