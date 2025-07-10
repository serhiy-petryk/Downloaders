using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using CefSharp;
using CefSharp.OffScreen;

namespace UAKino.Helpers
{
    public static class CefSharpDownloader
    {
        public static async Task DownloadPagesAsync(List<(string, string)> urlsAndFiles)
        {
            foreach (var urlAndFile in urlsAndFiles)
            {
                if (File.Exists(urlAndFile.Item2)) continue;

                using (var browser = new ChromiumWebBrowser(urlAndFile.Item1))
                {
                    var loaded = await browser.WaitForInitialLoadAsync();

                    if (loaded.Success)
                    {
                        var html = await browser.GetSourceAsync();
                        Debug.Print($"{html.Length} {urlAndFile.Item1}");
                        // File.WriteAllText(fileName, html);
                    }
                    else
                    {
                        Debug.Print($"Failed to load {urlAndFile.Item1}");
                    }
                }

                Thread.Sleep(100);
            }
        }

    }
}
