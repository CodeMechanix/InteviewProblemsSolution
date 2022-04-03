using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;

namespace SystemDesign.CallCenter
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            CallManager callManager = new CallManager();
            callManager.AddEmployee(new Operator("Ivan"));
            callManager.AddEmployee(new Operator("Yossi"));
            callManager.AddEmployee(new Operator("Max"));
            callManager.AddEmployee(new Superviser("Nick"));
            callManager.AddEmployee(new Director("Nikolay"));

            int id = 1;


            while (true)
            {
                callManager.AddCall(new Call(id, 30));
                id++;
                Thread.Sleep(1000);
            }
        }
    }
}
