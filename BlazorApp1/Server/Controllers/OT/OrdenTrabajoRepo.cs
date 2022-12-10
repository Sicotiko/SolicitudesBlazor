using BlazorApp1.Shared.Modelo.OT;
using BlazorApp1.Shared.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp1.Server.Controllers.OT
{
    public class OrdenTrabajoRepo : IOrdenTrabajoRepo
    {
        public async Task<bool> CloseOrden(OrdenTrabajo ordenTrabajo, IUsuario usuario)
        {
            return await Management.OT.Finalizacion.CerrarOrden(ordenTrabajo,usuario);
        }

        public async Task<OrdenTrabajo> CreateOrden(int Movil, IUsuario usuario)
        {
            return await Management.OT.Creacion.CreateOrdenTrabajo(Movil,usuario);
        }

        public async Task<List<OrdenTrabajo>> GetOrdenes(int Movil, string Estado, DateTime FechaDesde, DateTime FechaHasta, IUsuario usuario)
        {
            return await Management.OT.Obtencion.GetOrdenesAsync(Movil, Estado, FechaDesde, FechaHasta, usuario);
        }
    }
}
