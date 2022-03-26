using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CrackingCode.Cache
{
    [TestClass]
    public class CacheTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var cache = new Cache(3);

            cache.Add(new CacheItem() { Id = 1, Data = "casdc" });
            cache.Add(new CacheItem() { Id = 2, Data = "casdc" });
            cache.Add(new CacheItem() { Id = 3, Data = "casdc" });
            cache.Add(new CacheItem() { Id = 4, Data = "casdc" });

            cache.Find(3);
         
        }
    }
}