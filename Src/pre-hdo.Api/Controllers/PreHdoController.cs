using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using prehdo.Console;
using prehdo.Console.Entities;
using prehdo.Core.Services;
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

        [HttpGet]
        public string Get()
        {
            return ";)";
        }

        [HttpGet("today")]
        public async Task<JsonResult> GetToday()
        {
            _logger.LogInformation($"Getting HDO today...");
            return await GetTodayByTarig(Tarif.NT, Tarif.VT);
        }

        [HttpGet("today/nt")]
        public async Task<JsonResult> GetTodayNt()
        {
            _logger.LogInformation($"Getting HDO NT today...");
            return await GetTodayByTarig(Tarif.NT);
        }

        [HttpGet("today/vt")]
        public async Task<JsonResult> GetTodayVt()
        {
            _logger.LogInformation($"Getting HDO VT today...");
            return await GetTodayByTarig(Tarif.VT);
        }

        private async Task<JsonResult> GetTodayByTarig(params Tarif[] tarifs)
        {
            var dd = await _downloader.DownloadAsync();
            var result = await _parser.ParseAsync(dd);
            var day = result.Days.First();
            var current = day.Times.FirstOrDefault(Current) ?? day.Times.Last();

            _logger.LogInformation($"Return result for '{result.Command}' for '{day.Caption}'");

            return new JsonResult(new
            {
                Timestamp = DateTime.Now.ToString(),
                Title = $"{result.Command} {day.Caption}",
                Times = day.Times.Where(t => tarifs.Contains(t.Tarif)).Select(FormatTime),
                Current = FormatTime(current),
                Command = result.Command.ToString(),
            });
        }

        private static bool Current(TimeRange tr)
        {
            var now = DateTime.Now;

            var start = new DateTime(now.Year, now.Month, now.Day, tr.Start.Hour, tr.Start.Minute, 0);
            var end = new DateTime(now.Year, now.Month, now.Day, tr.End.Hour, tr.End.Minute, 0);

            return now >= start && now <= end;
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
                Timestamp = DateTime.Now.ToString(),
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
            return $"{tr.Start.Hour}:{tr.Start.Minute} - {tr.End.Hour}:{tr.End.Minute}  {tr.Tarif}";
        }
    }
}
