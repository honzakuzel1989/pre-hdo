using HtmlAgilityPack;
using prehdo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prehdo
{
    class HttpParser : IParser
    {
        private const int HTML_DAYS_TO_SKIP = 3;

        private readonly HtmlDocument htmlDoc = new HtmlDocument();

        public Task<HdoDto> ParseAsync(string page)
        {
            htmlDoc.LoadHtml(page);

            var dateFrom = htmlDoc.DocumentNode.SelectSingleNode(@"//*[@id=""hdo-url-od""]");
            var dateTo = htmlDoc.DocumentNode.SelectSingleNode(@"//*[@id=""hdo-url-do""]");
            var result = new HdoDto(ParseCommand(), ParseDays().ToArray(), GetDate(dateFrom), GetDate(dateTo));

            return Task.FromResult(result);
        }

        private Date GetDate(HtmlNode date)
        {
            var items = date.GetAttributeValue("value", string.Empty).Split('.', StringSplitOptions.RemoveEmptyEntries);
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
                var times = range.Split('-', StringSplitOptions.RemoveEmptyEntries);

                yield return new TimeRange(GetTime(times[0]), GetTime(times[1]), GetTarif(tarif));
            }
        }

        private Time GetTime(string timestr)
        {
            var items = timestr.Split(':', StringSplitOptions.RemoveEmptyEntries);
            
            int hours = int.Parse(items[0]);
            int minutes = int.Parse(items[1]);

            return new Time(new Hours(hours), new Minutes(minutes));
        }

        private Tarif GetTarif(string tarif)
        {
            return tarif switch
            {
                "hdovt" => Tarif.VT,
                "hdont" => Tarif.NT,
                _ => Tarif.UNDEFINED,
            };
        }

        private string ParseCommand()
        {
            return htmlDoc.DocumentNode
                .SelectSingleNode(@"//*[@id=""povel""]/option[@selected=""selected""]")
                .InnerText;
        }
    }
}
