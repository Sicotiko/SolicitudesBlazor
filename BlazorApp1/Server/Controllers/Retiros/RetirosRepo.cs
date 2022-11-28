using BlazorApp1.Shared.User;
using BlazorApp1.Shared.Modelo.Retiros;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp1.Server.Controllers.Retiros
{
    public class RetirosRepo : IRetirosRepo
    {
        public async Task AsignarRetiroAsync(Retiro retiro, Usuario usuario)
        {
            await Management.Retiros.Asignacion.Asignar(retiro, usuario);
        }

        public async Task<Retiro> GetDetalleAsync(int CodigoRetiro, Usuario usuario)
        {
            return await Management.Retiros.Obtencion.GetDetalleAsync(CodigoRetiro, usuario);
        }

        public async Task<IEnumerable<Retiro>> GetReporteSucursalesAsync(DateTime FechaSolicitud, Usuario usuario)
        {
            return await Management.Retiros.Obtencion.GetReporteSucursalesAsync(FechaSolicitud,usuario);
        }

        public async Task<IEnumerable<Retiro>> GetRetirosAsync(string TipoEntrada, string Comuna, DateTime FechaDesde, DateTime FechaHasta, Usuario usuario, string EstadoRetiro = "")
        {
            return await Management.Retiros.Obtencion.GetRetirosAsync(TipoEntrada, Comuna, FechaDesde, FechaHasta, usuario,EstadoRetiro);
        }
    }
}
