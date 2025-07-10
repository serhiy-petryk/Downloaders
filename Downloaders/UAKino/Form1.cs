using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UAKino
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnDownloadUAKinoFilmy_Click(object sender, EventArgs e)
        {
            btnDownloadUAKinoFilmy.Enabled = false;

            await Task.Factory.StartNew(DownloadUAKinoFilmyAction);

            btnDownloadUAKinoFilmy.Enabled = true;
        }

        private static async void DownloadUAKinoFilmyAction()
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
                await Helpers.CefSharpDownloader.DownloadPagesAsync(urlsAndFiles);
        }
    }
}
