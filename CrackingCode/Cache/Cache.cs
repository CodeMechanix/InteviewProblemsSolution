using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingCode.Cache
{
    public class Cache
    {
        private readonly int limit;
        private Dictionary<int, LinkedListNode<CacheItem>> CacheItems;
        private LinkedList<CacheItem> LinkedList;

        public Cache(int limit)
        {
            this.limit = limit;
            CacheItems = new Dictionary<int, LinkedListNode<CacheItem>>();
            LinkedList = new LinkedList<CacheItem>();
        }


        public CacheItem Find(int id)
        {
            if (CacheItems.ContainsKey(id))
            {
                LinkedListNode<CacheItem> cacheItem = CacheItems[id];
                LinkedList.Remove(cacheItem);
                LinkedList.AddFirst(cacheItem);
                return cacheItem.Value;
            }
            else
            {
                return null;
            }
        }

        public void Add(CacheItem cacheItem)
        {
            LinkedListNode<CacheItem> linkedListNode = LinkedList.AddFirst(cacheItem);
            CacheItems.Add(cacheItem.Id, linkedListNode);

            if (LinkedList.Count > limit)
            {
                LinkedListNode<CacheItem> linkedListLast = LinkedList.Last;
                CacheItems.Remove(linkedListLast.Value.Id);
                LinkedList.RemoveLast();
            }
        }
    }

    public class CacheItem
    {
        public int Id { get; set; }
        public string Data { get; set; }
    }
}