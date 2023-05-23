using System.ComponentModel.DataAnnotations;

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
