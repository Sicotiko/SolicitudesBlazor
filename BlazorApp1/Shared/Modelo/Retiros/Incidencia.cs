using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared.Modelo.Retiros
{
    public class Incidencia
    {
        public Incidencia()
        {

        }
        public Incidencia(DateTime Fecha,
                          string Delegacion = "",
                          string Usuario = "",
                          string Codigo = "",
                          string Descripcion = "",
                          string Ampliacion = "",
                          string Cierre = "",
                          string Acciones = "")
        {
            this.Fecha = Fecha;
            this.Del = Delegacion;
            this.Usuario = Usuario;
            this.Codigo = Codigo;
            this.Descripcion = Descripcion;
            this.Ampliacion = Ampliacion;
            this.Cierre = Cierre;
            this.Acciones = Acciones;
        }

        public DateTime Fecha { get; set; }
        public string Del { get; set; } = string.Empty;
        public string Usuario { get; set; } = string.Empty;
        public string Codigo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string Ampliacion { get; set; } = string.Empty;
        public string Cierre { get; set; } = string.Empty;
        public string Acciones { get; set; } = string.Empty;
    }
}
