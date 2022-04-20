using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SystemDesign.BookReader
{
    public class BookReaderManager
    {
        private BookReaderDisplay Display;
        private BookReaderLibrary Library;
        private BookReaderEngine Engine;
        private ConcurrentQueue<string> InputQueue;
        private AutoResetEvent AutoResetEvent;

        public BookReaderManager()
        {
            Display = new BookReaderDisplay();
            Library = new BookReaderLibrary();
            Engine = new BookReaderEngine();
            InputQueue = new ConcurrentQueue<string>();

            AutoResetEvent = new AutoResetEvent(false);

            Task.Run(InputQueueProcessing);
        }

        private void InputQueueProcessing()
        {
            while (true)
            {
                AutoResetEvent.WaitOne();

                if (!InputQueue.IsEmpty)
                {
                    string result;
                    InputQueue.TryDequeue(out result);
                    ProcessInput(result).Wait();
                }
            }
        }


        private async Task ProcessInput(string obj)
        {
            string[] strings = obj.Split(' ');
            string command = strings[0];

            switch (command)
            {
                case "menu":
                {
                    break;
                }
                case "OpenBook":
                {
                    Task<List<Book>> findBook = FindBook(strings[1]);
                    await OpenBook(findBook.Result.First());
                    Display.Text = Engine.CurrentPageText();
                    Display.Header = Engine.CurrentBook.Title;
                    Display.Footer = $"Page#:{Engine.CurrentPageNumber}";
                    Display.Render();
                    break;
                }
                case "FindBook":
                {
                    Task<List<Book>> findBook = FindBook(strings[1]);
                    Display.Text = string.Join(Environment.NewLine, findBook.Result.Select(book => book.Title));
                    Display.Render();
                    break;
                }
                case ">":
                {
                    Engine.NextPage();
                    Display.Text = Engine.CurrentPageText();
                    Display.Header = Engine.CurrentBook.Title;
                    Display.Footer = $"Page#:{Engine.CurrentPageNumber}";
                    Display.Render();
                    break;
                }

                default:
                    Display.Text = $@"Unknown command:{obj}";
                    Display.Render();
                    break;
            }
        }

        public async Task<List<Book>> FindBook(string name)
        {
            return await Task.Run(() => Library.FindBook(name));
        }

        public async Task OpenBook(Book book)
        {
            await Engine.PreparePages(book);
        }

        public void ReadConsole() //UI thread loop
        {
            while (true)
            {
                string readLine = Console.ReadLine();

                try
                {
                    InputQueue.Enqueue(readLine);
                    Console.WriteLine($"Received new command:{readLine}");
                    AutoResetEvent.Set();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }

    internal class BookReaderEngine
    {
        public int PageLength { get; set; } = 25;
        public List<string> PagesList { get; set; }
        public int CurrentPageNumber { get; set; }
        public Book CurrentBook { get; set; }

        public async Task PreparePages(Book book)
        {
            CurrentBook = book;
            CurrentPageNumber = 0;
            await Task.Run(() => LoadFile(book));
        }

        private void LoadFile(Book book)
        {
            Thread.Sleep(5000);
            PagesList = new List<string>();

            string[] bookText = File.ReadAllLines(book.Path);

            StringBuilder builder = new StringBuilder();

            int tempLineCounter = 0;

            foreach (string s in bookText)
            {
                if (tempLineCounter < PageLength)
                {
                    builder.Append(s);
                    builder.Append(Environment.NewLine);
                    tempLineCounter++;
                }
                else
                {
                    PagesList.Add(builder.ToString());
                    builder.Clear();
                    tempLineCounter = 0;
                }
            }
        }

        public void NextPage()
        {
            CurrentPageNumber++;
        }

        public string CurrentPageText()
        {
            return PagesList[CurrentPageNumber];
        }
    }

    internal class BookReaderLibrary
    {
        private List<Book> Books;

        public BookReaderLibrary()
        {
            Books = new List<Book>()
            {
                new Book()
                {
                    Title = "Irish Fairy Tales", Url = "https://www.gutenberg.org/files/2892/2892-0.txt",
                    Path = @"C:\Users\gleb.zinovyev\Source\Repos\MyCode\SystemDesign\BookReader\Lib\IrishFairyTales.txt"
                }
            };
        }

        public List<Book> FindBook(string name)
        {
            Thread.Sleep(5000);
            return Books.Where(book => book.Title.ToLower().Contains(name.ToLower())).ToList();
        }
    }

    public class Book
    {
        public string Url { get; set; }
        public string Title { get; set; }
        public string Path { get; set; }
    }

    internal class BookReaderDisplay
    {
        public string Text { get; set; }
        public string Header { get; set; }
        public string Footer { get; set; }

        public void Render()
        {
            Console.WriteLine("#################################################");
            Console.WriteLine(Header);
            Console.WriteLine("#################################################");
            Console.WriteLine(Text);
            Console.WriteLine("#################################################");
            Console.WriteLine(Footer);
            Console.WriteLine("#################################################");
        }
    }
}