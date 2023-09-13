using BlazorApp1.Shared.Modelo.OT;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorApp1.Server.Data.ContextConfig
{
    public class OrdenTrabajoConfig : IEntityTypeConfiguration<OrdenTrabajo>
    {
        public void Configure(EntityTypeBuilder<OrdenTrabajo> builder)
        {
            builder.HasIndex(ot => new { ot.Numero }).IsUnique();

            builder.HasOne(ot => ot.Movil);
            builder.HasOne(ot => ot.Comuna);
            builder.Navigation(ot => ot.Comuna).AutoInclude();
            builder.Navigation(ot => ot.Movil).AutoInclude();
        }
    }
}
