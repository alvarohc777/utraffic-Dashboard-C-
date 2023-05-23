using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Solicitudes.Models;

public class Solicitud
{
  public int Id { get; set; }

  [Required]
  [MaxLength(100)]
  public int Monto { get; set; }
  public int Plazo { get; set; }
  [Required]
  [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
  public DateTime FechaSolicitud { get; set; }


  // public int ClienteId { get; set; }

  // reference navigation property

  [JsonIgnore]
  public Cliente? Cliente { get; set; }

  public ICollection<Pago>? PlanPago { get; set; }



  // public ICollection<Cliente>? Clientes { get; set; }
  // public ICollection<ClienteCredito> ClienteCreditos { get; set; }
}