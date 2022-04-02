using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SystemDesign.CallCenter
{
    public interface IEmployee
    {
        string Name { get; set; }
        int Priority();
        void HandleCall(Call call, Action callBack);
    }

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

    public class Director : Employee
    {
        public override int Priority()
        {
            return 3;
        }

        public Director(string name) : base(name)
        {
        }
    }

    public class Superviser : Employee
    {
        public override int Priority()
        {
            return 2;
        }

        public Superviser(string name) : base(name)
        {
        }
    }

    public class Operator : Employee
    {
        public override int Priority()
        {
            return 1;
        }

        public Operator(string name) : base(name)
        {
        }
    }
}