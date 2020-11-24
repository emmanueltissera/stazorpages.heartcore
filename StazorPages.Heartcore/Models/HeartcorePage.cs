using System;

namespace StazorPages.Heartcore.Models
{
    public class HeartcorePage
    {
        protected bool isVisible = true;
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public bool IsVisible() => isVisible;
    }
}
