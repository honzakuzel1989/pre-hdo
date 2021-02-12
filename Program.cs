using System;
using System.Threading.Tasks;

namespace prehdo
{
    internal class Program
    {
        private const int DEFAULT_DOWNLOAD_PERIOD_MS = 1000 * 60 * 60;

        protected Program()
        {
        }

        static async Task Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.Error.WriteLine("Usage: pre-hdo <command>");
                return;
            }

            if (!int.TryParse(args[0], out var command))
            {
                Console.Error.WriteLine("Error: <command> must be a number");
                return;
            }

            var period = int.TryParse(Environment.GetEnvironmentVariable("PRE-HDO-DOWNLOAD-PERIOD-MS"), out var dp)
                ? dp : DEFAULT_DOWNLOAD_PERIOD_MS;

            var downloader = new HttpDownloader();
            var parser = new HttpParser();
            var senders = new[] { new NoopSender() };
            var vizualizers = new[] { new ConsoleVisualizer() };

            while (true)
            {
                try
                {
                    var page = await downloader.DownloadAsync(command);
                    var hdo = await parser.ParseAsync(page);

                    foreach (var sender in senders)
                        await sender.SendAsync(hdo);
                    foreach (var vizualizer in vizualizers)
                        await vizualizer.VizualizeAsync(hdo);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex.Message);
                }

                
                await Task.Delay(period);
            }
        }
    }
}
