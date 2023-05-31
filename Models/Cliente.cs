using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

//namespace Solicitudes.Models;
namespace Solicitudes.Models;

public class Cliente
{
  public int Id { get; set; }

  [Required]
  [MaxLength(100)]
  public string? Nombre { get; set; }
  public string? Documento { get; set; }
  public int Calificacion { get; set; }

  // Collection navigation property
  public ICollection<Solicitud>? Solicitudes { get; set; }
  // public List<ClienteCredito> ClienteCreditos { get; set; }


}

public class ClienteDto
{
  public int Id { get; set; }

  [Required]
  [MaxLength(100)]
  public string? Nombre { get; set; }
  public string? Documento { get; set; }
  public int Calificacion { get; set; }


  public ClienteDto(Cliente cliente)
  {
    Id = cliente.Id;
    Nombre = cliente.Nombre;
    Documento = cliente.Documento;
    Calificacion = cliente.Calificacion;
  }

  // Collection navigation property
  // [JsonIgnore]
  // public ICollection<Solicitud>? Solicitudes { get; set; }
  // public List<ClienteCredito> ClienteCreditos { get; set; }


}
