using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
namespace Core.Storage.Implement
{
    public class InMemoryConnection : IConnection
    {
        private CacheItemPolicy policy;
        private string regionName;

        public InMemoryConnection(string regionName)
        {
            policy = new CacheItemPolicy()
            {
                SlidingExpiration = new TimeSpan(1, 0, 0, 0)
            };
        }

        public void AddOrUpdate<tEntity>(List<tEntity> item, string name)
            where tEntity : BaseEntity
        {
            CacheItem cacheItem = ConstructCacheItem(item, name);
            if (!MemoryCache.Default.Contains(name, regionName))
                MemoryCache.Default.Add(cacheItem, policy);
            else
                MemoryCache.Default.Set(cacheItem, policy);
        }

        public List<tEntity> Get<tEntity>(string Name)
            where tEntity : BaseEntity
        {
            List<tEntity> listEntity = MemoryCache.Default.Get(Name, regionName) as List<tEntity>;
            if (listEntity == null)
                listEntity = new List<tEntity>();
            return listEntity;
        }

        private CacheItem ConstructCacheItem(object item, string name)
        {
            return new CacheItem(name, item, regionName);
        }

        public string TypeConnection => Constants.ConnectionTypes.InMemory;

        public string ConnectionString { get; set; }

        [Obsolete("In this connection is not necesary", true)]
        public IDbConnection DataProvider => throw new NotImplementedException();

        [Obsolete("In this connection is not necesary", true)]
        public void Close()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
        }

        [Obsolete("In this connection is not necesary", true)]
        public void Open()
        {
            throw new NotImplementedException();
        }
    }
}
