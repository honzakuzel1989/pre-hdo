using prehdo.Entities;
using System;
using System.Threading.Tasks;

namespace prehdo
{
    class ConsoleVisualizer : IVisualizer
    {
        public Task VizualizeAsync(Hdo hdo)
        {
            Console.WriteLine($"Staženo: {DateTime.Now}");
            Console.WriteLine($"Povel přijímače: {hdo.Command}");
            Console.WriteLine($"Od: {hdo.From}\tDo: {hdo.To}");
            Console.WriteLine();


            foreach (var day in hdo.Days)
            {
                var timeLeftCnt = 20;
                var captionLeftCnt = day.Times.Length * timeLeftCnt - 4;

                Console.Write($"{new string('*', 2)} {day.Caption} {new string('*', captionLeftCnt - day.Caption.Length)}");
                Console.WriteLine();

                foreach (var time in day.Times)
                {
                    var strTime = time.ToString();
                    Console.Write($"{new string(' ', timeLeftCnt - strTime.Length)}{strTime}");
                }
                Console.WriteLine();
            }

            return Task.CompletedTask;
        }
    }
}