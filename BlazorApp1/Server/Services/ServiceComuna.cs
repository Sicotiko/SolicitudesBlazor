using BlazorApp1.Server.Data;
using BlazorApp1.Shared.Modelo.Comunas;
using BlazorApp1.Shared.Modelo.OT;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace BlazorApp1.Server.Services
{
    public class ServiceComuna
    {
        private readonly IDbContextFactory<Context> contextFactory;

        public ServiceComuna(IDbContextFactory<Context> contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        public async Task<Comuna> AddAsync(Comuna comuna)
        {
            IDbContextTransaction transaction = null;
            try
            {
                using var context = await contextFactory.CreateDbContextAsync();
                var strategy = context.Database.CreateExecutionStrategy();
                await strategy.Execute(async () =>
                {
                    using (transaction = await context.Database.BeginTransactionAsync(System.Data.IsolationLevel.Snapshot))
                    {
                        context.Entry(comuna).State = EntityState.Added;

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
            return comuna;
        }

        public async Task<Comuna> UpdateAsync(Comuna comuna)
        {
            IDbContextTransaction transaction = null;
            try
            {
                using var context = await contextFactory.CreateDbContextAsync();
                var strategy = context.Database.CreateExecutionStrategy();
                await strategy.Execute(async () =>
                {
                    using (transaction = await context.Database.BeginTransactionAsync(System.Data.IsolationLevel.Snapshot))
                    {
                        context.Entry(comuna).State = EntityState.Modified;

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
            return comuna;
        }
        public async Task<List<Comuna>> GetAllAsync()
        {
            IDbContextTransaction transaction = null;
            List<Comuna> comunas = new List<Comuna>();
            try
            {
                using var context = await contextFactory.CreateDbContextAsync();
                var strategy = context.Database.CreateExecutionStrategy();
                await strategy.Execute(async () =>
                {
                    using (transaction = await context.Database.BeginTransactionAsync(System.Data.IsolationLevel.ReadCommitted))
                    {
                        comunas = await context.Comunas.ToListAsync();
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
            return comunas;
        }
        public async Task<List<Comuna>> GetSomeAsync(System.Linq.Expressions.Expression<Func<Comuna, bool>> WhereEpr)
        {
            IDbContextTransaction transaction = null;
            List<Comuna> comunas = new List<Comuna>();
            try
            {
                using var context = await contextFactory.CreateDbContextAsync();
                var strategy = context.Database.CreateExecutionStrategy();
                await strategy.Execute(async () =>
                {
                    using (transaction = await context.Database.BeginTransactionAsync(System.Data.IsolationLevel.ReadCommitted))
                    {
                        comunas = await context.Comunas.Where(WhereEpr).ToListAsync();
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
            return comunas;
        }
        public async Task<Comuna?> GetOneAsync(System.Linq.Expressions.Expression<Func<Comuna, bool>> FirstEpr)
        {
            IDbContextTransaction transaction = null;
            Comuna? comuna = null;
            try
            {
                using var context = await contextFactory.CreateDbContextAsync();
                var strategy = context.Database.CreateExecutionStrategy();
                await strategy.Execute(async () =>
                {
                    using (transaction = await context.Database.BeginTransactionAsync(System.Data.IsolationLevel.ReadCommitted))
                    {
                        comuna = await context.Comunas.FirstOrDefaultAsync(FirstEpr);
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
            return comuna;
        }
    }
}
