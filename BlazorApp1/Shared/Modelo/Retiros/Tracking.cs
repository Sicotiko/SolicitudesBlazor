using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorApp1.Shared.Modelo.Retiros
{
    public class Tracking
    {
        public DateTime FechaEstado { get; set; }
        public string Tipo { get; set; }
        public string Mensaje { get; set; }
        public string Usuario { get; set; }
        public string Delegacion { get; set; }

        public Tracking()
        {

        }
    }
}
