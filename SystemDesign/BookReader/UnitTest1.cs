using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SystemDesign.BookReader
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            BookReaderManager manager = new BookReaderManager();

            var book = manager.FindBook("iris");

           // manager.OpenBook(book);


            while (true)
            {
                   Thread.Sleep(1000);
            }
         
            

        }
    }

    //public class Program
    //{
    //    public static void Main()
    //    {
    //        BookReaderManager manager = new BookReaderManager();
    //        manager.ReadConsole();
    //    }
    //}
}
