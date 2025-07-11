using System;
using System.IO;
using System.Threading;

namespace UAKino.Helpers
{
    public static class Parsers
    {
        public static void ParseUAKinoFilmyAction(Action<string> showStatusAction)
        {
            var fileNames = Directory.GetFiles(@"D:\Temp\film\uakino-filmy", "*.html");
            var count = 0;
            foreach (var fileName in fileNames)
            {
                count++;
                var content = File.ReadAllText(fileName);
                Thread.Sleep(200);
                showStatusAction($"Parsed {count} from {fileNames.Length} file(s)");
            }
        }
    }
}
