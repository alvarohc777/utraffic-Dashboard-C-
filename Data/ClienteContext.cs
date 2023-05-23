using Microsoft.EntityFrameworkCore;
using Solicitudes.Models;

namespace Solicitudes.Data;

public class ClienteContext : DbContext
{
  public ClienteContext(DbContextOptions<ClienteContext> options)
  : base(options)
  {
  }


  public DbSet<Cliente> Clientes { get; set; }
  public DbSet<Solicitud> Solicitudes { get; set; }
  public DbSet<Pago> Pagos { get; set; }


  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Cliente>()
    .HasMany(c => c.Solicitudes)
    .WithOne(s => s.Cliente)
    .OnDelete(DeleteBehavior.SetNull);

    base.OnModelCreating(modelBuilder);
  }

}