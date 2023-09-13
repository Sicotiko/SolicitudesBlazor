using BlazorApp1.Shared.Excepciones;
using BlazorApp1.Shared.Modelo.Comunas;
using BlazorApp1.Shared.Modelo.Moviles;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorApp1.Client.Services.Comunas
{
    public class ComunaService
    {
        private readonly HttpClient httpClient;

        public ComunaService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<List<Comuna>> GetComunasPorSector(NombreSector nombreSector)
        {
            var response = await httpClient.PostAsJsonAsync($"api/Comuna/GetBySector", nombreSector);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<List<Comuna>>();
            else
                throw new ExceptionResponse(await response.Content.ReadAsStringAsync());
        }
        public async Task<List<Comuna>> GetComunas()
        {
            var response = await httpClient.GetAsync($"api/Comuna/GetAll");
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<List<Comuna>>();
            else
                throw new ExceptionResponse(await response.Content.ReadAsStringAsync());
        }
        public async Task<Comuna> UpdateComuna(Comuna comuna)
        {
            var response = await httpClient.PostAsJsonAsync($"api/Comuna/Update", comuna);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<Comuna>();
            else
                throw new ExceptionResponse(await response.Content.ReadAsStringAsync());
        }
    }
}
