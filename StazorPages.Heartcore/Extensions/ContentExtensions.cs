﻿using System;
using System.ComponentModel;
using Microsoft.AspNetCore.Html;
using Newtonsoft.Json.Linq;
using Umbraco.Headless.Client.Net.Delivery.Models;

namespace StazorPages.Heartcore.Extensions
{
    public static class ContentExtensions
    {
        public static object Value(this Content content, string alias)
        {
            content.Properties.TryGetValue(alias, out var value);
            return value;
        }

        public static T Value<T>(this Content content, string alias)
        {
            var value = Value(content, alias);
            if (value == null) return default;

            var descriptor = TypeDescriptor.GetConverter(typeof(T));
            if (descriptor.CanConvertFrom(value.GetType()))
                return (T)descriptor.ConvertFrom(value);

            if (value is string strValue && typeof(T) == typeof(IHtmlContent))
                return (T)(object)new HtmlString(strValue);

            if (value is JToken token)
                return token.ToObject<T>();

            return (T)Convert.ChangeType(value, typeof(T));
        }

        public static bool IsVisible(this Content content)
        {
            return content.Value<bool>("umbracoNaviHide") == false;
        }

    }
}
