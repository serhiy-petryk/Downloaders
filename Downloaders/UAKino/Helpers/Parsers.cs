using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace UAKino.Helpers
{
    public static class Parsers
    {
        public static void ParseUAKinoFilmyAction(Action<string> showStatusAction)
        {
            var genres = new Dictionary<string, int>();
            var fileNames = Directory.GetFiles(@"D:\Temp\film\uakino-filmy", "*.html");
            var count = 0;
            Debug.Print("Plus\tZero\tMinus\tQuality\tName\tIMDB\tGenre\tYear\tActors\tDescription");

            foreach (var fileName in fileNames)
            {
                count++;
                showStatusAction($"Parsed {count} from {fileNames.Length} file(s)");

                var content = File.ReadAllText(fileName);
                var lines = content.Split("class=\"movie-item short-item\"", StringSplitOptions.None);
                for (var k = 1; k < lines.Length; k++)
                {
                    var s = lines[k];

                    var i1 = s.IndexOf("class=\"related-item-rating positive", StringComparison.InvariantCulture);
                    var rating_plus = i1 == -1 ? (int?)null : int.Parse(GetValue(s, i1));

                    i1 = s.IndexOf("class=\"related-item-rating neutral", StringComparison.InvariantCulture);
                    var rating_zero = i1 == -1 ? (int?)null : int.Parse(GetValue(s, i1, "</span>"));

                    i1 = s.IndexOf("class=\"related-item-rating negative", StringComparison.InvariantCulture);
                    var rating_minus = i1 == -1 ? (int?)null : int.Parse(GetValue(s, i1));

                    i1 = s.IndexOf("class=\"full-quality", StringComparison.InvariantCulture);
                    var quality = GetValue(s, i1);

                    i1 = s.IndexOf("class=\"deck-title", i1, StringComparison.InvariantCulture);
                    var name = GetValue(s, i1);

                    var i2 = s.IndexOf(">IMDB:<", i1, StringComparison.InvariantCulture);
                    var sImdb = i2 == -1 ? null : GetDivValue(s, i2).Replace(",", ".");
                    var imdb = string.IsNullOrEmpty(sImdb) || sImdb == "n/A"
                        ? (decimal?)null
                        : decimal.Parse(sImdb, CultureInfo.InvariantCulture);

                    i1 = s.IndexOf(">Жанр:<", i1, StringComparison.InvariantCulture);
                    var genre = NormalizeGenre(GetDivValue(s, i1));
                    UpdateGenres(genre);

                    i1 = s.IndexOf(">Рік виходу:<", i1, StringComparison.InvariantCulture);
                    var year = GetYear(s, i1);

                    i1 = s.IndexOf(">Актори:<", i1, StringComparison.InvariantCulture);
                    var actors = GetActors(s, i1);

                    i1 = s.IndexOf("class=\"desc-about-text", i1, StringComparison.InvariantCulture);
                    var description = GetValue(s, i1).Replace("...", "");
                    if (string.IsNullOrEmpty(description)) description = null;

                    Debug.Print($"{rating_plus}\t{rating_zero}\t{rating_minus}\t{quality}\t{name}\t{imdb}\t{genre}\t{year}\t{actors}\t{description}");
                }
            }

            Debug.Print("/nGenres");
            foreach(var kvp in genres)
                Debug.Print($"{kvp.Key}\t{kvp.Value}");

            MessageBox.Show("See results in debug window");

            void UpdateGenres(string genre)
            {
                var ss = genre.Split(',', StringSplitOptions.None);
                foreach (var s in ss)
                {
                    var key = s.Trim();
                    if (!genres.ContainsKey(key)) genres.Add(key, 0);
                    genres[key]++;
                } 
            }
        }

        private static string GetValue(string content, int offset)
        {
            var i2 = content.IndexOf("<", offset, StringComparison.InvariantCulture);
            var i1 = content.LastIndexOf(">", i2, StringComparison.InvariantCulture);
            var s = content.Substring(i1 + 1, i2 - i1 - 1);
            return s.Trim();
        }
        private static string GetValue(string content, int offset, string endString)
        {
            var i2 = content.IndexOf(endString, offset, StringComparison.InvariantCulture);
            var i1 = content.LastIndexOf(">", i2, StringComparison.InvariantCulture);
            var s = content.Substring(i1 + 1, i2 - i1 - 1);
            return s.Trim();
        }
        private static string GetDivValue(string content, int offset)
        {
            var i2 = content.IndexOf("</div>", offset, StringComparison.InvariantCulture);
            i2 = content.IndexOf("</div>", i2 + 4, StringComparison.InvariantCulture);
            var i1 = content.LastIndexOf(">", i2, StringComparison.InvariantCulture);
            var s = content.Substring(i1 + 1, i2 - i1 - 1);
            return s.Trim();
        }
        private static string GetYear(string content, int offset)
        {
            var i1 = content.IndexOf("</div>", offset, StringComparison.InvariantCulture);
            i1 = content.IndexOf("</div>", i1 + 4, StringComparison.InvariantCulture);
            var s = content.Substring(offset, i1 - offset);
            if (s.EndsWith("</a>")) return GetValue(s, 0, "</a>");
            return null;
        }

        private static string GetActors(string content, int offset)
        {
            var i2 = content.IndexOf("</div>", offset, StringComparison.InvariantCulture);
            i2 = content.IndexOf("</div>", i2 + 4, StringComparison.InvariantCulture);
            var s = content.Substring(offset, i2 - offset);
            var ss = s.Split("</a>");
            var actors = new string[ss.Length - 1];
            if (actors.Length == 1) return null;
            for (var k = 0; k < ss.Length - 1; k++)
            {
                var i1 = ss[k].LastIndexOf(">", StringComparison.InvariantCulture);
                actors[k] = ss[k].Substring(i1 + 1).Trim();
            }
            return string.Join(", ", actors);
        }

        private static string NormalizeGenre(string oldGenres)
        {
            var ss = oldGenres.Split(',', StringSplitOptions.RemoveEmptyEntries);
            return string.Join(", ",
                ss.Where(a => !a.TrimStart().StartsWith("20") && !a.TrimStart().StartsWith("19"))
                    .Select(a => a.Trim()));
        }
    }
}
