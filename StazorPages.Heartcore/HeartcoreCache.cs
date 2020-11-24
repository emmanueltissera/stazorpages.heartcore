using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Umbraco.Headless.Client.Net.Delivery;
using Umbraco.Headless.Client.Net.Delivery.Models;

namespace StazorPages.Heartcore
{
    public sealed class HeartcoreCache
    {
        private readonly ContentDeliveryService _contentDelivery;
        private readonly IMemoryCache _memoryCache;

        public HeartcoreCache(ContentDeliveryService contentDelivery, IMemoryCache memoryCache)
        {
            _contentDelivery = contentDelivery ?? throw new ArgumentNullException(nameof(contentDelivery));
            _memoryCache = memoryCache;
        }
        
        /// <summary>
        /// Gets an <see cref="IContent"/> object for a given URL and caches it for the current request
        /// </summary>
        /// <param name="path"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public async Task<IContent> GetContentByUrl(string path, string culture)
        {
            var urlCache = GetIContentCacheContainer();

            var contentCacheKey = path + "|" + culture;
            if (urlCache.TryGetValue(contentCacheKey, out var content) == false)
            {
                urlCache[contentCacheKey] = content = await _contentDelivery.Content.GetByUrl(path, culture);
            }

            return content;
        }


        public async Task<IContent> GetContentById(Guid id, string culture)
        {
            var urlCache = GetIContentCacheContainer();

            var contentCacheKey = id + "|" + culture;
            if (urlCache.TryGetValue(contentCacheKey, out var content) == false)
            {
                urlCache[contentCacheKey] = content = await _contentDelivery.Content.GetById(id, culture);
            }

            return content;
        }

        public async Task<PagedContent> GetByType(string contentType, string culture = null, int page = 1, int pageSize = 10)
        {
            var urlCache = GetPagedContentCacheContainer();

            var contentCacheKey = contentType + "|" + culture + "|" + page + "|" + pageSize;
            if (urlCache.TryGetValue(contentCacheKey, out var pagedContent) == false)
            {
                urlCache[contentCacheKey] = pagedContent = await _contentDelivery.Content.GetByType(contentType, culture, page, pageSize);
            }

            return pagedContent;
        }

        public async Task<PagedContent> GetChildren(Guid id, string culture = null, int page = 1, int pageSize = 10)
        {
            var urlCache = GetPagedContentCacheContainer();

            var contentCacheKey = id + "|" + culture + "|" + page + "|" + pageSize;
            if (urlCache.TryGetValue(contentCacheKey, out var pagedContent) == false)
            {
                urlCache[contentCacheKey] = pagedContent = await _contentDelivery.Content.GetChildren(id, culture, page, pageSize);
            }

            return pagedContent;
        }

        private Dictionary<string, IContent> GetIContentCacheContainer()
        {
            var cacheKey = GetType().FullName + "|" + "IContent";
            if (_memoryCache.TryGetValue(cacheKey, out var cache) == false)
            {
                cache = new Dictionary<string, IContent>();
                _memoryCache.Set(cacheKey, cache);
            }

            var urlCache = (Dictionary<string, IContent>) cache;
            return urlCache;
        }

        private Dictionary<string, PagedContent> GetPagedContentCacheContainer()
        {
            var cacheKey = GetType().FullName + "|" + "PagedContent";
            if (_memoryCache.TryGetValue(cacheKey, out var cache) == false)
            {
                cache = new Dictionary<string, PagedContent>();
                _memoryCache.Set(cacheKey, cache);
            }

            var urlCache = (Dictionary<string, PagedContent>) cache;
            return urlCache;
        }
    }
}
