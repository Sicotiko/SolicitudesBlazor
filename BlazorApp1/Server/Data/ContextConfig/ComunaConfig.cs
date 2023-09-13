using BlazorApp1.Shared.Modelo.Comunas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorApp1.Server.Data.ContextConfig
{
    public class ComunaConfig : IEntityTypeConfiguration<Comuna>
    {
        public void Configure(EntityTypeBuilder<Comuna> builder)
        {
            builder.HasIndex(c => new { c.CodigoPostal }).IsUnique();

            builder.HasData(new Comuna { Id = 58, Nombre = "Colina", CodigoPostal = 9340000, NombreSector = NombreSector.Norte, CodigoPostalMax = 9379999 },
            new Comuna { Id = 1, Nombre = "Lampa", CodigoPostal = 9380000, NombreSector = NombreSector.Norte, CodigoPostalMax = 9419999 },
            new Comuna { Id = 2, Nombre = "TilTil", CodigoPostal = 9420000, NombreSector = NombreSector.Norte, CodigoPostalMax = 9459999 },
            new Comuna { Id = 3, Nombre = "Pirque", CodigoPostal = 9480000, NombreSector = NombreSector.NorteExtra, CodigoPostalMax = 9499999 },
            new Comuna { Id = 4, Nombre = "Puente Alto", CodigoPostal = 8150000, NombreSector = NombreSector.Oriente, CodigoPostalMax = 8239999 },
            new Comuna { Id = 5, Nombre = "San José de Maipo", CodigoPostal = 9460000, NombreSector = NombreSector.SantiagoExtra, CodigoPostalMax = 9479999 },
            new Comuna { Id = 6, Nombre = "Buin", CodigoPostal = 9500000, NombreSector = NombreSector.NorteExtra, CodigoPostalMax = 9539999 },
            new Comuna { Id = 7, Nombre = "Calera de Tango", CodigoPostal = 9560000, NombreSector = NombreSector.SantiagoExtra, CodigoPostalMax = 9579999 },
            new Comuna { Id = 8, Nombre = "Paine", CodigoPostal = 9540000, NombreSector = NombreSector.NorteExtra, CodigoPostalMax = 9559999 },
            new Comuna { Id = 9, Nombre = "San Bernardo", CodigoPostal = 8050000, NombreSector = NombreSector.SantiagoExtra, CodigoPostalMax = 8149999 },
            new Comuna { Id = 10, Nombre = "Alhué", CodigoPostal = 9650000, NombreSector = NombreSector.SantiagoExtra, CodigoPostalMax = 9659999 },
            new Comuna { Id = 11, Nombre = "Curacaví", CodigoPostal = 9630000, NombreSector = NombreSector.SantiagoExtra, CodigoPostalMax = 9649999 },
            new Comuna { Id = 12, Nombre = "María Pinto", CodigoPostal = 9620000, NombreSector = NombreSector.SantiagoExtra, CodigoPostalMax = 9629999 },
            new Comuna { Id = 13, Nombre = "Melipilla", CodigoPostal = 9580000, NombreSector = NombreSector.SantiagoExtra, CodigoPostalMax = 9619999 },
            new Comuna { Id = 14, Nombre = "San Pedro", CodigoPostal = 9660000, NombreSector = NombreSector.SantiagoExtra, CodigoPostalMax = 9669999 },
            new Comuna { Id = 15, Nombre = "Cerrillos", CodigoPostal = 9200000, NombreSector = NombreSector.Oriente, CodigoPostalMax = 9249999 },
            new Comuna { Id = 16, Nombre = "Cerro Navia", CodigoPostal = 9080000, NombreSector = NombreSector.Norte, CodigoPostalMax = 9119999 },
            new Comuna { Id = 17, Nombre = "Conchalí", CodigoPostal = 8540000, NombreSector = NombreSector.Norte, CodigoPostalMax = 8579999 },
            new Comuna { Id = 18, Nombre = "El Bosque", CodigoPostal = 8010000, NombreSector = NombreSector.NorteExtra, CodigoPostalMax = 8049999 },
            new Comuna { Id = 19, Nombre = "Estación Central", CodigoPostal = 9160000, NombreSector = NombreSector.Norte, CodigoPostalMax = 9199999 },
            new Comuna { Id = 20, Nombre = "Huechuraba", CodigoPostal = 8580000, NombreSector = NombreSector.Norte, CodigoPostalMax = 8639999 },
            new Comuna { Id = 21, Nombre = "Independencia", CodigoPostal = 8380000, NombreSector = NombreSector.Norte, CodigoPostalMax = 8419999 },
            new Comuna { Id = 22, Nombre = "La Cisterna", CodigoPostal = 7970000, NombreSector = NombreSector.NorteExtra, CodigoPostalMax = 8009999 },
            new Comuna { Id = 23, Nombre = "La Florida", CodigoPostal = 8240000, NombreSector = NombreSector.Oriente, CodigoPostalMax = 8319999 },
            new Comuna { Id = 24, Nombre = "La Granja", CodigoPostal = 8780000, NombreSector = NombreSector.Oriente, CodigoPostalMax = 8819999 },
            new Comuna { Id = 25, Nombre = "La Pintana", CodigoPostal = 8820000, NombreSector = NombreSector.Oriente, CodigoPostalMax = 8859999 },
            new Comuna { Id = 26, Nombre = "La Reina", CodigoPostal = 7850000, NombreSector = NombreSector.Oriente, CodigoPostalMax = 7909999 },
            new Comuna { Id = 27, Nombre = "Las Condes", CodigoPostal = 7550000, NombreSector = NombreSector.Oriente, CodigoPostalMax = 7629999 },
            new Comuna { Id = 28, Nombre = "Lo Barnechea", CodigoPostal = 7690000, NombreSector = NombreSector.Oriente, CodigoPostalMax = 7749999 },
            new Comuna { Id = 29, Nombre = "Lo Espejo", CodigoPostal = 9120000, NombreSector = NombreSector.NorteExtra, CodigoPostalMax = 9159999 },
            new Comuna { Id = 30, Nombre = "Lo Prado", CodigoPostal = 8980000, NombreSector = NombreSector.Norte, CodigoPostalMax = 9019999 },
            new Comuna { Id = 31, Nombre = "Macul", CodigoPostal = 7810000, NombreSector = NombreSector.Oriente, CodigoPostalMax = 7849999 },
            new Comuna { Id = 32, Nombre = "Maipú", CodigoPostal = 9250000, NombreSector = NombreSector.Oriente, CodigoPostalMax = 9339999 },
            new Comuna { Id = 33, Nombre = "Ñuñoa", CodigoPostal = 7750000, NombreSector = NombreSector.Oriente, CodigoPostalMax = 7809999 },
            new Comuna { Id = 34, Nombre = "Pedro Aguirre Cerda", CodigoPostal = 8460000, NombreSector = NombreSector.NorteExtra, CodigoPostalMax = 8499999 },
            new Comuna { Id = 35, Nombre = "Peñalolén", CodigoPostal = 7910000, NombreSector = NombreSector.Oriente, CodigoPostalMax = 7969999 },
            new Comuna { Id = 36, Nombre = "Providencia", CodigoPostal = 7500000, NombreSector = NombreSector.Oriente, CodigoPostalMax = 7549999 },
            new Comuna { Id = 37, Nombre = "Pudahuel", CodigoPostal = 9020000, NombreSector = NombreSector.Norte, CodigoPostalMax = 9079999 },
            new Comuna { Id = 38, Nombre = "Quilicura", CodigoPostal = 8700000, NombreSector = NombreSector.Norte, CodigoPostalMax = 8779999 },
            new Comuna { Id = 39, Nombre = "Quinta Normal", CodigoPostal = 8500000, NombreSector = NombreSector.Norte, CodigoPostalMax = 8539999 },
            new Comuna { Id = 40, Nombre = "Recoleta", CodigoPostal = 8420000, NombreSector = NombreSector.Norte, CodigoPostalMax = 8459999 },
            new Comuna { Id = 41, Nombre = "Renca", CodigoPostal = 8640000, NombreSector = NombreSector.Norte, CodigoPostalMax = 8699999 },
            new Comuna { Id = 42, Nombre = "San Joaquín", CodigoPostal = 8940000, NombreSector = NombreSector.Oriente, CodigoPostalMax = 8979999 },
            new Comuna { Id = 43, Nombre = "San Miguel", CodigoPostal = 8900000, NombreSector = NombreSector.NorteExtra, CodigoPostalMax = 8939999 },
            new Comuna { Id = 44, Nombre = "San Ramón", CodigoPostal = 8860000, NombreSector = NombreSector.Oriente, CodigoPostalMax = 8899999 },
            new Comuna { Id = 45, Nombre = "Santiago", CodigoPostal = 8320000, NombreSector = NombreSector.Santiago, CodigoPostalMax = 8379999 },
            new Comuna { Id = 46, Nombre = "Vitacura", CodigoPostal = 7630000, NombreSector = NombreSector.Oriente, CodigoPostalMax = 7689999 },
            new Comuna { Id = 47, Nombre = "El Monte", CodigoPostal = 9810000, NombreSector = NombreSector.SantiagoExtra, CodigoPostalMax = 9999999 },
            new Comuna { Id = 48, Nombre = "Isla de Maipo", CodigoPostal = 9790000, NombreSector = NombreSector.SantiagoExtra, CodigoPostalMax = 9809999 },
            new Comuna { Id = 49, Nombre = "Padre Hurtado", CodigoPostal = 9710000, NombreSector = NombreSector.Oriente, CodigoPostalMax = 9749999 },
            new Comuna { Id = 50, Nombre = "Peñaflor", CodigoPostal = 9750000, NombreSector = NombreSector.SantiagoExtra, CodigoPostalMax = 9789999 },
            new Comuna { Id = 51, Nombre = "Talagante", CodigoPostal = 9670000, NombreSector = NombreSector.NorteExtra, CodigoPostalMax = 9709999 },
            new Comuna { Id = 52, Nombre = "San Antonio", CodigoPostal = 2660000, NombreSector = NombreSector.SanAntonio, CodigoPostalMax = 2679999 },
            new Comuna { Id = 53, Nombre = "Algarrobo", CodigoPostal = 2710000, NombreSector = NombreSector.SanAntonio, CodigoPostalMax = 2719999 },
            new Comuna { Id = 54, Nombre = "Cartagena", CodigoPostal = 2680000, NombreSector = NombreSector.SanAntonio, CodigoPostalMax = 2689999 },
            new Comuna { Id = 55, Nombre = "El Tabo", CodigoPostal = 2690000, NombreSector = NombreSector.SanAntonio, CodigoPostalMax = 2699999 },
            new Comuna { Id = 56, Nombre = "El Quisco", CodigoPostal = 2700000, NombreSector = NombreSector.SanAntonio, CodigoPostalMax = 2709999 },
            new Comuna { Id = 57, Nombre = "Santo Domingo", CodigoPostal = 2720000, NombreSector = NombreSector.SanAntonio, CodigoPostalMax = 7499999 }
                );
        }
    }
}
