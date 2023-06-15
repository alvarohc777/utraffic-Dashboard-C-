using Solicitudes.Models;
using Solicitudes.Services;
using Microsoft.AspNetCore.Mvc;
using Solicitudes.Filters;

namespace Solicitudes.Controllers;

[ApiController]
[Route("[controller]")]
[ServiceFilter(typeof(LogActionFilterAsync))]
public class PagoController : ControllerBase
{
  PagoService _service;

  public PagoController(PagoService service)
  {
    _service = service;
  }

  [HttpGet]
  public IEnumerable<Pago> GetAll()
  {
    return _service.GetAll();
  }
}