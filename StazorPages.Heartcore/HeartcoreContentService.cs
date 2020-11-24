using System;
using System.Net;
using System.Threading.Tasks;
using StazorPages.Heartcore.Resolvers;
using StazorPages.Heartcore.Services;
using StazorPages.Models;
using StazorPages.Services;
using Umbraco.Headless.Client.Net.Delivery;

namespace StazorPages.Heartcore
{
    public class HeartcoreContentService : IContentService
    {
        private readonly ContentDeliveryService _contentDelivery;
        private readonly ITypeResolver _typeResolver;
        private const string Culture = "en-US";

        public HeartcoreContentService(ContentDeliveryService contentDelivery, ITypeResolver typeResolver)
        {
            _contentDelivery = contentDelivery ?? throw new ArgumentNullException(nameof(contentDelivery));
            _typeResolver = typeResolver;
        }

        public async Task<IRetrievedContent> GetContentByUrlSlug(string path)
        {
            try
            {
                path = PageUrlTranslator.TranslateToCmsPath(path);
                var content = await _contentDelivery.Content.GetByUrl(path, Culture);
                return _typeResolver.GetTypedContent(content);
            }
            catch (Refit.ApiException ex)
            {
                if (ex.StatusCode == HttpStatusCode.NotFound)
                {
                    return null;
                }
                throw;
            }
        }

        public async Task<IRetrievedContent> GetContentById(Guid id)
        {
            try
            {
                var content = await _contentDelivery.Content.GetById(id);
                return _typeResolver.GetTypedContent(content);
            }
            catch (Refit.ApiException ex)
            {
                if (ex.StatusCode == HttpStatusCode.NotFound)
                {
                    return null;
                }
                throw;
            }
        }
    }
}
