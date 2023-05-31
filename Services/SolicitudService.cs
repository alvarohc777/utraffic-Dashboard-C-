using Microsoft.EntityFrameworkCore;
using Solicitudes.Models;
using Solicitudes.Data;

namespace Solicitudes.Services;


public class SolicitudService
{
  private readonly ClienteContext _context;

  public SolicitudService(ClienteContext context)
  {
    _context = context;
  }

  public IEnumerable<SolicitudDto> GetAll()
  {
    return _context.Solicitudes
    .Include(p => p.Cliente)
    .Include(p => p.PlanPago)
    .Select(p =>
    new SolicitudDto()
    {
      Id = p.Id,
      Monto = p.Monto,
      Cliente = new ClienteDto(p.Cliente)
    })
    .AsNoTracking()
    .ToList();
    // return _context.Solicitudes
    // .Include(p => p.Cliente)
    // // .Include(p => p.PlanPago)
    // .AsNoTracking()
    // .ToList();
  }

  public Solicitud? GetById(int id)
  {
    return _context.Solicitudes
    .Include(p => p.Cliente)
    // .Include(p => p.PlanPago)
    .AsNoTracking()
    .SingleOrDefault(p => p.Id == id);
  }
}