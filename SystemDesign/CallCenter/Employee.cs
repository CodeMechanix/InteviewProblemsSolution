using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace SystemDesign.CallCenter
{
    public abstract class Employee : IEmployee
    {
        public string Name { get; set; }
        public abstract int Priority();

        public Employee(string name)
        {
            Name = name;
        }

        public void HandleCall(Call call, Action callBack)
        {
            Task.Run(() =>
            {
                Debug.WriteLine($"{this} Start handle call id:{call.Id}");
                Thread.Sleep(call.Duration * 1000);
                Debug.WriteLine($"{this} Done handle call id:{call.Id}");
            }).ContinueWith(task => { callBack(); });
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} - Name: {Name}";
        }
    }
}