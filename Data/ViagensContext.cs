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
}
