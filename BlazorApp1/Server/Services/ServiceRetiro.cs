using BlazorApp1.Shared.ControllerModel;
using BlazorApp1.Shared.Modelo.Moviles;
using BlazorApp1.Shared.Modelo.Retiros;
using BlazorApp1.Shared.User;
using BlazorApp1.Shared.Utilities;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace BlazorApp1.Server.Services
{
    public class ServiceRetiro
    {
        private readonly ServiceClient serviceClient;
        private readonly ServiceComuna serviceComuna;

        public ServiceRetiro(ServiceClient serviceClient, ServiceComuna serviceComuna)
        {
            this.serviceClient = serviceClient;
            this.serviceComuna = serviceComuna;
        }

        public async Task Asignar(RetiroToAssign retiro)
        {
            try
            {
                string Url = "recogidas_repartos/asignacion_recogidas.do";
                Dictionary<string, string> Parameters = new Dictionary<string, string>();

                Parameters.Add("masivos", "false");
                Parameters.Add("pagina_actua", "1");
                Parameters.Add("pagina_maximo", "1");
                Parameters.Add("pagina_total", "0");
                Parameters.Add("recogedor_ot_codigo", retiro.retiro.Movil.Codigo.ToString());
                Parameters.Add("recogedor_ot_descripcion", "");
                Parameters.Add("redirige", "");
                Parameters.Add("selectedCodigos", retiro.retiro.CodigoRetiro.ToString());
                Parameters.Add("orden_trabajo_codigo", retiro.retiro.OrdenTrabajo.Numero.ToString());

                await (await serviceClient.Get(retiro.usuario)).PostAsync(Url, Parameters);
                //await Shared.ClienteWeb.Consultas.ConsultaPost.PostAsync(Url, Parameters, usuario);
            }
            catch
            {
                throw;
            }

        }

        public async Task<IEnumerable<Retiro>> GetRetirosAsync(FiltroBusquedaRetiros busquedaRetiros)
        {
            try
            {
                string url = $"recogidas_repartos/recogidas_consulta.do";
                int paginaActual = 1;
                int paginaMaxima = 0;
                HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
                bool RevisarTotal = true;
                List<Retiro> retiros = new List<Retiro>();

                do
                {


                    Dictionary<string, string> Parametros = new Dictionary<string, string>();
                    Parametros.Add("pagina", paginaActual.ToString());
                    Parametros.Add("sinZona_check", busquedaRetiros.SinZona ? busquedaRetiros.SinZona.ToString() : "");
                    Parametros.Add("codigo", busquedaRetiros.Recogida != 0 ? busquedaRetiros.Recogida.ToString() : "");
                    Parametros.Add("tipo_servicio", busquedaRetiros.TipoDeCarga != TipoDeCarga.Todos ? busquedaRetiros.TipoDeCarga.ToString() : "");
                    Parametros.Add("estado", busquedaRetiros.Estado != Estado.Todos ? busquedaRetiros.Estado.ToString() : "");
                    Parametros.Add("recogedor_codigo", busquedaRetiros.Recogedor != 0 ? busquedaRetiros.Recogedor.ToString() : "");
                    Parametros.Add("telefono", busquedaRetiros.Telefono);
                    Parametros.Add("tipo_origen", busquedaRetiros.Tipo != Tipo.Todos ? busquedaRetiros.Tipo.ToString() : "");
                    Parametros.Add("tipo_entrada", busquedaRetiros.TipoEntrada != TipoEntrada.Todos ? busquedaRetiros.TipoEntrada.ToString() : "");
                    Parametros.Add("codpRecogida_codigo", busquedaRetiros.Poblacion != 0 ? busquedaRetiros.Poblacion.ToString() : "");
                    Parametros.Add("codpDestino_codigo", busquedaRetiros.CPDestino != 0 ? busquedaRetiros.CPDestino.ToString() : "");
                    Parametros.Add("cliente_codigo", busquedaRetiros.Cliente);
                    Parametros.Add("cliente_descripcion", "");
                    Parametros.Add("deleDestino_codigo", busquedaRetiros.CPDestino != 0 ? busquedaRetiros.CPDestino.ToString() : "");
                    Parametros.Add("deleDestino_descripcion", "");
                    Parametros.Add("fecha_desde_aux", busquedaRetiros.FechaDesde.ToShortDateString().Replace('-', '/'));
                    Parametros.Add("fecha_hasta_aux", busquedaRetiros.Hasta.ToShortDateString().Replace('-', '/'));
                    Parametros.Add("zona_codigo", busquedaRetiros.Zona != 0 ? busquedaRetiros.Zona.ToString() : "");
                    Parametros.Add("conIncidencia", busquedaRetiros.ConIncidencia != 0 ? busquedaRetiros.ConIncidencia.ToString() : "");
                    Parametros.Add("incidencia_codigo", (int)busquedaRetiros.TipoIncidencia != 0 ? ((int)busquedaRetiros.TipoIncidencia).ToString() : "");
                    Parametros.Add("documentada", busquedaRetiros.Documentada != Documentada.Ambas ? busquedaRetiros.Documentada.ToString() : "");
                    Parametros.Add("autorizacion", busquedaRetiros.Autorizacion);

                    string Body = await (await serviceClient.Get(busquedaRetiros.Usuario)).PostAsync(url, Parametros);   //await Shared.ClienteWeb.Consultas.ConsultaPost.PostAsync(url, Parametros, usuario);

                    document.LoadHtml(Body);

                    HtmlAgilityPack.HtmlNode BodyNode = Nodos.GetNode(document.DocumentNode, "body");

                    //Confirma solo una vez el total de retiros y paginas encontradas.
                    if (RevisarTotal)
                    {
                        HtmlAgilityPack.HtmlNode TrTituloTotal = Nodos.GetNode(BodyNode, "tr", "class", "titulo");
                        HtmlAgilityPack.HtmlNode TdTituloTotal = Nodos.GetNode(TrTituloTotal, "td", "align", "right");
                        string msgEncontrados = TdTituloTotal.InnerHtml;
                        msgEncontrados = msgEncontrados.Replace("&nbsp;registros encontrados&nbsp;&nbsp;", "");
                        int Founded;
                        int.TryParse(msgEncontrados, out Founded);

                        if (Founded == 0)
                            return new List<Retiro>();
                        else
                        {
                            RevisarTotal = false;
                            paginaMaxima = int.Parse(Nodos.GetNode(BodyNode, "input", "name", "pagina_maximo").GetAttributeValue("value", ""));
                        }
                    }


                    HtmlAgilityPack.HtmlNode CuerpoTabla = Nodos.GetNode(BodyNode, "tbody", "class", "cuerpo_tabla");
                    HtmlAgilityPack.HtmlNodeCollection RetirosTabla = Nodos.GetNodes(CuerpoTabla, "tr", "id");

                    foreach (var fila in RetirosTabla)
                    {
                        Retiro RetiroToAdd = await GetDetalleAsync(int.Parse(fila.GetAttributeValue("id", "").Replace("reco_", "")), busquedaRetiros.Usuario);
                        RetiroToAdd.OrdenTrabajo = new Shared.Modelo.OT.OrdenTrabajo
                        {
                            Clasificacion = RetiroToAdd.Clasificacion,
                            Movil = RetiroToAdd.Movil,
                            Numero = Nodos.GetNodes(fila, "td")[16].InnerText == "" ? 0 : int.Parse(Nodos.GetNodes(fila, "td")[16].InnerText),
                            Comuna = RetiroToAdd.Comuna,
                        }; //Nodos.GetNodes(fila, "td")[16].InnerText;
                        RetiroToAdd.Estado = Nodos.GetNodes(fila, "td")[14].InnerText;
                        //RetiroToAdd.TrackingList = await Trackings.Obtencion.GetTracking(RetiroToAdd,usuario);
                        retiros.Add(RetiroToAdd);
                    }
                    paginaActual++;


                } while (paginaActual <= paginaMaxima);
                return retiros.AsEnumerable();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Retiro> GetDetalleAsync(int CodigoRetiro, Usuario usuario)
        {
            string url = $"recogidas_repartos/gen_recogidas_manual_form.do?codigo_rec={CodigoRetiro}&volver=&pendiente=&finalizada=null";
            string AmDesde;
            string AmHasta;
            string PmDesde;
            string PmHasta;
            Retiro retiro = new Retiro();
            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            HtmlAgilityPack.HtmlNode BodyNode;

            try
            {
                string Body = await (await serviceClient.Get(usuario)).GetAsync(url);
                document.LoadHtml(Body);

                BodyNode = Nodos.GetNode(document.DocumentNode, "body");


                //Creacion del objeto a devolver y sus parametros principales
                retiro.CodigoRetiro = CodigoRetiro;
                retiro.Nombre = Nodos.GetNode(BodyNode, "input", "name", "nombre").GetAttributeValue("value", "");
                retiro.CodigoCliente = Nodos.GetNode(BodyNode, "input", "name", "origen_codigo").GetAttributeValue("value", "");
                retiro.Direccion = Nodos.GetNode(BodyNode, "input", "name", "direccion").GetAttributeValue("value", "");
                retiro.CodigoPostal = int.Parse(Nodos.GetNode(BodyNode, "input", "name", "cp_codigo").GetAttributeValue("value", ""));
                retiro.Bultos = int.Parse(Nodos.GetNode(BodyNode, "input", "name", "bultos").GetAttributeValue("value", ""));
                retiro.Kilos = float.Parse(Nodos.GetNode(BodyNode, "input", "name", "kilos").GetAttributeValue("value", ""));
                retiro.Zona = Nodos.GetNode(BodyNode, "input", "name", "zonaRecogida").GetAttributeValue("value", "");
                retiro.Movil = Nodos.GetNode(BodyNode, "input", "name", "recogedor_codigo").GetAttributeValue("value", "") != "" ? new Movil(int.Parse(Nodos.GetNode(BodyNode, "input", "name", "recogedor_codigo").GetAttributeValue("value", "")), "", "") : null; //  Nodos.GetNode(BodyNode, "input", "name", "recogedor_codigo").GetAttributeValue("value", "");
                retiro.Contacto = Nodos.GetNode(BodyNode, "input", "name", "contacto").GetAttributeValue("value", "");
                retiro.Telefono = Nodos.GetNode(BodyNode, "input", "name", "telefono").GetAttributeValue("value", "");
                retiro.Observacion = Nodos.GetNode(BodyNode, "input", "name", "observaciones").GetAttributeValue("value", "");

                //cp_descripcion
                ////DEBUG
                //string cpString = retiro.CodigoPostal.ToString();
                //string cpStringTake3 = new string(cpString.Take(3).ToArray());
                //string cpStringReverse = new string(cpString.Reverse().ToArray());
                //string cpStringReverseTake3 = new string(cpStringReverse.Take(3).ToArray());
                //string cpStringReverseTake3Reverse = new string(cpStringReverseTake3.Reverse().ToArray());
                //string dd = new string(retiro.CodigoPostal.ToString().Reverse().Take(3).Reverse().ToArray());

                //var comuna = (await Comunas.GetTotalComunasAsync()).FirstOrDefault(c => new string(c.CodigoPostal.Take(3).ToArray()) ==
                //                                                                    new string(retiro.CodigoPostal.ToString().Take(3).ToArray()));
                //var comuna = (await serviceComuna.GetAllAsync()).FirstOrDefault(c => Enumerable.Range(int.Parse(c.CodigoPostal), int.Parse(c.CodigoPostalMax)).Contains(retiro.CodigoPostal));
                var comuna = (await serviceComuna.GetAllAsync()).FirstOrDefault(c => c.CodigoPostal <= retiro.CodigoPostal &&
                                                                                     c.CodigoPostalMax >= retiro.CodigoPostal);


                if (comuna == null)
                {
                    retiro.Comuna = new Shared.Modelo.Comunas.Comuna
                    {
                        Nombre = Nodos.GetNode(BodyNode, "input", "name", "cp_descripcion").GetAttributeValue("value", ""),
                        CodigoPostal = int.Parse(Nodos.GetNode(BodyNode, "input", "name", "cp_codigo").GetAttributeValue("value", "")),
                    };
                    retiro.NombreSector = Shared.Modelo.Comunas.NombreSector.Oriente;
                }
                else
                {
                    retiro.Comuna = comuna;
                    retiro.NombreSector = retiro.Comuna.NombreSector;
                }


                AmDesde = Nodos.GetNode(BodyNode, "input", "name", "horadesde").GetAttributeValue("value", "");
                DateTime.TryParse(AmDesde, out DateTime resultAmDesde);
                retiro.AmDesde = resultAmDesde;

                AmHasta = Nodos.GetNode(BodyNode, "input", "name", "horahasta").GetAttributeValue("value", "");
                DateTime.TryParse(AmHasta, out DateTime resultAmHasta);
                retiro.AmHasta = resultAmHasta;

                PmDesde = Nodos.GetNode(BodyNode, "input", "name", "horadesde1").GetAttributeValue("value", "");
                DateTime.TryParse(PmDesde, out DateTime resultPmDesde);
                retiro.PmDesde = resultPmDesde;

                PmHasta = Nodos.GetNode(BodyNode, "input", "name", "horahasta1").GetAttributeValue("value", "");
                DateTime.TryParse(PmHasta, out DateTime resultPmHasta);
                retiro.PmHasta = resultPmHasta;


                //Obtener Horario AM o PM
                if (retiro.AmHasta > DateTime.Parse("15:00") || retiro.PmHasta > DateTime.Parse("15:00"))
                    retiro.TipoHorario = TipoHorario.Pm;
                else
                    retiro.TipoHorario = TipoHorario.Am;


                //Obtener Tipo de Retiro
                if (retiro.Nombre.Contains("CDP"))
                    retiro.Clasificacion = Clasificacion.CDP;// "Cdp";
                else if (retiro.Nombre.Contains("Sucursal", StringComparison.CurrentCultureIgnoreCase))
                    retiro.Clasificacion = Clasificacion.Sucursal;// "Sucursal";
                else if (Nodos.GetNode(BodyNode, "span", "id", "recogida_fija").InnerHtml == "FIJA")
                    retiro.Clasificacion = Clasificacion.Fijo;// "Fijo";
                else if (Nodos.GetNode(BodyNode, "span", "id", "recogida_fija").InnerHtml == "MANUAL")
                    retiro.Clasificacion = Clasificacion.Eventual; // "Eventual";

                retiro.Asignar = true;
            }
            catch
            {
                throw;
            }

            return retiro;
        }
    }
}
