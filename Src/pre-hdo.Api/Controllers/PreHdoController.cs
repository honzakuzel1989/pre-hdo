using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using prehdo.Console;
using prehdo.Console.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace pre_hdo.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PreHdoController : ControllerBase
    {
        private readonly ILogger<PreHdoController> _logger;
        private readonly IDownloader _downloader;
        private readonly IParser _parser;

        public PreHdoController(
            ILogger<PreHdoController> logger,
            IDownloader downloader,
            IParser parser)
        {
            _logger = logger;
            _downloader = downloader;
            _parser = parser;
        }

        [HttpGet("today")]
        public async Task<JsonResult> GetToday()
        {
            _logger.LogInformation($"Getting HDO today...");

            var dd = await _downloader.DownloadAsync();
            var result = await _parser.ParseAsync(dd);
            var day = result.Days.First();

            _logger.LogInformation($"Return result for '{result.Command}' for '{day.Caption}'");

            return new JsonResult(new
            {
                Title = $"{result.Command} {day.Caption}",
                Times = day.Times.Select(FormatTime),
                IsNt = day.Times.Any(IsNt)
            });
        }

        private static bool IsNt(TimeRange tr)
        {
            var now = DateTime.Now;

            var start = new DateTime(now.Year, now.Month, now.Day, tr.Start.Hour, tr.Start.Minute, 0);
            var end = new DateTime(now.Year, now.Month, now.Day, tr.End.Hour, tr.End.Minute, 0);

            return tr.Tarif == Tarif.NT && now >= start && now <= end;
        }

        [HttpGet("timetable")]
        public async Task<JsonResult> GetHdoTimetable()
        {
            _logger.LogInformation($"Getting HDO timetable...");

            var dd = await _downloader.DownloadAsync();
            var result = await _parser.ParseAsync(dd);

            _logger.LogInformation($"Return result for '{result.Command.Number}' from '{result.From}' to '{result.To}'");

            return new JsonResult(new
            {
                Title = $"{result.Command.Number}, {result.From.Day}.{result.From.Month} - {result.To.Day}.{result.To.Month}",
                Days = result.Days.Select(day => new
                {
                    Caption = day.Caption,
                    Times = day.Times.Select(FormatTime)
                })
            });
        }

        private static string FormatTime(TimeRange tr)
        {
            return $"{tr.Start.Hour}:{tr.Start.Minute} - {tr.End.Hour}:{tr.End.Minute}\t{tr.Tarif}";
        }
    }
}
