using BlazorApp1.Shared.ControllerModel;
using BlazorApp1.Shared.Modelo.Retiros;
using BlazorApp1.Shared.User;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorApp1.Client.Services.Retiros
{
    internal class RetirosRepoService : IRetirosRepoService
    {
        private readonly HttpClient _httpClient;
        private readonly Usuario _usuario;
        public RetirosRepoService(HttpClient httpClient, Usuario usuario)
        {
            _httpClient = httpClient;
            _usuario = usuario;
        }

        public async Task<IEnumerable<Retiro>> GetRetirosPendientes(string TipoRetiro, string CodigoComuna, DateTime Desde, DateTime Hasta)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"Retiros/GetRetiros/{TipoRetiro}/{CodigoComuna}/PEND/{Desde.Day:00}/{Desde.Month:00}/{Desde.Year}/{Hasta.Day:00}/{Hasta.Month:00}/{Hasta.Year}", _usuario);
                return await response.Content.ReadFromJsonAsync<IEnumerable<Retiro>>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public async Task<IEnumerable<Retiro>> GetRetirosTodosLosEstados(string TipoRetiro, string CodigoComuna, DateTime Desde, DateTime Hasta)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"Retiros/GetRetiros/{TipoRetiro}/{CodigoComuna}/TODOS/{Desde.Day:00}/{Desde.Month:00}/{Desde.Year}/{Hasta.Day:00}/{Hasta.Month:00}/{Hasta.Year}", _usuario);
                return await response.Content.ReadFromJsonAsync<IEnumerable<Retiro>>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        //Reporte Sucursales
        public async Task<IEnumerable<Retiro>> GetReporteSucursalesAsync(DateTime FechaReporte)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"Retiros/ReporteSucursal/{FechaReporte.Day:00}/{FechaReporte.Month:00}/{FechaReporte.Year}", _usuario);
                return await response.Content.ReadFromJsonAsync<IEnumerable<Retiro>>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<IEnumerable<Retiro>> GetRetirosAsignados(string TipoRetiro, string Movil, DateTime Desde, DateTime Hasta)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"Retiros/GetRetirosByMovil/{TipoRetiro}/{Movil}/ASIG/{Desde.Day:00}/{Desde.Month:00}/{Desde.Year}/{Hasta.Day:00}/{Hasta.Month:00}/{Hasta.Year}", _usuario);
                return await response.Content.ReadFromJsonAsync<IEnumerable<Retiro>>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task AsignarAsync(Retiro retiro)
        {
            try
            {
                if (retiro != null)
                {
                    RetiroToAssign retiroToAssign = new RetiroToAssign(retiro,_usuario);

                    var response = await _httpClient.PostAsJsonAsync("Retiros/Asignar", retiroToAssign);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
