using HtmlAgilityPack;
using pre_hdo.Core.Entities;
using prehdo.Console.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prehdo.Console
{
    public class HttpParser : IParser
    {
        private const int HTML_DAYS_TO_SKIP = 3;

        private readonly HtmlDocument htmlDoc = new HtmlDocument();

        public Task<Hdo> ParseAsync(string page)
        {
            htmlDoc.LoadHtml(page);

            var dateFrom = htmlDoc.DocumentNode.SelectSingleNode(@"//*[@id=""hdo-url-od""]");
            var dateTo = htmlDoc.DocumentNode.SelectSingleNode(@"//*[@id=""hdo-url-do""]");
            var result = new Hdo(ParseCommand(), ParseDays().ToArray(), GetDate(dateFrom), GetDate(dateTo));

            return Task.FromResult(result);
        }

        private Date GetDate(HtmlNode date)
        {
            var items = date.GetAttributeValue("value", string.Empty).Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            return new Date(int.Parse(items[0]), int.Parse(items[1]), int.Parse(items[2]));
        }

        private IEnumerable<Day> ParseDays()
        {
            var days = htmlDoc.DocumentNode.SelectNodes(@"//*[@class=""hdo-bar""]");
            foreach (var day in days.Skip(HTML_DAYS_TO_SKIP))
                yield return new Day(day.InnerText.Trim(), ParseTimeRange(day).ToArray());
        }

        private IEnumerable<TimeRange> ParseTimeRange(HtmlNode day)
        {
            var ranges = day.SelectNodes("span").ToArray();
            for (int i = 0; i < ranges.Length; i += 2)
            {
                var tarif = ranges[i].GetClasses().First();

                // One more cycle
                var range = ranges[i + 1].GetAttributeValue("title", string.Empty);
                var times = range.Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries);

                yield return new TimeRange(GetTime(times[0]), GetTime(times[1]), GetTarif(tarif));
            }
        }

        private Time GetTime(string timestr)
        {
            var items = timestr.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

            int hours = int.Parse(items[0]);
            int minutes = int.Parse(items[1]);

            return new Time(new Hour(hours), new Minute(minutes));
        }

        private Tarif GetTarif(string tarif)
        {
            switch (tarif)
            {
                case "hdovt": return Tarif.VT;
                case "hdont": return Tarif.NT;
                default: return Tarif.UNDEFINED;
            }
        }

        private Command ParseCommand()
        {
            var cmdstr = htmlDoc.DocumentNode
                .SelectSingleNode(@"//*[@id=""povel""]/option[@selected=""selected""]")
                .InnerText;

            var items = cmdstr.Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries);

            return new Command(int.Parse(items[0]), items[1]);
        }
    }
}
