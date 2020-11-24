using StazorPages.Models;
using Umbraco.Headless.Client.Net.Delivery.Models;

namespace StazorPages.Heartcore.Resolvers
{
    public interface ITypeResolver
    {
        IRetrievedContent GetTypedContent(Content content);
    }
}
