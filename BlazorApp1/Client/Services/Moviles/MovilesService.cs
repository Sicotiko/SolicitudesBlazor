using BlazorApp1.Shared.Excepciones;
using BlazorApp1.Shared.Modelo.Moviles;
using BlazorApp1.Shared.User;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorApp1.Client.Services.Moviles
{
    public class MovilesService
    {
        private readonly HttpClient _httpClient;
        private readonly Usuario _usuario;

        public MovilesService(HttpClient httpClient, Usuario usuario)
        {
            this._httpClient = httpClient;
            this._usuario = usuario;
        }

        public async Task<List<TipoMovil>> GetMovilesDisponibles()
        {
            var response = await _httpClient.PostAsJsonAsync($"TipoMoviles/GetMovilesDisponibles", _usuario);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<List<TipoMovil>>();
            else
                throw new ExceptionResponse(await response.Content.ReadAsStringAsync());
        }
    }
}
