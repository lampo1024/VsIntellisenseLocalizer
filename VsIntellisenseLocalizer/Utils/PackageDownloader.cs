using AngleSharp;
using AngleSharp.Dom;
using Flurl.Http;
using VsIntellisenseLocalizer.Models;

namespace VsIntellisenseLocalizer.Utils
{
    public class PackageDownloader
    {
        private static async Task<string> Download()
        {
            var html = "";
            var counter = 0;
            do
            {
                try
                {
                    html = await "https://dotnet.microsoft.com/en-us/download/intellisense".GetStringAsync();
                    break;
                }
                catch
                {
                    counter++;
                }
            } while (counter <= 3);

            return html;
        }
        public static async Task<List<IntelliSenseFile>> DownloadIntelliSenseFile()
        {
            var html = await Download();
            var config = Configuration.Default;
            var context = BrowsingContext.New(config);
            var document = await context.OpenAsync(req => req.Content(html));
            var releases = document.QuerySelectorAll("table[aria-labelledby='download-intellisense'] tbody tr");
            var packages = new List<IntelliSenseFile>();
            foreach (var release in releases)
            {
                var package = new IntelliSenseFile
                {
                    Version = release.QuerySelector("td:first-child").Text().Trim()
                };
                var urls = release.QuerySelectorAll("td:last-child ul li a");
                foreach (var url in urls)
                {
                    var title = url.Text().Trim();
                    var href = url.GetAttribute("href");
                    package.Resources.Add(new DownloadResource
                    {
                        Id = Guid.NewGuid(),
                        Title = title,
                        Url = href
                    });
                }
                packages.Add(package);
                if (package.Version.StartsWith("5.0.x"))
                {
                    packages.Add(new IntelliSenseFile
                    {
                        Version = "6.0.x",
                        Resources = package.Resources
                    });
                }
            }

            return packages.OrderByDescending(x => x.Version).ToList();
        }
    }
}
