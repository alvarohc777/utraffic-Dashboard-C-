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

  public List<object> GetAll()
  {
    return _context.Solicitudes
    // .Include(p => p.Cliente)
    // .Include(p => p.PlanPago)
    .Select(p =>
    new 
    {
      Id = p.Id,
      Monto = p.Monto,
      Cliente = new ClienteDto(p.Cliente),
      PlanPago = p.PlanPago
    })
    .ToList<object>();
  }
  // public IEnumerable<SolicitudDto> GetAll()
  // {
  //   return _context.Solicitudes
  //   // .Include(p => p.Cliente)
  //   // .Include(p => p.PlanPago)
  //   .Select(p =>
  //   new SolicitudDto()
  //   {
  //     Id = p.Id,
  //     Monto = p.Monto,
  //     Cliente = new ClienteDto(p.Cliente),
  //     PlanPago = p.PlanPago
  //   })
  //   .AsNoTracking()
  //   .ToList();
  // }

  public SolicitudDto? GetById(int id)
  {
    return _context.Solicitudes
    .Include(p => p.Cliente)
    .Include(p => p.PlanPago)
    .Select(p =>
    new SolicitudDto()
    {

      Id = p.Id,
      Monto = p.Monto,
      Cliente = new ClienteDto(p.Cliente),
      PlanPago = p.PlanPago
    })
    .AsNoTracking()
    .SingleOrDefault(p => p.Id == id);
  }

  public void CreatePago(int solicitudId, Pago pagoToCreate)
  {
    Solicitud solicitudToUpdate = _context.Solicitudes
    .Include(p => p.PlanPago)
    .SingleOrDefault(p => p.Id == solicitudId)!;

    if (solicitudToUpdate is null)
    {
      throw new InvalidOperationException("Solicitud does not exist.");
    }

    solicitudToUpdate.PlanPago.Add(pagoToCreate);
    _context.SaveChanges();

  }
}