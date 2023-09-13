using BlazorApp1.Shared.Modelo.OT;
using System.Collections.Generic;
using System.Linq;

namespace BlazorApp1.Server.Services
{
    public class ListadoOrdenes
    {
        public static List<OrdenTrabajo> Ordenes { get; set; } = new List<OrdenTrabajo>();

        public void AddOrden(OrdenTrabajo orden) => Ordenes.Add(orden);
        public void DeleteOrden(OrdenTrabajo orden) => Ordenes.Remove(orden);
        public List<OrdenTrabajo> GetOrdenes() => Ordenes;
        public OrdenTrabajo? GetOrden(System.Func<OrdenTrabajo, bool> predicate) => Ordenes.FirstOrDefault(predicate);

    }
}
