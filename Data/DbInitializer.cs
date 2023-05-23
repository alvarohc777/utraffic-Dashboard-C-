using Solicitudes.Models;

namespace Solicitudes.Data
{
  public static class DbInitializer
  {
    public static void Initialize(ClienteContext context)
    {
      if (context.Clientes.Any() && context.Solicitudes.Any()) return;



      var solicitud1 = new Solicitud { Monto = 5000000, Plazo = 5, FechaSolicitud = ParseDate("01/01/2023") };
      var solicitud2 = new Solicitud { Monto = 4000000, Plazo = 4, FechaSolicitud = ParseDate("01/01/2023") };
      var solicitud3 = new Solicitud { Monto = 24000000, Plazo = 12, FechaSolicitud = ParseDate("01/09/2022") };
      var solicitud4 = new Solicitud { Monto = 10000000, Plazo = 10, FechaSolicitud = ParseDate("01/11/2022") };
      var solicitud5 = new Solicitud { Monto = 2000000, Plazo = 10, FechaSolicitud = ParseDate("01/01/2022") };


      solicitud1.PlanPago = new List<Pago>
      {
        new Pago { Fecha = ParseDate("01/02/2023"), Valor = 1000000, Estado = "pagado" },
        new Pago { Fecha = ParseDate("01/03/2023"), Valor = 1000000, Estado = "pagado" },
        new Pago { Fecha = ParseDate("01/04/2023"), Valor = 1000000, Estado = "pagado" },
        new Pago { Fecha = ParseDate("01/05/2023"), Valor = 1000000, Estado = "pagado" },
        new Pago { Fecha = ParseDate("01/06/2023"), Valor = 1000000, Estado = null },
      };

      solicitud2.PlanPago = new List<Pago>
      {
        new Pago { Fecha = ParseDate("01/02/2023"), Valor = 1000000, Estado = "pagado" },
        new Pago { Fecha = ParseDate("01/03/2023"), Valor = 1000000, Estado = "pagado" },
        new Pago { Fecha = ParseDate("01/04/2023"), Valor = 1000000, Estado = "pagado" },
        new Pago { Fecha = ParseDate("01/05/2023"), Valor = 1000000, Estado = "pagadoMora" }
      };

      solicitud3.PlanPago = new List<Pago>
      {
        new Pago { Fecha = ParseDate("01/10/2022"), Valor = 2000000, Estado = "pagado" },
        new Pago { Fecha = ParseDate("01/11/2022"), Valor = 2000000, Estado = "pagado" },
        new Pago { Fecha = ParseDate("01/12/2022"), Valor = 2000000, Estado = "pagado" },
        new Pago { Fecha = ParseDate("01/01/2023"), Valor = 2000000, Estado = "pagado" },
        new Pago { Fecha = ParseDate("01/02/2023"), Valor = 2000000, Estado = "pagado" },
        new Pago { Fecha = ParseDate("01/03/2023"), Valor = 2000000, Estado = "pagado" },
        new Pago { Fecha = ParseDate("01/04/2023"), Valor = 2000000, Estado = "pagado" },
        new Pago { Fecha = ParseDate("01/05/2023"), Valor = 2000000, Estado = "mora" },
        new Pago { Fecha = ParseDate("01/06/2023"), Valor = 2000000, Estado = null },
        new Pago { Fecha = ParseDate("01/07/2023"), Valor = 2000000, Estado = null },
        new Pago { Fecha = ParseDate("01/08/2023"), Valor = 2000000, Estado = null },
        new Pago { Fecha = ParseDate("01/09/2023"), Valor = 2000000, Estado = null },
        new Pago { Fecha = ParseDate("01/10/2023"), Valor = 2000000, Estado = null }
      };

      solicitud4.PlanPago = new List<Pago>
      {
        new Pago { Fecha = ParseDate("01/12/2022"), Valor = 1000000, Estado = "pagado" },
        new Pago { Fecha = ParseDate("01/01/2023"), Valor = 1000000, Estado = "pagado" },
        new Pago { Fecha = ParseDate("01/02/2023"), Valor = 1000000, Estado = "pagado" },
        new Pago { Fecha = ParseDate("01/03/2023"), Valor = 1000000, Estado = "pagado" },
        new Pago { Fecha = ParseDate("01/04/2023"), Valor = 1000000, Estado = "pagado" },
        new Pago { Fecha = ParseDate("01/05/2023"), Valor = 1000000, Estado = "pagado" },
        new Pago { Fecha = ParseDate("01/06/2023"), Valor = 1000000, Estado = null },
        new Pago { Fecha = ParseDate("01/07/2023"), Valor = 1000000, Estado = null },
        new Pago { Fecha = ParseDate("01/08/2023"), Valor = 1000000, Estado = null },
        new Pago { Fecha = ParseDate("01/09/2023"), Valor = 1000000, Estado = null }
      };

      solicitud5.PlanPago = new List<Pago>
      {
        new Pago { Fecha = ParseDate("01/02/2022"), Valor = 200000, Estado = "pagado" },
        new Pago { Fecha = ParseDate("01/03/2022"), Valor = 200000, Estado = "pagado" },
        new Pago { Fecha = ParseDate("01/04/2022"), Valor = 200000, Estado = "pagado" },
        new Pago { Fecha = ParseDate("01/05/2022"), Valor = 200000, Estado = "pagado" },
        new Pago { Fecha = ParseDate("01/06/2022"), Valor = 200000, Estado = "pagado" },
        new Pago { Fecha = ParseDate("01/07/2022"), Valor = 200000, Estado = "pagado" },
        new Pago { Fecha = ParseDate("01/08/2022"), Valor = 200000, Estado = "pagado" },
        new Pago { Fecha = ParseDate("01/09/2022"), Valor = 200000, Estado = "pagado" },
        new Pago { Fecha = ParseDate("01/10/2022"), Valor = 200000, Estado = "pagado" },
        new Pago { Fecha = ParseDate("01/11/2022"), Valor = 200000, Estado = "pagado" }
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
            solicitud2,
            solicitud4
          }
        },
        new Cliente
        {
          Nombre = "Luis Jiménez",
          Documento = null,
          Calificacion = 3,
          Solicitudes = new List<Solicitud>
          {
            solicitud1,
            solicitud5
          }
        },
        new Cliente
        {
          Nombre = "Andrés Coronell",
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
    private static DateTime ParseDate(string date)
    {
      return DateTime.SpecifyKind(DateTime.Parse(date), DateTimeKind.Utc);
    }
  }
}