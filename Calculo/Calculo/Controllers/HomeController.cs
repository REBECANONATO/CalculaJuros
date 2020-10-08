using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Calculo.Models;
using Calculo.Executor;

namespace Calculo.Controllers
{
    [ApiController]
    [Route("calculajuros")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Post(JurosCompostos jurosCompostos)
        {
            CalculaJurosExecutor calcula = new CalculaJurosExecutor();
            var valor = calcula.CalcularJuros(jurosCompostos);
            return Ok(valor);
        }
    }
}
