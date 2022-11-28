using BlazorApp1.Shared.User;
using BlazorApp1.Shared.Modelo.Retiros;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp1.Server.Controllers.Retiros
{
    public interface IRetirosRepo
    {
        Task<IEnumerable<Retiro>> GetRetirosAsync(string TipoEntrada, string Comuna, DateTime FechaDesde,
                                                       DateTime FechaHasta, Usuario usuario, string EstadoRetiro = "");
        Task<Retiro> GetDetalleAsync(int CodigoRetiro, Usuario usuario);
        Task<IEnumerable<Retiro>> GetReporteSucursalesAsync(DateTime FechaSolicitud, Usuario usuario);
        Task AsignarRetiroAsync(Retiro retiro, Usuario usuario);
    }
}
