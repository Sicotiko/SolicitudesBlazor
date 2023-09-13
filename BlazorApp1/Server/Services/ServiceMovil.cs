using BlazorApp1.Server.Data;
using BlazorApp1.Shared.Modelo.Moviles;
using BlazorApp1.Shared.Modelo.OT;
using BlazorApp1.Shared.User;
using BlazorApp1.Shared.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlazorApp1.Server.Services
{
    public class ServiceMovil
    {
        private readonly ServiceClient serviceClient;
        private readonly IDbContextFactory<Context> contextFactory;

        public ServiceMovil(ServiceClient serviceClient, IDbContextFactory<Context> contextFactory)
        {
            this.serviceClient = serviceClient;
            this.contextFactory = contextFactory;
        }

        private async Task<List<Movil>> AddAsync(IEnumerable<Movil> moviles)
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
                        foreach (var movil in moviles)
                        {

                            if (await context.Moviles.FirstOrDefaultAsync(m => m.Codigo == movil.Codigo) is Movil movilFounded)
                            {
                                movilFounded.Tipo = movil.Tipo;
                                movilFounded.Nombre = movil.Nombre;
                                movilFounded.Codigo = movil.Codigo;
                                context.Moviles.Update(movilFounded);
                                //context.Entry(movil).State = EntityState.Modified;
                            }
                            else
                                context.Entry(movil).State = EntityState.Added;
                        }

                        await context.SaveChangesAsync();
                        await transaction.CommitAsync();

                        return moviles.ToList();

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
            return moviles.ToList();

        }
        private async Task<List<Movil>> GetAllAsync()
        {
            List<Movil> moviles = new List<Movil>();
            IDbContextTransaction transaction = null;
            using var context = await contextFactory.CreateDbContextAsync();
            try
            {
                var strategy = context.Database.CreateExecutionStrategy();
                await strategy.Execute(async () =>
                {
                    using (transaction = await context.Database.BeginTransactionAsync(System.Data.IsolationLevel.ReadCommitted))
                    {
                        moviles = await context.Moviles.ToListAsync();

                        await context.SaveChangesAsync();
                        await transaction.CommitAsync();

                        return moviles.ToList();

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
            return moviles;

        }

        public async Task<IEnumerable<Movil>> GetMovilesDisponibles(Usuario usuario)
        {
            try
            {
                string Url = "selector_generico.do";
                Dictionary<string, string> Parameters = new Dictionary<string, string>();

                Parameters.Add("aaxmlrequest", "true");
                Parameters.Add("selector_campo", "");
                Parameters.Add("selector_tipo", "recogedores_repartidores");
                Parameters.Add("campos_visibles", "");
                //for (int i = 0; i < 10; i++)
                Parameters.Add("selector_campo_filtro", "");
                //for (int i = 0; i < 10; i++)
                Parameters.Add("selector_filtro", "");

                string body = await (await serviceClient.Get(usuario)).PostAsync(Url, Parameters);
                //string body = await Shared.ClienteWeb.Consultas.ConsultaPost.PostAsync(Url, Parameters, usuario);


                HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
                List<Movil> Movilles = new List<Movil>();

                document.LoadHtml(body);

                HtmlAgilityPack.HtmlNode TableBodyNode = Nodos.GetNode(document.DocumentNode, "tbody", "class", "cuerpo_tabla");

                HtmlAgilityPack.HtmlNodeCollection FilasTableNode = Nodos.GetNodes(TableBodyNode, "tr");

                foreach (var fila in FilasTableNode)
                {
                    HtmlAgilityPack.HtmlNodeCollection columnas = Nodos.GetNodes(fila, "td");
                    string codigo = columnas[0].InnerText;
                    string nombre = columnas[1].InnerText;
                    string tipo = columnas[2].InnerText;

                    Movilles.Add(new Movil(int.Parse(codigo), nombre, tipo));
                }
                var movilesToReturn = Movilles.Where(m => m.Codigo >= 864000 && m.Codigo <= 864999);
                await AddAsync(movilesToReturn);

                return await GetAllAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
