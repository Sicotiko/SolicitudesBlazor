using BlazorApp1.Server.ClienteWeb;
using BlazorApp1.Shared.User;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared.ClienteWeb.Consultas
{
    public static class ConsultaPost
    {
        public static string Post(string URL, Dictionary<string, string> Parametros, IUsuario IUsuario)
        {
            string Body = string.Empty;
            try
            {
                HttpContent formUrlEncodedContent = new FormUrlEncodedContent(Parametros);
                Body = ClientInstance.GetClient(IUsuario).PostAsync(URL, formUrlEncodedContent).Result.Content.ReadAsStringAsync().Result;
            }
            catch (Exception)
            {
                throw new Exception("Compruebe su conexion a internet o VPN");
            }
            if (Body.Contains("Estado de HTTP 401"))
                throw new Exception("Comprueba tus credenciales (Usuario y Pass)");


            return Body;
        }

        public static async Task<string> PostAsync(string URL, Dictionary<string, string> Parametros, IUsuario IUsuario)
        {
            string Body = string.Empty;
            try
            {
                HttpContent formUrlEncodedContent = new FormUrlEncodedContent(Parametros);
                Body = await ClientInstance.GetClient(IUsuario).PostAsync(URL, formUrlEncodedContent).Result.Content.ReadAsStringAsync();
            }
            catch (Exception)
            {
                throw new Exception("Compruebe su conexion a internet o VPN");
            }
            if (Body.Contains("Estado de HTTP 401"))
                throw new Exception("Comprueba tus credenciales (Usuario y Pass)");


            return Body;
        }


    }
}
