using Microsoft.AspNetCore.Mvc;
using TesteTecnicoCodeNApp.Models;

namespace TesteTecnicoCodeNApp.Controllers;

[ApiController]
[Route("orcamento")]
public class OrcamentoController : ControllerBase
{
    private readonly AppDbContext _context;

    public OrcamentoController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok("API de Orçamentos está online. Use POST para cadastrar.");
    }

    [HttpPost]
    public async Task<ActionResult<OrcamentoResponse>> CadastrarOrcamento([FromBody] OrcamentoRequest request)
    {
        var total = request.Itens.Sum(i => i.Quantidade * i.ValorUnitario);

        var orcamento = new Orcamento
        {
            ClienteId = request.ClienteId!.Value,
            VeiculoId = request.VeiculoId!.Value,
            Total = total,
            Itens = request.Itens.Select(i => new OrcamentoItem
            {
                Descricao = i.Descricao,
                Quantidade = i.Quantidade,
                ValorUnitario = i.ValorUnitario
            }).ToList()
        };

        _context.Orcamentos.Add(orcamento);
        await _context.SaveChangesAsync();

        var response = new OrcamentoResponse
        {
            ClienteId = orcamento.ClienteId,
            VeiculoId = orcamento.VeiculoId,
            Total = orcamento.Total,
            Itens = orcamento.Itens.Select(i => new OrcamentoItemResponse
            {
                Descricao = i.Descricao,
                Quantidade = i.Quantidade,
                ValorUnitario = i.ValorUnitario
            }).ToList()
        };

        return CreatedAtAction(nameof(Get), response);
    }
}
