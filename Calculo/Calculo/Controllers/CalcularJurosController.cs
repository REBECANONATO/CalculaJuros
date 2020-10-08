using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Calculo.Models;
using Calculo.Executor;
using Microsoft.AspNetCore.Cors;

namespace Calculo.Controllers
{
    [ApiController]
    [Route("calculajuros")]
    public class CalcularJurosController : Controller
    {
        private readonly ILogger<CalcularJurosController> _logger;

        public CalcularJurosController(ILogger<CalcularJurosController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [EnableCors("PolicyNames.AllowOrigins")]
        public IActionResult Post(JurosCompostos jurosCompostos)
        {
            CalculaJurosExecutor calcula = new CalculaJurosExecutor();
            var valor = calcula.CalcularJuros(jurosCompostos);
            return Ok(valor);
        }
    }
}
