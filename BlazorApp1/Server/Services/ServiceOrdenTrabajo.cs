using BlazorApp1.Server.Data;
using BlazorApp1.Shared.Modelo.Moviles;
using BlazorApp1.Shared.Modelo.OT;
using BlazorApp1.Shared.User;
using BlazorApp1.Shared.Utilities;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1.Server.Services
{
    public class ServiceOrdenTrabajo
    {
        private readonly ServiceClient serviceClient;
        private readonly IDbContextFactory<Context> contextFactory;

        public ServiceOrdenTrabajo(ServiceClient serviceClient, IDbContextFactory<Context> contextFactory)
        {
            this.serviceClient = serviceClient;
            this.contextFactory = contextFactory;
        }

        public async Task<OrdenTrabajo> CreateOrdenTrabajoAsync(OrdenViewModel ordenViewModel)
        {
            string url = $"recogidas_repartos/asignacion_aceptar.do";
            string Body;
            Dictionary<string, string> Parameters = new Dictionary<string, string>();
            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            HtmlAgilityPack.HtmlNode BodyNode;
            HtmlAgilityPack.HtmlNode TableNode;

            IDbContextTransaction transaction = null;
            using var context = await contextFactory.CreateDbContextAsync();

            try
            {
                Parameters.Add("url_vuelta", "");
                Parameters.Add("codigo", "");
                Parameters.Add("recogedor_repartidor_codigo", ordenViewModel.OrdenDeTrabajo.Movil.Codigo.ToString());
                Parameters.Add("recogedor_repartidor_descripcion", "");
                Parameters.Add("fecha", DateTime.Now.Date.ToShortDateString().Replace('-', '/'));
                var client = await serviceClient.Get(ordenViewModel.Usuario);
                Body = await client.PostAsync(url, Parameters); //await Shared.ClienteWeb.Consultas.ConsultaPost.PostAsync(url, Parameters, usuario);

                document.LoadHtml(Body);
                BodyNode = Nodos.GetNode(document.DocumentNode, "body");
                TableNode = Nodos.GetNode(BodyNode, "table", "class", "filtro");
                if (ordenViewModel.OrdenDeTrabajo.Movil.Codigo == 999)
                    ordenViewModel.OrdenDeTrabajo.Clasificacion = Shared.Modelo.Retiros.Clasificacion.Muelle;// "Muelle";

                ordenViewModel.OrdenDeTrabajo.Numero = int.Parse(Nodos.GetNode(TableNode, "input", "name", "codigo").GetAttributeValue("value", ""));
                ordenViewModel.OrdenDeTrabajo.Fecha = DateTime.Parse(Nodos.GetNode(TableNode, "input", "name", "fecha").GetAttributeValue("value", ""));
                ordenViewModel.OrdenDeTrabajo.Movil = ordenViewModel.OrdenDeTrabajo.Movil;

                //Dar Definitiva la OT
                await client.GetAsync($"recogidas_repartos/definitivas_ordenes_trabajo.do?definitivas={ordenViewModel.OrdenDeTrabajo.Numero}");

                var strategy = context.Database.CreateExecutionStrategy();
                await strategy.Execute(async () =>
                {
                    using (transaction = await context.Database.BeginTransactionAsync(System.Data.IsolationLevel.Snapshot))
                    {

                        context.Entry(ordenViewModel.OrdenDeTrabajo).State = EntityState.Added;

                        await context.SaveChangesAsync();
                        await transaction.CommitAsync();

                        //result = Ok(entidad);

                        /*
                         Lógica de Auditoría 
                            Clase auditoría 
                            auditoria.objeto = "AsientoContable";
                            auditoria.valor = AsientContable.Xml;
                            auditoria.Evento = Evento.Insert;
                         */
                    }
                });

            }
            catch
            {
                throw;
            }
            return ordenViewModel.OrdenDeTrabajo;


        }

        public async Task<bool> CerrarOrdenAsync(OrdenViewModel ordenViewModel)
        {
            string url = $"recogidas_repartos/control_dato.do?C=jsrs1&F=cerrar&P0=[{ordenViewModel.OrdenDeTrabajo.Numero}]&P1=[0]&P2=[]&P3=[]&P4=[]&P5=[]&P6=[]&P7=[N]&P8=[]&P9=[]&P10=[]&P11=[]&P12=[]&P13=[]&P14=[]&U=1651521585558";
            string body;
            bool estado = false;
            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            HtmlAgilityPack.HtmlNode TextAreaNode;

            try
            {

                body = await (await serviceClient.Get(ordenViewModel.Usuario)).GetAsync(url);
                document.LoadHtml(body);
                TextAreaNode = Nodos.GetNode(document.DocumentNode, "textarea");

                if (!TextAreaNode.InnerHtml.Contains("Error de base de datos en la"))
                {
                    estado = true;
                    ordenViewModel.OrdenDeTrabajo.Cerrada = true;
                    await UpdateAsync(ordenViewModel.OrdenDeTrabajo);
                }

            }
            catch
            {
                throw;
            }
            return estado;
        }
        private async Task<OrdenTrabajo> UpdateAsync(OrdenTrabajo ordenTrabajo)
        {
            IDbContextTransaction transaction = null;
            using var context = await contextFactory.CreateDbContextAsync();
            try
            {
                var strategy = context.Database.CreateExecutionStrategy();
                await strategy.Execute(async () =>
                {
                    using (transaction = await context.Database.BeginTransactionAsync(System.Data.IsolationLevel.Snapshot))
                    {
                        context.Entry(ordenTrabajo).State = EntityState.Modified;

                        await context.SaveChangesAsync();
                        await transaction.CommitAsync();

                        return ordenTrabajo;

                        /*
                         Lógica de Auditoría 
                            Clase auditoría 
                            auditoria.objeto = "AsientoContable";
                            auditoria.valor = AsientContable.Xml;
                            auditoria.Evento = Evento.Insert;
                         */
                    }
                });

            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
            finally
            {
                await context.DisposeAsync();
            }
            return ordenTrabajo;

        }
        public async Task<List<OrdenTrabajo>> GetOrdenesAsync()
        {
            List<OrdenTrabajo> entidad = new List<OrdenTrabajo>();
            IDbContextTransaction transaction = null;
            using var context = await contextFactory.CreateDbContextAsync();
            try
            {
                var strategy = context.Database.CreateExecutionStrategy();
                await strategy.Execute(async () =>
                {
                    using (transaction = await context.Database.BeginTransactionAsync(System.Data.IsolationLevel.ReadCommitted))
                    {
                        entidad = await context.OrdenTrabajos.ToListAsync();

                        await transaction.CommitAsync();

                        if (entidad != null)
                            return entidad;
                        else
                            return new List<OrdenTrabajo>();
                        /*
                         Lógica de Auditoría 
                            Clase auditoría 
                            auditoria.objeto = "AsientoContable";
                            auditoria.valor = AsientContable.Xml;
                            auditoria.Evento = Evento.Insert;
                         */
                    }
                });
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
            finally
            {
                await context.DisposeAsync();
            }
            return entidad;
        }
        public async Task<List<OrdenTrabajo>> GetOrdenesAsync(System.Linq.Expressions.Expression<Func<OrdenTrabajo, bool>> WhereExp)
        {
            List<OrdenTrabajo> entidad = new List<OrdenTrabajo>();
            IDbContextTransaction transaction = null;
            using var context = await contextFactory.CreateDbContextAsync();
            try
            {
                var strategy = context.Database.CreateExecutionStrategy();
                await strategy.Execute(async () =>
                {
                    using (transaction = await context.Database.BeginTransactionAsync(System.Data.IsolationLevel.ReadCommitted))
                    {
                        var debug = await context.OrdenTrabajos.ToListAsync();
                        var hoy = DateTime.Today;
                        //entidad = await context.OrdenTrabajos.Where(WhereExp).ToListAsync();
                        entidad = await context.OrdenTrabajos.Where(ot => ot.Fecha == DateTime.Today).ToListAsync();

                        await transaction.CommitAsync();

                        if (entidad != null)
                            return entidad;
                        else
                            return new List<OrdenTrabajo>();
                        /*
                         Lógica de Auditoría 
                            Clase auditoría 
                            auditoria.objeto = "AsientoContable";
                            auditoria.valor = AsientContable.Xml;
                            auditoria.Evento = Evento.Insert;
                         */
                    }
                });
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
            finally
            {
                await context.DisposeAsync();
            }
            return entidad;
        }
        public async Task<List<OrdenTrabajo>> GetOrdenesAsync(DateTime Desde, DateTime Hasta)
        {
            List<OrdenTrabajo> entidad = new List<OrdenTrabajo>();
            IDbContextTransaction transaction = null;
            using var context = await contextFactory.CreateDbContextAsync();
            try
            {
                var strategy = context.Database.CreateExecutionStrategy();
                await strategy.Execute(async () =>
                {
                    using (transaction = await context.Database.BeginTransactionAsync(System.Data.IsolationLevel.ReadCommitted))
                    {
                        var debug = await context.OrdenTrabajos.ToListAsync();
                        var hoy = DateTime.Today;
                        //entidad = await context.OrdenTrabajos.Where(WhereExp).ToListAsync();
                        entidad = await context.OrdenTrabajos.Where(ot => ot.Fecha.DayOfYear >= Desde.DayOfYear &&
                                                                          ot.Fecha.DayOfYear < Hasta.DayOfYear && !ot.Cerrada).ToListAsync();

                        await transaction.CommitAsync();

                        if (entidad != null)
                            return entidad;
                        else
                            return new List<OrdenTrabajo>();
                        /*
                         Lógica de Auditoría 
                            Clase auditoría 
                            auditoria.objeto = "AsientoContable";
                            auditoria.valor = AsientContable.Xml;
                            auditoria.Evento = Evento.Insert;
                         */
                    }
                });
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
            finally
            {
                await context.DisposeAsync();
            }
            return entidad;
        }
        public async Task<OrdenTrabajo?> GetOrdenAsync(System.Linq.Expressions.Expression<Func<OrdenTrabajo, bool>> FirstExp)
        {
            OrdenTrabajo? entidad = new OrdenTrabajo();
            IDbContextTransaction transaction = null;
            using var context = await contextFactory.CreateDbContextAsync();
            try
            {
                var strategy = context.Database.CreateExecutionStrategy();
                await strategy.Execute(async () =>
                {
                    using (transaction = await context.Database.BeginTransactionAsync(System.Data.IsolationLevel.ReadCommitted))
                    {
                        entidad = await context.OrdenTrabajos.FirstOrDefaultAsync(FirstExp);

                        await transaction.CommitAsync();

                        /*
                         Lógica de Auditoría 
                            Clase auditoría 
                            auditoria.objeto = "AsientoContable";
                            auditoria.valor = AsientContable.Xml;
                            auditoria.Evento = Evento.Insert;
                         */
                    }
                });
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
            finally
            {
                await context.DisposeAsync();
            }
            return entidad;
        }
        public async Task<List<OrdenTrabajo>> GetOrdenesAsync(FiltroBusquedaOrdenTrabajo filtro)
        {
            try
            {

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

                do
                {
                    string url = $"recogidas_repartos/ordenes_trabajo_consulta.do?buscar=true";

                    Dictionary<string, string> Parameters = new Dictionary<string, string>();
                    Parameters.Add("tipo_error", "");
                    Parameters.Add("mensaje", "");
                    Parameters.Add("pagina", PaginaActual.ToString());
                    Parameters.Add("masivo", "N");
                    Parameters.Add("repartidor_recogedor_codigo", filtro.Recogedor.Codigo != 0 ? filtro.Recogedor.Codigo.ToString() : "");
                    Parameters.Add("repartidor_recogedor_descripcion", "");
                    Parameters.Add("crr_codigo", "");
                    Parameters.Add("crr_descripcion", "");
                    Parameters.Add("estado", filtro.Estado.ToString());
                    Parameters.Add("codigo", filtro.Ot.ToString());
                    Parameters.Add("fecha_desde", filtro.FechaDesde.ToUniversalTime().ToShortDateString().Replace('-', '/'));
                    Parameters.Add("fecha_hasta", filtro.FechaHasta.ToUniversalTime().ToShortDateString().Replace('-', '/'));
                    Parameters.Add("numero_envio", "");
                    Parameters.Add("incluir_ots_crr", "N");


                    string Body = await (await serviceClient.Get(filtro.Usuario)).PostAsync(url, Parameters); // await Shared.ClienteWeb.Consultas.ConsultaPost.PostAsync(url, Parameters, usuario);


                    doc.LoadHtml(Body);
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
                            ordenToAdd.Numero = int.Parse(DetalleListaOtNode[0].InnerHtml);
                        else
                            ordenToAdd.Numero = int.Parse(nodoNumero.InnerHtml);
                        ordenToAdd.Movil = new Movil(int.Parse(DetalleListaOtNode[1].InnerHtml), "", ""); //DetalleListaOtNode[1].InnerHtml;
                        ordenToAdd.Estado = DetalleListaOtNode[4].InnerHtml;
                        ordenToAdd.Fecha = DateTime.Parse(DetalleListaOtNode[5].InnerHtml).ToUniversalTime();
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

                return ordenTrabajos.Where(ot => ot.Repartos == 0).ToList();

            }
            catch
            {
                throw;
            }
        }
    }
}
