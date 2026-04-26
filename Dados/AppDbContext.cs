using BackendLearningHub.Modelos;
using Microsoft.EntityFrameworkCore;

namespace BackendLearningHub.Dados;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<UnidadeCurso> UnidadesCursos { get; set; }
    public DbSet<Topico> Topicos { get; set; }
    public DbSet<Aula> Aulas { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>()
            .HasMany(u => u.AulasConcluidas)
            .WithMany(a => a.Usuarios)
            .UsingEntity(j => j.ToTable("UsuarioAulas"));

        base.OnModelCreating(modelBuilder);
    }
}
