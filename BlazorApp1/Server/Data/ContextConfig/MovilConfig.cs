using BlazorApp1.Shared.Modelo.Comunas;
using BlazorApp1.Shared.Modelo.Moviles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorApp1.Server.Data.ContextConfig
{
    public class MovilConfig : IEntityTypeConfiguration<Movil>
    {
        public void Configure(EntityTypeBuilder<Movil> builder)
        {
            builder.HasIndex(m => new { m.Codigo }).IsUnique();
        }
    }
}
