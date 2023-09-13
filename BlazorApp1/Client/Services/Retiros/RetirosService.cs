using BlazorApp1.Shared.ControllerModel;
using BlazorApp1.Shared.Excepciones;
using BlazorApp1.Shared.Modelo.Moviles;
using BlazorApp1.Shared.Modelo.Retiros;
using BlazorApp1.Shared.User;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorApp1.Client.Services.Retiros
{
    public class RetirosService
    {
        private readonly HttpClient httpClient;
        private readonly Usuario usuario;

        public RetirosService(HttpClient httpClient, Usuario usuario)
        {
            this.httpClient = httpClient;
            this.usuario = usuario;
        }

        public async Task AsignarAsync(Retiro retiro)
        {

            if (retiro != null)
            {
                RetiroToAssign retiroToAssign = new RetiroToAssign(retiro, usuario);

                var response = await httpClient.PostAsJsonAsync("api/Retiros/Asignar", retiroToAssign);
                if (!response.IsSuccessStatusCode)
                    throw new ExceptionResponse(await response.Content.ReadAsStringAsync());
            }
        }
        public async Task<IEnumerable<Retiro>> GetRetirosAsync(FiltroBusquedaRetiros filtro)
        {
            IEnumerable<Retiro> resultado = new List<Retiro>();

            filtro.Usuario = usuario;
            var response = await httpClient.PostAsJsonAsync($"api/Retiros/GetRetiros", filtro);
            if (response.IsSuccessStatusCode)
                resultado = await response.Content.ReadFromJsonAsync<IEnumerable<Retiro>>();
            else
                throw new ExceptionResponse(await response.Content.ReadAsStringAsync());

            return resultado;
        }
        public async Task<IEnumerable<Retiro>> GetRetirosPorSectorAsync(FiltroBusquedaRetiros filtro)
        {
            IEnumerable<Retiro> resultado = new List<Retiro>();

            filtro.Usuario = usuario;
            var response = await httpClient.PostAsJsonAsync($"api/Retiros/GetRetirosPorSector", filtro);
            if (response.IsSuccessStatusCode)
                resultado = await response.Content.ReadFromJsonAsync<IEnumerable<Retiro>>();
            else
                throw new ExceptionResponse(await response.Content.ReadAsStringAsync());

            return resultado;
        }

    }
}
