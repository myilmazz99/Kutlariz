using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kutlariz.Business.Caching.Microsoft
{
    public class MicrosoftCacheManager : ICacheService
    {
        private readonly IMemoryCache _memoryCache;

        public MicrosoftCacheManager(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public void Add(string key, object data, int duration)
        {
            _memoryCache.Set(key, data, new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddMinutes(duration),
                SlidingExpiration = TimeSpan.FromMinutes(5)
            });
        }

        public bool DoesExist(string key)
        {
            return _memoryCache.TryGetValue(key, out object value);
        }

        public T Get<T>(string key)
        {
            return _memoryCache.Get<T>(key);
        }

        public object Get(string key)
        {
            return _memoryCache.Get(key);
        }

        public void Remove(string key)
        {
            _memoryCache.Remove(key);
        }
    }
}
