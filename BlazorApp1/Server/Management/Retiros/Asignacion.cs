using BlazorApp1.Shared.User;
using BlazorApp1.Shared.Modelo.Retiros;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Server.Management.Retiros
{
    public class Asignacion
    {
        public static async Task PreAsignar(Retiro retiro, IUsuario usuario)
        {
            try
            {
                string Url = "recogidas_repartos/asignacion_recogidas.do";

                Dictionary<string, string> Parametros = new Dictionary<string, string>();
                Parametros.Add("masivos", "");
                Parametros.Add("pagina_actua", "");
                Parametros.Add("pagina_maximo", "");
                Parametros.Add("pagina_total", "");
                Parametros.Add("recogedor_ot_codigo", retiro.Movil);
                Parametros.Add("recogedor_ot_descripcion", "");
                Parametros.Add("redirige", "");
                Parametros.Add("selectedCodigos", retiro.CodigoRetiro);
                Parametros.Add("orden_trabajo_codigo", "");

                await Shared.ClienteWeb.Consultas.ConsultaPost.PostAsync(Url, Parametros, usuario);
            }
            catch
            {
                throw;
            }
        }

        public static async Task PreAsignar(Retiro retiro, int Movil, IUsuario usuario)
        {
            try
            {
                string Url = "recogidas_repartos/asignacion_recogidas.do";

                Dictionary<string, string> Parametros = new Dictionary<string, string>();
                Parametros.Add("masivos", "");
                Parametros.Add("pagina_actua", "");
                Parametros.Add("pagina_maximo", "");
                Parametros.Add("pagina_total", "");
                Parametros.Add("recogedor_ot_codigo", Shared.Utilities.MobileNumber.ToCCMobileNumber(Movil));
                Parametros.Add("recogedor_ot_descripcion", "");
                Parametros.Add("redirige", "");
                Parametros.Add("selectedCodigos", retiro.CodigoRetiro);
                Parametros.Add("orden_trabajo_codigo", "");

                await Shared.ClienteWeb.Consultas.ConsultaPost.PostAsync(Url, Parametros, usuario);
            }
            catch
            {
                throw;
            }
        }
        public static async Task Asignar(Retiro retiro, IUsuario usuario)
        {
            try
            {
                int movil = int.Parse(retiro.Movil);
                string Url = "recogidas_repartos/asignacion_recogidas.do";
                Dictionary<string, string> Parameters = new Dictionary<string, string>();

                Parameters.Add("masivos", "false");
                Parameters.Add("pagina_actua", "1");
                Parameters.Add("pagina_maximo", "1");
                Parameters.Add("pagina_total", "0");
                Parameters.Add("recogedor_ot_codigo", Shared.Utilities.MobileNumber.ToCCMobileNumber(movil));
                Parameters.Add("recogedor_ot_descripcion", "");
                Parameters.Add("redirige", "");
                Parameters.Add("selectedCodigos", retiro.CodigoRetiro);
                Parameters.Add("orden_trabajo_codigo", retiro.Ot);

                await Shared.ClienteWeb.Consultas.ConsultaPost.PostAsync(Url, Parameters, usuario);
            }
            catch
            {
                throw;
            }

        }
        public static async Task Asignar(Retiro retiro, int Movil,string NumeroOrdenTrabajo, IUsuario usuario)
        {
            try
            {
                string Url = "recogidas_repartos/asignacion_recogidas.do";
                Dictionary<string, string> Parameters = new Dictionary<string, string>();

                Parameters.Add("masivos", "false");
                Parameters.Add("pagina_actua", "1");
                Parameters.Add("pagina_maximo", "1");
                Parameters.Add("pagina_total", "0");
                Parameters.Add("recogedor_ot_codigo", Shared.Utilities.MobileNumber.ToCCMobileNumber(Movil));
                Parameters.Add("recogedor_ot_descripcion", "");
                Parameters.Add("redirige", "");
                Parameters.Add("selectedCodigos", retiro.CodigoRetiro);
                Parameters.Add("orden_trabajo_codigo", NumeroOrdenTrabajo);

                await Shared.ClienteWeb.Consultas.ConsultaPost.PostAsync(Url, Parameters, usuario);
            }
            catch
            {
                throw;
            }

        }
        public static async Task Asignar(List<Retiro> Retiros, int Movil, string NumeroOrdenTrabajo, IUsuario usuario)
        {
            try
            {
                string Url = "recogidas_repartos/asignacion_recogidas.do";
                Dictionary<string, string> Parameters = new Dictionary<string, string>();

                Parameters.Add("masivos", "false");
                Parameters.Add("pagina_actua", "1");
                Parameters.Add("pagina_maximo", "1");
                Parameters.Add("pagina_total", "0");
                Parameters.Add("recogedor_ot_codigo", Shared.Utilities.MobileNumber.ToCCMobileNumber(Movil));
                Parameters.Add("recogedor_ot_descripcion", "");
                Parameters.Add("redirige", "");
                Parameters.Add("orden_trabajo_codigo", NumeroOrdenTrabajo);
                foreach (var retiro in Retiros)
                    Parameters.Add("selectedCodigos", retiro.CodigoRetiro);

                await Shared.ClienteWeb.Consultas.ConsultaPost.PostAsync(Url, Parameters, usuario);

            }
            catch
            {
                throw;
            }
        }
    }
}
