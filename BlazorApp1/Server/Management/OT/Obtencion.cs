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
    public class Obtencion
    {
        private static string _Body = string.Empty;

        private static async Task GetBodyOtAsync(int PaginaActual, int Movil, string Estado, DateTime FechaDesde, DateTime FechaHasta, IUsuario usuario, string NumeroOt = "")
        {
            string url = $"recogidas_repartos/ordenes_trabajo_consulta.do?buscar=true";

            Dictionary<string, string> Parameters = new Dictionary<string, string>();
            Parameters.Add("tipo_error", "");
            Parameters.Add("mensaje", "");
            Parameters.Add("pagina", PaginaActual.ToString());
            Parameters.Add("masivo", "N");
            Parameters.Add("repartidor_recogedor_codigo", MobileNumber.ToCCMobileNumber(Movil));
            Parameters.Add("repartidor_recogedor_descripcion", "");
            Parameters.Add("crr_codigo", "");
            Parameters.Add("crr_descripcion", "");
            Parameters.Add("estado", Estado);
            Parameters.Add("codigo", NumeroOt);
            Parameters.Add("fecha_desde", FechaDesde.ToShortDateString().Replace('-', '/'));
            Parameters.Add("fecha_hasta", FechaHasta.ToShortDateString().Replace('-', '/'));
            Parameters.Add("numero_envio", "");
            Parameters.Add("incluir_ots_crr", "N");

            _Body = await Shared.ClienteWeb.Consultas.ConsultaPost.PostAsync(url, Parameters, usuario);
        }

        public static async Task<List<OrdenTrabajo>> GetOrdenesAsync(int Movil, string Estado, DateTime FechaDesde, DateTime FechaHasta, IUsuario usuario, string NumeroOt = "")
        {
            _Body = string.Empty;
            List<OrdenTrabajo> ordenTrabajos = new List<OrdenTrabajo>();
            OrdenTrabajo ordenToAdd;
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            HtmlAgilityPack.HtmlNode BodyNode;
            HtmlAgilityPack.HtmlNode TableBodyNode;
            HtmlAgilityPack.HtmlNodeCollection ListaOtNode;
            HtmlAgilityPack.HtmlNodeCollection DetalleListaOtNode = null;
            bool VerificarTotal = true;
            int PaginaMaxima = 0;
            int PaginaActual = 1;

            try
            {

                do
                {
                    await GetBodyOtAsync(PaginaActual, Movil, Estado, FechaDesde, FechaHasta, usuario, NumeroOt);


                    doc.LoadHtml(_Body);
                    BodyNode = Nodos.GetNode(doc.DocumentNode, "body");

                    if (VerificarTotal)
                    {
                        HtmlAgilityPack.HtmlNode TrTituloTotal = Nodos.GetNode(BodyNode, "tr", "class", "titulo");
                        HtmlAgilityPack.HtmlNode TdTituloTotal = Nodos.GetNode(TrTituloTotal, "td", "align", "right");
                        string msgEncontrados = TdTituloTotal.InnerHtml;
                        //"\r\n\t    2571\r\n\t   "
                        msgEncontrados = msgEncontrados.Replace("&nbsp;registros encontrados&nbsp;&nbsp;", "");
                        msgEncontrados = msgEncontrados.Replace("\r\n\t", "");
                        msgEncontrados = msgEncontrados.Replace(" ", "");
                        int Founded;
                        int.TryParse(msgEncontrados, out Founded);

                        if (Founded == 0)
                            return new List<OrdenTrabajo>();
                        else
                        {
                            VerificarTotal = false;
                            PaginaMaxima = int.Parse(Nodos.GetNode(BodyNode, "input", "name", "pagina_maximo").GetAttributeValue("value", ""));
                        }
                    }
                    TableBodyNode = Nodos.GetNode(BodyNode, "tbody", "class", "cuerpo_tabla");
                    ListaOtNode = Nodos.GetNodes(TableBodyNode, "tr", "class");
                    foreach (HtmlAgilityPack.HtmlNode fila in ListaOtNode)
                    {
                        DetalleListaOtNode = Nodos.GetNodes(fila, "td");
                        ordenToAdd = new OrdenTrabajo();
                        var nodoNumero = Nodos.GetNode(DetalleListaOtNode[0], "a");
                        if (nodoNumero == null)
                            ordenToAdd.Numero = DetalleListaOtNode[0].InnerHtml;
                        else
                            ordenToAdd.Numero = nodoNumero.InnerHtml;
                        ordenToAdd.Movil = DetalleListaOtNode[1].InnerHtml;
                        ordenToAdd.Estado = DetalleListaOtNode[4].InnerHtml;
                        ordenToAdd.Fecha = DateTime.Parse(DetalleListaOtNode[5].InnerHtml);
                        int Repartos = 1;
                        int.TryParse(DetalleListaOtNode[6].InnerHtml, out Repartos);
                        ordenToAdd.Repartos = Repartos;
                        int Recogidas = 0;
                        int.TryParse(DetalleListaOtNode[7].InnerHtml, out Recogidas);
                        ordenToAdd.Recogidas = Recogidas;

                        ordenTrabajos.Add(ordenToAdd);
                    }

                    PaginaActual++;
                } while (PaginaActual <= PaginaMaxima);
            }
            catch (Exception ex)
            {
                if (DetalleListaOtNode is not null)
                    Console.WriteLine(Nodos.GetNode(DetalleListaOtNode[0], "a").InnerHtml);

            }
            return ordenTrabajos;
        }

        public static async IAsyncEnumerable<OrdenTrabajo> GetOrdenesAsyncYield(int Movil, string Estado, DateTime FechaDesde, DateTime FechaHasta, IUsuario usuario, string NumeroOt = "")
        {
            _Body = string.Empty;
            OrdenTrabajo ordenToAdd;
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            HtmlAgilityPack.HtmlNode BodyNode;
            HtmlAgilityPack.HtmlNode TableBodyNode;
            HtmlAgilityPack.HtmlNodeCollection ListaOtNode;
            HtmlAgilityPack.HtmlNodeCollection DetalleListaOtNode;
            bool VerificarTotal = true;
            int PaginaMaxima = 0;
            int PaginaActual = 1;

            do
            {
                await GetBodyOtAsync(PaginaActual, Movil, Estado, FechaDesde, FechaHasta, usuario, NumeroOt);

                doc.LoadHtml(_Body);
                BodyNode = Nodos.GetNode(doc.DocumentNode, "body");

                if (VerificarTotal)
                {
                    HtmlAgilityPack.HtmlNode TrTituloTotal = Nodos.GetNode(BodyNode, "tr", "class", "titulo");
                    HtmlAgilityPack.HtmlNode TdTituloTotal = Nodos.GetNode(TrTituloTotal, "td", "align", "right");
                    string msgEncontrados = TdTituloTotal.InnerHtml;
                    msgEncontrados = msgEncontrados.Replace("&nbsp;registros encontrados&nbsp;&nbsp;", "");
                    msgEncontrados = msgEncontrados.Replace("\r\n\t", "");
                    msgEncontrados = msgEncontrados.Replace(" ", "");
                    int Founded;
                    int.TryParse(msgEncontrados, out Founded);

                    if (Founded == 0)
                        yield break;
                    else
                    {
                        VerificarTotal = false;
                        PaginaMaxima = int.Parse(Nodos.GetNode(BodyNode, "input", "name", "pagina_maximo").GetAttributeValue("value", ""));
                    }
                }
                TableBodyNode = Nodos.GetNode(BodyNode, "tbody", "class", "cuerpo_tabla");
                ListaOtNode = Nodos.GetNodes(TableBodyNode, "tr", "class");
                foreach (HtmlAgilityPack.HtmlNode fila in ListaOtNode)
                {
                    DetalleListaOtNode = Nodos.GetNodes(fila, "td");
                    ordenToAdd = new OrdenTrabajo();
                    ordenToAdd.Numero = Nodos.GetNode(DetalleListaOtNode[0], "a").InnerHtml;
                    ordenToAdd.Movil = DetalleListaOtNode[1].InnerHtml;
                    ordenToAdd.Estado = DetalleListaOtNode[4].InnerHtml;
                    ordenToAdd.Fecha = DateTime.Parse(DetalleListaOtNode[5].InnerHtml);
                    ordenToAdd.Repartos = int.Parse(DetalleListaOtNode[6].InnerHtml);
                    ordenToAdd.Recogidas = int.Parse(DetalleListaOtNode[7].InnerHtml);

                    yield return ordenToAdd;
                }

                PaginaActual++;
            } while (PaginaActual <= PaginaMaxima);
        }
    }
}
