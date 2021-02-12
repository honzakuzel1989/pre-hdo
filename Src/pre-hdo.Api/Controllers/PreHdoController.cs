using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pre_hdo.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PreHdoController : ControllerBase
    {
        private readonly ILogger<PreHdoController> _logger;

        public PreHdoController(ILogger<PreHdoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public object Get()
        {
            return new { a = 1, b = 2 };
        }
    }
}
