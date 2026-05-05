using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TesteTecnicoCodeNApp.Models;

[Table("teste_mysql")]
public class Orcamento
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public int VeiculoId { get; set; }
    public decimal Total { get; set; }
    public DateTime DataCriacao { get; set; } = DateTime.Now;
    public List<OrcamentoItem> Itens { get; set; } = new();
}

public class OrcamentoItem
{
    public int Id { get; set; }
    public int OrcamentoId { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public int Quantidade { get; set; }
    public decimal ValorUnitario { get; set; }
}

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Orcamento> Orcamentos { get; set; }
    public DbSet<OrcamentoItem> OrcamentoItens { get; set; }
}
