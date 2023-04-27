using BlazorApp1.Shared.User;
using BlazorApp1.Shared.Modelo.Retiros;
using BlazorApp1.Shared.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Server.Management.Trackings
{
    public class Obtencion
    {
        public static async Task<List<Tracking>> GetTracking(Retiro Retiro, IUsuario usuario)
        {
            try
            {

                string URL = $"recogidas/recogidas_incidencias.do?recogida={Retiro.CodigoRetiro}&url=/padua/recogidas_repartos/gestion_recogidas.do&marca=I";
                string body;
                List<Tracking> trackList;
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                HtmlAgilityPack.HtmlNode BodyNode;
                HtmlAgilityPack.HtmlNode TableNode;
                HtmlAgilityPack.HtmlNodeCollection TrackingNodes;
                
                body =  await ClienteWeb.Consultas.ConsultaGet.GetAsync(URL, usuario);
                doc.LoadHtml(body);
                BodyNode = Nodos.GetNode(doc.DocumentNode, "body");
                TableNode = Nodos.GetNode(BodyNode, "table","id","listado2");
                TrackingNodes = Nodos.GetNodes(TableNode, "tr", "class");

                if (TrackingNodes is null)
                    return new List<Tracking>();
                else
                {
                    trackList = new List<Tracking>();
                    for (int i = 1; i < TrackingNodes.Count; i++) 
                    {
                        //solo debug
                        HtmlAgilityPack.HtmlNode trackActual = TrackingNodes[i];
                        trackList.Add(new Tracking
                        {
                            FechaEstado = DateTime.Parse(TrackingNodes[i].ChildNodes[1].InnerText),
                            Tipo = TrackingNodes[i].ChildNodes[3].InnerText,
                            Mensaje = TrackingNodes[i].ChildNodes[5].InnerText,
                            Usuario = TrackingNodes[i].ChildNodes[7].InnerText,
                            Delegacion = TrackingNodes[i].ChildNodes[9].InnerText
                        });
                    }
                }
                Retiro.TrackingList = trackList;
                return trackList;
            }
            catch
            {
                throw;
            }
        }

        public static async Task<List<Incidencia>> GetIncidencias(Retiro Retiro, IUsuario usuario)
        {
            try
            {

                string URL = $"recogidas/recogidas_incidencias.do?recogida={Retiro.CodigoRetiro}&url=/padua/recogidas_repartos/gestion_recogidas.do&marca=I";
                string body;
                List<Incidencia> IncidenciasList;
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                HtmlAgilityPack.HtmlNode BodyNode;
                HtmlAgilityPack.HtmlNode TableNode;
                HtmlAgilityPack.HtmlNodeCollection TrackingNodes;

                body = await ClienteWeb.Consultas.ConsultaGet.GetAsync(URL, usuario);
                doc.LoadHtml(body);
                BodyNode = Nodos.GetNode(doc.DocumentNode, "body");
                TableNode = Nodos.GetNode(BodyNode, "table", "id", "listado");
                TrackingNodes = Nodos.GetNodes(TableNode, "tr", "class");

                if (TrackingNodes is null)
                    return new List<Incidencia>();
                else
                {
                    IncidenciasList = new List<Incidencia>();
                    for (int i = 1; i < TrackingNodes.Count; i++)
                    {
                        //solo debug
                        HtmlAgilityPack.HtmlNode trackActual = TrackingNodes[i];
                        string[] InciDesc = TrackingNodes[i].ChildNodes[7].InnerText.Split(null, 2);
                        IncidenciasList.Add(new Incidencia(DateTime.Parse(TrackingNodes[i].ChildNodes[1].InnerText),
                                                           TrackingNodes[i].ChildNodes[3].InnerText,
                                                           TrackingNodes[i].ChildNodes[5].InnerText,
                                                           InciDesc[0],
                                                           InciDesc[1],
                                                           TrackingNodes[i].ChildNodes[9].InnerText));
                    }
                }
                Retiro.Incidencias = IncidenciasList;
                return IncidenciasList;
            }
            catch
            {
                throw;
            }
        }
    }
}
