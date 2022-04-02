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
            CallCenterManager callCenterManager = new CallCenterManager();
            callCenterManager.AddEmployee(new Operator("Ivan"));
            callCenterManager.AddEmployee(new Operator("Yossi"));
            callCenterManager.AddEmployee(new Operator("Max"));
            callCenterManager.AddEmployee(new Superviser("Nick"));
            callCenterManager.AddEmployee(new Director("Nikolay"));

            int id = 1;


            while (true)
            {
                callCenterManager.AddCall(new Call(id, 30));
                id++;
                Thread.Sleep(1000);
            }
        }
    }
}
