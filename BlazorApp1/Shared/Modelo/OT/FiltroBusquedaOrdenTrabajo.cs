using BlazorApp1.Shared.Modelo.Moviles;
using BlazorApp1.Shared.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared.Modelo.OT
{
    public class FiltroBusquedaOrdenTrabajo
    {
        public Movil Recogedor { get; set; }
        public string CRR { get; set; }
        public Estado Estado { get; set; } = Estado.NO_CERRADAS;
        public int Ot { get; set; }
        public DateTime FechaDesde { get; set; } = DateTime.Today;
        public DateTime FechaHasta { get; set; } = DateTime.Today.AddDays(1);
        public int NroEnvio { get; set; }
        public bool OtCrr { get; set; }

        public Usuario Usuario { get; set; }
    }
}
