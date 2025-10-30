using Domain;
using Microsoft.AspNetCore.Mvc;
using Service;
using System.Threading.Tasks;
using Newtonsoft.Json;

[ApiController]
[Route("api/produtos")]
public class ProdutoController : ControllerBase
{
    private readonly ProdutoService _produtoService;

    public ProdutoController(ProdutoService produtoService)
    {
        _produtoService = produtoService;
    }

    [HttpPost("cadastrar")]
    public async Task<IActionResult> CadastrarProduto([FromBody] Produto produto)
    {
        try
        {
            var id = await _produtoService.CadastrarProdutoAsync(produto);
            return CreatedAtAction(nameof(ObterProdutoPorId), new { id }, produto);
        }
        catch (System.Exception ex)
        {
            return BadRequest(new { erro = ex.Message });
        }
    }

    [HttpGet("abaixo-minimo")]
    public async Task<IActionResult> ProdutosAbaixoDoMinimo()
    {
        var produtos = await _produtoService.ListarProdutosAbaixoDoMinimoAsync();
        return Ok(produtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObterProdutoPorId(int id)
    {
        var produto = await _produtoService.ObterPorIdAsync(id);
        if (produto == null) return NotFound();
        return Ok(produto);
    }
}
