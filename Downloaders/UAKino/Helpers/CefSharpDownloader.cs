using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.OffScreen;

namespace UAKino.Helpers
{
    public static class CefSharpDownloader
    {
        public static async void DownloadUAKinoFilmyAction(Action<string> showStatus)
        {
            var urlsAndFiles = new List<(string, string)>();
            for (var k = 0; k < 369; k++)
            {
                urlsAndFiles.Add(($"https://uakino.best/filmy/page/{k + 1}/",
                    Path.Combine(@"D:\Temp\film\uakino-filmy", "uakino-filmy" + (k + 1).ToString("D5") + ".html")));
            }

            if (DialogResult.Yes ==
                MessageBox.Show($@"!!! Before run application run vpn (Psiphon3 - Poland) !!! Continue?", null,
                    MessageBoxButtons.YesNo))
                await DownloadPagesAsync(urlsAndFiles, showStatus);
        }


        private static async Task DownloadPagesAsync(List<(string, string)> urlsAndFiles, Action<string> showStatusAction)
        {
            var count = 0;
            foreach (var urlAndFile in urlsAndFiles)
            {
                count++;
                showStatusAction($"Downloaded {count} from {urlsAndFiles.Count} item(s)");

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
