using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorApp1.Shared.Modelo.Comunas;

namespace BlazorApp1.Shared.Modelo.OT
{
    public class OrdenTrabajo
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public string Movil { get; set; }
        public string DescripcionMovil { get; set; }
        public string PropiaOAjena { get; set; }
        public string Estado { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Today;
        public int Repartos { get; set; }
        public int Recogidas { get; set; }
        public string Tipo { get; set; }
        public string SubTipo { get; set; }
        public string Comuna { get; set; }
        public SectorName SectorName { get; set; }
        //public async Task<bool> Cerrar()
        //{
        //    //return true;
        //    return await Management.OT.Finalizacion.CerrarOrden(this);
        //}
    }
}
