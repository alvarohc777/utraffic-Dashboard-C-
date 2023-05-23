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
}















// public ClienteController()
// {
// }
// [HttpGet]
// public ActionResult<List<Cliente>> GetAll() => ClienteService.GetAll();

// [HttpGet("{id}")]
// public ActionResult<Cliente> Get(int id)
// {
//   var cliente = ClienteService.Get(id);
//   if (cliente == null) return NotFound();
//   return cliente;
// }
// [HttpPost]
// public IActionResult Create(Cliente cliente)
// {
//   ClienteService.Add(cliente);
//   return CreatedAtAction(nameof(Get), new { id = cliente.Id }, cliente);
// }
// [HttpPut("{id}")]
// public IActionResult Update(int id, Cliente cliente)
// {
//   if (id != cliente.Id) return BadRequest();

//   var existingCliente = ClienteService.Get(id);
//   if (existingCliente is null) return NotFound();
//   ClienteService.Update(cliente);
//   return NoContent();
// }
// [HttpDelete("{id}")]
// public IActionResult Delete(int id)
// {
//   var cliente = ClienteService.Get(id);
//   if (cliente is null) return NotFound();

//   ClienteService.Delete(id);
//   return NoContent();
// }
