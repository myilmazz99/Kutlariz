using System;
using System.Collections.Generic;
using System.Text;

namespace Kutlariz.Business.Caching
{
    public interface ICacheService
    {
        T Get<T>(string key);
        object Get(string key);
        void Add(string key, object data, int duration);
        bool DoesExist(string key);
        void Remove(string key);
    }
}
