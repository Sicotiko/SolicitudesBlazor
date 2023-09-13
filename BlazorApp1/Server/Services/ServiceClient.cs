using BlazorApp1.Server.ClienteWeb;
using BlazorApp1.Shared.User;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlazorApp1.Server.Services
{
    public class ServiceClient
    {
        private Dictionary<string, WebClient> clients = new Dictionary<string, WebClient>();

        public ServiceClient()
        {
        }

        public async Task<WebClient> Get(Usuario usuario)
        {
            var result = clients.FirstOrDefault(c => c.Key == usuario.UserInBase64);
            if (result.Key == null)
            {
                var client = new WebClient();
                client.SetCredentials(usuario);
                clients.Add(usuario.UserInBase64, client);
                return client;
            }
            else
                return result.Value;
        }
    }
}
