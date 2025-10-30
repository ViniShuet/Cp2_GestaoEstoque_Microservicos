using Domain;
using Microsoft.AspNetCore.Mvc;
using Service;
using System.Threading.Tasks;
using Newtonsoft.Json;

[ApiController]
[Route("api/movimentacoes")]
public class MovimentacaoController : ControllerBase
{
    private readonly MovimentacaoService _movimentacaoService;

    public MovimentacaoController(MovimentacaoService movimentacaoService)
    {
        _movimentacaoService = movimentacaoService;
    }

    [HttpPost("entrada")]
    public async Task<IActionResult> Entrada([FromBody] MovEstoque mov)
    {
        try
        {
            await _movimentacaoService.RealizarEntradaAsync(mov);
            return Ok(new { mensagem = "Entrada registrada com sucesso." });
        }
        catch (System.Exception ex)
        {
            return BadRequest(new { erro = ex.Message });
        }
    }

    [HttpPost("saida")]
    public async Task<IActionResult> Saida([FromBody] MovEstoque mov)
    {
        try
        {
            await _movimentacaoService.RealizarSaidaAsync(mov);
            return Ok(new { mensagem = "Saída registrada com sucesso." });
        }
        catch (System.Exception ex)
        {
            return BadRequest(new { erro = ex.Message });
        }
    }
}
