using BlazorApp1.Shared.Excepciones;
using BlazorApp1.Shared.Modelo.Moviles;
using BlazorApp1.Shared.Modelo.OT;
using BlazorApp1.Shared.User;
using DocumentFormat.OpenXml.Drawing;
using Radzen.Blazor;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorApp1.Client.Services.OT
{
    public class OrdenesService
    {
        private readonly HttpClient httpClient;
        private readonly Usuario usuario;

        public OrdenesService(HttpClient httpClient, Usuario usuario)
        {
            this.httpClient = httpClient;
            this.usuario = usuario;
        }
        public async Task<OrdenTrabajo> CrearAsync(OrdenTrabajo orden)
        {
            OrdenViewModel ordenViewModel = new OrdenViewModel
            {
                OrdenDeTrabajo = orden,
                Usuario = usuario
            };

            var response = await httpClient.PostAsJsonAsync($"api/OrdenTrabajo/Crear", ordenViewModel);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<OrdenTrabajo>();
            else
                throw new ExceptionResponse(await response.Content.ReadAsStringAsync());
        }
        public async Task<bool> CerrarAsync(OrdenTrabajo orden)
        {
            OrdenViewModel ordenViewModel = new OrdenViewModel
            {
                OrdenDeTrabajo = orden,
                Usuario = usuario
            };
            var response = await httpClient.PostAsJsonAsync($"api/OrdenTrabajo/Cerrar", ordenViewModel);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<bool>();
            else
                throw new ExceptionResponse(await response.Content.ReadAsStringAsync());
        }
        public async Task<List<OrdenTrabajo>> GetAsync(FiltroBusquedaOrdenTrabajo filtro)
        {
            filtro.Usuario = usuario;
            var response = await httpClient.PostAsJsonAsync($"api/OrdenTrabajo/Get", filtro);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<List<OrdenTrabajo>>();
            else
                throw new ExceptionResponse(await response.Content.ReadAsStringAsync());
        }
        public async Task<List<OrdenTrabajo>> GetLocalAsync(FiltroBusquedaOrdenTrabajo filtro)
        {
            var response = await httpClient.PostAsJsonAsync($"api/OrdenTrabajo/GetLocal", filtro);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<List<OrdenTrabajo>>();
            else
                throw new ExceptionResponse(await response.Content.ReadAsStringAsync());
        }
        public async Task BorrarLocalAsync(OrdenTrabajo orden)
        {
            var response = await httpClient.PostAsJsonAsync($"api/OrdenTrabajo/BorrarLocal", orden);
            if (!response.IsSuccessStatusCode)
                throw new ExceptionResponse(await response.Content.ReadAsStringAsync());
        }
    }
}
