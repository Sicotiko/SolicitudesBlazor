using BlazorApp1.Shared.ControllerModel;
using BlazorApp1.Shared.Modelo.Retiros;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp1.Client.Services.Retiros
{
    internal interface IRetirosRepoService
    {
        Task<IEnumerable<Retiro>> GetRetirosPendientes(string TipoRetiro, string CodigoComuna, DateTime Desde, DateTime Hasta);
        Task<IEnumerable<Retiro>> GetRetirosTodosLosEstados(string TipoRetiro, string CodigoComuna, DateTime Desde, DateTime Hasta);
        
        Task<IEnumerable<Retiro>> GetRetirosAsignados(string TipoRetiro, string Movil, DateTime Desde, DateTime Hasta);
        Task<IEnumerable<Retiro>> GetReporteSucursalesAsync(DateTime FechaReporte);
        Task AsignarAsync(Retiro retiroToAssign);
    }
}
