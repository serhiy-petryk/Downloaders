using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using UAKino.Helpers;

namespace UAKino
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnDownloadUAKinoFilmy_Click(object sender, EventArgs e) =>
            RunAction((Button)sender, CefSharpDownloader.DownloadUAKinoFilmyAction);

        private void btnParseUAKinoFilmy_Click(object sender, EventArgs e) =>
            RunAction((Button)sender, Parsers.ParseUAKinoFilmyAction);

        private async void RunAction(Control button, Action<Action<string>> action)
        {
            button.Enabled = false;
            await Task.Factory.StartNew(() => action(ShowStatus));
            button.Enabled = true;
        }

        private void ShowStatus(string message)
        {
            if (statusStrip1.InvokeRequired)
                Invoke(new MethodInvoker(delegate { ShowStatus(message); }));
            else
                statusLabel.Text = message;
        }
    }
}
