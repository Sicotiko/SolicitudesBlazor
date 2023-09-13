using BlazorApp1.Shared.Modelo.Comunas;
using BlazorApp1.Shared.User;
using System;

namespace BlazorApp1.Shared.Modelo.Retiros
{
    public class FiltroBusquedaRetiros
    {
        public int Recogida { get; set; }
        public TipoDeCarga TipoDeCarga { get; set; } = TipoDeCarga.Todos;
        public Estado Estado { get; set; } = Estado.Todos;
        public int Recogedor { get; set; }
        public string Telefono { get; set; } = string.Empty;
        public Tipo Tipo { get; set; } = Tipo.PROP_RECI;
        public TipoEntrada TipoEntrada { get; set; } = TipoEntrada.Todos;
        public int Poblacion { get; set; }
        public int CPDestino { get; set; }
        public string Cliente { get; set; } = string.Empty;
        public int PlantaDestino { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime Hasta { get; set; }
        public int Zona { get; set; }
        public bool SinZona { get; set; }
        public ConIncidencia ConIncidencia { get; set; } = ConIncidencia.Ambas;
        public TipoIncidencias TipoIncidencia { get; set; } = TipoIncidencias.Ninguna;
        public Documentada Documentada { get; set; } = Documentada.Ambas;
        public string Autorizacion { get; set; } = string.Empty;

        public NombreSector NombreSector { get; set; }
        public Usuario Usuario { get; set; }
    }
}
