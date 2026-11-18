using Microsoft.EntityFrameworkCore;
using ControleTreinoApi.Models;

namespace ControleTreinoApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Exercicio> Exercicios { get; set; }
    public DbSet<Treino> Treinos { get; set; }
    public DbSet<TreinoItem> TreinoItems { get; set; }
    public DbSet<Sessao> Sessoes { get; set; }
    public DbSet<RegistroSerieExecutada> RegistrosSerieExecutadas { get; set; }
}