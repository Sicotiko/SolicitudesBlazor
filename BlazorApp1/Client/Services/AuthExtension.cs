using BlazorApp1.Shared.User;
using Blazored.SessionStorage;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Microsoft.AspNetCore.Components.Authorization;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlazorApp1.Client.Services
{
    public class AuthExtension : AuthenticationStateProvider
    {
        private readonly ISessionStorageService _session;
        private ClaimsPrincipal _principalVacio = new ClaimsPrincipal(new ClaimsIdentity());

        public AuthExtension(ISessionStorageService sesion)
        {
            _session = sesion;
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
