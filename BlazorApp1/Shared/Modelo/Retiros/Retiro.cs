using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared.Modelo.Retiros
{
    public class Retiro
    {
        public int Id { get; set; }
        public string CodigoRetiro { get; set; }
        public string Nombre { get; set; }
        public string CodigoCliente { get; set; }
        public string Direccion { get; set; }
        public string Comuna { get; set; }
        public string CodigoPostal { get; set; }
        public DateTime AmDesde { get; set; }
        public DateTime AmHasta { get; set; }
        public DateTime PmDesde { get; set; }
        public DateTime PmHasta { get; set; }
        public string Contacto { get; set; }
        public string Telefono { get; set; }
        public string Observacion { get; set; }
        public string Bultos { get; set; }
        public string Kilos { get; set; }
        public string Zona { get; set; }
        public string Movil { get; set; }
        public string Ot { get; set; }
        public string Estado { get; set; }
        public string TipoRetiro { get; set; }
        public string SubTipoRetiro { get; set; }
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
