using BlazorApp1.Shared.Modelo.Comunas;
using BlazorApp1.Shared.Modelo.Moviles;
using BlazorApp1.Shared.Modelo.OT;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared.Modelo.Retiros
{
    public class Retiro
    {
        public int Id { get; set; }
        public int CodigoRetiro { get; set; }
        public string Nombre { get; set; }
        public string CodigoCliente { get; set; }
        public string Direccion { get; set; }
        public Comuna Comuna { get; set; }
        public int CodigoPostal { get; set; }
        public DateTime AmDesde { get; set; }
        public DateTime AmHasta { get; set; }
        public DateTime PmDesde { get; set; }
        public DateTime PmHasta { get; set; }
        public string Contacto { get; set; }
        public string Telefono { get; set; }
        public string Observacion { get; set; }
        public int Bultos { get; set; }
        public float Kilos { get; set; }
        public string Zona { get; set; }
        public int ZonaCodigo { get; set; }
        public Movil? Movil { get; set; }
        public OrdenTrabajo OrdenTrabajo { get; set; }
        public string Estado { get; set; }
        public TipoHorario TipoHorario { get; set; }
        public Clasificacion Clasificacion { get; set; }
        public NombreSector NombreSector { get; set; }
        public bool Asignar { get; set; }
        public List<Tracking> TrackingList { get; set; } = new List<Tracking>();
        public List<Incidencia> Incidencias { get; set; } = new List<Incidencia>();
        public Retiro() { }

        //public async Task GetTrackingList()
        //{
        //    this.TrackingList = await  Management.Tracking.Obtencion.GetTracking(this);
        //}

        //public async Task AsignarAsync()
        //{

        //   //await SolicitudesNet60.Management.Retiros.Asignacion.Asignar(this);
        //}


    }
}
