using System.ComponentModel.DataAnnotations;

namespace TesteTecnicoCodeNApp.Models;

public class OrcamentoRequest
{
    [Required(ErrorMessage = "O clienteId é obrigatório.")]
    public int? ClienteId { get; set; }

    [Required(ErrorMessage = "O veiculoId é obrigatório.")]
    public int? VeiculoId { get; set; }

    [Required(ErrorMessage = "A lista de itens é obrigatória.")]
    [MinLength(1, ErrorMessage = "Deve existir pelo menos 1 item no orçamento.")]
    public List<OrcamentoItemRequest> Itens { get; set; } = new();
}

public class OrcamentoItemRequest
{
    [Required(ErrorMessage = "A descrição do item é obrigatória.")]
    public string Descricao { get; set; } = string.Empty;

    [Range(0.01, double.MaxValue, ErrorMessage = "A quantidade deve ser maior que zero.")]
    public int Quantidade { get; set; }

    [Range(0.01, double.MaxValue, ErrorMessage = "O valor unitário deve ser maior que zero.")]
    public decimal ValorUnitario { get; set; }
}
