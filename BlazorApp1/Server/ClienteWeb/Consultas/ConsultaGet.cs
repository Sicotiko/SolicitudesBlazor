using BlazorApp1.Shared.Excepciones;
using BlazorApp1.Shared.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Server.ClienteWeb.Consultas
{
    public class ConsultaGet
    {
        public static string Get(string URL, IUsuario usuario)
        {
            string Body = string.Empty;

            try
            {
               Body = ClientInstance.GetClient(usuario).GetAsync(URL).Result.Content.ReadAsStringAsync().Result;

            }
            catch (Exception)
            {
                throw new ConnectionException("Compruebe su conexion a internet o VPN");
            }
            if (Body.Contains("Estado de HTTP 401"))
                throw new CredentialsException("Comprueba tus credenciales (Usuario y Pass)");

            return Body;
        }

        public static async Task<string> GetAsync(string URL,IUsuario usuario)
        {
            string Body = string.Empty;

            try
            {
                Body = await ClientInstance.GetClient(usuario).GetAsync(URL).Result.Content.ReadAsStringAsync();

            }
            catch (Exception)
            {
                throw new ConnectionException("Compruebe su conexion a internet o VPN");
            }
            if (Body.Contains("Estado de HTTP 401"))
                throw new CredentialsException("Comprueba tus credenciales (Usuario y Pass)");

            return Body;
        }
        public static async Task<string> GetFromMcAsync(string URL, IUsuario usuario)
        {
            string Body = string.Empty;

            try
            {
                Body = await ClientInstance.GetClientForMC(usuario).GetAsync(URL).Result.Content.ReadAsStringAsync();

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
