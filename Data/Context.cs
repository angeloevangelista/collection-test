using CollectionTest.Entities;
using Microsoft.EntityFrameworkCore;

namespace CollectionTest.Data
{
  public class Context : DbContext
  {
    public Context() : base()
    {
    }

    public DbSet<Apelido> Apelidos { get; set; }
    public DbSet<Humano> Humanos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlite("Data Source=db.sqlite");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Apelido>().HasKey(pre => pre.Id);
      modelBuilder.Entity<Humano>().HasKey(pre => pre.Id);

      modelBuilder.Entity<Humano>()
        .HasMany<Apelido>(pre => pre.Apelidos)
        .WithOne(pre => pre.Humano)
        .HasForeignKey(pre => pre.HumanoId)
        .OnDelete(DeleteBehavior.Cascade);
    }
  }
}