using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorApp1.Shared.Modelo.Comunas;
using BlazorApp1.Shared.Modelo.Moviles;
using BlazorApp1.Shared.Modelo.Retiros;

namespace BlazorApp1.Shared.Modelo.OT
{
    public class OrdenTrabajo
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public Movil Movil { get; set; }
        public string PropiaOAjena { get; set; }
        public string Estado { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Today;
        public int Repartos { get; set; }
        public int Recogidas { get; set; }
        public TipoHorario TipoHorario { get; set; }
        public Clasificacion Clasificacion { get; set; }
        public Comuna Comuna { get; set; }
        public NombreSector SectorName { get; set; }
        public bool Cerrada { get; set; } = false;
        //public async Task<bool> Cerrar()
        //{
        //    //return true;
        //    return await Management.OT.Finalizacion.CerrarOrden(this);
        //}
    }
}
