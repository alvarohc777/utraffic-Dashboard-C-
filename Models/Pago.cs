using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Solicitudes.Models;

public class Pago
{
  public int Id { get; set; }

  public DateTime Fecha { get; set; }
  public float Valor { get; set; }
  public string? Estado { get; set; }

  [JsonIgnore]
  public Solicitud? Solicitud { get; set; }

}