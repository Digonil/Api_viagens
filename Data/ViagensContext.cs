using GerenciamentoViagens.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoViagens.Data;

public class ViagensContext : DbContext
{
    public ViagensContext(DbContextOptions<ViagensContext> opts)
        : base(opts)
    {
        
    }
    public DbSet<Depoimento> depoimentos { get; set; }
    public DbSet<Destino> destinos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer("Server=localhost,1433;Database=viagensapirest;User ID=sa;Password=#Root2023#;TrustServerCertificate=True");
}
