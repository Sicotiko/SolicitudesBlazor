﻿// <auto-generated />
using System;
using BlazorApp1.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazorApp1.Server.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BlazorApp1.Shared.Modelo.Comunas.Comuna", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CodigoPostal")
                        .HasColumnType("int");

                    b.Property<int>("CodigoPostalMax")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NombreSector")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CodigoPostal")
                        .IsUnique();

                    b.ToTable("Comunas");

                    b.HasData(
                        new
                        {
                            Id = 58,
                            CodigoPostal = 9340000,
                            CodigoPostalMax = 9379999,
                            Nombre = "Colina",
                            NombreSector = 0
                        },
                        new
                        {
                            Id = 1,
                            CodigoPostal = 9380000,
                            CodigoPostalMax = 9419999,
                            Nombre = "Lampa",
                            NombreSector = 0
                        },
                        new
                        {
                            Id = 2,
                            CodigoPostal = 9420000,
                            CodigoPostalMax = 9459999,
                            Nombre = "TilTil",
                            NombreSector = 0
                        },
                        new
                        {
                            Id = 3,
                            CodigoPostal = 9480000,
                            CodigoPostalMax = 9499999,
                            Nombre = "Pirque",
                            NombreSector = 1
                        },
                        new
                        {
                            Id = 4,
                            CodigoPostal = 8150000,
                            CodigoPostalMax = 8239999,
                            Nombre = "Puente Alto",
                            NombreSector = 5
                        },
                        new
                        {
                            Id = 5,
                            CodigoPostal = 9460000,
                            CodigoPostalMax = 9479999,
                            Nombre = "San José de Maipo",
                            NombreSector = 3
                        },
                        new
                        {
                            Id = 6,
                            CodigoPostal = 9500000,
                            CodigoPostalMax = 9539999,
                            Nombre = "Buin",
                            NombreSector = 1
                        },
                        new
                        {
                            Id = 7,
                            CodigoPostal = 9560000,
                            CodigoPostalMax = 9579999,
                            Nombre = "Calera de Tango",
                            NombreSector = 3
                        },
                        new
                        {
                            Id = 8,
                            CodigoPostal = 9540000,
                            CodigoPostalMax = 9559999,
                            Nombre = "Paine",
                            NombreSector = 1
                        },
                        new
                        {
                            Id = 9,
                            CodigoPostal = 8050000,
                            CodigoPostalMax = 8149999,
                            Nombre = "San Bernardo",
                            NombreSector = 3
                        },
                        new
                        {
                            Id = 10,
                            CodigoPostal = 9650000,
                            CodigoPostalMax = 9659999,
                            Nombre = "Alhué",
                            NombreSector = 3
                        },
                        new
                        {
                            Id = 11,
                            CodigoPostal = 9630000,
                            CodigoPostalMax = 9649999,
                            Nombre = "Curacaví",
                            NombreSector = 3
                        },
                        new
                        {
                            Id = 12,
                            CodigoPostal = 9620000,
                            CodigoPostalMax = 9629999,
                            Nombre = "María Pinto",
                            NombreSector = 3
                        },
                        new
                        {
                            Id = 13,
                            CodigoPostal = 9580000,
                            CodigoPostalMax = 9619999,
                            Nombre = "Melipilla",
                            NombreSector = 3
                        },
                        new
                        {
                            Id = 14,
                            CodigoPostal = 9660000,
                            CodigoPostalMax = 9669999,
                            Nombre = "San Pedro",
                            NombreSector = 3
                        },
                        new
                        {
                            Id = 15,
                            CodigoPostal = 9200000,
                            CodigoPostalMax = 9249999,
                            Nombre = "Cerrillos",
                            NombreSector = 5
                        },
                        new
                        {
                            Id = 16,
                            CodigoPostal = 9080000,
                            CodigoPostalMax = 9119999,
                            Nombre = "Cerro Navia",
                            NombreSector = 0
                        },
                        new
                        {
                            Id = 17,
                            CodigoPostal = 8540000,
                            CodigoPostalMax = 8579999,
                            Nombre = "Conchalí",
                            NombreSector = 0
                        },
                        new
                        {
                            Id = 18,
                            CodigoPostal = 8010000,
                            CodigoPostalMax = 8049999,
                            Nombre = "El Bosque",
                            NombreSector = 1
                        },
                        new
                        {
                            Id = 19,
                            CodigoPostal = 9160000,
                            CodigoPostalMax = 9199999,
                            Nombre = "Estación Central",
                            NombreSector = 0
                        },
                        new
                        {
                            Id = 20,
                            CodigoPostal = 8580000,
                            CodigoPostalMax = 8639999,
                            Nombre = "Huechuraba",
                            NombreSector = 0
                        },
                        new
                        {
                            Id = 21,
                            CodigoPostal = 8380000,
                            CodigoPostalMax = 8419999,
                            Nombre = "Independencia",
                            NombreSector = 0
                        },
                        new
                        {
                            Id = 22,
                            CodigoPostal = 7970000,
                            CodigoPostalMax = 8009999,
                            Nombre = "La Cisterna",
                            NombreSector = 1
                        },
                        new
                        {
                            Id = 23,
                            CodigoPostal = 8240000,
                            CodigoPostalMax = 8319999,
                            Nombre = "La Florida",
                            NombreSector = 5
                        },
                        new
                        {
                            Id = 24,
                            CodigoPostal = 8780000,
                            CodigoPostalMax = 8819999,
                            Nombre = "La Granja",
                            NombreSector = 5
                        },
                        new
                        {
                            Id = 25,
                            CodigoPostal = 8820000,
                            CodigoPostalMax = 8859999,
                            Nombre = "La Pintana",
                            NombreSector = 5
                        },
                        new
                        {
                            Id = 26,
                            CodigoPostal = 7850000,
                            CodigoPostalMax = 7909999,
                            Nombre = "La Reina",
                            NombreSector = 5
                        },
                        new
                        {
                            Id = 27,
                            CodigoPostal = 7550000,
                            CodigoPostalMax = 7629999,
                            Nombre = "Las Condes",
                            NombreSector = 5
                        },
                        new
                        {
                            Id = 28,
                            CodigoPostal = 7690000,
                            CodigoPostalMax = 7749999,
                            Nombre = "Lo Barnechea",
                            NombreSector = 5
                        },
                        new
                        {
                            Id = 29,
                            CodigoPostal = 9120000,
                            CodigoPostalMax = 9159999,
                            Nombre = "Lo Espejo",
                            NombreSector = 1
                        },
                        new
                        {
                            Id = 30,
                            CodigoPostal = 8980000,
                            CodigoPostalMax = 9019999,
                            Nombre = "Lo Prado",
                            NombreSector = 0
                        },
                        new
                        {
                            Id = 31,
                            CodigoPostal = 7810000,
                            CodigoPostalMax = 7849999,
                            Nombre = "Macul",
                            NombreSector = 5
                        },
                        new
                        {
                            Id = 32,
                            CodigoPostal = 9250000,
                            CodigoPostalMax = 9339999,
                            Nombre = "Maipú",
                            NombreSector = 5
                        },
                        new
                        {
                            Id = 33,
                            CodigoPostal = 7750000,
                            CodigoPostalMax = 7809999,
                            Nombre = "Ñuñoa",
                            NombreSector = 5
                        },
                        new
                        {
                            Id = 34,
                            CodigoPostal = 8460000,
                            CodigoPostalMax = 8499999,
                            Nombre = "Pedro Aguirre Cerda",
                            NombreSector = 1
                        },
                        new
                        {
                            Id = 35,
                            CodigoPostal = 7910000,
                            CodigoPostalMax = 7969999,
                            Nombre = "Peñalolén",
                            NombreSector = 5
                        },
                        new
                        {
                            Id = 36,
                            CodigoPostal = 7500000,
                            CodigoPostalMax = 7549999,
                            Nombre = "Providencia",
                            NombreSector = 5
                        },
                        new
                        {
                            Id = 37,
                            CodigoPostal = 9020000,
                            CodigoPostalMax = 9079999,
                            Nombre = "Pudahuel",
                            NombreSector = 0
                        },
                        new
                        {
                            Id = 38,
                            CodigoPostal = 8700000,
                            CodigoPostalMax = 8779999,
                            Nombre = "Quilicura",
                            NombreSector = 0
                        },
                        new
                        {
                            Id = 39,
                            CodigoPostal = 8500000,
                            CodigoPostalMax = 8539999,
                            Nombre = "Quinta Normal",
                            NombreSector = 0
                        },
                        new
                        {
                            Id = 40,
                            CodigoPostal = 8420000,
                            CodigoPostalMax = 8459999,
                            Nombre = "Recoleta",
                            NombreSector = 0
                        },
                        new
                        {
                            Id = 41,
                            CodigoPostal = 8640000,
                            CodigoPostalMax = 8699999,
                            Nombre = "Renca",
                            NombreSector = 0
                        },
                        new
                        {
                            Id = 42,
                            CodigoPostal = 8940000,
                            CodigoPostalMax = 8979999,
                            Nombre = "San Joaquín",
                            NombreSector = 5
                        },
                        new
                        {
                            Id = 43,
                            CodigoPostal = 8900000,
                            CodigoPostalMax = 8939999,
                            Nombre = "San Miguel",
                            NombreSector = 1
                        },
                        new
                        {
                            Id = 44,
                            CodigoPostal = 8860000,
                            CodigoPostalMax = 8899999,
                            Nombre = "San Ramón",
                            NombreSector = 5
                        },
                        new
                        {
                            Id = 45,
                            CodigoPostal = 8320000,
                            CodigoPostalMax = 8379999,
                            Nombre = "Santiago",
                            NombreSector = 2
                        },
                        new
                        {
                            Id = 46,
                            CodigoPostal = 7630000,
                            CodigoPostalMax = 7689999,
                            Nombre = "Vitacura",
                            NombreSector = 5
                        },
                        new
                        {
                            Id = 47,
                            CodigoPostal = 9810000,
                            CodigoPostalMax = 9999999,
                            Nombre = "El Monte",
                            NombreSector = 3
                        },
                        new
                        {
                            Id = 48,
                            CodigoPostal = 9790000,
                            CodigoPostalMax = 9809999,
                            Nombre = "Isla de Maipo",
                            NombreSector = 3
                        },
                        new
                        {
                            Id = 49,
                            CodigoPostal = 9710000,
                            CodigoPostalMax = 9749999,
                            Nombre = "Padre Hurtado",
                            NombreSector = 5
                        },
                        new
                        {
                            Id = 50,
                            CodigoPostal = 9750000,
                            CodigoPostalMax = 9789999,
                            Nombre = "Peñaflor",
                            NombreSector = 3
                        },
                        new
                        {
                            Id = 51,
                            CodigoPostal = 9670000,
                            CodigoPostalMax = 9709999,
                            Nombre = "Talagante",
                            NombreSector = 1
                        },
                        new
                        {
                            Id = 52,
                            CodigoPostal = 2660000,
                            CodigoPostalMax = 2679999,
                            Nombre = "San Antonio",
                            NombreSector = 4
                        },
                        new
                        {
                            Id = 53,
                            CodigoPostal = 2710000,
                            CodigoPostalMax = 2719999,
                            Nombre = "Algarrobo",
                            NombreSector = 4
                        },
                        new
                        {
                            Id = 54,
                            CodigoPostal = 2680000,
                            CodigoPostalMax = 2689999,
                            Nombre = "Cartagena",
                            NombreSector = 4
                        },
                        new
                        {
                            Id = 55,
                            CodigoPostal = 2690000,
                            CodigoPostalMax = 2699999,
                            Nombre = "El Tabo",
                            NombreSector = 4
                        },
                        new
                        {
                            Id = 56,
                            CodigoPostal = 2700000,
                            CodigoPostalMax = 2709999,
                            Nombre = "El Quisco",
                            NombreSector = 4
                        },
                        new
                        {
                            Id = 57,
                            CodigoPostal = 2720000,
                            CodigoPostalMax = 7499999,
                            Nombre = "Santo Domingo",
                            NombreSector = 4
                        });
                });

            modelBuilder.Entity("BlazorApp1.Shared.Modelo.Moviles.Movil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Codigo")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Moviles");
                });

            modelBuilder.Entity("BlazorApp1.Shared.Modelo.OT.OrdenTrabajo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Cerrada")
                        .HasColumnType("bit");

                    b.Property<int>("Clasificacion")
                        .HasColumnType("int");

                    b.Property<int?>("ComunaId")
                        .HasColumnType("int");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MovilId")
                        .HasColumnType("int");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("PropiaOAjena")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Recogidas")
                        .HasColumnType("int");

                    b.Property<int>("Repartos")
                        .HasColumnType("int");

                    b.Property<int>("SectorName")
                        .HasColumnType("int");

                    b.Property<int>("TipoHorario")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ComunaId");

                    b.HasIndex("MovilId");

                    b.HasIndex("Numero")
                        .IsUnique();

                    b.ToTable("OrdenTrabajos");
                });

            modelBuilder.Entity("BlazorApp1.Shared.Modelo.OT.OrdenTrabajo", b =>
                {
                    b.HasOne("BlazorApp1.Shared.Modelo.Comunas.Comuna", "Comuna")
                        .WithMany()
                        .HasForeignKey("ComunaId");

                    b.HasOne("BlazorApp1.Shared.Modelo.Moviles.Movil", "Movil")
                        .WithMany()
                        .HasForeignKey("MovilId");

                    b.Navigation("Comuna");

                    b.Navigation("Movil");
                });
#pragma warning restore 612, 618
        }
    }
}
