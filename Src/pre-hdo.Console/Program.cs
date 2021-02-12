using System;
using System.Threading.Tasks;

namespace prehdo.Console
{
    internal class Program
    {
        private const int DEFAULT_DOWNLOAD_PERIOD_MS = 1000 * 60 * 60;

        protected Program()
        {
        }

        static async Task Main(string[] args)
        {
            var period = int.TryParse(Environment.GetEnvironmentVariable("PRE-HDO-DOWNLOAD-PERIOD-MS"), out var dp)
                ? dp : DEFAULT_DOWNLOAD_PERIOD_MS;

            var downloader = new HttpDownloader();
            var parser = new HttpParser();
            var vizualizer = new ConsoleVisualizer();

            while (true)
            {
                try
                {
                    var page = await downloader.DownloadAsync();
                    var hdo = await parser.ParseAsync(page);

                    await vizualizer.VizualizeAsync(hdo);
                }
                catch (Exception ex)
                {
                    System.Console.Error.WriteLine(ex.Message);
                }


                await Task.Delay(period);
            }
        }
    }
}
