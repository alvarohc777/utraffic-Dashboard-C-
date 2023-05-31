using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Solicitudes.Models;

public class Solicitud
{
  public int Id { get; set; }

  [Required]
  public int Monto { get; set; }
  public int Plazo { get; set; }
  [Required]
  [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
  public DateTime FechaSolicitud { get; set; }

  public string? Estado { get; set; }


  // reference navigation property

  [JsonIgnore]
  public Cliente Cliente { get; set; } = null!;

  public ICollection<Pago>? PlanPago { get; set; }



  // public ICollection<Cliente>? Clientes { get; set; }
  // public ICollection<ClienteCredito> ClienteCreditos { get; set; }
}




public class SolicitudDto
{
  public int Id { get; set; }
  [Required]
  public int Monto { get; set; }

  public int Plazo { get; set; }

  [Required]
  [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
  public DateTime FechaSolicitud { get; set; }

  public string? Estado { get; set; }

  // [JsonIgnore]
  public ClienteDto Cliente { get; set; } = null!;
  public ICollection<Pago>? PlanPago { get; set; }
}
