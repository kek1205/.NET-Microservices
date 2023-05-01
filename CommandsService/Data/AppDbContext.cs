using Microsoft.EntityFrameworkCore;
using CommandsService.Models;

namespace CommandsService.Data
{
  public class AppDbContext : DbContext
  {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<Platform> Platforms { get; set; }
    public DbSet<Command> Commands { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder
      .Entity<Platform>()
      .HasMany(P => P.Commands)
      .WithOne(p => p.Platform!)
      .HasForeignKey(p => p.PlatformId);

      modelBuilder
      .Entity<Command>()
      .HasOne(P => P.Platform)
      .WithMany(p => p.Commands)
      .HasForeignKey(p => p.PlatformId);
    }
  }
}