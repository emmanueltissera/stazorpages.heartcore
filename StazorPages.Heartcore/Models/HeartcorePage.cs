using System;
using StazorPages.Heartcore.Extensions;
using StazorPages.Heartcore.Services;
using Umbraco.Headless.Client.Net.Delivery.Models;

namespace StazorPages.Heartcore.Models
{
    public class HeartcorePage
    {
        protected bool isVisible = true;
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public bool IsVisible() => isVisible;
        public void MapCommonProperties(Content content)
        {
            Id = content.Id;
            Url = content.Url.ToSafeUrl();
            Name = content.Name;
            isVisible = content.IsVisible();
        }
    }
}
