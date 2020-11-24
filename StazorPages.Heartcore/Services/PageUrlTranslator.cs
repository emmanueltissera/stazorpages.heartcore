namespace StazorPages.Heartcore.Services
{
    public static class PageUrlTranslator
    {
        public static string TranslateToCmsPath(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return "/home/";
            }

            path = path.Trim('/');
            return $"/home/{path}/";
        }

        public static string TranslateToStazorPath(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                return "does-not-exist";
            }

            if (url.StartsWith("/home"))
            {
                url = url.Remove(0, 5);
            }

            url = url.Trim('/');

            return string.IsNullOrEmpty(url) ? "index.html" : $"{url}/index.html";
        }

        public static string ToSafeUrl(this string url)
        {
            return url.Replace("/home", "");
        }

    }
}
