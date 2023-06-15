using Solicitudes.Models;
using Solicitudes.Services;
using Microsoft.AspNetCore.Mvc;
using Solicitudes.Filters;

namespace Solicitudes.Controllers;

[ApiController]
[Route("[controller]")]
[ServiceFilter(typeof(LogActionFilterAsync))]
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
  public ActionResult<SolicitudDto> GetById(int id)
  {
    SolicitudDto solicitud = _service.GetById(id);
    if (solicitud is not null) return solicitud;
    else return NotFound();

  }

  [HttpPut("{id}/pagarCuota")]
  public IActionResult PagarCuota(int id, Pago pagoToCreate)
  {
    var solicitudToUpdate = _service.GetById(id);

    if (solicitudToUpdate is not null)
    {
      _service.CreatePago(id, pagoToCreate);
      return NoContent();
    }
    else
    {
      return NotFound();
    }
  }
}
