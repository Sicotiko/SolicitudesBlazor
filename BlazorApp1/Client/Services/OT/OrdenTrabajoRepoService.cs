using BlazorApp1.Shared.ControllerModel;
using BlazorApp1.Shared.Excepciones;
using BlazorApp1.Shared.Modelo.OT;
using BlazorApp1.Shared.User;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlazorApp1.Client.Services.OT
{
    public class OrdenTrabajoRepoService : IOrdenTrabajoRepoService
    {
        public List<OrdenTrabajo> Ordenes { get; set; }
        private readonly HttpClient _httpClient;
        private readonly Usuario _usuario;
        private JsonSerializerOptions _options;


        public OrdenTrabajoRepoService(HttpClient httpClient, Usuario usuario)
        {
            _httpClient = httpClient;
            _usuario = usuario;
            _options = new JsonSerializerOptions()
            {
                ReferenceHandler = ReferenceHandler.Preserve
            };
        }

        public Task CloseOrdenes()
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> CloseOrden(OrdenTrabajo ordenTrabajo)
        {

            OrdenToClose ordenToClose = new OrdenToClose(ordenTrabajo, _usuario);
            var response = await _httpClient.PostAsJsonAsync($"OrdenTrabajo/Cerrar", ordenToClose);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<bool>();
            else
                throw new ExceptionResponse(await response.Content.ReadAsStringAsync());
        }

        public async Task<OrdenTrabajo> CreateOrden(int Movil)
        {

            var response = await _httpClient.PostAsJsonAsync($"OrdenTrabajo/Crear/{Movil}", _usuario);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<OrdenTrabajo>();
            else
                throw new ExceptionResponse(await response.Content.ReadAsStringAsync());
        }

        public async Task UpdateOrdenes(int Movil, string Estado, DateTime Desde, DateTime Hasta)
        {
                var response = await _httpClient.PostAsJsonAsync($"OrdenTrabajo/Get/{Movil}/{Estado}/{Desde.Day:00}/{Desde.Month:00}/{Desde.Year}/{Hasta.Day:00}/{Hasta.Month:00}/{Hasta.Year}", _usuario);
            if(response.IsSuccessStatusCode)
                Ordenes = await response.Content.ReadFromJsonAsync<List<OrdenTrabajo>>();
            else
                throw new ExceptionResponse(await response.Content.ReadAsStringAsync());
        }
    }
}
