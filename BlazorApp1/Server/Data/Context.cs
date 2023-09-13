using BlazorApp1.Server.Data.ContextConfig;
using BlazorApp1.Shared.Modelo.Comunas;
using BlazorApp1.Shared.Modelo.Moviles;
using BlazorApp1.Shared.Modelo.OT;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Server.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        { }
        public DbSet<Comuna> Comunas => Set<Comuna>();
        public DbSet<Movil> Moviles => Set<Movil>();
        public DbSet<OrdenTrabajo> OrdenTrabajos => Set<OrdenTrabajo>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ComunaConfig());
            modelBuilder.ApplyConfiguration(new OrdenTrabajoConfig());

        }
    }
}
