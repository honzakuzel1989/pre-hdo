using System;
using System.Net;
using System.Threading.Tasks;

namespace prehdo.Console
{
    public class HttpDownloader : IDownloader, IDisposable
    {
        private const string DEFAULT_DOWNLOAD_URL = @"https://www.predistribuce.cz/cs/potrebuji-zaridit/zakaznici/stav-hdo/";
        private const string DEFAULT_DOWNLOAD_URL_PARAMS = @"?povel={0}&den_od={1}&mesic_od={2}&rok_od={3}&den_do={4}&mesic_do={5}&rok_do={6}";
        private const int DEFAULT_DOWNLOAD_DAY_RANGE = 10;
        private const int DEFAULT_COMMAND = 492;

        private readonly WebClient webClient = new WebClient();
        private bool disposedValue;

        public async Task<string> DownloadAsync()
        {
            var url = Environment.GetEnvironmentVariable("PRE-HDO-DOWNLOAD-URL")
                ?? DEFAULT_DOWNLOAD_URL;
            var urlparams = Environment.GetEnvironmentVariable("PRE-HDO-DOWNLOAD-URL-PARAMS")
                ?? DEFAULT_DOWNLOAD_URL_PARAMS;
            var days = int.TryParse(Environment.GetEnvironmentVariable("PRE-HDO-DOWNLOAD-DAY-RANGE"), out var dr)
                ? dr : DEFAULT_DOWNLOAD_DAY_RANGE;
            var command = int.TryParse(Environment.GetEnvironmentVariable("PRE-HDO-COMMAND"), out var cmd)
                ? cmd : DEFAULT_COMMAND;

            // TODO: dt provider
            var dtFrom = DateTime.Now;
            var dayFrom = dtFrom.Day;
            var monthFrom = dtFrom.Month;
            var yearFrom = dtFrom.Year;

            var dtTo = dtFrom.AddDays(days);
            var dayTo = dtTo.Day;
            var monthTo = dtTo.Month;

            var address = $"{url}{string.Format(urlparams, command, dayFrom, monthFrom, yearFrom, dayTo, monthTo, yearFrom)}";
            return await webClient.DownloadStringTaskAsync(address);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                webClient.Dispose();
            }

            disposedValue = true;
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
}
