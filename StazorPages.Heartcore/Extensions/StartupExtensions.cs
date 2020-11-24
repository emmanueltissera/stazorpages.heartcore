using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using StazorPages.Heartcore.Config;
using StazorPages.Heartcore.Resolvers;
using StazorPages.Heartcore.Services;
using StazorPages.Routing;
using StazorPages.Services;

namespace StazorPages.Heartcore.Extensions
{
    public static class StartupExtensions
    {

        public static IServiceCollection AddStazorPagesHeartcore(this IServiceCollection services, IWebHostEnvironment env, UmbracoConfig config, ITypeResolver typeResolver)
        {
            services.AddUmbracoHeadlessContentDelivery(config);

            services.AddSingleton<ITypeResolver>(typeResolver);
            services.AddSingleton<IContentService, HeartcoreContentService>();
            services.AddSingleton<HeartcoreCache>();

            services.AddStazorPages(env);

            return services;
        }
    }
}
