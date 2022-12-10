using BlazorApp1.Shared.ControllerModel;
using BlazorApp1.Shared.Modelo.OT;
using BlazorApp1.Shared.User;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorApp1.Client.Services.OT
{
    public class OrdenTrabajoRepoService : IOrdenTrabajoRepoService
    {
        public List<OrdenTrabajo> Ordenes { get ; set ; }
        private readonly HttpClient _httpClient;
        private readonly Usuario _usuario;

        public OrdenTrabajoRepoService(HttpClient httpClient, Usuario usuario)
        {
            _httpClient = httpClient;
            _usuario = usuario;
        }

        public Task CloseOrdenes()
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> CloseOrden(OrdenTrabajo ordenTrabajo)
        {
            try
            {
                OrdenToClose ordenToClose = new OrdenToClose(ordenTrabajo, _usuario);
                var response = await _httpClient.PostAsJsonAsync($"OrdenTrabajo/Cerrar",ordenToClose);
                return await response.Content.ReadFromJsonAsync<bool>();
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<OrdenTrabajo> CreateOrden(int Movil)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"OrdenTrabajo/Crear/{Movil}", _usuario);
                return await response.Content.ReadFromJsonAsync<OrdenTrabajo>();
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task UpdateOrdenes(int Movil, string Estado, DateTime Desde, DateTime Hasta)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"OrdenTrabajo/Get/{Movil}/{Estado}/{Desde.Day:00}/{Desde.Month:00}/{Desde.Year}/{Hasta.Day:00}/{Hasta.Month:00}/{Hasta.Year}", _usuario);
                Ordenes = await response.Content.ReadFromJsonAsync<List<OrdenTrabajo>>();
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
