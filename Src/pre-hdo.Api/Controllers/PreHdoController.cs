using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using prehdo.Console;
using System;
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

        [HttpGet()]
        public async Task<JsonResult> GetHdoTimetable()
        {
            _logger.LogInformation($"Getting HDO timetable...");

            var dd = await _downloader.DownloadAsync();
            var result = await _parser.ParseAsync(dd);

            _logger.LogInformation($"Return result for {result.Command} from {result.From} to {result.To}");

            return new JsonResult(result);
        }
    }
}
