using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace StazorPages.Heartcore.Models
{
    public class Element
    {
        public Element()
        {
            Properties = new Dictionary<string, object>();
        }

        [JsonProperty("contentTypeAlias")]
        public string ContentTypeAlias { get; set; }

        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonExtensionData]
        public IDictionary<string, object> Properties { get; set; }
    }
}
