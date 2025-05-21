using IottuModel;
using Microsoft.EntityFrameworkCore;

namespace IottuData;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<MotoModel> Moto { get; set; }
    public DbSet<AntenaModel> Antena { get; set; }
    public DbSet<TagModel> Tag { get; set; }
    public DbSet<UsuarioModel> Usuario { get; set; }
    public DbSet<PatioModel> Patio { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MotoModel>()
            .HasOne(m => m.Tag)
            .WithOne(t => t.Moto)
            .HasForeignKey<MotoModel>(m => m.TagId);

        modelBuilder.Entity<TagModel>()
            .HasOne(t => t.Antena)
            .WithMany(a => a.Tags)
            .HasForeignKey(t => t.AntenaId);

        modelBuilder.Entity<MotoModel>()
            .HasOne(m => m.Patio)
            .WithMany(p => p.Motos)
            .HasForeignKey(m => m.PatioId);

        modelBuilder.Entity<AntenaModel>()
            .HasOne(a => a.Patio)
            .WithMany(p => p.Antenas)
            .HasForeignKey(a => a.PatioId);

        modelBuilder.Entity<PatioModel>()
            .HasOne(p => p.Responsavel)
            .WithMany(u => u.PatiosResponsaveis)
            .HasForeignKey(p => p.ResponsavelId)
            .IsRequired(false);

        base.OnModelCreating(modelBuilder);
    }
}
