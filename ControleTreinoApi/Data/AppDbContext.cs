using Microsoft.EntityFrameworkCore;
using ControleTreinoApi.Models;

namespace ControleTreinoApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder mb)
    {
        // E-mail único 
        mb.Entity<Usuario>().HasIndex(u => u.Email).IsUnique();
        mb.Entity<Usuario>().Property(u => u.Email).HasMaxLength(200);
        mb.Entity<Usuario>().Property(u => u.Nome).HasMaxLength(100);

        // Excluir treino NÃO apaga as sessões: elas ficam com TreinoId = null
        mb.Entity<Sessao>()
            .HasOne(s => s.Treino)
            .WithMany()
            .HasForeignKey(s => s.TreinoId)
            .OnDelete(DeleteBehavior.SetNull);

        // Excluir sessão apaga os registros dela
        mb.Entity<RegistroSerieExecutada>()
            .HasOne(r => r.Sessao)
            .WithMany()
            .HasForeignKey(r => r.SessaoId)
            .OnDelete(DeleteBehavior.Cascade);

        // Exercício com histórico não pode ser excluído
        mb.Entity<RegistroSerieExecutada>()
            .HasOne(r => r.Exercicio)
            .WithMany()
            .HasForeignKey(r => r.ExercicioId)
            .OnDelete(DeleteBehavior.Restrict);
    }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Exercicio> Exercicios { get; set; }
    public DbSet<Treino> Treinos { get; set; }
    public DbSet<TreinoItem> TreinoItems { get; set; }
    public DbSet<Sessao> Sessoes { get; set; }
    public DbSet<RegistroSerieExecutada> RegistrosSerieExecutadas { get; set; }
}