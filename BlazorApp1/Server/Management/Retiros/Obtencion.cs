using BlazorApp1.Shared.User;
using BlazorApp1.Shared.Modelo.Monitor;
using BlazorApp1.Shared.Modelo.Retiros;
using BlazorApp1.Shared.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Server.Management.Retiros
{
    public class Obtencion
    {
        private static string _Body = string.Empty;
        private static int _PaginaActual = 1;
        private static int _PaginaMaxima = 0;

        private static async Task GetBodyRetirosAsync(string TipoEntrada, string Comuna, DateTime FechaDesde,
                                                       DateTime FechaHasta, string EstadoRetiro, int Movil,
                                                       string CodCliente, string Zona, IUsuario usuario)
        {
            string url = $"recogidas_repartos/recogidas_consulta.do";

            Dictionary<string, string> Parametros = new Dictionary<string, string>();
            Parametros.Add("pagina", _PaginaActual.ToString());
            Parametros.Add("sinZona_check", "false");
            Parametros.Add("codigo", "");
            Parametros.Add("tipo_servicio", "");
            Parametros.Add("estado", EstadoRetiro);
            Parametros.Add("recogedor_codigo", MobileNumber.ToCCMobileNumber(Movil));
            Parametros.Add("telefono", "");
            Parametros.Add("tipo_origen", "");
            Parametros.Add("tipo_entrada", TipoEntrada);
            Parametros.Add("codpRecogida_codigo", Comuna);
            Parametros.Add("codpDestino_codigo", "");
            Parametros.Add("cliente_codigo", CodCliente);
            Parametros.Add("cliente_descripcion", "");
            Parametros.Add("deleDestino_codigo", "");
            Parametros.Add("deleDestino_descripcion", "");
            Parametros.Add("fecha_desde_aux", FechaDesde.ToShortDateString().Replace('-', '/'));
            Parametros.Add("fecha_hasta_aux", FechaHasta.ToShortDateString().Replace('-', '/'));
            Parametros.Add("zona_codigo", Zona);
            Parametros.Add("conIncidencia", "");
            Parametros.Add("incidencia_codigo", "");
            Parametros.Add("documentada", "");
            Parametros.Add("autorizacion", "");

            _Body = await Shared.ClienteWeb.Consultas.ConsultaPost.PostAsync(url, Parametros, usuario);
        }

        public static async Task<List<Retiro>> GetRetirosAsync(string TipoEntrada, string Comuna, DateTime FechaDesde,
                                                       DateTime FechaHasta,IUsuario usuario, string EstadoRetiro = "",
                                                       int Movil = 0, string CodCliente = "", string Zona = "")
        {
            _Body = String.Empty;
            _PaginaActual = 1;
            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            List<Retiro> retiros = new List<Retiro>();
            bool RevisarTotal = true;
            try
            {

                do
                {
                    await GetBodyRetirosAsync(TipoEntrada, Comuna, FechaDesde, FechaHasta, EstadoRetiro, Movil, CodCliente, Zona, usuario);

                    document.LoadHtml(_Body);

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
                            _PaginaMaxima = int.Parse(Nodos.GetNode(BodyNode, "input", "name", "pagina_maximo").GetAttributeValue("value", ""));
                        }
                    }


                    HtmlAgilityPack.HtmlNode CuerpoTabla = Nodos.GetNode(BodyNode, "tbody", "class", "cuerpo_tabla");
                    HtmlAgilityPack.HtmlNodeCollection RetirosTabla = Nodos.GetNodes(CuerpoTabla, "tr", "id");

                    foreach (var fila in RetirosTabla)
                    {
                        Retiro RetiroToAdd = await GetDetalleAsync(int.Parse(fila.GetAttributeValue("id", "").Replace("reco_", "")), usuario);
                        //RetiroToAdd.Ot = //recorrer el nodo fila para encontrar el de la OT
                        retiros.Add(RetiroToAdd);
                    }
                    _PaginaActual++;

                } while (_PaginaActual <= _PaginaMaxima);

                return retiros;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            return retiros;
        }

        public static async IAsyncEnumerable<Retiro> GetRetirosAsyncYield(string TipoEntrada, string Comuna, DateTime FechaDesde,
                                                       DateTime FechaHasta, IUsuario usuario, string EstadoRetiro = "", int Movil = 0,
                                                       string CodCliente = "", string Zona = "")
        {
            _Body = String.Empty;
            _PaginaActual = 1;
            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            List<Retiro> retiros = new List<Retiro>();
            bool RevisarTotal = true;

            do
            {
                await GetBodyRetirosAsync(TipoEntrada, Comuna, FechaDesde, FechaHasta, EstadoRetiro, Movil, CodCliente, Zona, usuario);

                document.LoadHtml(_Body);

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
                        yield break;
                    else
                    {
                        RevisarTotal = false;
                        _PaginaMaxima = int.Parse(Nodos.GetNode(BodyNode, "input", "name", "pagina_maximo").GetAttributeValue("value", ""));
                    }
                }


                HtmlAgilityPack.HtmlNode CuerpoTabla = Nodos.GetNode(BodyNode, "tbody", "class", "cuerpo_tabla");
                HtmlAgilityPack.HtmlNodeCollection RetirosTabla = Nodos.GetNodes(CuerpoTabla, "tr", "id");

                foreach (var fila in RetirosTabla)
                {
                    Retiro RetiroToAdd = await GetDetalleAsync(int.Parse(fila.GetAttributeValue("id", "").Replace("reco_", "")), usuario);
                    //RetiroToAdd.Ot = //recorrer el nodo fila para encontrar el de la OT
                    yield return RetiroToAdd;
                }
                _PaginaActual++;
            } while (_PaginaActual <= _PaginaMaxima);

        }

        public static async Task<Retiro> GetDetalleAsync(int CodigoRetiro, IUsuario usuario)
        {
            _Body = String.Empty;
            string url = $"recogidas_repartos/gen_recogidas_manual_form.do?codigo_rec={CodigoRetiro}&volver=&pendiente=&finalizada=null";
            string AmDesde;
            string PmDesde;
            Retiro retiro = new Retiro();
            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            HtmlAgilityPack.HtmlNode BodyNode;

            try
            {
                _Body = await ClienteWeb.Consultas.ConsultaGet.GetAsync(url, usuario);
                document.LoadHtml(_Body);

                BodyNode = Nodos.GetNode(document.DocumentNode, "body");

                //Creacion del objeto a devolver y sus parametros principales
                retiro.CodigoRetiro = CodigoRetiro.ToString();
                retiro.Nombre = Nodos.GetNode(BodyNode, "input", "name", "nombre").GetAttributeValue("value", "");
                retiro.CodigoCliente = Nodos.GetNode(BodyNode, "input", "name", "origen_codigo").GetAttributeValue("value", "");
                retiro.Direccion = Nodos.GetNode(BodyNode, "input", "name", "direccion").GetAttributeValue("value", "");
                retiro.Comuna = Nodos.GetNode(BodyNode, "input", "name", "cp_descripcion").GetAttributeValue("value", "");
                retiro.CodigoPostal = Nodos.GetNode(BodyNode, "input", "name", "cp_codigo").GetAttributeValue("value", "");
                retiro.Bultos = Nodos.GetNode(BodyNode, "input", "name", "bultos").GetAttributeValue("value", "");
                retiro.Kilos = Nodos.GetNode(BodyNode, "input", "name", "kilos").GetAttributeValue("value", "");
                retiro.Zona = Nodos.GetNode(BodyNode, "input", "name", "zonaRecogida").GetAttributeValue("value", "");
                retiro.Movil = Nodos.GetNode(BodyNode, "input", "name", "recogedor_codigo").GetAttributeValue("value", "");
                retiro.Contacto = Nodos.GetNode(BodyNode, "input", "name", "contacto").GetAttributeValue("value", "");
                retiro.Telefono = Nodos.GetNode(BodyNode, "input", "name", "telefono").GetAttributeValue("value", "");
                retiro.Observacion = Nodos.GetNode(BodyNode, "input", "name", "observaciones").GetAttributeValue("value", "");

                AmDesde = Nodos.GetNode(BodyNode, "input", "name", "horadesde").GetAttributeValue("value", "");
                PmDesde = Nodos.GetNode(BodyNode, "input", "name", "horadesde1").GetAttributeValue("value", "");


                //Determinacion de Horario AM o PM
                if (!AmDesde.Equals(""))
                {
                    string amHasta = Nodos.GetNode(BodyNode, "input", "name", "horahasta").GetAttributeValue("value", "");
                    retiro.AmDesde = DateTime.Parse(AmDesde);
                    retiro.AmHasta = DateTime.Parse(amHasta);
                    if (DateTime.Parse(amHasta) <= DateTime.Parse("15:00"))
                        retiro.TipoRetiro = "AM";
                    else
                        retiro.TipoRetiro = "PM";
                }
                if (!PmDesde.Equals(""))
                {
                    string pmHasta = Nodos.GetNode(BodyNode, "input", "name", "horahasta1").GetAttributeValue("value", "");
                    retiro.PmDesde = DateTime.Parse(PmDesde);
                    retiro.PmHasta = DateTime.Parse(pmHasta);
                    if (DateTime.Parse(pmHasta) <= DateTime.Parse("15:00"))
                        retiro.TipoRetiro = "AM";
                    else
                        retiro.TipoRetiro = "PM";
                }


                //Obtener Tipo de Retiro
                if (retiro.Nombre.Contains("CDP"))
                    retiro.SubTipoRetiro = "Cdp";
                else if (retiro.Nombre.Contains("Sucursal", StringComparison.CurrentCultureIgnoreCase))
                    retiro.SubTipoRetiro = "Sucursal";
                else if (Nodos.GetNode(BodyNode, "span", "id", "recogida_fija").InnerHtml == "FIJA")
                    retiro.SubTipoRetiro = "Fijo";
                else if (Nodos.GetNode(BodyNode, "span", "id", "recogida_fija").InnerHtml == "MANUAL")
                    retiro.SubTipoRetiro = "Eventual";

                retiro.Asignar = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return retiro;
        }

        public static async Task<List<Retiro>> GetReporteSucursalesAsync(DateTime FechaSolicitud, IUsuario usuario)
        {
            Dictionary<string, string> Sucursales = Shared.Utilities.Sucursales.GetSucursales();
            List<Retiro> Retiros = new List<Retiro>();
            try
            {

                foreach (KeyValuePair<string, string> sucursal in Sucursales)
                {
                    List<Retiro> retiroToAdd = await GetRetirosAsync("COURIER", "", FechaSolicitud, FechaSolicitud, usuario, "", CodCliente: sucursal.Value); //await StaticRetirosManagement.GetRetirosEnumerable("", "COURIER", "", fechaTrabajable, fechaTrabajable, "", sucursal.Value);
                    Tracking trackingActual = new Tracking();
                    Retiro retiroActual = new Retiro();
                    if (retiroToAdd == null)
                        continue;
                    if (retiroToAdd.Count == 0)
                        continue;

                    retiroActual = retiroToAdd.Where(r => r.PmHasta != DateTime.Parse("0:00") &&
                                                          r.PmDesde != DateTime.Parse("0:00") &&
                                                          r.TipoRetiro == "PM" &&
                                                          !r.Contacto.Contains("RETIRO POSTAL") &&
                                                          r.Movil != "864999").FirstOrDefault();

                    if (retiroActual == null)
                        continue;

                    retiroActual.TrackingList = await Trackings.Obtencion.GetTracking(retiroActual, usuario);
                    //await retiroActual.GetTrackingList();

                    if (retiroActual.TrackingList.Count == 0)
                        continue;
                    else
                        trackingActual = retiroActual.TrackingList.LastOrDefault(t => t.Tipo.Equals("DIAF") || t.Tipo.Equals("DIAR"));

                    if (trackingActual == null)
                        continue;

                    retiroActual.TrackingList.Clear();
                    retiroActual.TrackingList.Add(trackingActual);

                    Retiros.Add(retiroActual);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Retiros;
        }
        public static async IAsyncEnumerable<Retiro> GetReporteSucursalesAsyncYield(DateTime FechaSolicitud, IUsuario usuario )
        {
            Dictionary<string, string> Sucursales = Shared.Utilities.Sucursales.GetSucursales();
            foreach (KeyValuePair<string, string> sucursal in Sucursales)
            {
                List<Retiro> retiroToAdd = await GetRetirosAsync("COURIER", "", FechaSolicitud, FechaSolicitud, usuario, "", CodCliente: sucursal.Value); //await StaticRetirosManagement.GetRetirosEnumerable("", "COURIER", "", fechaTrabajable, fechaTrabajable, "", sucursal.Value);
                Tracking trackingActual = new Tracking();
                Retiro retiroActual = new Retiro();
                if (retiroToAdd == null)
                    continue;
                if (retiroToAdd.Count == 0)
                    continue;

                retiroActual = retiroToAdd.Where(r => r.PmHasta != DateTime.Parse("0:00") &&
                                                      r.PmDesde != DateTime.Parse("0:00") &&
                                                      !r.Contacto.Contains("RETIRO POSTAL") &&
                                                      r.Movil != "864999" &&
                                                      r.TipoRetiro == "PM").LastOrDefault();

                if (retiroActual == null)
                    continue;

                retiroActual.TrackingList = await Trackings.Obtencion.GetTracking(retiroActual, usuario);

                //await retiroActual.GetTrackingList();

                //if (retiroActual.TrackingList.Count == 0)
                //    continue;
                //else
                trackingActual = retiroActual.TrackingList.LastOrDefault(t => t.Tipo.Equals("DIAF") || t.Tipo.Equals("DIAR"));

                if (trackingActual == null)
                    trackingActual = new Tracking();

                retiroActual.TrackingList.Clear();
                retiroActual.TrackingList.Add(trackingActual);

                yield return retiroActual;
            }
        }
        public static async Task<List<MovilDetalle>> GetDetalleFromMCAsync(DateTime Fecha, IUsuario usuario)
        {
            List<MovilDetalle> ret = new List<MovilDetalle>();
            string url = $"http://wsadmpdas.icorreos.cl/api/v1/tpt/vistageneral/cuadraturaretiros/864/{Fecha.ToString("yyyy-MM-dd")}";
            string jsonList = "";

            try
            {
                jsonList = await ClienteWeb.Consultas.ConsultaGet.GetFromMcAsync(url, usuario);
                if (jsonList.Equals("No se encontraron registros"))
                    throw new Exception("No se encontraron registros");
                var result = JsonConvert.DeserializeObject<List<MovilDetalle>>(jsonList);
                if(result is not null)
                    ret = result.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }

            return ret;
        }
        
        public static async Task<List<Retiro>> GetTotalFromMCAsync(MovilDetalle movilDetalle, EstadoDetalleMc Estado, DateTime Fecha, IUsuario usuario)
        {
            List<Retiro> ret = new List<Retiro>();
            // ttp://wsadmpdas.icorreos.cl/api/v1/tpt/vistageneral/cuadraturaretiros/detalle/TOTAL/864255/2022-09-11
            string url = $"http://wsadmpdas.icorreos.cl/api/v1/tpt/vistageneral/cuadraturaretiros/detalle/{Estado.ToString()}/{movilDetalle.usuario}/{Fecha.ToString("yyyy-MM-dd")}";
            string jsonList = "";

            try
            {
                jsonList = await ClienteWeb.Consultas.ConsultaGet.GetFromMcAsync(url, usuario);
                if (jsonList.Equals("No se encontraron registros"))
                    throw new Exception("No se encontraron registros");
                dynamic result = JsonConvert.DeserializeObject<object[]>(jsonList);
                if (result is not null)
                    foreach (var rst in result)
                    {
                        string numeroRetiroStr = rst.numeroSolicitud;
                        int numeroRetiro = int.Parse(numeroRetiroStr);
                        Retiro retiro = await GetDetalleAsync(numeroRetiro, usuario);
                        ret.Add(retiro);
                        //Console.WriteLine(rst.numeroSolicitud);
                    }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //throw new Exception(jsonList);
            }

            return ret;
        }

    }
}
