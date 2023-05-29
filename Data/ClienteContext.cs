using Microsoft.EntityFrameworkCore;
using Solicitudes.Models;

namespace Solicitudes.Data;

public class ClienteContext : DbContext
{
  public ClienteContext(DbContextOptions<ClienteContext> options)
  : base(options)
  {
  }


  public DbSet<Cliente> Clientes => Set<Cliente>();
  public DbSet<Solicitud> Solicitudes => Set<Solicitud>();
  public DbSet<Pago> Pagos => Set<Pago>();


  // protected override void OnModelCreating(ModelBuilder modelBuilder)
  // {
  //   modelBuilder.Entity<Cliente>()
  //   .HasMany(c => c.Solicitudes)
  //   .WithOne(s => s.Cliente)
  //   .OnDelete(DeleteBehavior.SetNull);


  //   modelBuilder.Entity<Solicitud>()
  //   .HasMany(s => s.PlanPago)
  //   .WithOne(p => p.Solicitud)
  //   // .HasForeignKey(p => p.SolicitudId)
  //   .OnDelete(DeleteBehavior.SetNull);

  //   base.OnModelCreating(modelBuilder);
  // }

}