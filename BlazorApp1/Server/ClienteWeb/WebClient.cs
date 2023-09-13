using BlazorApp1.Shared.Excepciones;
using BlazorApp1.Shared.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Server.ClienteWeb
{
    public class WebClient
    {
        public HttpClient Client { get; private set; }

        public WebClient()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri("http://padua.icorreos.cl/padua/");
        }

        public void SetCredentials(Usuario usuario)
        {
            var byteArray = Encoding.ASCII.GetBytes(usuario.GetCredentials());
            var header = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            Client.DefaultRequestHeaders.Authorization = header;
        }

        public async Task<string> PostAsync(string URL, Dictionary<string, string> Parametros)
        {
            string Body = string.Empty;
            try
            {
                HttpContent formUrlEncodedContent = new FormUrlEncodedContent(Parametros);
                var result = await Client.PostAsync(URL, formUrlEncodedContent); //.Result.Content.ReadAsStringAsync();
                Body = await result.Content?.ReadAsStringAsync();
            }
            catch (Exception)
            {
                throw new CredentialsException("Compruebe su conexion a internet o VPN");
            }
            if (Body.Contains("Estado de HTTP 401"))
                throw new ConnectionException("Comprueba tus credenciales (Usuario y Pass)");


            return Body;
        }
        public async Task<string> GetAsync(string URL)
        {
            string Body = string.Empty;

            try
            {
                var result = await Client.GetAsync(URL);//.Result.Content.ReadAsStringAsync();
                Body = await result.Content?.ReadAsStringAsync();

            }
            catch (Exception)
            {
                throw new ConnectionException("Compruebe su conexion a internet o VPN");
            }
            if (Body.Contains("Estado de HTTP 401"))
                throw new CredentialsException("Comprueba tus credenciales (Usuario y Pass)");

            return Body;
        }
    }
}
