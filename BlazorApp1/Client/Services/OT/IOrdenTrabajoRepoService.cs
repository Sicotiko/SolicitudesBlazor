using BlazorApp1.Shared.Modelo.Moviles;
using BlazorApp1.Shared.Modelo.OT;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp1.Client.Services.OT
{
    public interface IOrdenTrabajoRepoService
    {
        List<OrdenTrabajo> Ordenes { get; set; }

        Task UpdateOrdenes(int Movil, string Estado, DateTime Desde, DateTime Hasta);
        Task<OrdenTrabajo> CreateOrden(Movil movil);
        Task<bool> CloseOrden(OrdenTrabajo ordenTrabajo);
    }
}
