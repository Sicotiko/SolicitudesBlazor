using BlazorApp1.Client.Components.Loading;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Linq.Dynamic.Core.Tokenizer;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorApp1.Client.Services.Login
{
    public class LoginService
    {
        private readonly AuthenticationStateProvider authProvider;
        private readonly HttpClient httpClient;
        private readonly LoadingScreen _loadingScreen;
        public LoginService(AuthenticationStateProvider authProvider, HttpClient httpClient, LoadingScreen loadingScreen)
        {
            this.authProvider = authProvider;
            this.httpClient = httpClient;
            this._loadingScreen = loadingScreen;
        }

        public async Task<bool> Login(BlazorApp1.Shared.User.Usuario login)
        {
            _loadingScreen.Show("Entrando.... ;)");
            var loginResponse = await httpClient.PostAsJsonAsync("api/Login/Auth", login);
            if (loginResponse.IsSuccessStatusCode)
            {
                var sesionUsuario = await loginResponse.Content.ReadFromJsonAsync<BlazorApp1.Shared.User.Sesion>();
                var authentication = (AuthExtension)authProvider;
                await authentication.UpdateAuthorization(sesionUsuario);
                //this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sesionUsuario.Token);
                _loadingScreen.Close();
                return true;
            }
            _loadingScreen.Close();
            return false;
        }
        public async Task LogOut()
        {
            var authentication = (AuthExtension)authProvider;
            await authentication.UpdateAuthorization(null);
            this.httpClient.DefaultRequestHeaders.Authorization = null;
        }
    }
}
