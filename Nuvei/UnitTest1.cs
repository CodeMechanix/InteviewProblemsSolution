using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Nuvei
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var personCollection = new PersonCollection(new PersonComparer());
            // personCollection.Add(new Person(){Id = 4});
            // personCollection.Add(new Person() { Id = 1 });
            // personCollection.Add(new Person() { Id = 5 });
            // personCollection.Add(new Person() { Id = 2 });
            // personCollection.Add(new Person() { Id = 6 });
            // personCollection.Add(new Person() { Id = 3 });

            personCollection.OnAdd += (p) =>
            {
                Debug.Write($"Add - {p.Id}\n");
                Thread.Sleep(1000);
            };
            personCollection.OnDelete += (p) => Debug.Write($"OnDelete - {p.Id}\n");
            personCollection.CountUpdate+=(i) => Debug.Write($"CountUpdate {i}\n");

            var random = new Random();

            Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 20; i++)
                {
                    personCollection.Add(new Person() { Id = random.Next(-50, 50) });
                    Thread.Sleep(1000);
                }
            });

          

            Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 20; i++)
                {
                    var remove = personCollection.Remove();
                    Thread.Sleep(2000);
                }
            });
        

            while (true)
            {
                Thread.Sleep(1000);

            }

        }
    }
}
