using Solicitudes.Models;
using Solicitudes.Services;
using Microsoft.AspNetCore.Mvc;

namespace Solicitudes.Controllers;

[ApiController]
[Route("[controller]")]
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