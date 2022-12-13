using BlazorApp1.Shared.User;
using BlazorApp1.Shared.Modelo.OT;
using BlazorApp1.Shared.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorApp1.Shared.Excepciones;

namespace BlazorApp1.Server.Management.OT
{
    public class Creacion
    {
        public static async Task<OrdenTrabajo> CreateOrdenTrabajo(int Movil, IUsuario usuario, bool Definitiva = true)
        {
            string url = $"recogidas_repartos/asignacion_aceptar.do";
            string Body;
            Dictionary<string, string> Parameters = new Dictionary<string, string>();
            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            HtmlAgilityPack.HtmlNode BodyNode;
            HtmlAgilityPack.HtmlNode TableNode;
            OrdenTrabajo ordenTrabajo = new OrdenTrabajo();


            try
            {
                Parameters.Add("url_vuelta", "");
                Parameters.Add("codigo", "");
                Parameters.Add("recogedor_repartidor_codigo", MobileNumber.ToCCMobileNumber(Movil));
                Parameters.Add("recogedor_repartidor_descripcion", "");
                Parameters.Add("fecha", DateTime.Today.ToShortDateString().Replace('-', '/'));
                Body = await Shared.ClienteWeb.Consultas.ConsultaPost.PostAsync(url, Parameters, usuario);

                document.LoadHtml(Body);
                BodyNode = Nodos.GetNode(document.DocumentNode, "body");
                TableNode = Nodos.GetNode(BodyNode, "table", "class", "filtro");
                if (Movil == 999)
                    ordenTrabajo.Tipo = "Muelle";

                ordenTrabajo.Numero = Nodos.GetNode(TableNode, "input", "name", "codigo").GetAttributeValue("value", "");
                ordenTrabajo.Fecha = DateTime.Parse(Nodos.GetNode(TableNode, "input", "name", "fecha").GetAttributeValue("value", ""));
                ordenTrabajo.Movil = MobileNumber.ToCCMobileNumber(Movil);
                if (Definitiva)
                    await DefinitivaAsync(ordenTrabajo.Numero, usuario);

            }
            catch
            {
                throw;
            }
            return ordenTrabajo;


        }
        public static async Task DefinitivaAsync(string NumeroOrdenTrabajo, IUsuario usuario)
        {
            try
            {
                string url = $"recogidas_repartos/definitivas_ordenes_trabajo.do?definitivas={NumeroOrdenTrabajo}";
                await ClienteWeb.Consultas.ConsultaGet.GetAsync(url, usuario);
            }
            catch
            {
                throw;
            }
        }
    }
}
