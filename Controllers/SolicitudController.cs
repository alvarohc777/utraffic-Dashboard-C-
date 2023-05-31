using Solicitudes.Models;
using Solicitudes.Services;
using Microsoft.AspNetCore.Mvc;

namespace Solicitudes.Controllers;

[ApiController]
[Route("[controller]")]
public class SolicitudController : ControllerBase
{
  SolicitudService _service;

  public SolicitudController(SolicitudService service)
  {
    _service = service;
  }

  [HttpGet]
  public IEnumerable<SolicitudDto> GetAll()
  {
    return _service.GetAll();
  }

  [HttpGet("{id}")]
  public ActionResult<Solicitud> GetById(int id)
  {
    Solicitud solicitud = _service.GetById(id);
    if (solicitud is not null) return solicitud;
    else return NotFound();

  }
}
