using Microsoft.EntityFrameworkCore;
using Solicitudes.Models;
using Solicitudes.Data;

namespace Solicitudes.Services;

public class ClienteService
{
  private readonly ClienteContext _context;
  public ClienteService(ClienteContext context)
  {
    _context = context;
  }

  private int GenerateNewId()
  {
    int maxId = _context.Clientes.Max(c => c.Id);
    return maxId + 1;
  }

  public IEnumerable<Cliente> GetAll()
  {
    return _context.Clientes
    .Include(p => p.Solicitudes)
    .ThenInclude(s => s.PlanPago)
    .AsNoTracking()
    .ToList();
  }

  public Cliente? GetById(int id)
  {
    return _context.Clientes
    .Include(p => p.Solicitudes)
    .ThenInclude(s => s.PlanPago)
    .AsNoTracking()
    .SingleOrDefault(p => p.Id == id);
  }


  public Cliente Create(Cliente newCliente)
  {
    newCliente.Id = GenerateNewId(); // Ignore newCliente.Id
    _context.Clientes.Add(newCliente);
    _context.SaveChanges();

    return newCliente;
  }

  public void UpdateCliente(int id, Cliente cliente)
  {
    var clienteToUpdate = _context.Clientes.Find(id);
    if (clienteToUpdate is null) throw new InvalidOperationException("Cliente no existe");
    _context.Entry(clienteToUpdate).CurrentValues.SetValues(cliente);
    _context.SaveChanges();
  }


  public void DeleteById(int id)
  {
    var clienteToDelete = _context.Clientes.Find(id);
    if (clienteToDelete is not null)
    {
      _context.Clientes.Remove(clienteToDelete);
      _context.SaveChanges();
    }
  }

  public void CreateSolicitud(int clienteId, Solicitud solicitudToCreate)
  {
    // var clienteToUpdate = _context.Clientes.Find(clienteId);
    Cliente clienteToUpdate = _context.Clientes
    .Include(p => p.Solicitudes)
    .SingleOrDefault(p => p.Id == clienteId)!;

    if (clienteToUpdate is null)
    {
      throw new InvalidOperationException("Cliente does not exist");
    }

    Console.WriteLine("clienteToUpdate: " + clienteToUpdate); // Debugging statement
    Console.WriteLine("solicitudToCreate: " + solicitudToCreate); // Debugging statement

    // if (clienteToUpdate.Solicitudes is null)
    // {
    //   clienteToUpdate.Solicitudes = new List<Solicitud>(); // Initialize the collection
    // }

    clienteToUpdate.Solicitudes.Add(solicitudToCreate);
    Console.WriteLine("clienteToUpdate after adding solicitud: " + clienteToUpdate); // Debugging statement

    _context.SaveChanges();
  }









  private static DateTime ParseDate(string date)
  {
    return DateTime.SpecifyKind(DateTime.Parse(date), DateTimeKind.Utc);
  }
}