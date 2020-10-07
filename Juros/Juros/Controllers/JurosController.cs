using System;
using Juros.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Juros.Controllers
{
    [ApiController]
    [Route("taxaJuros")]
    public class JurosController : ControllerBase
    {
        private readonly ILogger<JurosController> _logger;

        public JurosController(ILogger<JurosController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            { 
                return Ok(Constantes.VALOR_JUROS_ATUAL);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
