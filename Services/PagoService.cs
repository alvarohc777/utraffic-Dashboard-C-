using Microsoft.EntityFrameworkCore;
using Solicitudes.Models;
using Solicitudes.Data;

namespace Solicitudes.Services;

public class PagoService
{
  private readonly ClienteContext _context;
  public PagoService(ClienteContext context)
  {
    _context = context;
  }

  public IEnumerable<Pago> GetAll()
  {
    return _context.Pagos
    .AsNoTracking()
    .ToList();
  }
}