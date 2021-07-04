using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace SwiftCode.BBS.Common.MemoryCache
{
    /// <summary>
    /// 实例化缓存接口ICachingProvider
    /// </summary>
    public class MemoryCachingProvider: ICachingProvider
    {
        //引用Microsoft.Extensions.Caching.Memory;
        private readonly IMemoryCache _cache;
        //还是通过构造函数的方法，获取
        public MemoryCachingProvider(IMemoryCache cache)
        {
            _cache = cache;
        }

        public object Get(string cacheKey)
        {
            return _cache.Get(cacheKey);
        }

        public void Set(string cacheKey, object cacheValue)
        {
            _cache.Set(cacheKey, cacheValue, TimeSpan.FromSeconds(7200));
        }
    }
}
