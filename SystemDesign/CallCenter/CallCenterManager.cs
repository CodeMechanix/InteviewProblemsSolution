using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SystemDesign.Common;

namespace SystemDesign.CallCenter
{
    public class CallCenterManager
    {
        private PriorityQueue<IEmployee> employeQueue;
        private ConcurrentQueue<Call> callsQueue;
        private AutoResetEvent HandleCallEvent;
        private CallDispatcher CallDispatcher;

        public CallCenterManager()
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

    public class CallDispatcher
    {
        private readonly PriorityQueue<IEmployee> employeQueue;
        private readonly ConcurrentQueue<Call> callsQueue;
        private readonly AutoResetEvent autoResetEvent;

        public CallDispatcher(PriorityQueue<IEmployee> employeQueue, ConcurrentQueue<Call> callsQueue,
            AutoResetEvent autoResetEvent)
        {
            this.employeQueue = employeQueue;
            this.callsQueue = callsQueue;
            this.autoResetEvent = autoResetEvent;
        }

        public void Start()
        {
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    autoResetEvent.WaitOne();//wait for signal

                    if (employeQueue.Counter > 0 && !callsQueue.IsEmpty)
                    {
                        IEmployee employee = employeQueue.Dequeue();
                        Debug.WriteLine($"{this.GetType().Name} - Next to handle call is Employee: {employee}");
                        Call result;
                        callsQueue.TryDequeue(out result);

                        Debug.WriteLine($"{this.GetType().Name} - Assign call id:{result.Id} to Employee: {employee},");

                        employee.HandleCall(result, () =>
                        {
                            Debug.WriteLine($"{this.GetType().Name} - Employee: {employee} if Free");
                            employeQueue.Enqueue(employee, employee.Priority());
                            autoResetEvent.Set();
                        });
                    }
                }
            });

        }

     
    }
}