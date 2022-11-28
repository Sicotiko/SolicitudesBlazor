using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared.Modelo.Monitor
{
    public class MovilDetalle
    {
        public string usuario { get; set; } = String.Empty;
        public double pendiente { get; set; }
        public double aceptado { get; set; }
        public double rechazado { get; set; }
        public double efectuado { get; set; }
        public double noefectuado { get; set; }
        public double total { get; set; }
    }
}
