using BlazorApp1.Client.Services.Moviles;
using BlazorApp1.Shared.Modelo.Moviles;
using BlazorApp1.Shared.User;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlazorApp1.Client.Services
{
    public class AuthExtension : AuthenticationStateProvider
    {
        private readonly ISessionStorageService _session;
        private readonly MovilesService movilesService;
        private ClaimsPrincipal _principalVacio = new ClaimsPrincipal(new ClaimsIdentity());

        public AuthExtension(ISessionStorageService sesion, MovilesService movilesService)
        {
            _session = sesion;
            this.movilesService = movilesService;
        }
        public async Task UpdateAuthorization(Sesion? sesion)
        {
            ClaimsPrincipal claimsPrincipal;

            if (sesion != null)
            {
                claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name, sesion.Nombre),
                    new Claim(ClaimTypes.Role, sesion.Rol),
                    new Claim("MovilesDisponibles", sesion.MovilesDisponibles)
                }, "JwtAuth"));
                await _session.SaveStorage("sesion", sesion);

                movilesService.SetMovilesDisponibles(JsonConvert.DeserializeObject<List<Movil>>(sesion.MovilesDisponibles));
            }
            else
            {
                claimsPrincipal = _principalVacio;
                await _session.RemoveItemAsync("sesion");
            }
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }


        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var sesion = await _session.GetStorage<Sesion>("sesion");

            if (sesion == null)
                return await Task.FromResult(new AuthenticationState(_principalVacio));

            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name, sesion.Nombre),
                    new Claim(ClaimTypes.Role, sesion.Rol),
                    new Claim("MovilesDisponibles", sesion.MovilesDisponibles)
                }, "JwtAuth"));

            return await Task.FromResult(new AuthenticationState(claimsPrincipal));

            //new AuthenticationState(claimsPrincipal).User.Claims.ToList().First(cl => cl.Type == "MovilesDisponibles");


        }

    }
}
