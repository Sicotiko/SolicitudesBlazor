using BlazorApp1.Shared.User;
using BlazorApp1.Shared.Modelo.OT;
using BlazorApp1.Shared.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Server.Management.OT
{
    public class Finalizacion
    {
        public static async Task<bool> CerrarOrden(OrdenTrabajo ordenTrabajo, Usuario usuario)
        {
            string url = $"recogidas_repartos/control_dato.do?C=jsrs1&F=cerrar&P0=[{ordenTrabajo.Numero}]&P1=[0]&P2=[]&P3=[]&P4=[]&P5=[]&P6=[]&P7=[N]&P8=[]&P9=[]&P10=[]&P11=[]&P12=[]&P13=[]&P14=[]&U=1651521585558";
            string body;
            bool estado = false;
            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            HtmlAgilityPack.HtmlNode TextAreaNode;
            
            try
            {

                body = await ClienteWeb.Consultas.ConsultaGet.GetAsync(url, usuario);
                document.LoadHtml(body);
                TextAreaNode = Nodos.GetNode(document.DocumentNode, "textarea");

                if (!TextAreaNode.InnerHtml.Contains("Error de base de datos en la"))
                    estado = true;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return estado;
        }
    }
}
