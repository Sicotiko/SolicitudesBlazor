using BlazorApp1.Shared.User;
using BlazorApp1.Shared.Modelo.Retiros;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp1.Server.Controllers.Retiros
{
    public class RetirosRepo : IRetirosRepo
    {
        public async Task AsignarRetiroAsync(Retiro retiro, IUsuario usuario)
        {
            await Management.Retiros.Asignacion.Asignar(retiro, usuario);
        }

        public async Task<Retiro> GetDetalleAsync(int CodigoRetiro, IUsuario usuario)
        {
            return await Management.Retiros.Obtencion.GetDetalleAsync(CodigoRetiro, usuario);
        }

        public async Task<IEnumerable<Incidencia>> GetIncidencias(Retiro retiro, IUsuario usuario)
        {
            return await Management.Trackings.Obtencion.GetIncidencias(retiro, usuario);
        }

        public async Task<IEnumerable<Retiro>> GetReporteSucursalesAsync(DateTime FechaSolicitud, IUsuario usuario)
        {
            return await Management.Retiros.Obtencion.GetReporteSucursalesAsync(FechaSolicitud, usuario);
        }

        public async Task<IEnumerable<Retiro>> GetRetirosAsync(string TipoEntrada, string Comuna, DateTime FechaDesde, DateTime FechaHasta, IUsuario usuario, string EstadoRetiro = "", string Movil = "", string Cliente="")
        {
            int mobileNumber = 0;
            if (Movil != "")
                mobileNumber = int.Parse(Movil);
            return await Management.Retiros.Obtencion.GetRetirosAsync(TipoEntrada, Comuna, FechaDesde, FechaHasta, usuario, EstadoRetiro, Movil: mobileNumber, CodCliente: Cliente);
        }

    }
}
