using BlazorApp1.Shared.Modelo.OT;
using BlazorApp1.Shared.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp1.Server.Controllers.OT
{
    public interface IOrdenTrabajoRepo
    {
        Task<OrdenTrabajo> CreateOrden(int Movil, IUsuario usuario);
        Task<bool> CloseOrden(OrdenTrabajo ordenTrabajo, IUsuario usuario);
        Task<List<OrdenTrabajo>> GetOrdenes(int Movil, string Estado, DateTime FechaDesde, DateTime FechaHasta, IUsuario usuario);
    }
}
