using Solicitudes.Models;

namespace Solicitudes.Data
{
  public static class DbInitializer
  {
    public static void Initialize(ClienteContext context)
    {
      if (context.Clientes.Any() && context.Solicitudes.Any()) return;

      var pago1 = new Pago { Fecha = DateTime.Parse("01/02/2023"), Valor = 1000000, Estado = "pagado" };
      var pago2 = new Pago { Fecha = DateTime.Parse("01/03/2023"), Valor = 1000000, Estado = "pagado" };
      var pago3 = new Pago { Fecha = DateTime.Parse("01/04/2023"), Valor = 1000000, Estado = "pagado" };
      var pago4 = new Pago { Fecha = DateTime.Parse("01/05/2023"), Valor = 1000000, Estado = "pagado" };
      var pago5 = new Pago { Fecha = DateTime.Parse("01/06/2023"), Valor = 1000000, Estado = null };

      var solicitud1 = new Solicitud { Monto = 5000000, Plazo = 5, FechaSolicitud = DateTime.Parse("01/01/2023") };
      var solicitud3 = new Solicitud { Monto = 1000000, Plazo = 2, FechaSolicitud = DateTime.Parse("01/02/2023") };
      var solicitud2 = new Solicitud { Monto = 10000000, Plazo = 10, FechaSolicitud = DateTime.Parse("01/02/2023") };
      var solicitud4 = new Solicitud { Monto = 20000000, Plazo = 10, FechaSolicitud = DateTime.Parse("01/05/2023") };

      solicitud1.PlanPago = new List<Pago>
      {
        pago1,
        pago2,
        pago3,
        pago4,
        pago5
      };

      var clientes = new Cliente[]
      {
        new Cliente
        {
          Nombre = "Alvaro Herrada",
          Documento = null,
          Calificacion = 5,
          Solicitudes = new List<Solicitud>
          {
            solicitud1,
            solicitud4
          }
        },
        new Cliente
        {
          Nombre = "Andres Coronell",
          Documento = null,
          Calificacion = 5,
          Solicitudes = new List<Solicitud>
          {
            solicitud2,

          }
        },
        new Cliente
        {
          Nombre = "Luis Jimenez",
          Documento = null,
          Calificacion = 3,
          Solicitudes = new List<Solicitud>
          {
            solicitud3,

          }
        },
      };
      context.Clientes.AddRange(clientes);
      context.SaveChanges();


    }
  }
}