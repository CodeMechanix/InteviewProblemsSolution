using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SystemDesign.JukeBox
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Player player = new Player();
            player.Play();

            Task.Delay(3000).Wait();

            player.Stop();

            Task.Delay(3000).Wait();
        }
    }
}
