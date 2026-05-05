namespace TesteTecnicoCodeNApp.Models;

public class OrcamentoResponse
{
    public int ClienteId { get; set; }
    public int VeiculoId { get; set; }
    public List<OrcamentoItemResponse> Itens { get; set; } = new();
    public decimal Total { get; set; }
}

public class OrcamentoItemResponse
{
    public string Descricao { get; set; } = string.Empty;
    public int Quantidade { get; set; }
    public decimal ValorUnitario { get; set; }
    public decimal Subtotal => Quantidade * ValorUnitario;
}
