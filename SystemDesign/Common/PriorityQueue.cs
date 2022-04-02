using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemDesign.Common
{
    public class PriorityQueue<T>
    {
        private readonly SortedDictionary<int, Queue<T>> dictionary;
        private object counterLock;
        private object dicLock;
        private int counter;

        public PriorityQueue()
        {
            dictionary = new SortedDictionary<int, Queue<T>>();
            counterLock = new object();
            dicLock = new object();
        }

        public int Counter
        {
            get
            {
                lock (counterLock)
                {
                    return counter;
                }
            }
            set {
                lock (counterLock)
                {
                    counter = value;
                }
            }
        }

        public void Enqueue(T item, int prio)
        {
            lock (dicLock)
            {
                if (!dictionary.ContainsKey(prio))
                {
                    dictionary.Add(prio, new Queue<T>());
                }

                dictionary[prio].Enqueue(item);
                Counter++;
            }
        }

        public T Dequeue()
        {
            lock (dicLock)
            {
                foreach (Queue<T> queue in dictionary.Values)
                {
                    if (queue.Count>0)
                    {
                        Counter--;
                        return queue.Dequeue();
                    }
                }

                throw new InvalidOperationException("Queue is empty");
            }
        }

    }
}
