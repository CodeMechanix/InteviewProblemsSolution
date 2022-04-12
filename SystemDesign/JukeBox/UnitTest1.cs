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
            JukeBox box = new JukeBox();
            box.AddSong(new Song() { Duration = 5, Name = "S1" });
            box.AddSong(new Song() { Duration = 5, Name = "S2" });


            Task.Delay(10000000).Wait();

        }
    }
}