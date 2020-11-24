using System;
using System.Text.Json.Serialization;
using StazorPages.Models;

namespace StazorPages.Heartcore.Models
{
    public class HeadlessNotification : INotification
    {
        public string ContentTypeAlias { get; set; }

        [JsonPropertyName("_id")]
        public Guid Id { get; set; }
    }
}
