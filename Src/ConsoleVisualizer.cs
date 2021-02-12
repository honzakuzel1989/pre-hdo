using prehdo.Console.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace prehdo.Console
{
    class ConsoleVisualizer : IVisualizer
    {
        public Task VizualizeAsync(Hdo hdo)
        {
            var timeLeftCnt = 20;
            var headerCaptionLeftCnt = hdo.Days.Max(day => day.Times.Length) * timeLeftCnt;
            var captionLeftCnt = headerCaptionLeftCnt - 4;

            var header = $"{hdo.Command}, {hdo.From} - {hdo.To}, {DateTime.Now}";
            System.Console.WriteLine($"{new string(' ', headerCaptionLeftCnt - header.Length)}{header}");

            foreach (var day in hdo.Days)
            {
                System.Console.Write($"{new string('-', 2)} {day.Caption} {new string('-', captionLeftCnt - day.Caption.Length)}");
                System.Console.WriteLine();

                foreach (var time in day.Times)
                {
                    var strTime = time.ToString();
                    System.Console.Write($"{new string(' ', timeLeftCnt - strTime.Length)}{strTime}");
                }
                System.Console.WriteLine();
            }

            return Task.CompletedTask;
        }
    }
}