using Domain;
using Microsoft.AspNetCore.Mvc;
using Service;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GestaoEstoquesln.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelatorioController : ControllerBase
    {
        private readonly RelatorioService _relatorioService;

        public RelatorioController(RelatorioService relatorioService)
        {
            _relatorioService = relatorioService;
        }

        [HttpGet("valor-total")]
        public async Task<IActionResult> ValorTotalEstoque()
        {
            var valorTotal = await _relatorioService.CalcularValorTotalAsync();
            return Ok(new { valorTotal });
        }

        [HttpGet("vencendo-em-7-dias")]
        public async Task<IEnumerable<Produto>> VencendoEm7Dias()
        {
            return await _relatorioService.VencendoEm7DiasAsync();
        }

        [HttpGet("abaixo-do-minimo")]
        public async Task<IEnumerable<Produto>> AbaixoDoMinimo()
        {
            return await _relatorioService.AbaixoDoMinimoAsync();
        }
    }
}
