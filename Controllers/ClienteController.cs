using Solicitudes.Models;
using Solicitudes.Services;
using Microsoft.AspNetCore.Mvc;
namespace Solicitudes.Controllers;

[ApiController]
[Route("[controller]")]
public class ClienteController : ControllerBase
{
  ClienteService _service;

  public ClienteController(ClienteService service)
  {
    _service = service;
  }

  [HttpGet]
  public IEnumerable<Cliente> GetAll()
  {
    return _service.GetAll();
  }

  [HttpGet("{id}")]
  public ActionResult<Cliente> GetById(int id)
  {
    var cliente = _service.GetById(id);
    if (cliente is not null) return cliente;
    else return NotFound();
  }

  [HttpPost]
  public IActionResult Create(Cliente newCliente)
  {
    var cliente = _service.Create(newCliente);
    return CreatedAtAction(nameof(GetById), new { id = cliente!.Id }, cliente);
  }

  [HttpDelete("{id}")]
  public IActionResult Delete(int id)
  {
    var cliente = _service.GetById(id);

    if (cliente is not null)
    {
      _service.DeleteById(id);
      return Ok();
    }
    else
    {
      return NotFound();
    }
  }

  [HttpPut("{id}")]
  public IActionResult Update(int id, Cliente cliente)
  {


    // var clienteIdExists = cliente.GetType().GetProperty("Id");
    if (cliente.Id != id)
    {
      // return BadRequest("Id mismatch between URL and body");
      return Conflict("Id mismatch between URL and body");
    }
    var clienteToUpdate = _service.GetById(id);
    if (clienteToUpdate is not null)
    {
      _service.UpdateCliente(id, cliente);
      return Ok(cliente);
    }
    else
    {
      return NotFound();
    }
  }

  [HttpPut("{id}/createSolicitud")]
  public IActionResult CreateSolicitud(int id, Solicitud solicitudToCreate)
  {
    var clienteToUpdate = _service.GetById(id);

    if (clienteToUpdate is not null)
    {
      _service.CreateSolicitud(id, solicitudToCreate);
      return NoContent();
    }
    else
    {
      return NotFound();
    }
  }


}







