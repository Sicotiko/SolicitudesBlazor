using BlazorApp1.Shared.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace BlazorApp1.Server.ClienteWeb
{
    public class ClientInstance
    {

        private static Dictionary<string,HttpClient> Clients = new Dictionary<string, HttpClient>();
        private static Dictionary<string,HttpClient> ClientsForMC = new Dictionary<string, HttpClient>();

        public static HttpClient GetClient(IUsuario usuario)
        {
            //HttpClient cliente = new HttpClient();
            if(Clients.TryGetValue(usuario.GetCredentials(), out var cliente))
                return cliente;

            var byteArray = Encoding.ASCII.GetBytes(usuario.GetCredentials());
            
            var header = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            HttpClient localClient = new HttpClient();
            localClient.DefaultRequestHeaders.Authorization = header;
            localClient.BaseAddress = new Uri("http://padua.icorreos.cl/padua/");
            Clients.Add(usuario.GetCredentials(), localClient);

            return localClient;
        }
        
        public static HttpClient GetClientForMC(IUsuario usuario)
        {
            if (Clients.TryGetValue(usuario.GetCredentials(), out var cliente))
                return cliente;

            HttpClient httpClient = new HttpClient();
            ClientsForMC.Add(usuario.GetCredentials(),httpClient);

            return httpClient;
        }

    }
}
